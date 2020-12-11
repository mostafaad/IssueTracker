using IssueTracker.Domain.Entities;
using IssueTracker.Infrastructure.Repository.GenericRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IssueTracker.Infrastructure.Repository.Repositories.ProjectRepository
{
    public interface IProjectRepository : IRepositoryBase<Project>
    {
        IEnumerable<Project> GetAllUserProjectsAsync(string UserId);
        Task<bool> ValidateProjectKeyAsync(string projectKey);
    }
}
