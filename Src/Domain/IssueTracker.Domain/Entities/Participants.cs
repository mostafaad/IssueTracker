using IssueTracker.Domain.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IssueTracker.Domain.Entities
{
  public  class Participants: BaseEntity
    {
        public int Id { get; set; }

        public int ProjectId { get; set; }
        public Project Project { get; set; }
        public bool IsOwner { get; set; }

        public string ParticipantUser { get; set; }
        public ApplicationUser User { get; set; }

    }
}
