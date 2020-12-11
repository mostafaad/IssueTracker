using Microsoft.AspNetCore.Identity;
using System.Collections.Generic;

namespace IssueTracker.Domain.Entities
{
    public class ApplicationUser : IdentityUser
    {
        public string FullName { get; set; }
        public virtual ICollection<Project> Projects { get; set; }
        public virtual ICollection<Participants> Participants{ get; set; }

    }

}
