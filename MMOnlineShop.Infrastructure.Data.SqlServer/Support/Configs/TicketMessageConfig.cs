using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using MMOnlineShop.Core.Domain.Support.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MMOnlineShop.Infrastructure.Data.SqlServer.Support.Configs
{
    public class TicketMessageConfig : IEntityTypeConfiguration<TicketMessage>
    {
        public void Configure(EntityTypeBuilder<TicketMessage> builder)
        {
            builder.HasQueryFilter(c => c.IsActive.Equals(true));
            builder.HasQueryFilter(c => c.IsDeleted.Equals(false));
            builder.HasOne(c => c.Ticket).WithMany(c => c.TicketMessages).HasForeignKey(c => c.TicketId).OnDelete(DeleteBehavior.Restrict);
            builder.Property(c => c.Message).HasMaxLength(300).IsRequired();
            builder.Property(c => c.IsSupport).IsRequired();
        }
    }
}
