using IssueTracker.Domain.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IssueTracker.Domain.Entities
{
   public class Project: AuditableEntity
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Key { get; set; }
        public string Owner { get; set; }
        public ApplicationUser User { get; set; }
    }
}
