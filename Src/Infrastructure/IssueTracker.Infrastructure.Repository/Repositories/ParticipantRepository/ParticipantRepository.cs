using IssueTracker.Domain.Entities;
using IssueTracker.Infrastructure.Persistence;
using IssueTracker.Infrastructure.Repository.GenericRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IssueTracker.Infrastructure.Repository.Repositories.ParticipantRepository
{
    class ParticipantRepository : RepositoryBase<Participants>, IParticipantRepository
    {
        public ParticipantRepository(ApplicationDbContext repositoryContext)
          : base(repositoryContext)
        {
        }

        public async Task<IEnumerable<Participants>> GetAllUserProjectIssuesAsync(int ProjectId)
        {
            return FindByCondition(x => x.ProjectId == ProjectId && x.IsDeleted == false).OrderByDescending(ow => ow.Created);

        }
    }
}
