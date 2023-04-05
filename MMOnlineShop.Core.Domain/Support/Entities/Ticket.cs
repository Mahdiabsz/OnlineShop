using MMOnlineShop.Common.Domain;
using MMOnlineShop.Core.Domain.Users.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MMOnlineShop.Core.Domain.Support.Entities
{
    public class Ticket : BaseEntity
    {
        public int UserId { get; set; }
        public User User { get; set; }
        public string Title { get; set; }
        public List<TicketMessage> TicketMessages { get; set; }
    }
}
