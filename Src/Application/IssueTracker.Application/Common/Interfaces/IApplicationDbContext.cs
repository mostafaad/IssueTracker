using IssueTracker.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace IssueTracker.Application.Common.Interfaces
{
    public interface IApplicationDbContext
    {
        public DbSet<Project> Projects { get; set; }
        public DbSet<Issue> Issues { get; set; }
        public DbSet<Participants> Participants { get; set; }
        Task<int> SaveChangesAsync(CancellationToken cancellationToken);
    }
}
