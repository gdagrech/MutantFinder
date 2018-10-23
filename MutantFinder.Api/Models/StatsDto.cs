using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MutantFinder.Api.Models
{
    public class StatsDto
    {
        public int CountMutantDna { get; set; }
        public int CountHumanDna { get; set; }
        public float Ratio { get; set; }
    }
}
