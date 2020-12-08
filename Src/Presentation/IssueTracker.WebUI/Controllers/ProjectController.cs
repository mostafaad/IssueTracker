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
            return await Mediator.Send(new GetCategoryQuery());
        }
    }
}
