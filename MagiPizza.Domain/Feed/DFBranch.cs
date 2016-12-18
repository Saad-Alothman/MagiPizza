namespace MagiPizza.Domain.Feed
{
    public class DFBranch
    {
        int branch_id;
        double queueTime;
        double distanceToCustomer;
        bool isStaffAvailable;
        bool isVehiclesAvailable;
        bool isAvailable;
        bool enoughStock;

        public bool EnoughStock
        {
            get { return enoughStock; }
            set { enoughStock = value; }
        }

        public bool IsAvailable
        {
            get { return isAvailable; }
            set { isAvailable = value; }
        }

        public bool IsVehiclesAvailable
        {
            get { return isVehiclesAvailable; }
            set { isVehiclesAvailable = value; }
        }

        public bool IsStaffAvailable
        {
            get { return isStaffAvailable; }
            set { isStaffAvailable = value; }
        }


        public double DistanceToCustomer
        {
            get { return distanceToCustomer; }
            set { distanceToCustomer = value; }
        }

        public double QueueTime
        {
            get { return queueTime; }
            set { queueTime = value; }
        }
        public int Branch_id
        {
            get { return branch_id; }
            set { branch_id = value; }
        }
        public DFBranch()
        {
            this.branch_id = -1;
            this.queueTime = -1;
            this.distanceToCustomer = -1;
            this.IsStaffAvailable = false;
            this.IsVehiclesAvailable = false;
            this.IsAvailable = false;
        }
    }
}