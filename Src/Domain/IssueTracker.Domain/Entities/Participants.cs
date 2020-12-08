using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IssueTracker.Domain.Entities
{
  public  class Participants
    {
        public int Id { get; set; }
        public int ProjectId { get; set; }
        public string ParticipantUser { get; set; }
        public ApplicationUser User { get; set; }
    }
}
