using AutoMapper;
using IssueTracker.Application.Common.Interfaces;
using IssueTracker.Domain.Entities;
using IssueTracker.Infrastructure.Repository.RepositoryWrapper;
using MediatR;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace IssueTracker.Application.Features.User.Queries
{
    public class GetUserListQuery : IRequest<List<ApplicationUser>>
    {

    }

    public class GetUserListQueryHandler : IRequestHandler<GetUserListQuery, List<ApplicationUser>>
    {
        private readonly IRepositoryWrapper _wrapper;
        private readonly IMapper _mapper;
        private readonly UserManager<ApplicationUser> _userManager;

        public GetUserListQueryHandler(IRepositoryWrapper wrapper, IMapper mapper, UserManager<ApplicationUser> userManager)
        {
            _wrapper = wrapper;
            _mapper = mapper;
            _userManager = userManager;
        }

        public async Task<List<ApplicationUser>> Handle(GetUserListQuery request, CancellationToken cancellationToken)
        {
            var UserList = _userManager.Users.ToList();
           

            return UserList;
        }
    }
}
