using IssueTracker.Application.Features.Projects.Commands;
using IssueTracker.Application.Features.Projects.Queries;
using IssueTracker.Application.Features.Projects.ViewModels;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace IssueTracker.WebUI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProjectController : ApiController
    {
        [HttpGet]
        public async Task<ActionResult> Get()
        {
            return Ok(await Mediator.Send(new GetProjectListQuery()));
        }

        [HttpPost]
        public async Task<ActionResult> Create(ProjectViewModel model)
        {
            return Ok(await Mediator.Send(new CreateProjectCommand() { project = model }));
        }

        [HttpGet("ValidateProjectKey/{ProjectKey}")]
        public async Task<ActionResult> ValidateProjectKey(string ProjectKey)
        {
            return Ok(await Mediator.Send(new ValidateProjectKeyQuery() { ProjectKey = ProjectKey }));
        }
    }
}
