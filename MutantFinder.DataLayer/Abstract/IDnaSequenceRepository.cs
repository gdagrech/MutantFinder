using MutantFinder.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace MutantFinder.DataLayer.Abstract
{
    public interface IDnaSequenceRepository
    {
        IEnumerable<DnaSequence> GetDnaSequences();
        void CreateDnaSequence(DnaSequence entity);
        bool Save();
    }
}
