using IssueTracker.Domain.Common;
using IssueTracker.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IssueTracker.Domain.Entities
{
    public class Issue : BaseEntity
    {
        public string Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public string Reporter { get; set; }
        public string Assignee { get; set; }
        public Status Status { get; set; }
        public int ProjectId { get; set; }

        public Project Project { get; set; }
    }
}
