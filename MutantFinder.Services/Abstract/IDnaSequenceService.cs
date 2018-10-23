using MutantFinder.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace MutantFinder.Services.Abstract
{
    public interface IDnaSequenceService
    {
        IEnumerable<DnaSequence> GetDnaSequences();
        void CreateDnaSequence(DnaSequence entity);
        bool Save();
    }
}
