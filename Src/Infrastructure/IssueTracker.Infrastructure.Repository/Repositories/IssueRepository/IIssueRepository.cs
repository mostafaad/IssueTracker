using IssueTracker.Domain.Entities;
using IssueTracker.Infrastructure.Repository.GenericRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IssueTracker.Infrastructure.Repository.Repositories.IssueRepository
{
    public interface IIssueRepository : IRepositoryBase<Issue>
    {
        Task<IEnumerable<Issue>> GetAllUserProjectIssuesAsync(string ProjectKey);
    }
}
