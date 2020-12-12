using IssueTracker.Domain.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IssueTracker.Domain.Entities
{
   public class Project: BaseEntity
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Key { get; set; }
        public string Owner { get; set; }
        public virtual ApplicationUser User { get; set; }
        public virtual ICollection<Issue> Issues{ get; set; }
        public virtual ICollection<Participants> Participants { get; set; }

    }
}
