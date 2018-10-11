using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models
{
    public class Users
    {
        public int UserId { get; set; }
        public string Tz { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Mail { get; set; }
        public string Tel { get; set; }
        public string Password { get; set; }
        public virtual ICollection<ProductForSale> ProductForSale { get; set; }
        public virtual ICollection<Tender> Tender { get; set; }
    }
}
