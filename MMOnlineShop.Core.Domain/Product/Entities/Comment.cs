using MMOnlineShop.Common.Domain;
using MMOnlineShop.Core.Domain.Users.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MMOnlineShop.Core.Domain.Products.Entities
{
    public class Comment : BaseEntity
    {
        public int UserId { get; set; }
        public User User { get; set; }
        public int ProductId { get; set; }
        public Product Product { get; set; }
        public string Description { get; set; }
        public int? ParentCommentId { get; set; }
        public Comment ParentComment { get; set; }
        public int? ReplyCommentId { get; set; }
        public Comment ReplyComment { get; set; }
        public List<Comment> ChildComments { get; set; }
        public List<Comment> ReplyChildComments { get; set; }
    }
}
