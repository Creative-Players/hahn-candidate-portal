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
    public class JobOptionService : IJobOptionService

    {
        private readonly IRepository<JobOption> JobOptionRepository;
        public JobOptionService(IRepository<JobOption> repository)
        {
            JobOptionRepository = repository;
        }

        public async Task<JobOption> AddJobOption(JobOptionModel candidateTypeModel)
        {
            try
            {

                var jobOption = BuildJobOptionEntity(candidateTypeModel);
                return await JobOptionRepository.AddItem(jobOption);
            }
            catch (Exception exception)
            {
                throw;
            }
        }

        public async Task<bool> DeleteJobOption(int candidateTypeId)
        {
            try
            {
                return await JobOptionRepository.Remove(candidateTypeId);
            }
            catch (Exception exception)
            {
                throw;
            }
        }

        public async Task<JobOption> GetJobOption(int candidateTypeId)
        {
            try
            {
                return await JobOptionRepository.Find(candidateTypeId);
            }
            catch (Exception exception)
            {
                throw;
            }
        }

        public async Task<IEnumerable<JobOption>> GetJobOptions()
        {
            try
            {
                return await JobOptionRepository.GetItems();
            }
            catch (Exception exception)
            {
                throw;
            }
        }

        public async Task<IEnumerable<JobOption>> GetJobOptions(Func<JobOption, bool> predicate)
        {
            try
            {
                return await JobOptionRepository.GetItems(predicate);
            }
            catch (Exception exception)
            {
                return Enumerable.Empty<JobOption>();
            }
        }

        public async Task<bool> UpdateJobOption(int id, JobOption updatedInfo)
        {
            try
            {
                var candidateTypeToUpdate = await GetJobOption(id);
                if (candidateTypeToUpdate == null)
                    return false;
                candidateTypeToUpdate.Name = updatedInfo.Name;
                return (await JobOptionRepository.UpdateItem(id, candidateTypeToUpdate)) != null;
            }
            catch (Exception exception)
            {
                throw;
            }
        }

        #region privates


        private JobOption BuildJobOptionEntity(JobOptionModel candidateTypeModel)
        {
            return new JobOption
            {
                Name = candidateTypeModel.Name
            };
        }
        #endregion
    }
}
