using Hahn.Application.Domain.Entities;
using Hahn.Application.Domain.Interfaces;
using Hahn.Application.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hahn.Application.Domain.Services
{
    public class CandidateService : ICandidateService
    {
        private readonly IRepository<Candidate> _candidateRepository;
        public CandidateService(IRepository<Candidate> repository)
        {
            _candidateRepository = repository;
        }

        public async Task<Candidate> AddCandidate(CandidateModel candidateModel)
        {
            try
            {

                var candidate = BuildCandidateEntity(candidateModel);
                return await _candidateRepository.AddItem(candidate);
            }
            catch (Exception exception)
            {
                throw;
            }
        }


        public async Task<bool> DeleteCandidate(int candidateId)
        {
            try
            {
                return await _candidateRepository.Remove(candidateId);
            }
            catch (Exception exception)
            {
                throw;
            }
        }

        public async Task<Candidate> GetCandidate(int candidateId)
        {
            try
            {
                return await _candidateRepository.Find(candidateId);
            }
            catch (Exception exception)
            {
                throw;
            }
        }

        public async Task<IEnumerable<Candidate>> GetCandidates()
        {
            try
            {
                return await _candidateRepository.GetItems();
            }
            catch (Exception exception)
            {
                throw;
            }
        }

        public async Task<IEnumerable<Candidate>> GetCandidates(Func<Candidate, bool> predicate)
        {
            try
            {
                return await _candidateRepository.GetItems(predicate);
            }
            catch (Exception exception)
            {
                return Enumerable.Empty<Candidate>();
            }
        }

        public async Task<bool> UpdateCandidate(int id, Candidate updatedInfo)
        {
            try
            {
                var candidateToUpdate = await GetCandidate(id);
                if (candidateToUpdate == null)
                    return false;
                candidateToUpdate.Address = updatedInfo.Address;
                candidateToUpdate.CountryOfOrigin = updatedInfo.CountryOfOrigin;
                candidateToUpdate.Email = updatedInfo.Email;
                candidateToUpdate.LastName = updatedInfo.LastName;
                candidateToUpdate.PhoneNumber = updatedInfo.PhoneNumber;
                candidateToUpdate.JobOptionId = updatedInfo.JobOptionId;
                candidateToUpdate.PhoneNumber = updatedInfo.PhoneNumber;
                candidateToUpdate.FirstName = updatedInfo.FirstName;
                candidateToUpdate.DateOfBirth = updatedInfo.DateOfBirth;
                return (await _candidateRepository.UpdateItem(id, candidateToUpdate)) != null;
            }
            catch (Exception exception)
            {
                throw;
            }
        }

        #region privates


        private Candidate BuildCandidateEntity(CandidateModel candidateModel)
        {
            return new Candidate
            {
                Address = candidateModel.Address,
                Email = candidateModel.Email,
                JobOptionId = candidateModel.JobOptionId,
                CountryOfOrigin = candidateModel.CountryOfOrigin,
                PhoneNumber = candidateModel.PhoneNumber,
                FirstName = candidateModel.FirstName,
                LastName = candidateModel.LastName,
                DateOfBirth = candidateModel.DateOfBirth

            };
        }
        #endregion
    }
}
