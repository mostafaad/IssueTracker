using IssueTracker.Domain.Entities;
using IssueTracker.Infrastructure.Persistence;
using IssueTracker.Infrastructure.Repository.GenericRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IssueTracker.Infrastructure.Repository.Repositories.IssueRepository
{
    class IssueRepository : RepositoryBase<Issue>, IIssueRepository
    {
        public IssueRepository(ApplicationDbContext repositoryContext)
          : base(repositoryContext)
        {
        }

        public async Task<IEnumerable<Issue>> GetAllUserProjectIssuesAsync(string ProjectKey)
        {
           return FindByCondition(x => x.Project.Key == ProjectKey && x.IsDeleted == false).OrderByDescending(ow => ow.Created);
        }
    }
}
