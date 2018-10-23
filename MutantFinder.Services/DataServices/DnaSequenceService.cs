using MutantFinder.DataLayer.Abstract;
using MutantFinder.Domain.Entities;
using MutantFinder.Services.Abstract;
using System;
using System.Collections.Generic;
using System.Text;

namespace MutantFinder.Services.DataServices
{
    public class DnaSequenceService : IDnaSequenceService
    {
        private readonly IDnaSequenceRepository _dnaSequenceRepository;

        public DnaSequenceService(IDnaSequenceRepository dnaSequenceRepository)
        {
            _dnaSequenceRepository = dnaSequenceRepository;
        }
        public void CreateDnaSequence(DnaSequence entity)
        {
            _dnaSequenceRepository.CreateDnaSequence(entity);
        }

        public IEnumerable<DnaSequence> GetDnaSequences()
        {
            return _dnaSequenceRepository.GetDnaSequences();
        }

        public bool Save()
        {
            return _dnaSequenceRepository.Save();
        }
    }
}
