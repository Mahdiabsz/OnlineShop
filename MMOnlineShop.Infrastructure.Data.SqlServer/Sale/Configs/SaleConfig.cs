using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using MMOnlineShop.Core.Domain.Products.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MMOnlineShop.Core.Domain.Sales.Entities;

namespace MMOnlineShop.Infrastructure.Data.SqlServer.Sales.Configs
{
    public class SaleConfig : IEntityTypeConfiguration<Sale>
    {
        public void Configure(EntityTypeBuilder<Sale> builder)
        {
            builder.HasQueryFilter(c => c.IsActive.Equals(true));
            builder.HasQueryFilter(c => c.IsDeleted.Equals(false));
            builder.HasOne(c => c.User).WithMany(c => c.Sales).HasForeignKey(c => c.UserId).OnDelete(DeleteBehavior.Restrict);
            builder.Property(c => c.TotalPrice).IsRequired();
            builder.Property(c => c.Address).HasMaxLength(100).IsRequired();
            builder.Property(c => c.Description).HasMaxLength(200).IsRequired();
            builder.Property(c => c.PhoneNumber).HasMaxLength(15).IsRequired();
            builder.Property(c => c.PostalCode).HasMaxLength(15).IsRequired();
            builder.Property(c => c.Status).IsRequired();
        }
    }
}
