using MMOnlineShop.Common.Domain;
using MMOnlineShop.Core.Domain.Products.Entities;
using MMOnlineShop.Core.Domain.Users.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MMOnlineShop.Core.Domain.Sales.Entities
{
    public class Cart : BaseEntity
    {
        public int UserId { get; set; }
        public User User { get; set; }
        public int StockId { get; set; }
        public Stock Stock { get; set; }
        [Range(1,1000)]
        public int Number { get; set; }
    }
}
