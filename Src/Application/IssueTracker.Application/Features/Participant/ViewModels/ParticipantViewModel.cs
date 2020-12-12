using AutoMapper;
using IssueTracker.Application.Common.Mappings;
using IssueTracker.Application.Features.Projects.ViewModels;
using IssueTracker.Domain.Entities;
using IssueTracker.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IssueTracker.Application.Features.Participant.ViewModels
{
   public class ParticipantViewModel : IMapFrom<Participants>
    {
        public int Id { get; set; }

        public int ProjectId { get; set; }
        public ProjectViewModel Project { get; set; }

        public string ParticipantUser { get; set; }
        public ApplicationUser User { get; set; }

        public void Mapping(Profile profile)
        {
            profile.CreateMap<ParticipantViewModel, Participants>();
            profile.CreateMap<Participants, ParticipantViewModel>();
        }
    }
}
