using IssueTracker.Domain.Entities;
using IssueTracker.Infrastructure.Repository.GenericRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IssueTracker.Infrastructure.Repository.Repositories.ParticipantRepository
{
    public interface IParticipantRepository : IRepositoryBase<Participants>
    {
        Task<IEnumerable<Participants>> GetAllUserProjectIssuesAsync(int ProjectId);
    }
}
