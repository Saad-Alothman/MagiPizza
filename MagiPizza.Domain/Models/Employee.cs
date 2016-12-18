namespace MagiPizza.Domain.Models
{
    public class Employee
    {
        int employeeId;
        string first_name;
        string last_name;


        public string Last_name
        {
            get { return last_name; }
            set { last_name = value; }
        }

        public string First_Name
        {
            get { return first_name; }
            set { first_name = value; }
        }
        public int EmployeeId
        {
            get { return employeeId; }
            set { employeeId = value; }
        }
        int branchId;

        public int BranchId
        {
            get { return branchId; }
            set { branchId = value; }
        }
        bool isAvailable;

        public bool IsAvailable
        {
            get { return isAvailable; }
            set { isAvailable = value; }
        }
        public Employee()
        {
            this.first_name = "";
            this.branchId = -1;
            this.employeeId = -1;
            this.isAvailable = false;

        }
        public Employee(int eid, int bid, bool available)
        {
            this.employeeId = eid;
            this.branchId = bid;

            this.isAvailable = available;
        }

    }
}