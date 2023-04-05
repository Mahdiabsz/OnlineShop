using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MMOnlineShop.Core.Domain.Products.Entities;

namespace MMOnlineShop.Infrastructure.Data.SqlServer.Products.Configs
{
    public class CommentConfig : IEntityTypeConfiguration<Comment>
    {
        public void Configure(EntityTypeBuilder<Comment> builder)
        {
            builder.Property(c => c.Description).IsRequired().HasMaxLength(50);
            builder.HasQueryFilter(c => c.IsActive.Equals(true));
            builder.HasQueryFilter(c => c.IsDeleted.Equals(false));
            builder.HasOne(c => c.User).WithMany(c => c.Comments).HasForeignKey(c => c.UserId).OnDelete(DeleteBehavior.Restrict);
            builder.HasOne(c => c.Product).WithMany(c => c.Comments).HasForeignKey(c => c.ProductId).OnDelete(DeleteBehavior.Restrict);
            builder.HasOne(c => c.ParentComment).WithMany(c => c.ChildComments).HasForeignKey(c => c.ParentCommentId).OnDelete(DeleteBehavior.Restrict);
            builder.HasOne(c => c.ReplyComment).WithMany(c => c.ReplyChildComments).HasForeignKey(c => c.ReplyCommentId).OnDelete(DeleteBehavior.Restrict);
        }
    }
}
