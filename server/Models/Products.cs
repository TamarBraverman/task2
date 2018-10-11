using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models
{
    public class Products
    {
        public int ProductId { get; set; }
        public string ProductName { get; set; }
        public Nullable<int> CategoryId { get; set; }
        public virtual Categories Categories { get; set; }
        public virtual ICollection<ProductForSale> ProductForSale { get; set; }
        public virtual ICollection<Tender> Tender { get; set; }
    }
}
