using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models
{
    public class ProductForSale
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public int ProductId { get; set; }
        public string Description { get; set; }
        public string ImageUrl { get; set; }
        public int City { get; set; }

        public virtual Cities Cities { get; set; }
        public virtual ICollection<SuggestedPrices> SuggestedPrices { get; set; }
        public virtual Products Products { get; set; }
        public virtual Users Users { get; set; }
    }
}
