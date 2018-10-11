using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models
{
    public class SuggestedPrices
    {
        public int TenderId { get; set; }
        public int UserProductId { get; set; }
        public Nullable<int> SuggestedPrice { get; set; }

        public virtual ProductForSale ProductForSale { get; set; }
        public virtual Tender Tender { get; set; }
    }
}
