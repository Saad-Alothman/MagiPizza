namespace MagiPizza.Domain.Models
{
    public class Vehicle
    {
        private int vehicleId;
        private int branchId;
        private bool isAvailable;
        private int capacity;

        public int VehicleId
        {
            get { return vehicleId; }
            set { vehicleId = value; }
        }
        public int BranchId
        {
            get { return branchId; }
            set { branchId = value; }
        }
        public int Capacity
        {
            get { return capacity; }
            set { capacity = value; }
        }
        public bool IsAvailable
        {
            get { return isAvailable; }
            set { isAvailable = value; }
        }
        public Vehicle()
        {
            this.branchId = -1;
            this.vehicleId = -1;
            this.capacity = -1;
            this.isAvailable = false;

        }
        public Vehicle(int vid, int bid, int capacity, bool available)
        {
            this.vehicleId = vid;
            this.branchId = bid;
            this.capacity = capacity;
            this.isAvailable = available;
        }

    }
}