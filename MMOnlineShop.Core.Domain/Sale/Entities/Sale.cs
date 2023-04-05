using MMOnlineShop.Common.Domain;
using MMOnlineShop.Core.Domain.Sales.Enums;
using MMOnlineShop.Core.Domain.Users.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MMOnlineShop.Core.Domain.Sales.Entities
{
    public class Sale : BaseEntity
    {
        public int UserId { get; set; }
        public User User { get; set; }
        public decimal TotalPrice { get; set; }
        public string Address { get; set; }
        public string PostalCode { get; set; }
        public string PhoneNumber { get; set; }
        public string Description { get; set; }
        public SaleStatus Status { get; set; }
        public SaleShipmentStatus? ShipmentStatus { get; set; }
        public List<SaleDetail> SaleDetails { get; set; }
    }
}
