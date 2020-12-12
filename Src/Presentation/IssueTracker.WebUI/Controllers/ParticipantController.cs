using IssueTracker.Application.Features.Issues.Commands;
using IssueTracker.Application.Features.Issues.Queries;
using IssueTracker.Application.Features.Participant.ViewModels;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace IssueTracker.WebUI.Controllers
{
    public class ParticipantController : ApiController
    {
        [HttpGet("{ProjectKey}")]
        public async Task<ActionResult> Get(string ProjectKey)
        {
            return Ok(await Mediator.Send(new GetParticipantListQuery() { ProjectKey = ProjectKey }));
        }

        [HttpPost("{ProjectKey}/{UserId}")]
        public async Task<ActionResult> Create(string ProjectKey, string UserId)
        {
            return Ok(await Mediator.Send(new CreateParticipantCommand() { UserId = UserId, ProjectKey= ProjectKey }));
        }
    }
}
