using Microsoft.EntityFrameworkCore;
using MutantFinder.Domain.Entities;

namespace MutantFinder.DataLayer.Concrete
{
    public class MutantFinderContext : DbContext
    {
        public MutantFinderContext(DbContextOptions<MutantFinderContext> options) : base(options)
        {

        }

        public DbSet<DnaSequence> DnaSequences { get; set; }
    }
}
