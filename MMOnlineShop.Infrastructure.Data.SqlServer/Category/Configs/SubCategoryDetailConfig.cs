using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using MMOnlineShop.Core.Domain.Category.SubCategories.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MMOnlineShop.Core.Domain.Category.SubCategoryDetails.Entities;

namespace MMOnlineShop.Infrastructure.Data.SqlServer.Category.SubCategoryDetails.Configs
{
    public class SubCategoryDetailConfig : IEntityTypeConfiguration<SubCategoryDetail>
    {
        public void Configure(EntityTypeBuilder<SubCategoryDetail> builder)
        {
            builder.Property(c => c.Title).IsRequired().HasMaxLength(30);
            builder.HasQueryFilter(c => c.IsActive.Equals(true));
            builder.HasQueryFilter(c => c.IsDeleted.Equals(false));
            builder.HasOne(c => c.SubCategory).WithMany(c => c.SubCategoryDetails).HasForeignKey(c => c.SubCategoryId).OnDelete(DeleteBehavior.Restrict);
            builder.Property(c => c.Type).IsRequired();

        }
    }
}
