using IssueTracker.Application.Features.Issues.Commands;
using IssueTracker.Application.Features.Issues.Queries;
using IssueTracker.Application.Features.Issues.ViewModels;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace IssueTracker.WebUI.Controllers
{
    public class IssueController : ApiController
    {
        [HttpGet("{ProjectKey}")]
        public async Task<ActionResult> Get(string ProjectKey)
        {
            return Ok(await Mediator.Send(new GetIssueListQuery() { ProjectKey = ProjectKey }));
        }
        [HttpPost("{ProjectKey}")]
        public async Task<ActionResult> Create(string ProjectKey ,IssueViewModel model)
        {
            return Ok(await Mediator.Send(new CreateIssueCommand() { model = model, ProjectKey= ProjectKey }));
        }

        [HttpGet("GetIssue/{IssueKey}")]
        public async Task<ActionResult> GetIssue(string IssueKey)
        {
            return Ok(await Mediator.Send(new GetIssueQuery() { IssueKey = IssueKey }));
        }
    }
}
