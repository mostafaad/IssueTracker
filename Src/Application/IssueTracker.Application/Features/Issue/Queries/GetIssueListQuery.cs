using AutoMapper;
using IssueTracker.Application.Common.Interfaces;
using IssueTracker.Application.Features.Issues.ViewModels;
using IssueTracker.Infrastructure.Repository.RepositoryWrapper;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace IssueTracker.Application.Features.Issues.Queries
{
   public class GetIssueListQuery:IRequest<List<IssueViewModel>>
    {
        public int ProjectId { get; set; }
    }

    public class GetIssueListQueryHandler : IRequestHandler<GetIssueListQuery, List<IssueViewModel>>
    {
        private readonly IRepositoryWrapper _wrapper;
        private readonly IMapper _mapper;
        private readonly ICurrentUserService _currentUserInfo;

        public GetIssueListQueryHandler(IRepositoryWrapper wrapper, IMapper mapper, ICurrentUserService currentUserInfo)
        {
            _wrapper = wrapper;
            _mapper = mapper; ;
            _currentUserInfo = currentUserInfo;
        }

        public async Task<List<IssueViewModel>> Handle(GetIssueListQuery request, CancellationToken cancellationToken)
        {
            var IssueList = await _wrapper.Issue.GetAllUserProjectIssuesAsync(request.ProjectId);
            var MappedIssueList = _mapper.Map<List<IssueViewModel>>(IssueList);

            if (MappedIssueList == null)
                MappedIssueList = new List<IssueViewModel>();


            return MappedIssueList;
        }
    }
}
