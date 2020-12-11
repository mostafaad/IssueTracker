using AutoMapper;
using IssueTracker.Application.Common.Interfaces;
using IssueTracker.Infrastructure.Repository.RepositoryWrapper;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace IssueTracker.Application.Features.Projects.Queries
{
    public class ValidateProjectKeyQuery : IRequest<bool>
    {
        public string ProjectKey { get; set; }
    }

    public class ValidateProjectKeyQueryHandler : IRequestHandler<ValidateProjectKeyQuery, bool>
    {
        private readonly IRepositoryWrapper _wrapper;
        private readonly IMapper _mapper;
        private readonly ICurrentUserService _currentUserInfo;

        public ValidateProjectKeyQueryHandler(IRepositoryWrapper wrapper, IMapper mapper, ICurrentUserService currentUserInfo)
        {
            _wrapper = wrapper;
            _mapper = mapper; ;
            _currentUserInfo = currentUserInfo;
        }

        public async Task<bool> Handle(ValidateProjectKeyQuery request, CancellationToken cancellationToken)
        {
            return await _wrapper.Project.ValidateProjectKeyAsync(request.ProjectKey);
        }
    }

}
