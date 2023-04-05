using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using MMOnlineShop.Core.Domain.Category.SubCategoryDetails.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MMOnlineShop.Core.Domain.Category.SubCategoryDetailValues.Entities;

namespace MMOnlineShop.Infrastructure.Data.SqlServer.Category.SubCategoryDetailValues.Configs
{
    public class SubCategoryDetailValueConfig : IEntityTypeConfiguration<SubCategoryDetailValue>
    {
        public void Configure(EntityTypeBuilder<SubCategoryDetailValue> builder)
        {
            builder.Property(c => c.Value).IsRequired().HasMaxLength(30);
            builder.HasQueryFilter(c => c.IsActive.Equals(true));
            builder.HasQueryFilter(c => c.IsDeleted.Equals(false));
            builder.HasOne(c => c.SubCategoryDetail).WithMany(c => c.SubCategoryDetailValues).HasForeignKey(c => c.SubCategoryDetailId).OnDelete(DeleteBehavior.Restrict);
        }
    }
}
