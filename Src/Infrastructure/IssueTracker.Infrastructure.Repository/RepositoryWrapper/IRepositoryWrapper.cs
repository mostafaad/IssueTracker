using IssueTracker.Infrastructure.Repository.Repositories.IssueRepository;
using IssueTracker.Infrastructure.Repository.Repositories.ParticipantRepository;
using IssueTracker.Infrastructure.Repository.Repositories.ProjectRepository;
using System.Threading;
using System.Threading.Tasks;

namespace IssueTracker.Infrastructure.Repository.RepositoryWrapper
{
    public interface IRepositoryWrapper
    {
        IProjectRepository Project { get; }
        IIssueRepository Issue { get; }
        IParticipantRepository Participant { get; }
        Task<int> SaveChangesAsync(CancellationToken cancellationToken = new CancellationToken());
    }
}
