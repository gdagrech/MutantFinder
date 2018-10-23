using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MutantFinder.Api.Models
{
    public class DnaSequenceForCreationDto
    {
        public string[] Dna { get; set; }
        public bool IsMutant { get; set; }
    }
}
