using IssueTracker.Application.Features.User.Queries;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace IssueTracker.WebUI.Controllers
{
    public class UserController : ApiController
    {
        [HttpGet]
        public async Task<ActionResult> Get()
        {
            return Ok(await Mediator.Send(new GetUserListQuery()));
        }
    }
}
