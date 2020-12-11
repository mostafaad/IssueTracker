using IssueTracker.Domain.Common;
using IssueTracker.Infrastructure.Persistence;
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
        public IProjectRepository _Project;
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

    }
}
