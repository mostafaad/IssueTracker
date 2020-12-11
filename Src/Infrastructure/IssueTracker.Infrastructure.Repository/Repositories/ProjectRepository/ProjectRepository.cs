using IssueTracker.Domain.Entities;
using IssueTracker.Infrastructure.Persistence;
using IssueTracker.Infrastructure.Repository.GenericRepository;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace IssueTracker.Infrastructure.Repository.Repositories.ProjectRepository
{
    class ProjectRepository : RepositoryBase<Project>, IProjectRepository
    {
        public ProjectRepository(ApplicationDbContext repositoryContext)
          : base(repositoryContext)
        {
        }

        public IEnumerable<Project> GetAllUserProjectsAsync(string UserId)
        {
            return FindByCondition(x => x.Owner == UserId && x.IsDeleted == false).Include(c=>c.User).OrderByDescending(ow => ow.Created); 
        }

        public async Task<bool> ValidateProjectKeyAsync(string projectKey)
        {
            return await FindAnyAsync(x => x.Key == projectKey);
        }

    }
}
