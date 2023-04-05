using MMOnlineShop.Common.Domain;
using MMOnlineShop.Core.Domain.Users.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MMOnlineShop.Core.Domain.Products.Entities
{
    public class Rate : BaseEntity
    {
        public int UserId { get; set; }
        public User User { get; set; }
        public int ProductId { get; set; }
        public Product Product { get; set; }
        [Range(1,5)]
        public int Value { get; set; }
    }
}
