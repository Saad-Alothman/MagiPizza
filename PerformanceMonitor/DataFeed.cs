using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Data.SqlClient;
using System.Data.Odbc;
using WindowsFormsApplication4;
using System.Timers;
namespace PerformanceMonitor
{
    //the purpose of this class is to run a simulation for stochastic orders with different customers to 
    //analyze and measure the algorithm behind the process
    public class DataFeed // this class represents the scheduling, load balancing algorithm found in the server side 
                            //script in the website
    {
        /*MaxjourneyDestinationTimeM : the maximum time taken to deliver an order to a customer within a journey
         * machineCapacity : the number of products that the machine can contain
         * vehicleAvgSpeed : the average travel speed of a vehicle 
         * orderwaitTimeMM: the time which an order must wait before leaving the branch if it is the first order of the journey
         */
        public int maxjourneyDestinationTimeM = 20;


 
       const int  machineCapacity = 10;
       const double  vehicleAvgSpeed = 50000;// 50 Km/h
       const int orderwaitTimeMM = 58;
       /* The next variables are the boundaries 
        * of the x,y grid which holds
        * the locations of the customer 
        * and the branches ,this represents for example the city grid,this is used for the purpose of this simulation where no actual addresses does exist*/
        
       const int MaxX = 20; 
       const int MaxY = 20;
       const int MinX = 0;
       const int MinY = 0;
       const int MAXIMUM_LAST_JD_Delay_M = 100;// The maximum delay last journey destination of a journey,this is used when inserting a destination before the last destination this is used for finding the best fit DVR
       public List<order> dbOrders; // the orders that are held in the database,this is used for the graph plotting only
       public List<string[]> storeCoordinates;// this is used for the purpose of this simulation where no actual addresses does exist
       public List<int[]> storeCoordinatesR;// this is used for the purpose of this simulation where no actual addresses does exist
       //public List<object[]> customers; //comment it out
       public List<CustomerR> customersR;//a list that will hold the customers class
       public List<Employee> dbStaff;// a list that will hold the randomly generated staff for every branch
       public List<Branch> dbBranches; // a list that will contain the data about a branch from the database.
       internal List<Vehicle> dbVehicles;// a list that will hold the data about vehicles for every branch
       public List<Product> products;// the list of the store products
       public List<DFOrder> queueOfOrders; // a list that will hold the customers orders
       SqlConnection connection;//remove
       SqlCommand command;//      ==
       SqlDataReader dataReader;//==
       string strConnection;
       SqlConnection mycon;
       SqlCommand mycommand;
       SqlDataReader reader;
       internal string sqlQuery;
       bool isTimedService;//  this is used to put a delay between every customer order to observe the status of the system
       internal int TimedServiceDelay;// this is used to put a delay between every customer order to observe the status of the system
       int nextorderIndex;
       Timer itimer ;
        

        
        public DataFeed()
        {
            this.strConnection = @"Data Source=.\;AttachDbFilename=C:\Users\saad\Desktop\GradProj\WindowsFormsApplication4\PerformanceMonitor\Database1.mdf;Integrated Security=True;";
            this.mycon = new SqlConnection(strConnection);
            this.dbBranches = new List<Branch>();
            this.sqlQuery = "";
            this.storeCoordinates = new List<string[]>();
            this.customersR = new List<CustomerR>();
            dbBranches = new List<Branch>();
            this.products = new List<Product>();
            this.queueOfOrders = new   List<DFOrder>();
            this.TimedServiceDelay = 0;
            //this.customers = new List<object[]>();
            this.dbVehicles = new  List<Vehicle> ();
            this.nextorderIndex = 0;
            this.itimer = new Timer();
            this.dbOrders = new List<order>();
            this.dbStaff = new List<Employee>();
        }
        public void clearDB()
        {
            mycon.Open();
            string[] tables = { "orders", "orderLine", "order_servant", "journey", "journey_destinations", "branch", "fleet", "customer_for_performance_test","staff" };
            for (int i = 0; i < tables.Length; i++)
            {
                sqlQuery = "DELETE  FROM " + tables[i];

                mycommand = new SqlCommand(sqlQuery, mycon);
                mycommand.CommandText = sqlQuery;
                mycommand.ExecuteNonQuery();
            }
            mycon.Close();

        }
        internal void randomVehiclesForBranches(int min_of_vehicles_per_branch, int max_of_vehicles_per_branch,int min_capacity,int max_capacity)
        {
            // this method generates random vehicles for every branch based on the inputs from the performance monitor application
            Random r = new Random();
            int numberOfVehicles = 0;
            int vehicleCapacity = 0;
            Vehicle temp;
            foreach (Branch b in dbBranches)
            {
                numberOfVehicles = r.Next(min_of_vehicles_per_branch, max_of_vehicles_per_branch);
                for (int i = 0; i < numberOfVehicles;i++ )
                {
                    temp = new Vehicle();
                    temp.IsAvailable = true;
                    temp.Capacity = r.Next(min_capacity,max_capacity);
                    temp.BranchId = b.Branch_id;
                    dbVehicles.Add(temp);
                }


            }
        }
        public void hardCodedVehiclesForBranches(List<Vehicle> vehicleshc)
        {
            //  this method is used for testing while hardcoding the vehicles data instead of random data
            Vehicle vtemp;
            foreach (Branch b in dbBranches)
            {
                foreach (Vehicle v in vehicleshc)
                {
                    vtemp = new Vehicle();
                    vtemp.BranchId = b.Branch_id;
                    vtemp.Capacity = v.Capacity;
                    vtemp.IsAvailable = true;
                    
                    dbVehicles.Add(vtemp);
                }
            }
        }
        internal void insertRandomVehicles()
        {
            // this method inserts vehicles into the database
            string strStatus;

            try
            {
                mycon.Open();
                foreach (Vehicle v in dbVehicles)
                {         
                    if (v.IsAvailable)
                        strStatus = "available";
                    else
                        strStatus = "unavailable";
                    sqlQuery = "INSERT INTO fleet "
                + "(branch_id,capacity,status)" + " VALUES ('" + v.BranchId + "','" + v.Capacity + "','"+strStatus+"')";
                    mycommand = new SqlCommand(sqlQuery, mycon);
                    mycommand.CommandText = sqlQuery;
                    mycommand.ExecuteNonQuery();
                }
            }
            finally
            {
                mycon.Close();
            }
        }
        internal void readRandomVehicles()
        {
            //this method will read the vehicles from the database and assign it to the dbVehicles list variable
            
            Vehicle temp;
            sqlQuery = "SELECT * FROM fleet ";
            try
            {

            mycon.Open();
            mycommand = new SqlCommand(sqlQuery, mycon);
            mycommand.CommandText = sqlQuery;
            reader = mycommand.ExecuteReader();
            
                while (reader.Read())
                {
                    temp = new  Vehicle();
                    temp.VehicleId = reader.GetInt32(0);
                    temp.BranchId = reader.GetInt32(1);
                    temp.Capacity = reader.GetInt32(2);
                    if(reader.GetString(3).TrimEnd()== "available")
                    temp.IsAvailable=true;
                    else
                    temp.IsAvailable = false;
                    dbVehicles.Add(temp);
                }
            }
            finally
            {
                mycon.Close();
            }
 
        }
        public void insertRandomBranches()
        {
            //this method wil insert the randomly generated branches in the list variable dbBranches into the database
            mycon.Open();
            Branch temp = new Branch();
            for (int i = 0; i < dbBranches.Count; i++)
            {
                temp = dbBranches[i];
                string strStatus;
                if(temp.IsAvialable)
                    strStatus="available";
                else
                    strStatus="unavailable";
                sqlQuery = "INSERT INTO branch "
                            + "(postcode,status)" + " VALUES ('" + temp.Branch_postcode + "','" + strStatus + "')";

                mycommand = new SqlCommand(sqlQuery, mycon);
                mycommand.CommandText = sqlQuery;
                mycommand.ExecuteNonQuery();
            }
            mycon.Close();
        }
        public void hardCodedCustomers(List<CustomerR> customers)
        {
            customersR = customers;
        }
        public void hardCodedBranches(List<Branch> branches)
        {
            dbBranches = branches;
        }
        public void hardCodedOrders(Queue<DFOrder> ordershc)
        {
            DFOrder tempo;
            List<DFOrder> olist = new List<DFOrder>();
            olist = ordershc.ToList();
            //Queue<DFOrder> theorderesQ = new Queue<DFOrder>();
            for (int i = 0; i < olist.Count; i++)
            {
                tempo = new DFOrder();
                tempo = olist[i];
                tempo.customer_id = customersR[i].Customer_id;
                queueOfOrders.Add(tempo);
            }
            
        }
        public void RandomCustomers(int numberOfCustomers,bool isCloseToAbranch)
        {
            //this will create random customers based on the number of customers and if isCloseToAbranch is set to true,h
            // the customers are going to be located around one branch to observe the load balancing over the branches
            CustomerR temp;
            int x,y, customerXCoordinates, customerYCoordinates;
            string county = "london" , city = "london";
            string xString, yString;
            int  branchRad,branchX,branchY;
            branchRad = 5; //the radius of the customers location from the branch

            Random r = new Random();
            int mincX,maxcX,maxcY,mincY;
            string customerFName,customerLName,customerAddress,customerContact;
            for (int i = 0; i < numberOfCustomers;i++)
            {
                temp = new CustomerR();
                customerFName = "customer";
                customerLName = "Number" + (i+1);
                if (isCloseToAbranch)
                {
                    branchX = int.Parse(dbBranches[0].Branch_postcode.Remove(2));
                    branchY = int.Parse(dbBranches[0].Branch_postcode.Remove(0,3));
                    if (branchX - branchRad < 0)
                        mincX = 0;
                    else
                        mincX = branchX - branchRad;
                    if (branchX + branchRad > MaxX)
                        maxcX = MaxX;
                    else
                        maxcX = branchX + branchRad;
                    if (branchY - branchRad < 0)
                        mincY = 0;
                    else
                        mincY = branchY - branchRad;
                    if (branchY + branchRad > MaxY)
                        maxcY = MaxY;
                    else
                        maxcY = branchY + branchRad;

                    x = r.Next(mincX, maxcX);
                    y = r.Next(mincY, maxcY);
                }
                else
                {
                    x = r.Next(MinX, MaxX);
                    y = r.Next(MinY, MaxY);
                }
                if (x < 10)
                    xString = "0" + x.ToString();
                else
                    xString = x.ToString();
                if (y < 10)
                    yString = "0" + y.ToString();
                else
                    yString = y.ToString();
                
                customerContact = "07595946193";
                temp.AddressLine1 = customerFName + customerLName + " Address1";
                temp.AddressLine2 = customerFName + customerLName + " Address2";
                temp.City = city;
                temp.County = county;
                temp.Email = customerFName + customerLName + "@" + customerLName + ".co.uk";
                temp.FirstName = customerFName;
                temp.LastName = customerLName;
                temp.Postcode = xString + "," + yString; ;
                temp.Telephone = customerContact;
                temp.XCoordinate = x;
                temp.YCoordinate = y;
                customersR.Add(temp);
            }
            

        }
        public void insertCustomersR()
        {
            // this method inserts the randomly generated customers into the database
            
            sqlQuery = "";
            CustomerR temp = new CustomerR();
            for (int i = 0; i < customersR.Count; i++)
            {
                temp = customersR[i];
                sqlQuery += "INSERT INTO customer_for_performance_test "
                            +"(customer_firstName,customer_lastName,addressLine1 ,addressLine2 "
                            +",county ,city ,postcode ,email ,telephone ,xCoordinate ,yCoordinate)"
                            + " VALUES ('" + temp.FirstName + "','" + temp.LastName + "','" + temp.AddressLine1 + "','" +
                            temp.AddressLine2 + "','" + temp.County + "','" + temp.City + "','" + temp.Postcode 
                            + "','" + temp.Email + "','" + temp.Telephone + 
                            "','" + temp.XCoordinate + "','" + temp.YCoordinate + "');";

                
            }
            mycon.Open();
            mycommand = new SqlCommand(sqlQuery,mycon);
            mycommand.CommandText = sqlQuery;
            mycommand.ExecuteNonQuery();
            mycon.Close();

        }
        public void readDBOrders()
        {
            //this method reads the orders that are inserted into the database, this method is used for graph plotting
            order temp;
            sqlQuery = "SELECT * FROM orders";
            mycon.Open();
            mycommand = new SqlCommand(sqlQuery, mycon);
            mycommand.CommandText = sqlQuery;
            reader = mycommand.ExecuteReader();
            try
            {


                while (reader.Read())
                {
                    temp = new  order();
                    temp.Order_id = reader.GetInt32(0);
                    temp.Customer_id = reader.GetInt32(1);
 
                    dbOrders.Add(temp);
                }
            }
            finally
            {
                mycon.Close();
            }

        }
        public List<object[]> getJourneys()
        {
            // this method returns the journeys with their destinations for all the vehicles in the system, this method is used for graph plotting only
            List<object[]> result = new List<object[]>();
            object[] r;
            string journeyQuery;
            journey jtemp;
            
            SqlCommand command3;
            SqlDataReader dataReader3;
            journeyDestinations jdtemp;
            List<journey> journeyList = new List<journey>();
            List<journeyDestinations> jds;
            sqlQuery = "SELECT        journey.journey_id, journey.vehicle_id, journey.journey_date, journey.journey_startTime, journey.journey_finishTime, journey.journey_capacity,"+
                         "journey_destinations.destination_id, journey_destinations.destination_sequence, journey_destinations.duration_from_branch, "+
                         "journey_destinations.duration_from_last_stop, journey_destinations.postcode, journey_destinations.journey_id AS Expr1, journey_destinations.order_id "+
" FROM            journey INNER JOIN "+
                         "journey_destinations ON journey.journey_id = journey_destinations.journey_id "+
" ORDER BY journey.journey_id, journey_destinations.destination_sequence ";

            mycommand = new SqlCommand(sqlQuery, mycon);
            mycommand.CommandText = sqlQuery;
            mycon.Open();
            reader = mycommand.ExecuteReader();
            jds = new List<journeyDestinations>();
            while (reader.Read())
            {
                r = new object[2];
                jtemp = new journey();

                jtemp.JourneyId = reader.GetInt32(reader.GetOrdinal("journey_id"));
                jtemp.Vehicle_id = reader.GetInt32(reader.GetOrdinal("vehicle_id"));
                jtemp.Journey_date = reader.GetDateTime(reader.GetOrdinal("journey_date"));
                jtemp.Journey_startTime = reader.GetDateTime(reader.GetOrdinal("journey_startTime"));
                jtemp.Journey_finishTime = reader.GetDateTime(reader.GetOrdinal("journey_finishTime"));
                jtemp.Journey_capacity = reader.GetInt32(reader.GetOrdinal("journey_capacity"));
                journeyList.Add(jtemp);
              //  r[0] = jtemp;
                // step3 get journey destinations
                
                
                    //destination_id 	journey_id 	destination_sequence 	order_id 	duration_from_last_stop 	duration_from_branch 	postcode
                    jdtemp = new journeyDestinations();
                    jdtemp.DestinationId = reader.GetInt32(reader.GetOrdinal("destination_id"));
                    jdtemp.JourneyId = reader.GetInt32(reader.GetOrdinal("journey_id"));
                    jdtemp.Destination_sequence = reader.GetInt32(reader.GetOrdinal("destination_sequence"));
                    jdtemp.Order_id = reader.GetInt32(reader.GetOrdinal("order_id"));
                    jdtemp.Duration_from_last_stop = reader.GetInt32(reader.GetOrdinal("duration_from_last_stop"));
                    jdtemp.Duration_from_branch = reader.GetInt32(reader.GetOrdinal("duration_from_branch"));
                    jdtemp.Postcode = reader.GetString(reader.GetOrdinal("postcode"));
                    jds.Add(jdtemp);
                    
                
              //  r[1] = jds;
                
            }
            List<journeyDestinations> jdsList = new List<journeyDestinations>();
            foreach (var item in journeyList)
            {
                jdsList = new List<journeyDestinations>();
                foreach (var journeyDest in jds)
                {
                    if (item.JourneyId == journeyDest.JourneyId)
                        jdsList.Add(journeyDest);
                }
                result.Add(new object[]{item,jdsList} );
            }
            
            mycon.Close();

  
            
            return result;
        }
        public void readCustomers()
        {
            // this method reads the customers from the database 
            CustomerR temp;
            sqlQuery = "SELECT * FROM customer_for_performance_test";
            mycon.Open();
            mycommand = new SqlCommand(sqlQuery, mycon);
            mycommand.CommandText = sqlQuery;
            reader = mycommand.ExecuteReader();
            try
            {


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
                    temp.XCoordinate = reader.GetInt32(11);
                    temp.YCoordinate = reader.GetInt32(12);

                    customersR.Add(temp);
                }
            }
            finally
            {
                mycon.Close();
            }
 

        }
        public void randomBranches(int numberOfStores)
        {
           // this method will generate random branches with their information based on the number of stores
            // this is used for the performance monitor app
            Branch temp;
            
            int x, y, storeXCoordinates, storeYCoordinates;
            string  xString, yString;
            Random r = new Random();
            //1 x coordinates //2 y coordinates
            int[] store = new int[3];
            for (int i = 0; i < numberOfStores;i++)
            {
                temp = new Branch();
                temp.IsAvialable = true;

                x = r.Next(MinX, MaxX);
                y = r.Next(MinY, MaxY);
                if (x < 10)
                    xString = "0" + x.ToString();
                else
                    xString = x.ToString();
                if (y < 10)
                    yString = "0" + y.ToString();
                else
                    yString = y.ToString();

                temp.Branch_postcode = xString+","+yString;
                dbBranches.Add(temp);
                
            }      
        }
        public double calcDistance(int[] start, int[] finish)
        {
            //this method calculates the  distance on a x,y graph
            // distance = SquareRooT((x1-x2)power2 + (y1-y2)power2))
            double distance;
            distance =Math.Sqrt( Math.Pow((start[0] - finish[0]), 2) + Math.Pow((start[1] - finish[1]), 2));
            return distance;
        }
        public void readBranches()
        {
            //this method will read the branches from the database and all the information that is required to fill the
            // branch object
            string staffQuery;
            SqlCommand command2;
            SqlDataReader reader2;
            dbBranches = new List<Branch>();
            Branch temp;
            sqlQuery = "SELECT * FROM branch ";
            mycon.Open();
            mycommand = new SqlCommand(sqlQuery, mycon);
            mycommand.CommandText = sqlQuery;
            reader = mycommand.ExecuteReader();
            try
            {


                while (reader.Read())
                {
                    temp = new Branch();
                    temp.Branch_id = reader.GetInt32(0);
                    temp.Branch_postcode = reader.GetString(1);
                    temp.IsAvialable = "available" == reader.GetString(2).TrimEnd() ? true : false;
                    dbBranches.Add(temp);
                }
                reader.Close();
                foreach (Branch item in dbBranches)
                {
                    staffQuery = "select * from staff where branch_id = '"+item.Branch_id+"' and status = 'available' ";
                    command2 = mycon.CreateCommand();
                    command2.CommandText = staffQuery;
                    reader2 = command2.ExecuteReader();
                    item.NumberOfStaff = 0;
                    while (reader2.Read())
                    {
                        item.NumberOfStaff++;
                    }
                    reader2.Close();
                }
            }
            finally
            {
                mycon.Close();
            }
            
        }
        public int  insert_order(int customerId, string orderDate, string orderTime, string orderStatus, string order_processing_startTime, string order_processing_FinishTime)
        {
            // this method will insert a customer order into the database
            // and returns the order_id of the inserted order
            object orderId;
            Int32 ordId;
            sqlQuery = "INSERT INTO orders (customer_id ,order_date,order_time, order_status ,order_processing_startTime ,order_processing_FinishTime) VALUES ("
                           + "'" + customerId + "', '" + orderDate + "','" + orderTime + "','" + orderStatus + "','" + order_processing_startTime + "','" + order_processing_FinishTime + "') " + ";SELECT  @@IDENTITY AS NewID";
            
            try
            {

                mycon.Open();
                mycommand = new SqlCommand(sqlQuery, mycon);
                mycommand.CommandText = sqlQuery;
                orderId =  mycommand.ExecuteScalar();
                ordId = Convert.ToInt32(orderId);
                mycommand.CommandText = " SELECT SCOPE_IDENTITY()";
    
            }
            finally
            {
                mycon.Close();
            }

            return (int)ordId;

           
        }
        public void insert_orderLine(int orderId, int product_id, int quantity)
        {
            //this method will insert a particular order line for an order
            string query = "INSERT INTO orderLine (order_id ,	product_id, 	quantity)  VALUES ("
                           + "'" + orderId + "', '" + product_id + "','" + quantity + "') ";
            try
            {
                mycon.Open();
                mycommand = new SqlCommand(sqlQuery, mycon);
                mycommand.CommandText = query;
                mycommand.ExecuteNonQuery();
               
            }
            finally
            {
                mycon.Close();
            }
        }
        public void hardCodedOrdersForCustomers()
        {

        }
        public void create_orders_for_the_customers()       
         {
            //this method will create random orders for the customers, for every customer there is only one order
             DFOrder tempOrder;
            int randomQty,RandomproductId;
            Random r = new Random();
            int[] idAndQty ;
            
         foreach (CustomerR c in customersR)
         {

             tempOrder = new DFOrder();
             idAndQty = new int[2];
             randomQty = r.Next(5,10);
             RandomproductId = r.Next(1,3);
             tempOrder.customer_id = c.Customer_id;
             idAndQty[0] =RandomproductId;
             idAndQty[1] =randomQty;
             tempOrder.order.Add(idAndQty);
             queueOfOrders.Add(tempOrder);
             
         }
        }

        internal void serveOrders()
        {

      /*      
            if (TimedServiceDelay > 0)
            {

                itimer.Interval = TimedServiceDelay * 1000;
        itimer.AutoReset = true;
        itimer.Elapsed += new ElapsedEventHandler(onTimerEvent);
        isTimedService = true;
            }
            else
                isTimedService = false;
       */
//            if ((queueOfOrders.Count > 0))
            for (int i =0;i<queueOfOrders.Count;i++)
            {
//                findBestSolution(queueOfOrders[i]);
                findBestSolution(queueOfOrders[i]);
                nextorderIndex++;
               // queueOfOrders.Dequeue();
            //    if((!itimer.Enabled) && (isTimedService))
              //  itimer.Start();
                //GC.KeepAlive(itimer);

            }
            /*else
                if(isTimedService)
                itimer.Stop();
             */

        }

        internal  void onTimerEvent(object source, ElapsedEventArgs e)
        {
            serveOrders();
        }
        private void findBestSolution_DVR_BestFit(DFOrder order)
        {
            List<DFBranch> branchInfo = new List<DFBranch>();
            DFBranch branchTemp;
            List<DFVehicle> vehiclesInfo = new List<DFVehicle>();
            List<DFVehicle> vehicletemp;
            foreach (Branch b in dbBranches)
            {
                branchTemp = new DFBranch();
                // step1 get branch info
                branchTemp = getBranchInfo(b.Branch_id, order);
                if (branchTemp.IsAvailable && branchTemp.IsStaffAvailable
                    && branchTemp.EnoughStock)// if branch 
                {
                    branchInfo.Add(branchTemp);
                    //step2 get vehicles info NOTE U SHOULD CALC VEHICLE DISTANCE IN 
                    vehicletemp = new List<DFVehicle>();
                    vehicletemp = getVehicleInfo(b.Branch_id);
                    //add the branch vehicles to the vehicles list
                    foreach (DFVehicle v in vehicletemp)
                    {
                        vehiclesInfo.Add(v);
                    }
                }
            }
            // now after getting all the info, still the distance from a vehicle to the customer dpepending on its last
            //location before the customer (from branch or from another customer?) AND the time to delivere
            int brnchInd;
            int customerInd = getCustomerIndex(order.customer_id);
            int branchx;
            int branchy;
            List<int[]> vIdAndInsertionIndex = new List<int[]>();
            int[] vIdAndInsertionIndexTemp;
            List<int[]> PrevcustomersCo;
            int customerX = customersR[customerInd].XCoordinate;
            int customerY = customersR[customerInd].YCoordinate;
            int[] branchco = new int[2];
            int[] prevCustomerCo = new int[2];
            int[] customerco = { customerX, customerY };
            double branchdistance, vehicledistance;
            foreach (DFVehicle v in vehiclesInfo)
            {
                if (v.IsAvailable)
                {
                    //prevCustomerCo[0] = int.Parse(v.Jd[v.Jd.Count-1].Postcode.Remove(2));
                    //prevCustomerCo[1] = int.Parse(v.Jd[v.Jd.Count-1].Postcode.Remove(2));
                    //vehicledistance = calcDistance(customerco,prevCustomerCo);
                    brnchInd = getbranchIndex(v.BranchId);
                    branchx = int.Parse(dbBranches[brnchInd].Branch_postcode.Remove(2));
                    branchy = int.Parse(dbBranches[brnchInd].Branch_postcode.Remove(0, 3));
                    branchco[0] = branchx;
                    branchco[1] = branchy;
                    //branchdistance = calcDistance(customerco, branchco);
                    branchdistance = calcDistance(customerco, branchco);
                    if (v.HasJourney)
                    {
                        /**/
                        int[] temp = new int[3];
                        PrevcustomersCo = new List<int[]>();
                        temp = FindBestFit(v.Jd, customerco,v);
                        prevCustomerCo[0]=temp[0];
                        prevCustomerCo[1] = temp[1];
                        vIdAndInsertionIndexTemp = new int[2];
                        vIdAndInsertionIndexTemp[0] = v.VehicleId;
                        vIdAndInsertionIndexTemp[1] = temp[2];
                        vIdAndInsertionIndex.Add(vIdAndInsertionIndexTemp);

                        //prevCustomerCo[0] = int.Parse(v.Jd[(v.Jd.Count - 1)].Postcode.Remove(2));
                        //prevCustomerCo[1] = int.Parse(v.Jd[(v.Jd.Count - 1)].Postcode.Remove(0, 3));
                        vehicledistance = calcDistance(customerco, prevCustomerCo);
                        v.Distance_from_customer = vehicledistance;
                        v.TimeToDeliver = (int)Math.Ceiling(((v.Distance_from_customer * 1000 / vehicleAvgSpeed) * 60) + v.Jd[vIdAndInsertionIndexTemp[1]].Duration_from_branch);
                    }
                    else
                    {
                        v.Distance_from_customer = branchdistance;
                        v.TimeToDeliver = (int)Math.Ceiling((v.Distance_from_customer * 1000 / vehicleAvgSpeed) * 60);
                    }
                }
            }


            DFVehicle bestVehicle = findBestVehicle_DVR_BF(order, vehiclesInfo, branchInfo, vIdAndInsertionIndex);
            if (bestVehicle != null)
                placeOrder_DVR_BF(bestVehicle, order, branchInfo[getbranchIndex(bestVehicle.BranchId, branchInfo)], vIdAndInsertionIndex);
        }

        private void placeOrder_DVR_BF(DFVehicle bestVehicle, DFOrder order, DFBranch branchInfo, List<int[]> vIdAndInsertionIndex)
        {
            int journeyinsertionPoint=-1;
            if (bestVehicle.HasJourney)
            {
                int j = -1;
                for (int i = 0; i < vIdAndInsertionIndex.Count; i++)
                {
                    if (vIdAndInsertionIndex[i][0] == bestVehicle.VehicleId)
                        j = i;
                }
                journeyinsertionPoint = j;// insertAfter Point
            }

            //if (bestVehicle.HasJourney)
            //{
            //    int j = -1;
            //    for (int i = 0; i < vIdAndInsertionIndex.Count; i++)
            //    {
            //        if (vIdAndInsertionIndex[i][0] == bestVehicle.VehicleId)
            //            j = i;
            //    }
            //    journeyinsertionPoint = getVehicleIndex(vIdAndInsertionIndex[j][0]);
            //}
            int vehicledbBranchIndex = getbranchIndex(bestVehicle.BranchId);
            DateTime today = DateTime.Now;
            string strDate = today.Year + "-" + today.Month + "-" + today.Day;
            TimeSpan qTime = new TimeSpan(0, (int)branchInfo.QueueTime, 0);
            string orderTime = today.ToShortTimeString();
            DateTime orderStartTime = today.Add(qTime);
            TimeSpan orderProcessingTime = new TimeSpan(0, (int)calcOrderProcessingTime(order, vehicledbBranchIndex), 0);
            DateTime order_processing_FinishTime = orderStartTime.Add(orderProcessingTime);
            int orderId = insert_order(order.customer_id, strDate, today.ToShortTimeString()
                        , "placed", orderStartTime.ToShortTimeString(), order_processing_FinishTime.ToShortTimeString());

            int totalOrderSize = 0;
            foreach (int[] oLine in order.order)
            {
                //INSERT INTO orderLine (order_id ,	product_id, 	quantity) VALUES 
                insert_orderLine(orderId, oLine[0], oLine[1]);
                totalOrderSize += oLine[1];
            }
            updateStock(order, branchInfo);
            //journey and journeydestinations and order_servant
            assignTojourney_DVR_BF(bestVehicle, order, totalOrderSize, orderId, order_processing_FinishTime, branchInfo, journeyinsertionPoint);

        }

        private void assignTojourney_DVR_BF(DFVehicle bestVehicle, DFOrder order, int totalOrderSize, int orderId, DateTime order_processing_FinishTime, DFBranch branchInfo, int journeyinsertionPoint)
        {

            string orderServantQuery = "INSERT INTO order_servant (order_id,branch_id,vehicle_id) VALUES ('" + orderId + "','" + bestVehicle.BranchId + "','" + bestVehicle.VehicleId + "')";
            string journeyQuery, journey_destinationsQuery;
            int customerIndex = getCustomerIndex(order.customer_id);

            mycon.Open();


            mycommand = new SqlCommand(sqlQuery, mycon);
            mycommand.CommandText = orderServantQuery;
            mycommand.ExecuteNonQuery();
            TimeSpan TimeToDeliver = new TimeSpan(0, bestVehicle.TimeToDeliver, 0);

            if (bestVehicle.HasJourney)
            {
                if (bestVehicle.CanAddToCurrentJourney)
                {
                    //heeeeeeeeeeeeeeeeeeeeeeeeeeer need to rethink all of this
                    //1- calc time from new customer to the customer after (the one in the insertion (or b4?)
                    //3- calc time from prev location b4 the insertion to the new customer
                    // that will be duration from last stop,if insertion point is the first,this will be duration from branch as well,else add to it (duration from last stop)previous customer duration from branch to get this new customer
                    //duration from branch
                    //2- change that customer(that will be pushed) duration from branch and from last stop and sequence
                    // take away from the journey finishtime the time from the prev customer to the prevpoint
                    // add to the journey finish time the new added times to the new customer
                    
                    int brnchInd = getbranchIndex(bestVehicle.BranchId);
                    int branchx = int.Parse(dbBranches[brnchInd].Branch_postcode.Remove(2));
                    int branchy = int.Parse(dbBranches[brnchInd].Branch_postcode.Remove(0, 3));
                    int[] branchCo = new int[2];
                    int[] CustomerCo = new int[2];
                    CustomerCo[0] = customersR[customerIndex].XCoordinate;
                    CustomerCo[1] = customersR[customerIndex].YCoordinate;
                    branchCo[0] = branchx;
                    branchCo[1] = branchy;
                    int[] prevCustomerCo;
                    double distanceFromCustomerToPrevCustomer;
                    //if((journeyinsertionPoint+1) ==1 && bestVehicle.Jd.Count > 1)
                    if (journeyinsertionPoint+1 != 1 )
                    {
                        /* the pushed destination:
                         * duration from last stop = time from the new customer
                         * duration from branch = time from the new customer + new customer duration from branch
                         * new Destination:
                         * duration from last stop = duration from branch;
                         * get the difference between the removed edge and the newly added edges,then add this to all forth coming
                         * destinations for Duration from branch and will be added for journey finishTime,and update their sequence aswell
                         * 
                         */

                        prevCustomerCo = new int[2];
                        prevCustomerCo[0] = int.Parse(bestVehicle.Jd[(journeyinsertionPoint)].Postcode.Remove(2));
                        prevCustomerCo[1] = int.Parse(bestVehicle.Jd[(journeyinsertionPoint)].Postcode.Remove(0, 3));
                        int[] nextCCo = new int[2];
                        nextCCo[0] = int.Parse(bestVehicle.Jd[(journeyinsertionPoint+1)].Postcode.Remove(2));
                        nextCCo[1] = int.Parse(bestVehicle.Jd[(journeyinsertionPoint+1)].Postcode.Remove(0, 3));
                        distanceFromCustomerToPrevCustomer = calcDistance(prevCustomerCo,CustomerCo);
                        double prevCustomerFrombranch = calcDistance(branchCo, prevCustomerCo);
                        double newCustomerToNextCustomer = calcDistance(nextCCo, CustomerCo);
                        TimeSpan durationFromNewCustomerToNextCustomer = new TimeSpan(0,(int)((newCustomerToNextCustomer * 1000 / vehicleAvgSpeed) * 60),0);
                        TimeSpan prevCustomerDurationFromLastStop = new TimeSpan(0,bestVehicle.Jd[(journeyinsertionPoint)].Duration_from_last_stop,0);
                        TimeSpan newFromCustomerDurationToPrevCustomer = new TimeSpan(0, (int)((distanceFromCustomerToPrevCustomer * 1000 / vehicleAvgSpeed) * 60), 0);
                        TimeSpan prevCustomerTonextCustomer = new TimeSpan(0, bestVehicle.Jd[(journeyinsertionPoint)].Duration_from_last_stop , 0);
                        TimeSpan DifferenceBetweenpreviousRemovedEdgeandNewEdges =
                            new TimeSpan(0, newFromCustomerDurationToPrevCustomer.Minutes + newFromCustomerDurationToPrevCustomer.Minutes - prevCustomerTonextCustomer.Minutes, 0);
                        DateTime newJourneyFinishTime 
                            = bestVehicle.LastJourney.Journey_finishTime.Subtract(DifferenceBetweenpreviousRemovedEdgeandNewEdges);
                       
                        journeyQuery = "UPDATE journey SET journey_finishTime = '"
                            + newJourneyFinishTime.ToShortTimeString() + "', journey_capacity = journey_capacity+ '"+totalOrderSize+"' WHERE journey_id = '" + bestVehicle.LastJourney.JourneyId + "'";

                        mycommand.CommandText = journeyQuery;
                        mycommand.ExecuteNonQuery();
                        journey_destinationsQuery = "update journey_destinations SET duration_from_branch = duration_from_branch + '"
                            + DifferenceBetweenpreviousRemovedEdgeandNewEdges.Minutes
                            + "' WHERE journey_id = '" + bestVehicle.LastJourney.JourneyId + "' and destination_sequence > '"+(journeyinsertionPoint+1)+"'";
                        mycommand.CommandText = journey_destinationsQuery;
                        mycommand.ExecuteNonQuery();
                        journey_destinationsQuery = "update journey_destinations SET  destination_sequence =destination_sequence+1  WHERE journey_id = '"
                            + bestVehicle.LastJourney.JourneyId + "' and destination_sequence > '"+(journeyinsertionPoint+2)+"'";
                        mycommand.CommandText = journey_destinationsQuery;
                        mycommand.ExecuteNonQuery();
                        journey_destinationsQuery = "update journey_destinations SET  duration_from_last_stop = '" + durationFromNewCustomerToNextCustomer.Minutes + "'  WHERE journey_id = '"
                            + bestVehicle.LastJourney.JourneyId + "' and destination_sequence = '" + (journeyinsertionPoint+3) + "'";
                        mycommand.CommandText = journey_destinationsQuery;
                        mycommand.ExecuteNonQuery();

                        journey_destinationsQuery = "INSERT INTO journey_destinations (journey_id,destination_sequence,order_id ,duration_from_last_stop,duration_from_branch,postcode) VALUES " +
    "('" + bestVehicle.LastJourney.JourneyId + "','" + (journeyinsertionPoint + 2) + "','" + orderId + "','" + newFromCustomerDurationToPrevCustomer.Minutes + "','" + bestVehicle.TimeToDeliver + "','" + customersR[customerIndex].Postcode + "')";

                        mycommand.CommandText = journey_destinationsQuery;
                        mycommand.ExecuteNonQuery();

                    }
                    //else if ((journeyinsertionPoint+1) == bestVehicle.Jd[bestVehicle.Jd.Count - 1].Destination_sequence)
                    //{
                    //    int[] prevPrevCustomerCo = new int[2];
                    //    prevPrevCustomerCo[0]=int.Parse(bestVehicle.Jd[(journeyinsertionPoint-1)].Postcode.Remove(2));
                    //    prevPrevCustomerCo[1] = int.Parse(bestVehicle.Jd[(journeyinsertionPoint-1)].Postcode.Remove(0, 3));
                    //    prevCustomerCo = new int[2];
                    //    prevCustomerCo[0] = int.Parse(bestVehicle.Jd[(journeyinsertionPoint)].Postcode.Remove(2));
                    //    prevCustomerCo[1] = int.Parse(bestVehicle.Jd[(journeyinsertionPoint)].Postcode.Remove(0, 3));
                    //    distanceFromCustomerToPrevCustomer = calcDistance(prevCustomerCo, CustomerCo);
                    //    double distanceFromPrevPrevToPrev = calcDistance(prevPrevCustomerCo, CustomerCo);

                    //    TimeSpan prevCustomerDurationFromLastStop = new TimeSpan(0, bestVehicle.Jd[(journeyinsertionPoint)].Duration_from_last_stop, 0);
                    //    TimeSpan newCustomerDurationFromPrevPrev = new TimeSpan(0, (int)((distanceFromPrevPrevToPrev * 1000 / vehicleAvgSpeed) * 60), 0);
                    //    TimeSpan newFromCustomerDurationToPrevCustomer = new TimeSpan(0, (int)((distanceFromCustomerToPrevCustomer * 1000 / vehicleAvgSpeed) * 60), 0);
                    //    TimeSpan DifferenceBetweenpreviousRemovedEdgeandNewEdges =
                    //        new TimeSpan(0, newCustomerDurationFromPrevPrev.Minutes + newFromCustomerDurationToPrevCustomer.Minutes - prevCustomerDurationFromLastStop.Minutes, 0);
                    //    DateTime newJourneyFinishTime
                    //        = bestVehicle.LastJourney.Journey_startTime.Add(DifferenceBetweenpreviousRemovedEdgeandNewEdges);
                    //    journeyQuery = "UPDATE journey SET journey_finishTime = '"
                    //       + newJourneyFinishTime.ToShortTimeString() + "', journey_capacity = journey_capacity+ '" + totalOrderSize + "' WHERE journey_id = '" + bestVehicle.LastJourney.JourneyId + "'";

                    //    mycommand.CommandText = journeyQuery;
                    //    mycommand.ExecuteNonQuery();
                    //    journey_destinationsQuery = "update journey_destinations SET duration_from_branch = duration_from_branch + '"
                    //        + DifferenceBetweenpreviousRemovedEdgeandNewEdges.Minutes
                    //        + "' WHERE journey_id = '" + bestVehicle.LastJourney.JourneyId + "'";
                    //    mycommand.CommandText = journey_destinationsQuery;
                    //    mycommand.ExecuteNonQuery();
                    //    journey_destinationsQuery = "update journey_destinations SET  destination_sequence =destination_sequence+1  WHERE journey_id = '"
                    //        + bestVehicle.LastJourney.JourneyId + "' and destination_sequence >= '" + (journeyinsertionPoint + 1) + "'";
                    //    mycommand.CommandText = journey_destinationsQuery;
                    //    mycommand.ExecuteNonQuery();
                    //    journey_destinationsQuery = "update journey_destinations SET  duration_from_last_stop = '" + newFromCustomerDurationToPrevCustomer.Minutes + "'  WHERE journey_id = '"
                    //        + bestVehicle.LastJourney.JourneyId + "' and destination_sequence = '" + (journeyinsertionPoint + 1+1) + "'";
                    //    mycommand.CommandText = journey_destinationsQuery;
                    //    mycommand.ExecuteNonQuery();

                    //    //TimeSpan durationFromLastStop = TimeToDeliver.Subtract(durationFromBranchToPrevCustomer);
                    //    journey_destinationsQuery = "INSERT INTO journey_destinations (journey_id,destination_sequence,order_id ,duration_from_last_stop,duration_from_branch,postcode) VALUES " +
                    //        "('" + bestVehicle.LastJourney.JourneyId + "','" + (journeyinsertionPoint + 1) + "','" + orderId + "','" + newCustomerDurationFromPrevPrev.Minutes + "','" + bestVehicle.TimeToDeliver + "','" + customersR[customerIndex].Postcode + "')";

                    //    mycommand.CommandText = journey_destinationsQuery;
                    //    mycommand.ExecuteNonQuery();
                    //}
                    else
                    {
                         brnchInd = getbranchIndex(bestVehicle.BranchId);
                         branchx = int.Parse(dbBranches[brnchInd].Branch_postcode.Remove(2));
                         branchy = int.Parse(dbBranches[brnchInd].Branch_postcode.Remove(0, 3));
                        branchCo = new int[2];
                        branchCo[0] = branchx;
                        branchCo[1] = branchy;
                        prevCustomerCo = new int[2];
                        prevCustomerCo[0] = int.Parse(bestVehicle.Jd[(bestVehicle.Jd.Count - 1)].Postcode.Remove(2));
                        prevCustomerCo[1] = int.Parse(bestVehicle.Jd[(bestVehicle.Jd.Count - 1)].Postcode.Remove(0, 3));
                        double prevCustomerFrombranch = calcDistance(branchCo, prevCustomerCo);

                        TimeSpan durationFromBranchToPrevCustomer = new TimeSpan(0, (int)((prevCustomerFrombranch * 1000 / vehicleAvgSpeed) * 60), 0);

                        TimeSpan durationFromCustomerBackToBranch = new TimeSpan(0, (int)(branchInfo.DistanceToCustomer * 1000 / vehicleAvgSpeed * 60), 0);

                        TimeSpan newDurationForJourneyFinishTime = TimeToDeliver.Add(durationFromCustomerBackToBranch);
                        //newDurationForJourneyFinishTime = newDurationForJourneyFinishTime.Subtract(durationFromBranchToPrevCustomer);
                        DateTime journeyFinishTime = bestVehicle.LastJourney.Journey_startTime.Add(newDurationForJourneyFinishTime);
                        journeyQuery = "UPDATE  journey SET journey_finishTime= '" + journeyFinishTime.ToShortTimeString() + "',journey_capacity=journey_capacity + '" + totalOrderSize + "' '' WHERE journey_id ='" + bestVehicle.LastJourney.JourneyId + "' ";
                        /*
                         * $destSeq = $finalvehicles[$thefastest['carIndex']]['last_journey']['journey_destinations'][$destinationsLastIndex ]['destination_sequence'] + 1;
            $durationFromLastStop = $finalvehicles[$thefastest['carIndex']]['timeToDeliver']	-$finalvehicles[$thefastest['carIndex']]['journey_destinations'][$destinationsLastIndex ]['duration_from_branch'] ;
            $durationFromBranch = $finalvehicles[$thefastest['carIndex']]['timeToDeliver'];
            $postCode = $_SESSION['cpc'];
            $journeyDestQuery = "INSERT INTO journey_destinations (journey_id 	,destination_sequence 	
                                                ,order_id 	,duration_from_last_stop 	,duration_from_branch 	,postcode) VALUES ('".$jID."','".$destSeq."','".$orderId ."','".$durationFromLastStop ."','".$durationFromBranch ."','".$postCode ."')";
		
                         */
                        mycommand.CommandText = journeyQuery;
                        mycommand.ExecuteNonQuery();
                        int destinationSequence = bestVehicle.Jd[bestVehicle.Jd.Count - 1].Destination_sequence + 1;
                        TimeSpan durationFromLastStop = TimeToDeliver.Subtract(durationFromBranchToPrevCustomer);
                        journey_destinationsQuery = "INSERT INTO journey_destinations (journey_id,destination_sequence,order_id ,duration_from_last_stop,duration_from_branch,postcode) VALUES " +
                            "('" + bestVehicle.LastJourney.JourneyId + "','" + destinationSequence + "','" + orderId + "','" + durationFromLastStop.TotalMinutes + "','" + bestVehicle.TimeToDeliver + "','" + customersR[customerIndex].Postcode + "')";

                        mycommand.CommandText = journey_destinationsQuery;
                        mycommand.ExecuteNonQuery();
                    }
                    //nextCustomerCo[0] = int.Parse(bestVehicle.Jd[(bestVehicle.Jd[insertion - 1)].Postcode.Remove(2));
                    
                    

        //            TimeSpan durationFromBranchToPrevCustomer = new TimeSpan(0, (int)((prevCustomerFrombranch * 1000 / vehicleAvgSpeed) * 60), 0);

        //            TimeSpan durationFromCustomerBackToBranch = new TimeSpan(0, (int)(branchInfo.DistanceToCustomer * 1000 / vehicleAvgSpeed * 60), 0);

        //            TimeSpan newDurationForJourneyFinishTime = TimeToDeliver.Add(durationFromCustomerBackToBranch);
        //            //newDurationForJourneyFinishTime = newDurationForJourneyFinishTime.Subtract(durationFromBranchToPrevCustomer);
        //            DateTime journeyFinishTime = bestVehicle.LastJourney.Journey_startTime.Add(newDurationForJourneyFinishTime);
        //            journeyQuery = "UPDATE  journey SET journey_finishTime= '" + journeyFinishTime.ToShortTimeString() + "',journey_capacity=journey_capacity + '" + totalOrderSize + "' '' WHERE journey_id ='" + bestVehicle.LastJourney.JourneyId + "' ";
        //            /*
        //             * $destSeq = $finalvehicles[$thefastest['carIndex']]['last_journey']['journey_destinations'][$destinationsLastIndex ]['destination_sequence'] + 1;
        //$durationFromLastStop = $finalvehicles[$thefastest['carIndex']]['timeToDeliver']	-$finalvehicles[$thefastest['carIndex']]['journey_destinations'][$destinationsLastIndex ]['duration_from_branch'] ;
        //$durationFromBranch = $finalvehicles[$thefastest['carIndex']]['timeToDeliver'];
        //$postCode = $_SESSION['cpc'];
        //$journeyDestQuery = "INSERT INTO journey_destinations (journey_id 	,destination_sequence 	
        //                                    ,order_id 	,duration_from_last_stop 	,duration_from_branch 	,postcode) VALUES ('".$jID."','".$destSeq."','".$orderId ."','".$durationFromLastStop ."','".$durationFromBranch ."','".$postCode ."')";
		
        //             */
        //            mycommand.CommandText = journeyQuery;
        //            mycommand.ExecuteNonQuery();
        //            int destinationSequence = bestVehicle.Jd[bestVehicle.Jd.Count - 1].Destination_sequence + 1;
        //            TimeSpan durationFromLastStop = TimeToDeliver.Subtract(durationFromBranchToPrevCustomer);
        //            journey_destinationsQuery = "INSERT INTO journey_destinations (journey_id,destination_sequence,order_id ,duration_from_last_stop,duration_from_branch,postcode) VALUES " +
        //                "('" + bestVehicle.LastJourney.JourneyId + "','" + destinationSequence + "','" + orderId + "','" + durationFromLastStop.TotalMinutes + "','" + bestVehicle.TimeToDeliver + "','" + customersR[customerIndex].Postcode + "')";

        //            mycommand.CommandText = journey_destinationsQuery;
        //            mycommand.ExecuteNonQuery();
                }
                else
                {
                    TimeSpan orderWaitTimeMM = new TimeSpan(0, orderwaitTimeMM, 0);
                    TimeSpan journeyDuration = new TimeSpan(0, bestVehicle.TimeToDeliver * 2, 0);
                    TimeSpan DurationFromBranch = new TimeSpan(0, bestVehicle.TimeToDeliver, 0);
                    DateTime now = DateTime.Now;
                    DateTime journeyStartTime;
                    string strToday = now.Year + "-" + now.Month + "-" + now.Day;
                    journeyStartTime = order_processing_FinishTime.Add(orderWaitTimeMM);
                    //jst difference between orderReadyTime and journey finishTime, subtract this from orderWaitTime
                    //jst difference between orderReadyTime and journey finishTime, subtract this from orderWaitTime
                    if (bestVehicle.LastJourney.Journey_finishTime.CompareTo(order_processing_FinishTime) == 1)
                    {
                        TimeSpan diff = new TimeSpan(bestVehicle.LastJourney.Journey_finishTime.Hour - order_processing_FinishTime.Hour,
                                bestVehicle.LastJourney.Journey_finishTime.Minute - order_processing_FinishTime.Minute, 0);
                        if (diff.CompareTo(orderWaitTimeMM) == 1)
                        {
                            orderWaitTimeMM = orderWaitTimeMM.Subtract(diff);
                            journeyStartTime = bestVehicle.LastJourney.Journey_finishTime;
                        }
                        else
                            journeyStartTime = order_processing_FinishTime.Add(orderWaitTimeMM);
                    }
                    else
                        journeyStartTime = order_processing_FinishTime.Add(orderWaitTimeMM);

                    //DateTime journeyStartTime = order_processing_FinishTime.Add(orderWaitTimeMM);
                    DateTime journeyFinishTime = journeyStartTime.Add(journeyDuration);
                    journeyQuery = "INSERT INTO journey (vehicle_id,journey_date,journey_startTime,journey_finishTime ,journey_capacity)"
                    + "VALUES ('" + bestVehicle.VehicleId + "','" + strToday + "','" + journeyStartTime.ToShortTimeString() + "','"
                    + journeyFinishTime.ToShortTimeString() + "','" + totalOrderSize + "') ";
                    mycommand.CommandText = journeyQuery;
                    mycommand.ExecuteNonQuery();
                    mycommand.CommandText = " SELECT LAST_INSERT_ID()";
                    UInt32 journey_id = new UInt32();
                    journey_id = (UInt32)(Int64)mycommand.ExecuteScalar();
                    string journey_destinations_query = "INSERT INTO journey_destinations (journey_id ,destination_sequence,order_id ,duration_from_last_stop ,duration_from_branch ,postcode) VALUES "
                        + "('" + journey_id + "','" + "1" + "','" + orderId + "','" + DurationFromBranch.TotalMinutes + "','" +
                            DurationFromBranch.TotalMinutes + "','" + customersR[customerIndex].Postcode + "')";
                    mycommand.CommandText = journey_destinations_query;
                    mycommand.ExecuteNonQuery();

                }
            }
            else
            {


                TimeSpan orderWaitTimeMM = new TimeSpan(0, orderwaitTimeMM, 0);
                TimeSpan journeyDuration = new TimeSpan(0, bestVehicle.TimeToDeliver * 2, 0);
                TimeSpan DurationFromBranch = new TimeSpan(0, bestVehicle.TimeToDeliver, 0);
                DateTime now = DateTime.Now;
                string strToday = now.Year + "-" + now.Month + "-" + now.Day;
                DateTime journeyStartTime = order_processing_FinishTime.Add(orderWaitTimeMM);
                DateTime journeyFinishTime = journeyStartTime.Add(journeyDuration);
                journeyQuery = "INSERT INTO journey (vehicle_id,journey_date,journey_startTime,journey_finishTime ,journey_capacity)"
                + "VALUES ('" + bestVehicle.VehicleId + "','" + strToday + "','" + journeyStartTime.ToShortTimeString() + "','"
                + journeyFinishTime.ToShortTimeString() + "','" + totalOrderSize + "') ";
                mycommand.CommandText = journeyQuery;
                mycommand.ExecuteNonQuery();
                mycommand.CommandText = " SELECT LAST_INSERT_ID()";
                UInt32 journey_id = new UInt32();
                journey_id = (UInt32)(Int64)mycommand.ExecuteScalar();
                string journey_destinations_query = "INSERT INTO journey_destinations (journey_id ,destination_sequence,order_id ,duration_from_last_stop ,duration_from_branch ,postcode) VALUES "
                    + "('" + journey_id + "','" + "1" + "','" + orderId + "','" + DurationFromBranch.TotalMinutes + "','" +
                        DurationFromBranch.TotalMinutes + "','" + customersR[customerIndex].Postcode + "')";
                mycommand.CommandText = journey_destinations_query;
                mycommand.ExecuteNonQuery();
            }
            mycon.Close();
            
        }

        private DFVehicle findBestVehicle_DVR_BF(DFOrder order, List<DFVehicle> vehiclesInfo, List<DFBranch> branchInfo, List<int[]> vIdAndInsertionIndex)
        {
            List<DFVehicle> finalVehicles = new List<DFVehicle>();
            List<DFVehicle> finalVehiclesSecodOption = new List<DFVehicle>();//vehicles where order is > journy capacity or journey startTime< order readyTime
            List<DFVehicle> finalVehiclesThirdOption = new List<DFVehicle>();//vehicles where order is > vehicle capacity

            //step1 find vehicles that can delivere the order
            foreach (DFVehicle v in vehiclesInfo)
            {
                if (v.IsAvailable)
                {
                    if (!(orderSize(order) > v.Capacity))
                    {
                        v.IfEmptyCanContainOrder = true;
                        if (v.HasJourney)
                        {

                            // need to add if the eta2customer is > const max eta then dont add
                            if ((!(v.LastJourney.Journey_capacity + orderSize(order) > v.Capacity)) && (v.LastJourney.Journey_startTime.CompareTo(orderReadyTimeAtBranch(v.BranchId, order, branchInfo)) == 1))
                            {
                                finalVehicles.Add(v);
                                v.CanAddToCurrentJourney = true;

                            }
                            else
                            {
                                v.CanAddToCurrentJourney = false;
                                finalVehiclesSecodOption.Add(v);
                            }

                        }
                        else
                        {

                            finalVehicles.Add(v);

                        }
                    }
                    else
                    {
                        finalVehiclesThirdOption.Add(v);
                        v.IfEmptyCanContainOrder = false;
                    }
                }
            }
            //step2 find the best vehicle out of the vehicles that can delivere
            int fastestCarIndex = -1;
            TimeSpan ts;
            int minutesFromNow;
            int vehicledbBranchIndex;
            DateTime etaToCustomer, fastestETAToCustomer = DateTime.Now;
            int vehicleBranchIndex = -1;
            for (int i = 0; i < finalVehicles.Count; i++)
            {
                if (finalVehicles[i].HasJourney)
                {
                    etaToCustomer = finalVehicles[i].LastJourney.Journey_startTime;
                    minutesFromNow = finalVehicles[i].TimeToDeliver;
                    ts = new TimeSpan(0, minutesFromNow, 0);
                    etaToCustomer = etaToCustomer.Add(ts);
                    if ((i == 0) || (etaToCustomer.CompareTo(fastestETAToCustomer) == -1))
                    {
                        fastestETAToCustomer = etaToCustomer;
                        fastestCarIndex = i;
                    }
                }
                else
                {
                    vehicledbBranchIndex = getbranchIndex(finalVehicles[i].BranchId);
                    vehicleBranchIndex = getbranchIndex(finalVehicles[i].BranchId, branchInfo);
                    minutesFromNow = (int)branchInfo[vehicleBranchIndex].QueueTime + (int)calcOrderProcessingTime(order, vehicledbBranchIndex) + orderwaitTimeMM + finalVehicles[i].TimeToDeliver;
                    ts = new TimeSpan(0, minutesFromNow, 0);
                    etaToCustomer = DateTime.Now.Add(ts);
                    if ((i == 0) || (etaToCustomer.CompareTo(fastestETAToCustomer) == -1))
                    {
                        fastestETAToCustomer = etaToCustomer;
                        fastestCarIndex = i;
                    }

                }
            }
            if (fastestCarIndex > -1)
                return finalVehicles[fastestCarIndex];
            else
            {
                fastestCarIndex = -1;

                //fixxx redeclare eta to customer
                fastestETAToCustomer = DateTime.Now;
                vehicleBranchIndex = -1;
                for (int i = 0; i < finalVehiclesSecodOption.Count; i++)
                {
                    vehicledbBranchIndex = getbranchIndex(finalVehiclesSecodOption[i].BranchId);
                    vehicleBranchIndex = getbranchIndex(finalVehiclesSecodOption[i].BranchId, branchInfo);
                    etaToCustomer = finalVehiclesSecodOption[i].LastJourney.Journey_finishTime;
                    //fixxx it should be time from branch directly
                    finalVehiclesSecodOption[i].TimeToDeliver = (int)Math.Ceiling(branchInfo[vehicleBranchIndex].DistanceToCustomer * 1000 / vehicleAvgSpeed * 60);

                    minutesFromNow = finalVehiclesSecodOption[i].TimeToDeliver
                                 + (int)branchInfo[vehicleBranchIndex].QueueTime + (int)calcOrderProcessingTime(order, vehicledbBranchIndex) + orderwaitTimeMM;
                    ts = new TimeSpan(0, minutesFromNow, 0);
                    etaToCustomer = etaToCustomer.Add(ts);
                    if ((i == 0) || (etaToCustomer.CompareTo(fastestETAToCustomer) == -1))
                    {
                        fastestETAToCustomer = etaToCustomer;
                        fastestCarIndex = i;
                    }
                }

                if (fastestCarIndex > -1)
                    return finalVehiclesSecodOption[fastestCarIndex];
                else
                {
                    fastestCarIndex = -1;


                    fastestETAToCustomer = DateTime.Now;
                    vehicleBranchIndex = -1;
                    for (int i = 0; i < finalVehiclesThirdOption.Count; i++)
                    {
                        int avgSize;
                        //split the order then put it back to the queue
                        avgSize = getVehiclesAverageSize();
                        List<DFOrder> splittedOrder = new List<DFOrder>();
                        splittedOrder = splitOrder(order, avgSize);


                        foreach (DFOrder o in splittedOrder)
                        {
                            queueOfOrders.Add(o);
                        }

                    }
                    return null;
                }
            }
            
        }

        private int[] FindBestFit(List<journeyDestinations> list, int[] customerco,DFVehicle v)
        {
            //need to add MAXIMUM_LAST_JD_Delay_M as a constraint
           // int bIndex= getbranchIndex(v.BranchId);
            int[] jrnydCo= new int[2];// 3 is for the insertion point
            jrnydCo[0] = int.Parse(list[0].Postcode.Remove(2));
            jrnydCo[1] = int.Parse(list[0].Postcode.Remove(0, 3));
            //jrnydCo[2] = 0;
            int[] jrnydCoMin = new int[3];// 3 is for the insertion point
            jrnydCoMin[0] = int.Parse(list[list.Count-1].Postcode.Remove(2));
            jrnydCoMin[1] = int.Parse(list[list.Count - 1].Postcode.Remove(0, 3));
            jrnydCoMin[2] = list.Count-1;
            double shortestAllowedDistance = calcDistance(customerco, jrnydCoMin);
            double jdDistance;
            for (int i = 0; i < list.Count;i++ )
            {
                jrnydCo = new int[2];
                jrnydCo[0] = int.Parse(list[i].Postcode.Remove(2));
                jrnydCo[1] = int.Parse(list[i].Postcode.Remove(0, 3));
                
                jdDistance = calcDistance(customerco, jrnydCo);
                if (jdDistance < shortestAllowedDistance)
                {
                    shortestAllowedDistance = jdDistance;
                    jrnydCoMin[0] = int.Parse(list[i].Postcode.Remove(2));
                    jrnydCoMin[1] = int.Parse(list[i].Postcode.Remove(0, 3));
                    jrnydCoMin[2] = i;
                }

            }

            return jrnydCoMin;
        }

        private void findBestSolution(DFOrder order)
        {
            // CONTINUE COMMENTING FROM HEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEERE
             List<DFBranch> branchInfo = new List<DFBranch>();
             DFBranch branchTemp;
             List<DFVehicle> vehiclesInfo = new List<DFVehicle>();
             List<DFVehicle> vehicletemp;
            foreach(Branch b in dbBranches)
            {
                branchTemp = new DFBranch();
                // step1 get branch info
                branchTemp = getBranchInfo(b.Branch_id, order);
                if (branchTemp.IsAvailable && branchTemp.IsStaffAvailable 
                    && branchTemp.EnoughStock)
                    // if branch 
                {
                    branchInfo.Add(branchTemp);
                    //step2 get vehicles info NOTE U SHOULD CALC VEHICLE DISTANCE IN 
                    vehicletemp = new List<DFVehicle>();
                    vehicletemp = getVehicleInfo(b.Branch_id);
                    //add the branch vehicles to the vehicles list
                    foreach (DFVehicle v in vehicletemp)
                    {
                        vehiclesInfo.Add(v);
                    }
                }
            }
            // now after getting all the info, still the distance from a vehicle to the customer dpepending on its last
            //location before the customer (from branch or from another customer?) AND the time to delivere
            int brnchInd ;
            int customerInd = getCustomerIndex(order.customer_id);
            int branchx ;
            int branchy ;
            int customerX = customersR[customerInd].XCoordinate;
            int customerY = customersR[customerInd].YCoordinate;
            int[] branchco = new  int[2];
            int[] prevCustomerCo = new  int[2];
            int[] customerco = { customerX, customerY };
            double branchdistance,vehicledistance;
            foreach (DFVehicle v in vehiclesInfo)
            {
                if (v.IsAvailable)
                {
                    //prevCustomerCo[0] = int.Parse(v.Jd[v.Jd.Count-1].Postcode.Remove(2));
                    //prevCustomerCo[1] = int.Parse(v.Jd[v.Jd.Count-1].Postcode.Remove(2));
                    //vehicledistance = calcDistance(customerco,prevCustomerCo);
                    brnchInd = getbranchIndex(v.BranchId);
                    branchx = int.Parse(dbBranches[brnchInd].Branch_postcode.Remove(2));
                    branchy = int.Parse(dbBranches[brnchInd].Branch_postcode.Remove(0, 3));
                    branchco[0] = branchx;
                    branchco[1] = branchy;
                    branchdistance = calcDistance(customerco, branchco);
                    if (v.HasJourney)
                    {
                        /**/
                        prevCustomerCo[0] = int.Parse(v.Jd[(v.Jd.Count - 1)].Postcode.Remove(2));
                        prevCustomerCo[1] = int.Parse(v.Jd[(v.Jd.Count - 1)].Postcode.Remove(0, 3));
                        vehicledistance = calcDistance(customerco, prevCustomerCo);
                        v.Distance_from_customer = vehicledistance;
                        v.TimeToDeliver = (int)Math.Ceiling(((v.Distance_from_customer * 1000 / vehicleAvgSpeed) * 60) + v.Jd[v.Jd.Count - 1].Duration_from_branch);
                    }
                    else
                    {
                        v.Distance_from_customer = branchdistance;
                        v.TimeToDeliver = (int)Math.Ceiling((v.Distance_from_customer * 1000 / vehicleAvgSpeed) * 60);
                    }
                }
            }


           DFVehicle bestVehicle =  findBestVehicle(order, vehiclesInfo,branchInfo);
            if(bestVehicle!=null)
                placeOrder(bestVehicle, order, branchInfo[getbranchIndex(bestVehicle.BranchId, branchInfo)]);
        }

        private void placeOrder(DFVehicle bestVehicle, DFOrder order,DFBranch branchInfo)
        {
            int vehicledbBranchIndex = getbranchIndex(bestVehicle.BranchId);
            DateTime today = DateTime.Now;
            string strDate = today.Year + "-" + today.Month + "-" + today.Day;
            TimeSpan qTime = new TimeSpan(0,(int) branchInfo.QueueTime,0);
            string orderTime = today.ToShortTimeString();
            DateTime  orderStartTime= today.Add(qTime);
            TimeSpan orderProcessingTime = new TimeSpan(0, (int)calcOrderProcessingTime(order, vehicledbBranchIndex), 0);
            DateTime order_processing_FinishTime = orderStartTime.Add(orderProcessingTime);
            int orderId = insert_order(order.customer_id, strDate, today.ToShortTimeString()
                        ,"placed",orderStartTime.ToShortTimeString(),order_processing_FinishTime.ToShortTimeString());
            
            int totalOrderSize = 0;
            foreach (int[] oLine in order.order)
            {
                //INSERT INTO orderLine (order_id ,	product_id, 	quantity) VALUES 
                insert_orderLine(orderId,oLine[0],oLine[1]);
                totalOrderSize+=oLine[1];
            }
            updateStock(order, branchInfo);
            //journey and journeydestinations and order_servant
            assignTojourney(bestVehicle, order, totalOrderSize, orderId, order_processing_FinishTime, branchInfo);

        }

        private void updateStock(DFOrder order, DFBranch branchInfo)
        {
            int olSize;
            int rawId=-1;
            try
            {
                foreach (int[] ol in order.order)
                {
                    sqlQuery = "SELECT raw_id FROM products where product_id='" + ol[0] + "'";
                    mycon.Open();
                    mycommand = new SqlCommand(sqlQuery, mycon);
                    mycommand.CommandText = sqlQuery;
                    reader = mycommand.ExecuteReader();
                    while (reader.Read())
                    {
                        rawId = reader.GetInt32(0);
                    }
                    reader.Close();
                    sqlQuery = "update  raw_stock set stock_level = stock_level -" + ol[1] + " where branch_id = '" + branchInfo.Branch_id + "' and raw_id ='" + rawId + "' ";
                    mycommand = new SqlCommand(sqlQuery, mycon);
                    mycommand.CommandText = sqlQuery;
                    mycommand.ExecuteNonQuery();
                }
            }
            finally
            { 
                mycon.Close();
            }
        }

        private void assignTojourney(DFVehicle bestVehicle, DFOrder order, int totalOrderSize, int orderId, DateTime order_processing_FinishTime, DFBranch branchInfo)
        {
            string orderServantQuery = "INSERT INTO order_servant (order_id,branch_id,vehicle_id) VALUES ('"+orderId+"','"+bestVehicle.BranchId+"','"+bestVehicle.VehicleId+"')";
            string journeyQuery, journey_destinationsQuery;
            int customerIndex= getCustomerIndex(order.customer_id);
            
            mycon.Open();
            

                mycommand = new SqlCommand(sqlQuery, mycon);
                mycommand.CommandText = orderServantQuery;                
                mycommand.ExecuteNonQuery();
            TimeSpan TimeToDeliver = new TimeSpan(0, bestVehicle.TimeToDeliver, 0);

            if (bestVehicle.HasJourney)
            {
                if (bestVehicle.CanAddToCurrentJourney)
                {   
                        int brnchInd = getbranchIndex(bestVehicle.BranchId);
                        int branchx = int.Parse(dbBranches[brnchInd].Branch_postcode.Remove(2));
                        int branchy = int.Parse(dbBranches[brnchInd].Branch_postcode.Remove(0,3));
                    int[] branchCo = new int[2];
                    branchCo[0] = branchx;
                    branchCo[1] = branchy;
                    int[] prevCustomerCo = new int[2];
                    prevCustomerCo[0] = int.Parse(bestVehicle.Jd[(bestVehicle.Jd.Count-1)].Postcode.Remove(2));
                    prevCustomerCo[1] = int.Parse(bestVehicle.Jd[(bestVehicle.Jd.Count-1)].Postcode.Remove(0,3));
                    double prevCustomerFrombranch = calcDistance(branchCo,prevCustomerCo);

                    TimeSpan durationFromBranchToPrevCustomer = new TimeSpan(0, (int)((prevCustomerFrombranch * 1000 / vehicleAvgSpeed)*60), 0);

                    TimeSpan durationFromCustomerBackToBranch = new TimeSpan(0, (int)(branchInfo.DistanceToCustomer*1000/vehicleAvgSpeed*60), 0);

                    TimeSpan newDurationForJourneyFinishTime = TimeToDeliver.Add(durationFromCustomerBackToBranch);
                    //newDurationForJourneyFinishTime = newDurationForJourneyFinishTime.Subtract(durationFromBranchToPrevCustomer);
                    DateTime journeyFinishTime = bestVehicle.LastJourney.Journey_startTime.Add(newDurationForJourneyFinishTime);
                    journeyQuery = "UPDATE  journey SET journey_finishTime= '" + journeyFinishTime.ToShortTimeString() + "',journey_capacity=journey_capacity + '" + totalOrderSize + "'  WHERE journey_id ='" + bestVehicle.LastJourney.JourneyId + "' ";
                    /*
                     * $destSeq = $finalvehicles[$thefastest['carIndex']]['last_journey']['journey_destinations'][$destinationsLastIndex ]['destination_sequence'] + 1;
		$durationFromLastStop = $finalvehicles[$thefastest['carIndex']]['timeToDeliver']	-$finalvehicles[$thefastest['carIndex']]['journey_destinations'][$destinationsLastIndex ]['duration_from_branch'] ;
		$durationFromBranch = $finalvehicles[$thefastest['carIndex']]['timeToDeliver'];
		$postCode = $_SESSION['cpc'];
		$journeyDestQuery = "INSERT INTO journey_destinations (journey_id 	,destination_sequence 	
											,order_id 	,duration_from_last_stop 	,duration_from_branch 	,postcode) VALUES ('".$jID."','".$destSeq."','".$orderId ."','".$durationFromLastStop ."','".$durationFromBranch ."','".$postCode ."')";
		
                     */
                    mycommand.CommandText = journeyQuery;
                    mycommand.ExecuteNonQuery();
                    int destinationSequence = bestVehicle.Jd[bestVehicle.Jd.Count - 1].Destination_sequence + 1;
                    TimeSpan durationFromLastStop = TimeToDeliver.Subtract(durationFromBranchToPrevCustomer);
                    journey_destinationsQuery = "INSERT INTO journey_destinations (journey_id,destination_sequence,order_id ,duration_from_last_stop,duration_from_branch,postcode) VALUES " +
                        "('" + bestVehicle.LastJourney.JourneyId + "','" + destinationSequence + "','" + orderId + "','" + durationFromLastStop.TotalMinutes + "','" + bestVehicle.TimeToDeliver + "','" + customersR[customerIndex].Postcode + "')";

                    mycommand.CommandText = journey_destinationsQuery;
                    mycommand.ExecuteNonQuery();
                }
                else
                {
                TimeSpan orderWaitTimeMM = new TimeSpan(0, orderwaitTimeMM, 0);
                TimeSpan journeyDuration = new TimeSpan(0, bestVehicle.TimeToDeliver * 2, 0);
                TimeSpan DurationFromBranch = new TimeSpan(0, bestVehicle.TimeToDeliver, 0);
                DateTime now = DateTime.Now;
                DateTime journeyStartTime;
                string strToday = now.Year + "-" + now.Month + "-" + now.Day;
                journeyStartTime = order_processing_FinishTime.Add(orderWaitTimeMM);
                    //jst difference between orderReadyTime and journey finishTime, subtract this from orderWaitTime
                //jst difference between orderReadyTime and journey finishTime, subtract this from orderWaitTime
                if (bestVehicle.LastJourney.Journey_finishTime.CompareTo(order_processing_FinishTime) == 1)
                {
                    TimeSpan diff = new TimeSpan(bestVehicle.LastJourney.Journey_finishTime.Hour - order_processing_FinishTime.Hour,
                            bestVehicle.LastJourney.Journey_finishTime.Minute - order_processing_FinishTime.Minute, 0);
                    if (diff.CompareTo(orderWaitTimeMM) == 1)
                    {
                        orderWaitTimeMM = orderWaitTimeMM.Subtract(diff);
                        journeyStartTime = bestVehicle.LastJourney.Journey_finishTime;
                    }
                    else
                        journeyStartTime = order_processing_FinishTime.Add(orderWaitTimeMM);
}
else
    journeyStartTime = order_processing_FinishTime.Add(orderWaitTimeMM);

                //DateTime journeyStartTime = order_processing_FinishTime.Add(orderWaitTimeMM);
                DateTime journeyFinishTime = journeyStartTime.Add(journeyDuration);
                journeyQuery = "INSERT INTO journey (vehicle_id,journey_date,journey_startTime,journey_finishTime ,journey_capacity)"
                + "VALUES ('" + bestVehicle.VehicleId + "','" + strToday + "','" + journeyStartTime.ToShortTimeString() + "','"
                + journeyFinishTime.ToShortTimeString() + "','" + totalOrderSize + "') "+" SELECT @@IDENTITY";
                mycommand.CommandText = journeyQuery;
                object jonyId;
                Int32 journey_id = new Int32();
                jonyId = mycommand.ExecuteScalar();
                journey_id = Convert.ToInt32(jonyId);
                string journey_destinations_query = "INSERT INTO journey_destinations (journey_id ,destination_sequence,order_id ,duration_from_last_stop ,duration_from_branch ,postcode) VALUES "
                    + "('" + journey_id + "','" + "1" + "','" + orderId + "','" + DurationFromBranch.TotalMinutes + "','" +
                        DurationFromBranch.TotalMinutes + "','" + customersR[customerIndex].Postcode + "')";
                mycommand.CommandText = journey_destinations_query;
                mycommand.ExecuteNonQuery();

                }
            }
            else
            {


                TimeSpan orderWaitTimeMM = new TimeSpan(0, orderwaitTimeMM, 0);
                TimeSpan journeyDuration = new TimeSpan(0, bestVehicle.TimeToDeliver * 2, 0);
                TimeSpan DurationFromBranch = new TimeSpan(0, bestVehicle.TimeToDeliver, 0);
                DateTime now = DateTime.Now;
                string strToday = now.Year + "-" + now.Month + "-" + now.Day;
                DateTime journeyStartTime = order_processing_FinishTime.Add(orderWaitTimeMM);
                DateTime journeyFinishTime = journeyStartTime.Add(journeyDuration);
                journeyQuery = "INSERT INTO journey (vehicle_id,journey_date,journey_startTime,journey_finishTime ,journey_capacity)"
                + "VALUES ('" + bestVehicle.VehicleId + "','" + strToday + "','" + journeyStartTime.ToShortTimeString() + "','"
                + journeyFinishTime.ToShortTimeString() + "','" + totalOrderSize + "') " + " SELECT @@Identity";
                mycommand.CommandText = journeyQuery;
             //   mycommand.ExecuteNonQuery();
               // mycommand.CommandText = " SELECT LAST_INSERT_ID()";
                object jid = mycommand.ExecuteScalar();
                Int32 journey_id = new Int32();
                journey_id = Convert.ToInt32(jid);
                string journey_destinations_query = "INSERT INTO journey_destinations (journey_id ,destination_sequence,order_id ,duration_from_last_stop ,duration_from_branch ,postcode) VALUES "
                    + "('" + journey_id + "','" + "1" + "','" + orderId + "','" + DurationFromBranch.TotalMinutes + "','" +
                        DurationFromBranch.TotalMinutes + "','" + customersR[customerIndex].Postcode + "')";
                mycommand.CommandText = journey_destinations_query;
                mycommand.ExecuteNonQuery();
            }
            mycon.Close();
            
        }

        private DFVehicle findBestVehicle(DFOrder order, List<DFVehicle> vehiclesInfo, List<DFBranch> branchInfo)
        {
            List<DFVehicle> finalVehicles = new List<DFVehicle>();
            List<DFVehicle> finalVehiclesSecodOption = new List<DFVehicle>();//vehicles where order is > journy capacity or journey startTime< order readyTime
            List<DFVehicle> finalVehiclesThirdOption = new List<DFVehicle>();//vehicles where order is > vehicle capacity

            //step1 find vehicles that can delivere the order
            foreach (DFVehicle v in vehiclesInfo)
            {
                if(v.IsAvailable)
                {
                if (!(orderSize(order) > v.Capacity))
                {
                    v.IfEmptyCanContainOrder = true;
                    if (v.HasJourney)
                    {
                        
                        
                        
                        // need to add if the eta2customer is > const max eta then dont add
                        if ((!(v.LastJourney.Journey_capacity + orderSize(order) > v.Capacity)) && (v.LastJourney.Journey_startTime.CompareTo(orderReadyTimeAtBranch(v.BranchId, order, branchInfo)) == -1)
                            &&(v.TimeToDeliver < maxjourneyDestinationTimeM))
                        {
                            finalVehicles.Add(v);
                            v.CanAddToCurrentJourney = true;

                        }
                        else
                        {
                            v.CanAddToCurrentJourney = false;
                            finalVehiclesSecodOption.Add(v);
                        }

                    }
                    else
                    {

                        finalVehicles.Add(v);

                    }
                }
                else
                {
                    finalVehiclesThirdOption.Add(v);
                    v.IfEmptyCanContainOrder = false;
                }
            }
            }
            //step2 find the best vehicle out of the vehicles that can delivere
            int fastestCarIndex = -1;
            TimeSpan ts;
            int minutesFromNow;
            int vehicledbBranchIndex;
            DateTime etaToCustomer,fastestETAToCustomer = DateTime.Now;
            int vehicleBranchIndex = -1;
            for (int i = 0; i < finalVehicles.Count; i++)
            {
                if (finalVehicles[i].HasJourney)
                {
                    etaToCustomer = finalVehicles[i].LastJourney.Journey_startTime;
                    minutesFromNow = finalVehicles[i].TimeToDeliver;
                    ts = new TimeSpan(0, minutesFromNow, 0);
                    etaToCustomer = etaToCustomer.Add(ts);
                    if ((i == 0) || (etaToCustomer.CompareTo(fastestETAToCustomer) == -1))
                    {  
                        fastestETAToCustomer = etaToCustomer;
                        fastestCarIndex = i;
                    }
                }
                else
                {
                    vehicledbBranchIndex= getbranchIndex(finalVehicles[i].BranchId);
                    vehicleBranchIndex = getbranchIndex(finalVehicles[i].BranchId,branchInfo);
                    minutesFromNow = (int)branchInfo[vehicleBranchIndex].QueueTime + (int)calcOrderProcessingTime(order, vehicledbBranchIndex) + orderwaitTimeMM + finalVehicles[i].TimeToDeliver;
                    ts = new TimeSpan(0, minutesFromNow, 0);
                    etaToCustomer = DateTime.Now.Add(ts);
                    if ((i == 0) || (etaToCustomer.CompareTo(fastestETAToCustomer) == -1))
                    {
                        fastestETAToCustomer = etaToCustomer;
                        fastestCarIndex = i;
                    }

                }
            }
                if (fastestCarIndex > -1)
            return finalVehicles[fastestCarIndex];
                else
                {
                     fastestCarIndex = -1;
                    
                    //fixxx redeclare eta to customer
                    fastestETAToCustomer = DateTime.Now;
                    vehicleBranchIndex = -1;
                    for (int i = 0; i < finalVehiclesSecodOption.Count; i++)
                    {
                        vehicledbBranchIndex = getbranchIndex(finalVehiclesSecodOption[i].BranchId);
                        vehicleBranchIndex=getbranchIndex(finalVehiclesSecodOption[i].BranchId,branchInfo);              
                            etaToCustomer = finalVehiclesSecodOption[i].LastJourney.Journey_finishTime;
                        //fixxx it should be time from branch directly
                            finalVehiclesSecodOption[i].TimeToDeliver = (int) Math.Ceiling(branchInfo[vehicleBranchIndex].DistanceToCustomer*1000/vehicleAvgSpeed*60);

                            minutesFromNow = finalVehiclesSecodOption[i].TimeToDeliver
                                         + (int)branchInfo[vehicleBranchIndex].QueueTime + (int)calcOrderProcessingTime(order, vehicledbBranchIndex) + orderwaitTimeMM;
                            ts = new TimeSpan(0, minutesFromNow, 0);
                            etaToCustomer = etaToCustomer.Add(ts);
                            if ((i == 0) || (etaToCustomer.CompareTo(fastestETAToCustomer) == -1))
                            {
                                fastestETAToCustomer = etaToCustomer;
                                fastestCarIndex = i;
                            }                                                                  
                    }

                  if (fastestCarIndex > -1)
                      return finalVehiclesSecodOption[fastestCarIndex];
                  else
                  {
                      fastestCarIndex = -1;


                      fastestETAToCustomer = DateTime.Now;
                      vehicleBranchIndex = -1;
                      //this is wrong !! take of the looop LOOOOOOOOOOOOOOOOOP
                      for (int i = 0; i < finalVehiclesThirdOption.Count; i++)
                      {
                          int avgSize;
                          //split the order then put it back to the queue
                          avgSize= getVehiclesAverageSize();
                          List<DFOrder> splittedOrder = new List<DFOrder>();
                          splittedOrder = splitOrder(order, avgSize);
                          
                          
                          foreach (DFOrder o in splittedOrder)
                          {
                              queueOfOrders.Add(o);
                          }

                      }
                      return null;
                  }
                }
            

        }

        private List<DFOrder> splitOrder(DFOrder order, int targetSize)
        {
            List<DFOrder> splittedOrderList = new List<DFOrder>();
            DFOrder singlesplit ;
            int[] singloLine;
            int orderLsize;
            foreach (int[] ol in order.order)
            {
                
                orderLsize = ol[1];
                while (orderLsize > 0)
                {
                    if(( orderLsize - targetSize >0))
                    {
                    singloLine=new int[2];
                    singlesplit = new DFOrder();
                    singlesplit.customer_id = order.customer_id;
                    singloLine[0] = ol[0];
                    singloLine[1] = targetSize;
                    singlesplit.order.Add(singloLine);
                    splittedOrderList.Add(singlesplit);
                    orderLsize -= targetSize;
                    }
                    else if (orderLsize > 0)
                    {
                                            singloLine=new int[2];
                    singlesplit = new DFOrder();
                    singlesplit.customer_id = order.customer_id;
                    singloLine[0] = ol[0];
                    singloLine[1] = orderLsize;
                    orderLsize =0;
                    singlesplit.order.Add(singloLine);
                    splittedOrderList.Add(singlesplit);
                    }

                }
            }
            return splittedOrderList;


        }

        private int getVehiclesAverageSize()
        {
            int avg=0;
            foreach (Vehicle v in dbVehicles)
            {
                avg+=v.Capacity;
            }
            avg = avg / dbVehicles.Count;
            return avg;
        }

        private DateTime orderReadyTimeAtBranch(int branchId, DFOrder order, List<DFBranch> branchInfo)
        {
            int vehicledbBranchIndex = getbranchIndex(branchId);
            int vehicleBinfoIndex = getbranchIndex(branchId, branchInfo);
            DateTime orderReadyTime = DateTime.Now;
            TimeSpan queueAndOrderProcessingSpan = new TimeSpan(0, ((int)calcOrderProcessingTime(order, vehicledbBranchIndex) + (int)branchInfo[vehicleBinfoIndex].QueueTime), 0);
            orderReadyTime = DateTime.Now.Add(queueAndOrderProcessingSpan);
            return orderReadyTime;

        }

        private int orderSize(DFOrder order)
        {
            int size = 0;
            foreach (int[] line in order.order)
            {
                size += line[1];
            }
            return size;
        }

        private List<DFVehicle> getVehicleInfo(int branchId)
        {
            List<DFVehicle> branchvehicles = new  List<DFVehicle>();
            DFVehicle tempvehicle;
            
            SqlCommand command2;
            SqlDataReader dataReader2;
                        SqlCommand command3;
            SqlDataReader dataReader3;
            journeyDestinations jdtemp;
            sqlQuery = "SELECT * FROM fleet WHERE branch_id = '" + branchId + "' and status= 'available'"; //get all vehicles for  branch
                    
            mycon.Open();
            mycommand = new SqlCommand(sqlQuery, mycon);
            mycommand.CommandText = sqlQuery;
            reader = mycommand.ExecuteReader();
            try
            {


                while (reader.Read())
                {
                    tempvehicle = new DFVehicle();
                    // step1  read vehicle id,branch id , and capacity
                    tempvehicle.VehicleId = reader.GetInt32(0);
                    tempvehicle.BranchId = reader.GetInt32(1);
                    tempvehicle.Capacity = reader.GetInt32(2);
                    string isavailable = reader.GetString(3).TrimEnd();
                    if (isavailable.TrimEnd() .TrimEnd()  == "available")
                        tempvehicle.IsAvailable = true;
                    else
                        tempvehicle.IsAvailable = false;

                    branchvehicles.Add(tempvehicle);
                    
                    
                }
                string idVehicles = "";
                //step 2 get the most recent journey for the vehicle
                foreach (var item in branchvehicles)
                {
                    if(item.IsAvailable)
                    idVehicles += item.VehicleId + " or vehicle_id= ";

                }
                idVehicles = idVehicles.Remove(idVehicles.LastIndexOf("or vehicle_id="), "or vehicle_id=".Length);
                reader.Close();
                if (true)
                {
                    DateTime today = DateTime.Now;
                    string strTiemNow = today.Hour + ":" + today.Minute + ":" + today.Second;
                    string strToday = today.Year + "-" + today.Month + "-" + today.Day;
                    string journeyQuery = "SELECT * FROM journey where vehicle_id = '" + idVehicles + "' and journey_date = '" + strToday + "' and journey_finishTime > '" + strTiemNow + "' and journey_startTime = (SELECT MAX(journey_startTime) FROM journey)";
                    command2 = new SqlCommand(journeyQuery, mycon);
                    //   command2.CommandText = journeyQuery;
                    dataReader2 = command2.ExecuteReader();
                    List<journey> jrnyList = new List<journey>();
                    string jrnysIDs = "";
                    if (dataReader2.HasRows)
                    {
                        while (dataReader2.Read())
                        {
                            if (!(dataReader2.IsDBNull(0)))
                            {
                                
                               // item.HasJourney = true;
                                journey jrny = new journey();
                                jrny.JourneyId = dataReader2.GetInt32(0);
                                jrny.Vehicle_id = dataReader2.GetInt32(1);
                                jrny.Journey_date = dataReader2.GetDateTime(2);
                                jrny.Journey_startTime = dataReader2.GetDateTime(3);
                                jrny.Journey_finishTime = dataReader2.GetDateTime(4);
                                jrny.Journey_capacity = dataReader2.GetInt32(5);
                                jrnyList.Add(jrny);

                                jrnysIDs += jrny.JourneyId+" or journey_id = ";
                               
                            }
                            

                        }
                        jrnysIDs = jrnysIDs.Remove(jrnysIDs.LastIndexOf("or journey_id ="), "or journey_id =".Length);
                        dataReader2.Close();
                        //put journeys into vehicles
                        foreach (var jrny in jrnyList)
                        {

                            foreach (var vehicle in branchvehicles)
                        {
                            if (jrny.Vehicle_id == vehicle.VehicleId)
                            {
                                vehicle.LastJourney = jrny;
                                vehicle.HasJourney = true;
                            }
                            
                        }
                        }


                        string journeyDestinationsQuery = "SELECT * FROM journey_destinations WHERE journey_id = '" + jrnysIDs + "' order by destination_sequence";
                        command3 = mycon.CreateCommand();
                        command3.CommandText = journeyDestinationsQuery;
                        dataReader3 = command3.ExecuteReader();
                        // step3 get journey destinations
                        List<journeyDestinations> jdsList = new List<journeyDestinations>();
                        while (dataReader3.Read())
                        {
                            //destination_id 	journey_id 	destination_sequence 	order_id 	duration_from_last_stop 	duration_from_branch 	postcode
                            jdtemp = new journeyDestinations();
                            jdtemp.DestinationId = dataReader3.GetInt32(dataReader3.GetOrdinal("destination_id"));
                            jdtemp.JourneyId = dataReader3.GetInt32(dataReader3.GetOrdinal("journey_id"));
                            jdtemp.Destination_sequence = dataReader3.GetInt32(dataReader3.GetOrdinal("destination_sequence"));
                            jdtemp.Order_id = dataReader3.GetInt32(dataReader3.GetOrdinal("order_id"));
                            jdtemp.Duration_from_last_stop = dataReader3.GetInt32(dataReader3.GetOrdinal("duration_from_last_stop"));
                            jdtemp.Duration_from_branch = dataReader3.GetInt32(dataReader3.GetOrdinal("duration_from_branch"));
                            jdtemp.Postcode = dataReader3.GetString(dataReader3.GetOrdinal("postcode"));
                            jdsList.Add(jdtemp);
                        }
                        foreach (var item in branchvehicles)
                        {
                            if(item.HasJourney)
                            foreach (var jdestn in jdsList)
                            {
                                if (item.LastJourney.JourneyId == jdestn.JourneyId
                                    )
                                    item.Jd.Add(jdestn);
                            }   
                        }
                    }
                    //else
                      //  item.HasJourney = false;
                }
                
                /*           if (tempvehicle.HasJourney)
                           {
                       
                           }
                           */
                //step 4 add vehicle
                
                // add checking and dont forget the has journey and is direct and compare with php code to confirm;
            }
            finally
            {
                mycon.Close();
            }

            return branchvehicles;
        }

        private DFBranch getBranchInfo(int branchId, DFOrder order)
        {
            
            DFBranch result = new DFBranch();
            //check if branch is available
            result.IsAvailable = getBranchStatus(branchId);
            result.EnoughStock = checkBranchStockForOrder(branchId, order);
            if (result.IsAvailable)
            {

                //u can increase the performance by not executing the code below if branch is not available
                // get the distance
                int brnchInd = getbranchIndex(branchId);
                int customerInd = getCustomerIndex(order.customer_id);
                int branchx = int.Parse(dbBranches[brnchInd].Branch_postcode.Remove(2));
                int branchy = int.Parse(dbBranches[brnchInd].Branch_postcode.Remove(0, 3));
                int customerX = customersR[customerInd].XCoordinate;
                int customerY = customersR[customerInd].YCoordinate;
                int[] branchco = { branchx, branchy };
                int[] customerco = { customerX, customerY };
                double distance = calcDistance(customerco, branchco);



                //check if their is staff available
                result.IsStaffAvailable = checkBranchStaff(branchId);

                //get the queue time
                List<int> orderIds = new List<int>();
                orderIds = getOrdersBeingServedBy(branchId);
                double qTime = getBranchQueueTime(orderIds, brnchInd);

                result.Branch_id = branchId;
                result.DistanceToCustomer = distance;
                result.QueueTime = qTime;
            }
            return result;

        }

        private bool checkBranchStockForOrder(int branchId, DFOrder order)
        {
            bool stockEnough = true;
            int rawId=-1;
            int rawStockLevel =-1;
            foreach (int[] ol in order.order)
            {
                rawStockLevel = 0;
                sqlQuery = "SELECT raw_id FROM products where product_id='"+ol[0]+"'";
                try
                {

                    mycon.Open();
                    mycommand = new SqlCommand(sqlQuery, mycon);
                    mycommand.CommandText = sqlQuery;
                    reader = mycommand.ExecuteReader();
                    while (reader.Read() )
                    {
                        rawId = reader.GetInt32(0);
                    }
                    reader.Close();
                    
                    if (rawId != -1)
                    {
                        sqlQuery = "SELECT raw_stock.*, product_raw.* FROM raw_stock,"
                                + "product_raw  where product_raw.raw_id = raw_stock.raw_id" +
                                " and branch_id = '" + branchId + "' and product_raw.raw_id= '" + rawId + "'";
                    
                    mycommand = new SqlCommand(sqlQuery, mycon);
                    mycommand.CommandText = sqlQuery;
                    reader = mycommand.ExecuteReader();
                    while (reader.Read())
                    {
                        rawStockLevel = reader.GetInt32(2);
                    }
                    }
                }
                finally
                {
                    mycon.Close();
                }
                if (rawStockLevel < ol[1])
                {
                    stockEnough = false;
                    break;

                }

            }
            return stockEnough;
            
        }

        private bool getBranchStatus(int branchId)
        {
            bool isBAvailable = false;
            sqlQuery = "SELECT status FROM branch  where branch_id = '" + branchId + "' ";
            try
            {

                mycon.Open();
                mycommand = new SqlCommand(sqlQuery, mycon);
                mycommand.CommandText = sqlQuery;
                reader = mycommand.ExecuteReader();

                while (reader.Read() && isBAvailable == false)
                {

                    if (reader.GetString(0).TrimEnd() == "available")
                        isBAvailable = true;

                }
            }
            finally
            {
                mycon.Close();
            }
            return isBAvailable;
        }

        public bool checkBranchStaff(int branchId)
        {
            bool isStaffAvailable = false;
            sqlQuery = "SELECT * FROM staff where branch_id = '"+branchId+"'";
            try
            {

                mycon.Open();
                mycommand = new SqlCommand(sqlQuery, mycon);
                mycommand.CommandText = sqlQuery;
                reader = mycommand.ExecuteReader();

                while (reader.Read() && isStaffAvailable == false)
                {

                    if (reader.GetString(2).TrimEnd()  == "available")
                        isStaffAvailable = true;
                    
                }
            }
            finally
            {
                mycon.Close();
            }
            return isStaffAvailable;
        }
        internal void readProducts()
        {
            Product temp;

            sqlQuery = "SELECT * FROM products ";
            try
            {

                mycon.Open();
                mycommand = new SqlCommand(sqlQuery, mycon);
                mycommand.CommandText = sqlQuery;
                reader = mycommand.ExecuteReader();

                while (reader.Read())
                {
                    temp = new  Product();
                    temp.Product_id = reader.GetInt32(0);
                    temp.Raw_id = reader.GetInt32(1);
                    temp.Product_size = reader.GetString(4);
                    temp.Price =(double) reader.GetDecimal(2);
                    temp.ProcessingTimeM =reader.GetInt32(3);
                    temp.SetupTime= reader.GetInt32(5);
                    products.Add(temp);
                }
            }
            finally
            {
                mycon.Close();
            }
        }
        private double calcOrderProcessingTime(DFOrder order,int branchIndex)
        {
            //staff involvement needed
            // new formula should be
            //products[productIndex].ProcessingTimeM)*(Math.Ceiling((double)ol[1] / (double)machineCapacity));
            double processingTime =0;
            int productIndex;
            foreach(int[] ol in order.order )
            {
               productIndex= getproductIndex(ol[0]);

              // processingTime += products[productIndex].ProcessingTimeM*(Math.Ceiling((double)ol[1] / (double)machineCapacity));
               processingTime += (products[productIndex].SetupTime *(1/(double)dbBranches[branchIndex].NumberOfStaff)) *Math.Ceiling((double)ol[1]) + products[productIndex].ProcessingTimeM * (Math.Ceiling((double)ol[1] / (double)machineCapacity));
            }
            return processingTime;
        }

        private int getproductIndex(int pId)
        {
            int productIndex = -1;
            int i=-1;
            foreach (Product prod in products)
            {
                i++;
                if (prod.Product_id == pId)
                    productIndex = i;

            }
            return productIndex;
        }
        public double getBranchQueueTime(List<int> orderIds, int branchIndex)
        {
            // oh and stock involvement..
            // for the staff involvement u need to query the number of available staff
            
            double qTime = 0;
            string whereString = "SELECT products.* ,orderLine.* FROM products INNER JOIN orderLine ON products.product_id = orderLine.product_id  WHERE order_id = ";
            for ( int i =0;i< orderIds.Count;i++)
            {
                if (orderIds.Count-1 != i)
                    whereString += "'" + orderIds[i] + "' or order_id = ";
                else
                    whereString += "'" + orderIds[i] + "' ";

            }
            if (orderIds.Count > 0) // no point of executing the query when there is no orders assigned to the branch
            {
                mycon.Open();
                mycommand = new SqlCommand(sqlQuery, mycon);
                mycommand.CommandText = whereString;
                reader = mycommand.ExecuteReader();
                try
                {


                    while (reader.Read())
                    {
                        //staff involvement needed
                        // new formula should be
                        //products[productIndex].ProcessingTimeM)*(Math.Ceiling((double)ol[1] / (double)machineCapacity));
                        //                      processingtime *( qty / machine capacity)
                        //no no no .. q time is just get the last order finish time
                        // time that the machine will be free? spereate from setup time // no no this is probably right because there r orders being setup right now
                        // formual qtime = SUM (productSetupTime *( 1/noStaff))*qty + productProcessingTime *(oderqty/machineCapacity)
                        qTime += (reader.GetInt32(reader.GetOrdinal("setup_time")) * (1 / (double)dbBranches[branchIndex].NumberOfStaff) * reader.GetInt32(reader.GetOrdinal("quantity"))) + ((double)reader.GetInt32(reader.GetOrdinal("processing_time")) * (Math.Ceiling((double)reader.GetInt32(reader.GetOrdinal("quantity")) / (double)machineCapacity)));
                        //qTime += (products[productIndex].SetupTimeM * (1 / )) * Math.Ceiling((double)ol[1]) + products[productIndex].ProcessingTimeM * (Math.Ceiling((double)ol[1] / (double)machineCapacity));
                        //products[productIndex].SetupTimeM * (Math.Ceiling((double)ol[1] / (double)dbBranches[branchIndex].NumberOfStaff)) + products[productIndex].ProcessingTimeM * (Math.Ceiling((double)ol[1] / (double)machineCapacity));



                    }
                }
                finally
                {
                    mycon.Close();
                }
            }
            
            return qTime;
        
        }

        internal List<int> getOrdersBeingServedBy(int brnchInd)
        {
            DateTime today = DateTime.Now;
            string todayReverse = today.Year+"-"+today.Month+"-"+today.Day;
            string time = today.Hour + ":" + today.Minute + ":" + today.Second;
            List<int> orderIds = new List<int>();
            sqlQuery = "SELECT order_servant.* FROM order_servant INNER JOIN orders on order_servant.order_id"
            + " = orders.order_id WHERE order_servant.branch_id ='" + brnchInd + "' and orders.order_date " +
                "= '" + todayReverse + "' and orders.order_processing_FinishTime > '" + time + "'";
            mycon.Open();
            mycommand = new SqlCommand(sqlQuery, mycon);
            mycommand.CommandText = sqlQuery;
            reader = mycommand.ExecuteReader();
            try
            {


                while (reader.Read())
                {
                    orderIds.Add(reader.GetInt32(0));



                }
            }
            finally
            {
                mycon.Close();
            }

            return orderIds;
        }

        public int getCustomerIndex(int customerId)
        {
            int i = -1;
            int index = -1;
            foreach (CustomerR c in customersR)
            {
                i++;
                if (c.Customer_id == customerId)
                {
                    index = i;
                }

            }
            return index;
            
        }


        public int getbranchIndex(int branchId)
        {
            int i = -1;
            int index = -1;
            foreach (Branch b in dbBranches)
            {
                i++;
                if (b.Branch_id == branchId)
                {
                    index = i;
                    break;
                }
                    
            }
            return index;

        }
        public int getbranchIndex(int branchId,List<DFBranch> branchinfo)
        {
            int i = -1;
            int index = -1;
            foreach (DFBranch b in branchinfo)
            {
                i++;
                if (b.Branch_id == branchId)
                {
                    index = i;
                    break;
                }

            }
            return index;

        }



        internal void randomStaffForBranches(int min, int max)
        {
            string fName= "fEmployee";
            string lName = "lEmployee";
            
            Random r = new Random();
            int numberOfstaff = 0;
            
            Employee temp;
            foreach (Branch b in dbBranches)
            {
                numberOfstaff = r.Next(min, max);
                for (int i = 0; i < numberOfstaff; i++)
                {
                    temp = new Employee();
                    temp.IsAvailable = true;                    
                    temp.BranchId = b.Branch_id;
                    temp.First_Name = fName + i;
                    temp.Last_name = lName + i;
                    dbStaff.Add(temp);
                }


            }
        }

        internal void insertRandomStaff()
        {
            string strStatus;

            try
            {
                mycon.Open();
                foreach (Employee e in dbStaff)
                {
                    if (e.IsAvailable)
                        strStatus = "available";
                    else
                        strStatus = "unavailable";
                    sqlQuery = "INSERT INTO staff "
                + "(branch_id,status, first_name,last_name)" + " VALUES ('" + e.BranchId + "','" + strStatus + "','"  + e.First_Name+ "','"  + e.Last_name+ "')";
                    mycommand = new SqlCommand(sqlQuery, mycon);
                    mycommand.CommandText = sqlQuery;
                    mycommand.ExecuteNonQuery();
                }
            }
            finally
            {
                mycon.Close();
            }
        }

        internal void randomStockLevels(int min, int max)
        {
            Random r = new Random();
            int branchStockLevel = 0;
            bool found;
            List<int> rawIds=new List<int>();
            foreach (Product p in products)
            {
                found = false;
                for (int i=0;i<rawIds.Count;i++)
                {
                    if(p.Raw_id == rawIds[i])
                        found=true;
                }
                    if(!found)
                        rawIds.Add(p.Raw_id);
                
            }


            foreach(Branch b in dbBranches)
            foreach (int raw in rawIds)
            {
                branchStockLevel = r.Next(min, max);
                insertBranchRawStockLevel(b.Branch_id,raw,branchStockLevel);


            }
        }

        public void insertBranchRawStockLevel(int branchId, int raw, int branchStockLevel)
        {
            sqlQuery ="INSERT INTO raw_stock (branch_id,raw_id,stock_level) "
        +"VALUES ('"+branchId+"','"+raw+"','"+branchStockLevel+"')";
            try 
            {
                mycon.Open();
                mycommand = new SqlCommand(sqlQuery, mycon);
                mycommand.CommandText = sqlQuery;
                mycommand.ExecuteNonQuery();
            }
            finally 
            {
                mycon.Close();
            }
        }

        internal int getVehicleIndex(int id)
        {
            int index=-1;
            for (int i = 0; i < dbVehicles.Count; i++)
                if (dbVehicles[i].VehicleId == id)
                {
                    index = i;
                    break;
                }
            return index;
        }
    }//
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
    public class DFVehicle : Vehicle
    {
        bool ifEmptyCanContainOrder;
        double distance_from_customer;
        bool canAddToCurrentJourney;
        bool hasJourney;
        journey lastJourney;
        List<journeyDestinations> jd;
        int timeToDeliver;
        bool isDirect;

        public bool IfEmptyCanContainOrder
        {
            get { return ifEmptyCanContainOrder; }
            set { ifEmptyCanContainOrder = value; }
        }   

        public bool CanAddToCurrentJourney
        {
            get { return canAddToCurrentJourney; }
            set { canAddToCurrentJourney = value; }
        }

        public bool IsDirect
        {
            get { return isDirect; }
            set { isDirect = value; }
        }

        public int TimeToDeliver
        {
            get { return timeToDeliver; }
            set { timeToDeliver = value; }
        }
        public double Distance_from_customer
        {
            get { return distance_from_customer; }
            set { distance_from_customer = value; }
        }

        public journey LastJourney
        {
            get { return lastJourney; }
            set { lastJourney = value; }
        }

        public List<journeyDestinations> Jd
        {
            get { return jd; }
            set { jd = value; }
        }

        public bool HasJourney
        {
            get { return hasJourney; }
            set { hasJourney = value; }
        }
        public DFVehicle()
        {
            this.ifEmptyCanContainOrder = false;
            this.canAddToCurrentJourney = false;
            this.hasJourney = false;
            this.lastJourney = new journey();
            this.jd = new List<journeyDestinations>();
        }
    }
    public class journeyDestinations
    {
        int journeyId;        // 	 	 	 	 	 	
        int destinationId;
        string postcode;
        int destination_sequence;
        int order_id;
        int duration_from_last_stop;
        int duration_from_branch;
        public journeyDestinations()
        {
            this.journeyId = -1;
            this.postcode = "";
            this.order_id = -1;
            this.destination_sequence = -1;
            this.destinationId = -1;
            this.duration_from_branch = -1;
            this.duration_from_last_stop = -1;
        }

        public int Duration_from_branch
        {
            get { return duration_from_branch; }
            set { duration_from_branch = value; }
        }

        public int Duration_from_last_stop
        {
            get { return duration_from_last_stop; }
            set { duration_from_last_stop = value; }
        }

        public int Order_id
        {
            get { return order_id; }
            set { order_id = value; }
        }

        public int Destination_sequence
        {
            get { return destination_sequence; }
            set { destination_sequence = value; }
        }

        public string Postcode
        {
            get { return postcode; }
            set { postcode = value; }
        }


        public int DestinationId
        {
            get { return destinationId; }
            set { destinationId = value; }
        }

        public int JourneyId
        {
            get { return journeyId; }
            set { journeyId = value; }
        }
    }
    public class journey
    {
        int journeyId;// 	 	 	
        int vehicle_id;
        DateTime journey_date;
        int journey_capacity;
        DateTime journey_finishTime;
        DateTime journey_startTime;

        public journey()
        {
            this.journey_capacity = -1;
            this.journeyId = -1;
            this.journey_startTime = new DateTime();
            this.journey_finishTime = new DateTime();
            this.vehicle_id = -1;
            this.journey_date = new DateTime();
        }

        public DateTime Journey_startTime
        {
            get { return journey_startTime; }
            set { journey_startTime = value; }
        }

        public DateTime Journey_finishTime
        {
            get { return journey_finishTime; }
            set { journey_finishTime = value; }
        }

        public int Journey_capacity
        {
            get { return journey_capacity; }
            set { journey_capacity = value; }
        }

        public DateTime Journey_date
        {
            get { return journey_date; }
            set { journey_date = value; }
        }
public int Vehicle_id
{
  get { return vehicle_id; }
  set { vehicle_id = value; }
} 	

        public int JourneyId
        {
            get { return journeyId; }
            set { journeyId = value; }
        }
    }
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
    
    public class DFOrder
    {
        public List<int[]> order; // eg {product_id,qty}
        public int customer_id;
        public DFOrder()
        {
            this.order = new List<int[]>();
        }
    }
    public class Product
    {
        int processingTimeM;
        double price;
        string product_size;
        int raw_id;
        int product_id;
        int setupTime;

        public int SetupTime
        {
            get { return setupTime; }
            set { setupTime = value; }
        }

        public int Product_id
        {
            get { return product_id; }
            set { product_id = value; }
        }

        public int Raw_id
        {
            get { return raw_id; }
            set { raw_id = value; }
        }

        public string Product_size
        {
            get { return product_size; }
            set { product_size = value; }
        }

        public double Price
        {
            get { return price; }
            set { price = value; }
        }

        public int ProcessingTimeM
        {
            get { return processingTimeM; }
            set { processingTimeM = value; }
        }
        public Product()
        {
            this.Price = -1;
            this.ProcessingTimeM = -1;
            this.Product_id = -1;
            this.Product_size = "";
            this.Raw_id = -1;

        }
        public Product(int id,int rawId, string size,int processingTime,double price )
        {
            this.Price = -1;
            this.ProcessingTimeM = -1;
            this.Product_id = -1;
            this.Product_size = "";
            this.Raw_id = -1;

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

}
