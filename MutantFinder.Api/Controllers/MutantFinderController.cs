﻿using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using MutantFinder.Api.Models;
using MutantFinder.DataLayer.Abstract;
using MutantFinder.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MutantFinder.Api.Controllers
{
    [Route("api/mutant")]
    public class MutantFinderController : Controller
    {

        private IDnaSequenceRepository _dnaSequenceRepository;

        public MutantFinderController(IDnaSequenceRepository dnaSequenceRepository)
        {
            _dnaSequenceRepository = dnaSequenceRepository;
        }

        [HttpPost]
        public IActionResult IsMutant([FromBody] DnaSequenceDto dna)
        {
            var isValidDnaSequenceEntry = ValidateDnaSequenceEntry(dna);

            if (!isValidDnaSequenceEntry)
            {
                return BadRequest(ModelState);

            }
            var isMutant = CheckForMutantSequence(dna.Dna);
                        
            CreateDnaSequence(dna, isMutant);

            if (!isMutant)
            {
                ModelState.AddModelError("Filthy Human", "New target for termination");
                return StatusCode(403, ModelState);
            }

            return Ok("Mutant soldier ready to fight for our leader Magneto!!!");             
        }

        private void CreateDnaSequence(DnaSequenceDto model, bool isMutant)
        {
            var entity = Mapper.Map<DnaSequence>(model);
            entity.IsMutant = isMutant;
            entity.DnaText = string.Join(", ", model.Dna);
            _dnaSequenceRepository.CreateDnaSequence(entity);
            _dnaSequenceRepository.Save();
        }

        private bool CheckForMutantSequence(string[] dna)
        {            
            char[][] jaggedArr = new char[dna.Count()][];
            int l = 0;

            foreach (var item in dna)
            {
                var seqArr = new char[item.Count()];
                for (int i = 0; i < item.Length; i++)
                {
                    int j = 0;
                    foreach (var c in item)
                    {
                        seqArr[j] = c;
                        j++;
                    }
                }
                jaggedArr[l] = seqArr;
                l++;
            }
            
            var outputArr = new List<string>();
            var builder = new StringBuilder();

            for (int row = 0; row < jaggedArr.Length; row++)
            {
                for (int col = 0; col < jaggedArr[row].Length; col++)
                {
                    builder.Append(jaggedArr[row][col]);
                }
                outputArr.Add(builder.ToString());
                builder = new StringBuilder();
                for (int col = 0; col < jaggedArr[row].Length; col++)
                {
                    builder.Append(jaggedArr[col][row]);
                }
                outputArr.Add(builder.ToString());
                builder = new StringBuilder();
            }
            for (int row = 0; row < jaggedArr.Length; row++)
            {
                builder.Append(jaggedArr[row][row]);
            }
            outputArr.Add(builder.ToString());
            builder = new StringBuilder();

            int row2 = jaggedArr.Length - 1;
            for (int row = 0; row < jaggedArr.Length; row++)
            {
                builder.Append(jaggedArr[row][row2]);
                row2--;
            }
            outputArr.Add(builder.ToString());
            builder = new StringBuilder();

            int mutantSegFound = 0;
            foreach (var item in outputArr)
            {                
                if (item.Contains("AAAA") || item.Contains("CCCC") || item.Contains("TTTT") || item.Contains("GGGG"))
                {
                    mutantSegFound++;
                }                
            }
            return mutantSegFound > 1;
        }

        private bool ValidateDnaSequenceEntry(DnaSequenceDto dna)
        {
            var isValidSequence = true;
            var firstItemLenght = dna.Dna.First().Length;
            string allowedLetters = "aAtTcCgG";
            foreach (var item in dna.Dna)
            {
                foreach (char c in item)
                {
                    if (!allowedLetters.Contains(c.ToString()))
                    {
                        ModelState.AddModelError("Wrong Sequence", "Only allowed letters in code sequence are: A-T-C-G");
                        return isValidSequence = false;
                    } 
                }
                if (item.Length != firstItemLenght)
                {
                    ModelState.AddModelError("Wrong Sequence", "Sequences in dna structure can be of any size but all the sequences must have same length");
                    return isValidSequence = false;  
                }
                
            }
            
            return isValidSequence;
        }
    }
}
