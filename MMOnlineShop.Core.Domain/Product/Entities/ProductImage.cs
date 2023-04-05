using MMOnlineShop.Common.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MMOnlineShop.Core.Domain.Products.Entities
{
    public class ProductImage : BaseEntity
    {
        public int ProductId { get; set; }
        public Product Product { get; set; }
        public string Location { get; set; }
        public bool IsMain { get; set; } = false;
    }
}
