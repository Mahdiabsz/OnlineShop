using MMOnlineShop.Common.Domain;
using MMOnlineShop.Core.Domain.Products.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MMOnlineShop.Core.Domain.Sales.Entities
{
    public class SaleDetail : BaseEntity
    {
        public int SaleId { get; set; }
        public Sale Sale { get; set; }
        public int StockId { get; set; }
        public Stock Stock { get; set; }
        [Range(1,1000)]
        public int Number { get; set; }
    }
}
