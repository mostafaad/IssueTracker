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
    public class DeleteProjectCommand : IRequest<Unit>
    {
        public string ProjectKey { get; set; }

    }

    public class DeleteProjectCommandHandler : IRequestHandler<DeleteProjectCommand, Unit>
    {
        private readonly IMapper _mapper;
        private readonly ICurrentUserService _currentUserInfo;
        private readonly IRepositoryWrapper _wrapper;

        public DeleteProjectCommandHandler(IMapper mapper, ICurrentUserService currentUserInfo, IRepositoryWrapper wrapper)
        {
            _mapper = mapper;
            _currentUserInfo = currentUserInfo;
            _wrapper = wrapper;

        }

        public async Task<Unit> Handle(DeleteProjectCommand request, CancellationToken cancellationToken)
        {
           var ProjectData = _wrapper.Project.FindByCondition(c => c.Key == request.ProjectKey).FirstOrDefault();

            ProjectData.IsDeleted = true;
            _wrapper.Project.Update(ProjectData);
            await _wrapper.SaveChangesAsync(cancellationToken);

            return Unit.Value;
        }
    }
}
