using Hahn.Application.Domain.Entities;
using Hahn.Application.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hahn.Application.Domain.Interfaces
{
    public interface ICandidateService
    {
        Task<Candidate> AddCandidate(CandidateModel candidate);
        Task<Candidate> GetCandidate(int candidateId);
        Task<bool> UpdateCandidate(int id, Candidate updatedInfo);
        Task<bool> DeleteCandidate(int candidateId);
        Task<IEnumerable<Candidate>> GetCandidates();
        Task<IEnumerable<Candidate>> GetCandidates(Func<Candidate, bool> predicate);

    }
}
