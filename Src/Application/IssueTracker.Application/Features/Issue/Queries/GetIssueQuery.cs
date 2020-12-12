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
   public class GetIssueQuery : IRequest<IssueViewModel>
    {
        public string IssueKey { get; set; }
    }

    public class GetIssueQueryHandler : IRequestHandler<GetIssueQuery, IssueViewModel>
    {
        private readonly IRepositoryWrapper _wrapper;
        private readonly IMapper _mapper;
        private readonly ICurrentUserService _currentUserInfo;

        public GetIssueQueryHandler(IRepositoryWrapper wrapper, IMapper mapper, ICurrentUserService currentUserInfo)
        {
            _wrapper = wrapper;
            _mapper = mapper; ;
            _currentUserInfo = currentUserInfo;
        }

        public async Task<IssueViewModel> Handle(GetIssueQuery request, CancellationToken cancellationToken)
        {
            var Issue = _wrapper.Issue.FindByCondition(c => c.Id == request.IssueKey).FirstOrDefault() ;
            var MappedIssue = _mapper.Map<IssueViewModel>(Issue);

            if (MappedIssue == null)
                MappedIssue = new IssueViewModel();


            return MappedIssue;
        }
    }
}
