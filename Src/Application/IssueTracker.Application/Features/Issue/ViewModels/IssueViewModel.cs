using AutoMapper;
using IssueTracker.Application.Common.Mappings;
using IssueTracker.Domain.Entities;
using IssueTracker.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IssueTracker.Application.Features.Issues.ViewModels
{
   public class IssueViewModel: IMapFrom<Issue>
    {
        public string Id { get; set; }

        public string Title { get; set; }
        public string Description { get; set; }
        public string Reporter { get; set; }
        public string Assignee { get; set; }
        public Status Status { get; set; }
        public int ProjectId { get; set; }
        public DateTime Created { get; set; }

        // add automapper between model and entity
        public void Mapping(Profile profile)
        {
            profile.CreateMap<IssueViewModel, Issue>();
            profile.CreateMap<Issue, IssueViewModel>();
        }
    }
}
