using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using MMOnlineShop.Core.Domain.Products.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MMOnlineShop.Core.Domain.Support.Entities;

namespace MMOnlineShop.Infrastructure.Data.SqlServer.Support.Configs
{
    public class TicketConfig : IEntityTypeConfiguration<Ticket>
    {
        public void Configure(EntityTypeBuilder<Ticket> builder)
        {
            builder.HasQueryFilter(c => c.IsActive.Equals(true));
            builder.HasQueryFilter(c => c.IsDeleted.Equals(false));
            builder.HasOne(c => c.User).WithMany(c => c.Tickets).HasForeignKey(c => c.UserId).OnDelete(DeleteBehavior.Restrict);
            builder.Property(c => c.Title).HasMaxLength(30).IsRequired();
        }
    }
}
