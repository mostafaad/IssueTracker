using IssueTracker.Domain.Entities;
using IssueTracker.Infrastructure.Persistence;
using IssueTracker.Infrastructure.Repository.GenericRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IssueTracker.Infrastructure.Repository.Repositories.ProjectRepository
{
    class ProjectRepository : RepositoryBase<Project>, IProjectRepository
    {
        public ProjectRepository(ApplicationDbContext repositoryContext)
          : base(repositoryContext)
        {
        }

        public IEnumerable<Project> GetAllUserProjects(string UserId)
        {
            return FindByCondition(x => x.Owner == UserId)
                .Where(c => c.IsDeleted == false).OrderByDescending(ow => ow.Created);

        }

    }
}
