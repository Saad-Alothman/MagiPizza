using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MagiPizza.Domain.Models;

namespace MagiPizza.Persistance
{
    public class DBHandler
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
            sqlQuery = "SELECT * FROM branch WHERE branch_id = '" + bId + "'";
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
            bInfo.BranchVehicles = getvehicles(bId);
            bInfo.BranchEmployees = getStaff(bId);
            return bInfo;
        }
        public Customer getCustomer(int customerID)
        {
            Customer customerDetails = new Customer();
            sqlQuery = "SELECT * FROM customer WHERE customer_id = '" + customerID + "'";
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
            DateTime now = DateTime.Now;
            string strToday = now.Year + "-" + now.Month + "-" + now.Day;
            order singleOrder;
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
            sqlQuery = "UPDATE orders set ORDERSTATUS = '" + newState + "' "
                + "WHERE order_id = '" + orderID + "'";
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
            List<Employee> staff = new List<Employee>(); //get working only or all ?
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

                    if (available == "available")
                        singleEmployee.IsAvailable = true;
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

        public void setStaffAs(int employeeID, int branchID, string newState)
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
            List<Vehicle> vehicles = new List<Vehicle>(); //get working only or all ?
            sqlQuery = "SELECT * FROM fleet WHERE branch_id ='" + branchID + "' "; //probably u need INNER join
            Vehicle singleVehicle;
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


        public void setBranchAs(int branchId, string status)
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
}
