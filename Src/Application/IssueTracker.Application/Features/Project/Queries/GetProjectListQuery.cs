using AutoMapper;
using IssueTracker.Application.Common.Interfaces;
using IssueTracker.Application.Features.Projects.ViewModels;
using IssueTracker.Infrastructure.Repository.RepositoryWrapper;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper.QueryableExtensions;
using IssueTracker.Domain.Entities;

namespace IssueTracker.Application.Features.Projects.Queries
{
    public class GetProjectListQuery : IRequest<List<ProjectViewModel>>
    {
    }
    public class GetProjectListQueryHandler : IRequestHandler<GetProjectListQuery, List<ProjectViewModel>>
    {
        private readonly IRepositoryWrapper _wrapper;
        private readonly IMapper _mapper;
        private readonly ICurrentUserService _currentUserInfo;

        public GetProjectListQueryHandler(IRepositoryWrapper wrapper, IMapper mapper, ICurrentUserService currentUserInfo)
        {
            _wrapper = wrapper;
            _mapper = mapper; ;
            _currentUserInfo = currentUserInfo;
        }

        public async Task<List<ProjectViewModel>> Handle(GetProjectListQuery request, CancellationToken cancellationToken)
        {
            var ProjectList =  _wrapper.Project.GetAllUserProjectsAsync(_currentUserInfo.UserId);
            var MappedProjectList = _mapper.Map<List<ProjectViewModel>>(ProjectList);

            if (MappedProjectList == null)
                MappedProjectList = new List<ProjectViewModel>();


            return MappedProjectList;
        }
    }
}
