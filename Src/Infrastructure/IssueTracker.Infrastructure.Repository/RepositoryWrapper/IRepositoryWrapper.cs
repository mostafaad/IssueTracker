using IssueTracker.Infrastructure.Repository.Repositories.ProjectRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IssueTracker.Infrastructure.Repository.RepositoryWrapper
{
    public interface IRepositoryWrapper
    {
        IProjectRepository Project { get; }

    }
}
