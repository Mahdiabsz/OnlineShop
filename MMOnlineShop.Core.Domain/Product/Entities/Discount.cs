using MMOnlineShop.Common.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MMOnlineShop.Core.Domain.Products.Entities
{
    public class Discount : BaseEntity
    {
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public string Description { get; set; }
        public float Percent { get; set; }
        public int ProductId { get; set; }
        public Product Product { get; set; }
    }
}
