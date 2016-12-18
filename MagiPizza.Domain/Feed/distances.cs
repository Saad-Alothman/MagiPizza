using System.Collections.Generic;

namespace MagiPizza.Domain.Feed
{
    public class distances
    {
        int customerId;
        int orderId;
        List<int[]> vehiclesDistance; // {vid ,distance}
        List<int[]> branchesDistance; // {bid , distance}

        public distances()
        {
            this.customerId = -1;
            this.orderId = -1;
            this.vehiclesDistance = new List<int[]>();
            this.branchesDistance = new List<int[]>();
        }
        private List<int[]> BranchesDistance
        {
            get { return branchesDistance; }
            set { branchesDistance = value; }
        }

        private List<int[]> VehiclesDistance
        {
            get { return vehiclesDistance; }
            set { vehiclesDistance = value; }
        }
        public int OrderId
        {
            get { return orderId; }
            set { orderId = value; }
        }
        public int CustomerId
        {
            get { return customerId; }
            set { customerId = value; }
        }
    }
}