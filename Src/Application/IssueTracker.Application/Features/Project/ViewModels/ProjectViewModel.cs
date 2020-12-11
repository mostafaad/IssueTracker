using AutoMapper;
using IssueTracker.Application.Common.Mappings;
using IssueTracker.Domain.Entities;
using System;

namespace IssueTracker.Application.Features.Projects.ViewModels
{
    public class ProjectViewModel : IMapFrom<Project>
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Key { get; set; }
        public string Owner { get; set; }
        public DateTime Created { get; set; }

        public ApplicationUser User { get; set; }

        public void Mapping(Profile profile)
        {
            profile.CreateMap<ProjectViewModel, Project>();
            profile.CreateMap<Project, ProjectViewModel>();
        }
    }
}
