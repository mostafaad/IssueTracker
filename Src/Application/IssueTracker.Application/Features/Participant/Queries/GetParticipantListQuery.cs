using AutoMapper;
using IssueTracker.Application.Common.Interfaces;
using IssueTracker.Application.Features.Issues.ViewModels;
using IssueTracker.Application.Features.Participant.ViewModels;
using IssueTracker.Infrastructure.Repository.RepositoryWrapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace IssueTracker.Application.Features.Issues.Queries
{
   public class GetParticipantListQuery : IRequest<List<ParticipantViewModel>>
    {
        public string ProjectKey { get; set; }
    }

    public class GetParticipantListQueryHandler : IRequestHandler<GetParticipantListQuery, List<ParticipantViewModel>>
    {
        private readonly IRepositoryWrapper _wrapper;
        private readonly IMapper _mapper;
        private readonly ICurrentUserService _currentUserInfo;

        public GetParticipantListQueryHandler(IRepositoryWrapper wrapper, IMapper mapper, ICurrentUserService currentUserInfo)
        {
            _wrapper = wrapper;
            _mapper = mapper; ;
            _currentUserInfo = currentUserInfo;
        }

        public async Task<List<ParticipantViewModel>> Handle(GetParticipantListQuery request, CancellationToken cancellationToken)
        {
            // Get current project data
            var ProjectData = _wrapper.Project.FindByCondition(c => c.Key == request.ProjectKey).FirstOrDefault();

            var ParticipantList = _wrapper.Participant.FindByCondition(c => c.ProjectId == ProjectData.Id).Include(c => c.User);
            var MappedParticipantList = _mapper.Map<List<ParticipantViewModel>>(ParticipantList);

            if (MappedParticipantList == null)
                MappedParticipantList = new List<ParticipantViewModel>();


            return MappedParticipantList;
        }
    }
}
