using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SqlClient;
using System.Data.Odbc;
using WindowsFormsApplication4;


namespace WindowsFormsApplication4
{
   internal class DBHandler
    {
       string strConnection;
        SqlConnection mycon;
        SqlCommand mycommand;
        SqlDataReader reader;
        internal string sqlQuery;
        public DBHandler()
        {

            this.strConnection = @"Data Source=.\SQLEXPRESS;AttachDbFilename=|DataDirectory|\Databajse1.mdf;Integrated Security=True;Connect Timeout=30;User Instance=True";
            this.mycon = new SqlConnection(strConnection);
            
            this.sqlQuery = "";
        }
       
        public Branch getBranchInfo(int bId)
        {
            
            Branch bInfo = new Branch();
            sqlQuery = "SELECT * FROM branch WHERE branch_id = '"+bId+"'";
            mycon.Open();
            mycommand = mycon.CreateCommand();
            mycommand.CommandText = sqlQuery;
            reader = mycommand.ExecuteReader();
            try
            {


                while (reader.Read())
                {

                    bInfo.Branch_id = reader.GetInt32(0);
                    bInfo.Branch_postcode = reader.GetString(1);
                    
                }
            }
            finally
            {
                mycon.Close();
            }
            bInfo.BranchVehicles=  getvehicles(bId);
            bInfo.BranchEmployees = getStaff(bId);
            return bInfo;
        }
        public Customer getCustomer(int customerID)
        {
            Customer customerDetails = new Customer();
            sqlQuery = "SELECT * FROM customer WHERE customer_id = '"+customerID+"'";
            try
            {
                mycon.Open();
                mycommand = mycon.CreateCommand();
                mycommand.CommandText = sqlQuery;
                reader = mycommand.ExecuteReader();


                while (reader.Read())
                {

                    customerDetails.Customer_id = reader.GetInt32(0);
                    customerDetails.FirstName = reader.GetString(1);
                    customerDetails.LastName = reader.GetString(2);
                    customerDetails.AddressLine1 = reader.GetString(3);
                    customerDetails.AddressLine2 = reader.GetString(4);
                    customerDetails.County = reader.GetString(5);
                    customerDetails.City = reader.GetString(6);
                    customerDetails.Postcode = reader.GetString(7);
                    customerDetails.Email = reader.GetString(8);
                    customerDetails.Telephone = reader.GetString(9);
                    customerDetails.Postcode = reader.GetString(10);
                }
            }
            finally
            {
                mycon.Close();
            }
            return customerDetails;
        }
        public CustomerR getCustomerR(int customerID)
        {
                        CustomerR temp = new CustomerR();
                        sqlQuery = "SELECT * FROM customer_for_performance_test WHERE customer_id = '" + customerID + "'";
            try
            {
                mycon.Open();
                mycommand = mycon.CreateCommand();
                mycommand.CommandText = sqlQuery;
                reader = mycommand.ExecuteReader();


                while (reader.Read())
                {


            temp = new CustomerR();
            temp.Customer_id = reader.GetInt32(0);
            temp.FirstName = reader.GetString(1);
            temp.LastName = reader.GetString(2);
            temp.AddressLine1 = reader.GetString(3);
            temp.AddressLine2 = reader.GetString(4);
            temp.County = reader.GetString(5);
            temp.City = reader.GetString(6);
            temp.Postcode = reader.GetString(7);
            temp.Email = reader.GetString(8);
            temp.Telephone = reader.GetString(9);
            temp.XCoordinate = reader.GetInt32(10);
            temp.YCoordinate = reader.GetInt32(11);
                }
            }
            finally
            {
                mycon.Close();
            }
            return temp;

           
        }
       public List<Branch> getBranches()
       {
           Branch singleBranch = new Branch();
           List<Branch> branches = new List<Branch>(); 
           sqlQuery = "SELECT * FROM branch"; 

           mycon.Open();
           mycommand = mycon.CreateCommand();
           mycommand.CommandText = sqlQuery;
           reader = mycommand.ExecuteReader();
           try
           {


               while (reader.Read())
               {
                   singleBranch = new Branch();
                   singleBranch.Branch_id = reader.GetInt32(0);
                   singleBranch.Branch_postcode = reader.GetString(1);
                   branches.Add(singleBranch);
               }
           }
           finally
           {
               mycon.Close();
           }
           return branches;

       }
       public List<order> getOrders(int branchID)
        {
            DateTime now= DateTime.Now;
            string strToday = now.Year+"-"+now.Month+"-"+now.Day;
            order singleOrder ;
            List<order> orders = new List<order>(); // maybe get the none processed only for the branch
            sqlQuery = "SELECT * FROM orders INNER JOIN order_servant on orders.order_id = order_servant.order_id "
            + "WHERE order_servant.branch_id ='" + branchID + "' and  orders.order_date = "
            + "'" + strToday + "' and orders.order_processing_startTime > '" + now.ToShortTimeString() + "'"; // maybe add AND status != processed

            //   String[] singleOrder = new String[8]; // size of array = number of columns in db
            mycon.Open();
            mycommand = mycon.CreateCommand();
            mycommand.CommandText = sqlQuery;
            reader = mycommand.ExecuteReader();
                try
                {

            while (reader.Read()) 
            {
                singleOrder = new order();
                    singleOrder.Order_id = reader.GetInt32(0);
                    singleOrder.Customer_id = reader.GetInt32(1);
                    singleOrder.Order_date = reader.GetDateTime(2).ToString();
                    singleOrder.Order_status = reader.GetString(3);
                    //singleOrder.Dispatch_time = reader.GetDateTime(4).ToString();
                  //  singleOrder.Time_required = reader.GetDateTime(5).ToString();
                    singleOrder.Order_time = reader.GetDateTime(6).ToString();
                    singleOrder.Order_processing_startTime = reader.GetDateTime(7).ToString();
                    singleOrder.Order_processing_FinishTime = reader.GetDateTime(8).ToString();
                

                orders.Add(singleOrder);
            }
                }
           finally
           {
               mycon.Close();
           }
            return orders;
        }
       public void setOrderAs(int orderID, string newState)
       {
           sqlQuery = "UPDATE orders set ORDERSTATUS = '"+newState+"' "
               +"WHERE order_id = '"+orderID+"'";
          // dbCommand = new SqlCommand(sqlQuery, dbConnection);

           try
           {
             //  dbConnection.Open();
               //dbCommand.ExecuteNonQuery();
           }
           finally
           {
            //   dbConnection.Close();
           }


       }
       public List<Employee> getStaff(int branchID)
       {
           List<Employee> staff = new  List<Employee>(); //get working only or all ?
           sqlQuery = "SELECT * FROM staff WHERE branch_id ='" + branchID + "' "; //probably u need INNER join with branch staff
           Employee singleEmployee;  // size of array = number of columns in db

           mycon.Open();
           mycommand = mycon.CreateCommand();
           mycommand.CommandText = sqlQuery;
           reader = mycommand.ExecuteReader();
           try
           {



               while (reader.Read())
               {

                   singleEmployee = new Employee();
                   singleEmployee.EmployeeId = reader.GetInt32(0);
                   singleEmployee.BranchId = reader.GetInt32(1);
                   singleEmployee.Last_name = reader.GetString(4);
                   singleEmployee.First_Name = reader.GetString(2);
                   string available = reader.GetString(3);

                   if(available=="available")
                   singleEmployee.IsAvailable =true ;
                   else
                       singleEmployee.IsAvailable = false;
                   staff.Add(singleEmployee);
               }
           }
           finally
           {
               mycon.Close();
           }
           return staff;
       }

       public void setStaffAs(int employeeID, int branchID,string newState)
       {
           sqlQuery = "UPDATE staff set status = '" + newState + "' "
               + "WHERE employee_id = '" + employeeID + "' "; // maybe u need branch id in the query as well
           try
           {
               mycon.Open();
               mycommand = mycon.CreateCommand();
               mycommand.CommandText = sqlQuery;
               mycommand.ExecuteNonQuery();
            
           }
           finally
           {
               mycon.Close();
           }
        //   dbCommand = new SqlCommand(sqlQuery, dbConnection);
/*
           try
           {
               dbConnection.Open();
          //     dbCommand.ExecuteNonQuery();
           }
           finally
           {
               dbConnection.Close();
           }
           */
       }
       public List<Vehicle> getvehicles(int branchID)
       {
           List<Vehicle> vehicles = new   List<Vehicle>(); //get working only or all ?
           sqlQuery = "SELECT * FROM fleet WHERE branch_id ='" + branchID + "' "; //probably u need INNER join
           Vehicle singleVehicle ;
           mycon.Open();
           mycommand = mycon.CreateCommand();
           mycommand.CommandText = sqlQuery;
           reader = mycommand.ExecuteReader();
           try
           {


               while (reader.Read())
               {
                   singleVehicle = new Vehicle();
                   singleVehicle.VehicleId = reader.GetInt32(0);
                   singleVehicle.BranchId = reader.GetInt32(1);
                   singleVehicle.Capacity = reader.GetInt32(2);
                   //string status = reader.GetString(3);
                   //if (status != "not available")
                   //singleVehicle.IsAvailable = ;
                   vehicles.Add(singleVehicle);                 
               }
           }
           finally
           {
               mycon.Close();
           }

           

           return vehicles;
       }

       public void setVehicleAs(int VehicleID, int branchID, string newState)
       {
           sqlQuery = "UPDATE fleet set status = '" + newState + "' "
               + "WHERE vehicle_id = '" + VehicleID + "' "; // maybe u need branch id in the query as well

           try
           {
               mycon.Open();
               mycommand = mycon.CreateCommand();
               mycommand.CommandText = sqlQuery;
               mycommand.ExecuteNonQuery();

           }
           finally
           {
               mycon.Close();
           }
           /*
           dbCommand = new SqlCommand(sqlQuery, dbConnection);

           try
           {
               dbConnection.Open();
               dbCommand.ExecuteNonQuery();
           }
           finally
           {
               dbConnection.Close();
           }
           */
       }



       internal void setBranchAs(int branchId, string status)
       {
           try
           {
               sqlQuery = "update branch set status = '" + status + "' WHERE branch_id = '" + branchId + "'";
               mycommand = mycon.CreateCommand();
               mycommand.CommandText = sqlQuery;
               mycon.Open();
               mycommand.ExecuteNonQuery();
           }
           finally
           {
               mycon.Close();
           }

       }
    }
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
        public Branch()
        {
            this.branch_id =-1;
            this.branch_postcode = "";
            this.branchEmployees = new List<Employee>();
            this.branchVehicles = new List<Vehicle>();
        }
        public override bool Equals(object obj)
        {
            return ((Branch)obj).Branch_id == this.Branch_id;
        }
    }
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
        public Vehicle(int vid,int bid,int capacity,bool available)
        {
            this.vehicleId = vid;
            this.branchId = bid;
            this.capacity = capacity;
            this.isAvailable = available;
        }

    }
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
            this.employeeId= -1;            
            this.isAvailable = false;
            
        }
         public Employee(int eid, int bid, bool available)
        {
            this.employeeId= eid;
            this.branchId = bid;
            
            this.isAvailable = available;
        }

    }
  public class order
   {
       public order()
       {
           this.customer_id = 0;
           this.order_id = 0;
           this.order_date = "";
           this.order_processing_FinishTime = "";
           this.order_processing_startTime = "";
           this.order_status = "";
           this.order_time = "";
           this.time_required = "";
           this.dispatch_time = "";
       }
       int order_id, customer_id;
       string order_date, order_status, dispatch_time, 
           time_required, order_time, order_processing_startTime, order_processing_FinishTime;

       public string Order_processing_FinishTime
       {
           get { return order_processing_FinishTime; }
           set { order_processing_FinishTime = value; }
       }

       public string Order_processing_startTime
       {
           get { return order_processing_startTime; }
           set { order_processing_startTime = value; }
       }

       public string Order_time
       {
           get { return order_time; }
           set { order_time = value; }
       }

       public string Time_required
       {
           get { return time_required; }
           set { time_required = value; }
       }

       public string Dispatch_time
       {
           get { return dispatch_time; }
           set { dispatch_time = value; }
       }

       public string Order_status
       {
           get { return order_status; }
           set { order_status = value; }
       }

       public string Order_date
       {
           get { return order_date; }
           set { order_date = value; }
       }

       public int Customer_id
       {
           get { return customer_id; }
           set { customer_id = value; }
       }

       public int Order_id
       {
           get { return order_id; }
           set { order_id = value; }
       }
   }
  public class Customer
  {
      int customer_id;
      string firstName;
      string lastName;
      string addressLine1;
      string addressLine2;
      string county;
      string city;
      string postcode;
      string email;
      string telephone;


      public Customer()
      {
          this.AddressLine1 = "";
          this.AddressLine2 = "";
          this.County = "";
          this.City = "";
          this.Customer_id = -1;
          this.Email = "";
          this.FirstName = "";
          this.LastName = "";
          this.Postcode = "";
          this.Telephone = "";

      }
      public Customer(string addr1, string addr2, string cont, string cty, int customId, string eml, string fname, string lname, string pcode, string tel)
      {
          this.AddressLine1 = addr1;
          this.AddressLine2 = addr2;
          this.County = cont;
          this.City = cty;
          this.Customer_id = customId;
          this.Email = eml;
          this.FirstName = fname;
          this.LastName = lname;
          this.Postcode = pcode;
          this.Telephone = tel;
          
      }
      
      public string Telephone
      {
          get { return telephone; }
          set { telephone = value; }
      }
      public string Email
      {
          get { return email; }
          set { email = value; }
      }
      public string Postcode
      {
          get { return postcode; }
          set { postcode = value; }
      }
      public string County
      {
          get { return county; }
          set { county = value; }
      }
      public string City
      {
          get { return city; }
          set { city = value; }
      }
      public string AddressLine2
      {
          get { return addressLine2; }
          set { addressLine2 = value; }
      }
      public string AddressLine1
      {
          get { return addressLine1; }
          set { addressLine1 = value; }
      }
      //addressLine1 	addressLine2 county postcode email telephone xCoordinate yCoordinate
      public string LastName
      {
          get { return lastName; }
          set { lastName = value; }
      }
      public string FirstName
      {
          get { return firstName; }
          set { firstName = value; }
      }
      public int Customer_id
      {
          get { return customer_id; }
          set { customer_id = value; }
      }

  }
}
public class CustomerR
{
    int customer_id;
    string firstName;
    string lastName;
    string addressLine1;
    string addressLine2;
    string county;
    string city;
    string postcode;
    string email;
    string telephone;
    int xCoordinate;
    int yCoordinate;

    public CustomerR()
    {
        this.AddressLine1 = "";
        this.AddressLine2 = "";
        this.County = "";
        this.City = "";
        this.Customer_id = -1;
        this.Email = "";
        this.FirstName = "";
        this.LastName = "";
        this.Postcode = "";
        this.Telephone = "";
        this.XCoordinate = 0;
        this.YCoordinate = 0;
    }
    public CustomerR(string addr1, string addr2, string cont, string cty, int customId, string eml, string fname, string lname, string pcode, string tel, int x, int y)
    {
        this.AddressLine1 = addr1;
        this.AddressLine2 = addr2;
        this.County = cont;
        this.City = cty;
        this.Customer_id = customId;
        this.Email = eml;
        this.FirstName = fname;
        this.LastName = lname;
        this.Postcode = pcode;
        this.Telephone = tel;
        this.XCoordinate = x;
        this.YCoordinate = y;
    }
    public int YCoordinate
    {
        get { return yCoordinate; }
        set { yCoordinate = value; }
    }
    public int XCoordinate
    {
        get { return xCoordinate; }
        set { xCoordinate = value; }
    }
    public string Telephone
    {
        get { return telephone; }
        set { telephone = value; }
    }
    public string Email
    {
        get { return email; }
        set { email = value; }
    }
    public string Postcode
    {
        get { return postcode; }
        set { postcode = value; }
    }
    public string County
    {
        get { return county; }
        set { county = value; }
    }
    public string City
    {
        get { return city; }
        set { city = value; }
    }
    public string AddressLine2
    {
        get { return addressLine2; }
        set { addressLine2 = value; }
    }
    public string AddressLine1
    {
        get { return addressLine1; }
        set { addressLine1 = value; }
    }
    //addressLine1 	addressLine2 county postcode email telephone xCoordinate yCoordinate
    public string LastName
    {
        get { return lastName; }
        set { lastName = value; }
    }
    public string FirstName
    {
        get { return firstName; }
        set { firstName = value; }
    }
    public int Customer_id
    {
        get { return customer_id; }
        set { customer_id = value; }
    }

}
