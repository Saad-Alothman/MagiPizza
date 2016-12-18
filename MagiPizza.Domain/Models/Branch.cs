using System;
using System.Collections.Generic;

namespace MagiPizza.Domain.Models
{
    public class Branch
    {
        int branch_id;
        string branch_postcode;
        int numberOfStaff;
        int numberOfVehicles;
        public List<Vehicle> branchVehicles;
        private List<Employee> branchEmployees;
        bool isAvialable;

        public bool IsAvialable
        {
            get { return isAvialable; }
            set { isAvialable = value; }
        }
        public List<Employee> BranchEmployees
        {
            get { return branchEmployees; }
            set { branchEmployees = value; }
        }

        public int NumberOfVehicles
        {
            get { return numberOfVehicles; }
            set { numberOfVehicles = value; }
        }

        public int NumberOfStaff
        {
            get { return numberOfStaff; }
            set { numberOfStaff = value; }
        }

        public List<Vehicle> BranchVehicles
        {
            get { return branchVehicles; }
            set { branchVehicles = value; }
        }

        public int Branch_id
        {
            get { return branch_id; }
            set { branch_id = value; }
        }
        public string Branch_postcode
        {
            get { return branch_postcode; }
            set { branch_postcode = value; }
        }

        public int X => Convert.ToInt32(Branch_postcode.Remove(0, 3));
        public int Y => Convert.ToInt32(Branch_postcode.Remove(2));

        public Branch()
        {
            this.branch_id = -1;
            this.branch_postcode = "";
            this.branchEmployees = new List<Employee>();
            this.branchVehicles = new List<Vehicle>();
        }
        public override bool Equals(object obj)
        {
            return ((Branch)obj).Branch_id == this.Branch_id;
        }
    }
}