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
   public class CreateProjectCommand : IRequest
    {
        public ProjectViewModel project { get; set; }

    }

    public class CreateProjectCommandHandler : IRequestHandler<CreateProjectCommand>
    {
        private readonly IMapper _mapper;
        private readonly ICurrentUserService _currentUserInfo;
        private readonly IRepositoryWrapper _wrapper;

        public CreateProjectCommandHandler( IMapper mapper, ICurrentUserService currentUserInfo, IRepositoryWrapper wrapper)
        {
            _mapper = mapper;
            _currentUserInfo = currentUserInfo;
            _wrapper = wrapper;

        }

        public async Task<Unit> Handle(CreateProjectCommand request, CancellationToken cancellationToken)
        {
            var ProjectObj = _mapper.Map<Project>(request.project);
            _wrapper.Project.Create(ProjectObj);

            _wrapper.Save();

            return Unit.Value;
        }
    }
}
