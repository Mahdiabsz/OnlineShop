using MMOnlineShop.Common.Domain;
using MMOnlineShop.Core.Domain.Sales.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MMOnlineShop.Core.Domain.Products.Entities
{
    public class Stock : BaseEntity
    {
        public int ProductId { get; set; }
        public Product Product { get; set; }
        public string DetailValueArray { get; set; }
        public int Inventory { get; set; }
        public List<SaleDetail> SaleDetails { get; set; }
        public List<Cart> Carts { get; set; }
    }
}
