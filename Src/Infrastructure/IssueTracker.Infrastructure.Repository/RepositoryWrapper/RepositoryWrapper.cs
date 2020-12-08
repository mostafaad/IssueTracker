using IssueTracker.Infrastructure.Persistence;
using IssueTracker.Infrastructure.Repository.Repositories.ProjectRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IssueTracker.Infrastructure.Repository.RepositoryWrapper
{
   public class RepositoryWrapper: IRepositoryWrapper
    {
        private ApplicationDbContext _repoContext;

        public IProjectRepository _Project;


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
