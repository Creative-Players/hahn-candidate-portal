using Hahn.Application.Domain.Entities;
using Hahn.Application.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hahn.Application.Domain.Interfaces
{
    public interface IJobOptionService
    {
        Task<JobOption> AddJobOption(JobOptionModel jobOption);
        Task<JobOption> GetJobOption(int jobOptionId);
        Task<bool> UpdateJobOption(int id, JobOption updatedInfo);
        Task<bool> DeleteJobOption(int candidateId);
        Task<IEnumerable<JobOption>> GetJobOptions();
        Task<IEnumerable<JobOption>> GetJobOptions(Func<JobOption, bool> predicate);

    }
}
