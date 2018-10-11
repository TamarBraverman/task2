using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models
{
    public class Tender
    {
        public int Id { get; set; }
        public int ProductId { get; set; }
        public Nullable<decimal> MaxCost { get; set; }
        public int UserId { get; set; }
        public DateTime StartDate { get; set; }
        public Nullable<int> City { get; set; }
        public string Description { get; set; }
        public System.DateTime EndDate { get; set; }

        public virtual Cities Cities { get; set; }
        public virtual Products Products { get; set; }
        public virtual ICollection<SuggestedPrices> SuggestedPrices { get; set; }
        public virtual Users Users { get; set; }
    }
}
