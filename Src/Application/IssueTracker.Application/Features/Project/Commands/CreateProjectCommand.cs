using AutoMapper;
using IssueTracker.Application.Common.Interfaces;
using IssueTracker.Application.Features.Projects.ViewModels;
using IssueTracker.Domain.Entities;
using IssueTracker.Infrastructure.Repository.RepositoryWrapper;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace IssueTracker.Application.Features.Projects.Commands
{
    public class CreateProjectCommand : IRequest<Project>
    {
        public ProjectViewModel project { get; set; }

    }

    public class CreateProjectCommandHandler : IRequestHandler<CreateProjectCommand, Project>
    {
        private readonly IMapper _mapper;
        private readonly ICurrentUserService _currentUserInfo;
        private readonly IRepositoryWrapper _wrapper;

        public CreateProjectCommandHandler(IMapper mapper, ICurrentUserService currentUserInfo, IRepositoryWrapper wrapper)
        {
            _mapper = mapper;
            _currentUserInfo = currentUserInfo;
            _wrapper = wrapper;

        }

        public async Task<Project> Handle(CreateProjectCommand request, CancellationToken cancellationToken)
        {
            var ProjectObj = _mapper.Map<Project>(request.project);
            ProjectObj.Owner = _currentUserInfo.UserId;
            ProjectObj.Participants = new List<Participants>();

            //add owner Participant to project 
            ProjectObj.Participants.Add(new Participants()
            {
                ParticipantUser = _currentUserInfo.UserId,
                IsOwner = true
            }) ;
            _wrapper.Project.Create(ProjectObj);

            await _wrapper.SaveChangesAsync(cancellationToken);

            return ProjectObj;
        }
    }
}
