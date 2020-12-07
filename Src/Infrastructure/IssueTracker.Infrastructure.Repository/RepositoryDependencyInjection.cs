using IssueTracker.Infrastructure.Repository.RepositoryWrapper;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IssueTracker.Infrastructure.Repository
{
    public static class RepositoryDependencyInjection
    {
        public static void ConfigureRepositoryWrapper(this IServiceCollection services)
        {
            services.AddScoped<IRepositoryWrapper, RepositoryWrapper.RepositoryWrapper>();
        }
    }
}
