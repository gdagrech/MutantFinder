using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace MutantFinder.Domain.Entities
{
    [Table("DnaSequence")]
    public class DnaSequence : BaseEntity
    {
        [NotMapped]
        public string[] Dna { get; set; }
        public string DnaText { get; set; }
        public bool IsMutant { get; set; }
    }
}
