using Microsoft.AspNetCore.Identity;
using MMOnlineShop.Core.Domain.Products.Entities;
using MMOnlineShop.Core.Domain.Sales.Entities;
using MMOnlineShop.Core.Domain.Support.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MMOnlineShop.Core.Domain.Users.Entities
{
    public class User : IdentityUser<int>
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public List<Comment> Comments { get; set; }
        public List<Rate> Rates { get; set; }
        public List<Ticket> Tickets { get; set; }
        public List<Sale> Sales { get; set; }
        public List<Cart> Carts { get; set; }
        public List<Favorite> Favorites { get; set; }
    }
}
