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
    public class ValidateProjectOwnerQuery : IRequest<bool>
    {
        public string ProjectKey { get; set; }
    }

    public class ValidateProjectOwnerQueryHandler : IRequestHandler<ValidateProjectOwnerQuery, bool>
    {
        private readonly IRepositoryWrapper _wrapper;
        private readonly IMapper _mapper;
        private readonly ICurrentUserService _currentUserInfo;

        public ValidateProjectOwnerQueryHandler(IRepositoryWrapper wrapper, IMapper mapper, ICurrentUserService currentUserInfo)
        {
            _wrapper = wrapper;
            _mapper = mapper; ;
            _currentUserInfo = currentUserInfo;
        }

        public async Task<bool> Handle(ValidateProjectOwnerQuery request, CancellationToken cancellationToken)
        {
            return _wrapper.Project.FindByCondition(c => c.Key == request.ProjectKey && c.Participants.Any(c=>c.ParticipantUser == _currentUserInfo.UserId && c.IsOwner == true)).Any();
        }
    }

}
