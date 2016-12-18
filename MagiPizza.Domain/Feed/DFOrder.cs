using System.Collections.Generic;

namespace MagiPizza.Domain.Feed
{
    public class DFOrder
    {
        public List<int[]> order; // eg {product_id,qty}
        public int customer_id;
        public DFOrder()
        {
            this.order = new List<int[]>();
        }
    }
}