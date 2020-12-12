using AutoMapper;
using IssueTracker.Application.Common.Interfaces;
using IssueTracker.Application.Features.Issues.ViewModels;
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

namespace IssueTracker.Application.Features.Issues.Commands
{
    public class CreateIssueCommand : IRequest<Issue>
    {
        public IssueViewModel model { get; set; }
        public string ProjectKey { get; set; }
    }

    public class CreateIssueCommandHandler : IRequestHandler<CreateIssueCommand, Issue>
    {
        private readonly IMapper _mapper;
        private readonly ICurrentUserService _currentUserInfo;
        private readonly IRepositoryWrapper _wrapper;

        public CreateIssueCommandHandler(IMapper mapper, ICurrentUserService currentUserInfo, IRepositoryWrapper wrapper)
        {
            _mapper = mapper;
            _currentUserInfo = currentUserInfo;
            _wrapper = wrapper;
        }

        public async Task<Issue> Handle(CreateIssueCommand request, CancellationToken cancellationToken)
        {
            var ProjectData = _wrapper.Project.FindByCondition(c => c.Key == request.ProjectKey).FirstOrDefault();
            var MaxIssueNumber = _wrapper.Issue.FindByCondition(c => c.ProjectId == ProjectData.Id).Count() + 1;
            var IssueObj = _mapper.Map<Issue>(request.model);
            IssueObj.ProjectId = ProjectData.Id;
            IssueObj.Reporter = _currentUserInfo.UserId;
            IssueObj.Id = ProjectData.Key + "-" + MaxIssueNumber;
            _wrapper.Issue.Create(IssueObj);

            await _wrapper.SaveChangesAsync(cancellationToken);

            return IssueObj;
        }
    }
}
