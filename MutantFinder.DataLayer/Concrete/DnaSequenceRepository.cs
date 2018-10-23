using MutantFinder.DataLayer.Abstract;
using MutantFinder.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MutantFinder.DataLayer.Concrete
{
    public class DnaSequenceRepository : IDnaSequenceRepository
    {
        private MutantFinderContext _ctx;

        public DnaSequenceRepository(MutantFinderContext ctx)
        {
            _ctx = ctx;
        }
        public void CreateDnaSequence(DnaSequence entity)
        {
            _ctx.DnaSequences.Add(entity);
        }

        public IEnumerable<DnaSequence> GetDnaSequences()
        {
            return _ctx.DnaSequences.ToList();
        }

        public bool Save()
        {
            return _ctx.SaveChanges() >= 0;
        }
    }
}
