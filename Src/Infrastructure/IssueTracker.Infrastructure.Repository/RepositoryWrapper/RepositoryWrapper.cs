using IssueTracker.Domain.Common;
using IssueTracker.Infrastructure.Persistence;
using IssueTracker.Infrastructure.Repository.Repositories.IssueRepository;
using IssueTracker.Infrastructure.Repository.Repositories.ParticipantRepository;
using IssueTracker.Infrastructure.Repository.Repositories.ProjectRepository;
using Microsoft.EntityFrameworkCore;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace IssueTracker.Infrastructure.Repository.RepositoryWrapper
{
    public class RepositoryWrapper : IRepositoryWrapper
    {
        private ApplicationDbContext _repoContext;
        private IProjectRepository _Project;
        private IIssueRepository _Issue;
        private IParticipantRepository _Participant;
        public RepositoryWrapper(ApplicationDbContext repositoryContext)
        {
            _repoContext = repositoryContext;
        }

        public async Task<int> SaveChangesAsync(CancellationToken cancellationToken = new CancellationToken())
        {
            foreach (var entry in _repoContext.ChangeTracker.Entries<BaseEntity>())
            {
                switch (entry.State)
                {
                    case EntityState.Added:
                        entry.Entity.Created = DateTime.UtcNow;
                        break;
                    case EntityState.Modified:
                        entry.Entity.LastModified = DateTime.UtcNow;
                        break;
                }
            }

            return await _repoContext.SaveChangesAsync(cancellationToken);
        }

        public IProjectRepository Project
        {
            get
            {
                if (_Project == null)
                {
                    _Project = new ProjectRepository(_repoContext);
                }
                return _Project;
            }
        }

        public IIssueRepository Issue
        {
            get
            {
                if (_Issue == null)
                {
                    _Issue = new IssueRepository(_repoContext);
                }
                return _Issue;
            }
        }

        public IParticipantRepository Participant {
            get
            {
                if (_Participant == null)
                {
                    _Participant = new ParticipantRepository(_repoContext);
                }
                return _Participant;
            }
        }
    }
}
