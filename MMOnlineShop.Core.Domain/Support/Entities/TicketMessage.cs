using MMOnlineShop.Common.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MMOnlineShop.Core.Domain.Support.Entities
{
    public class TicketMessage : BaseEntity
    {
        public int TicketId { get; set; }
        public Ticket Ticket { get; set; }
        public string Message { get; set; }
        public bool IsSupport { get; set; } = false;
    }
}
