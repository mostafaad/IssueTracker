using IssueTracker.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IssueTracker.Infrastructure.Persistence.Configurations
{

    public class ParticipantsConfiguration : IEntityTypeConfiguration<Participants>
    {
        public void Configure(EntityTypeBuilder<Participants> builder)
        {
            builder.HasKey(s => s.Id);
            builder.HasOne(c => c.Project).WithMany(c => c.Participants).HasForeignKey(c => c.ProjectId);
            builder.HasOne(c => c.User).WithMany(c => c.Participants).HasForeignKey(c => c.ParticipantUser);

        }
    }
}
