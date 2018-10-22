using System;
using System.Collections.Generic;
using System.Text;

namespace MutantFinder.Domain.Entities
{
    public class DnaSequence : BaseEntity
    {
        public string[] Dna { get; set; }
    }
}
