using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using WindowsFormsApplication4;
using System.Data.SqlClient;

namespace PerformanceMonitor
{
    public partial class Form1 : Form
    {
        
        DataFeed df ;
        public Form1()
        {
            InitializeComponent();
            df = new DataFeed();
            this.udNoCustomers.Value = 8;
            this.udNoStores.Value = 1;
            this.udNoVehiclesMax.Value = 1;
            this.udNoVehiclesMin.Value = 1;
            this.udVehiclesCapacityMax.Value = 70;
            this.udVehiclesCapacityMin.Value = 70;
            this.udStaffMax.Value = 1;
            this.udStaffMin.Value = 1;
            this.udStockMax.Value = 300;
            this.udStockMin.Value = 300;
            this.numericUpDown1.Value = 40;


        }

        private void button1_Click(object sender, EventArgs e)
        {

        }
        public void drawPieChart()
        {
            listBox1.Items.Clear();
            List<decimal> qTimes = new List<decimal>();
            List<DFBranch> branchesInfo = new List<DFBranch>();
            DFBranch temp;
            int branchDbIndex;
            foreach (Branch b in df.dbBranches)
            {
                branchDbIndex = df.getbranchIndex(b.Branch_id);
                temp = new DFBranch();
                temp.Branch_id = b.Branch_id;
                temp.QueueTime = df.getBranchQueueTime(df.getOrdersBeingServedBy(b.Branch_id), branchDbIndex);
                branchesInfo.Add(temp);
            }

            //  qTimes.Add((decimal)df.getBranchQueueTime(df.getOrdersBeingServedBy(b.Branch_id)));            
            Random rand = new Random();
            int x;
            Color white = new Color();
            decimal[] values = { rand.Next(1, 30), 10, rand.Next(1, 30), rand.Next(1, 30), rand.Next(1, 30), rand.Next(1, 30) };
            PieChart pchart = new PieChart();
            Bitmap pic = pchart.Draw(white, 100, 100, branchesInfo);
            pictureBox1.Image = pic;
            foreach (string[] s in pchart.branchAndColor)
                listBox1.Items.Add(" bId:" + s[0] + "," + s[1]);
                //label11.Text += ;
            //MessageBox.Show( pchart.branchAndColor[0][1]);
        }
        public Bitmap plotPoints(List<Branch> branches, List<CustomerR> customersR,List<DFOrder> orders)
        {
                 
                        // just make the window big enough to fit this graph...
                        int width = 500;
                        int height = 350;
                        
                        // add 5 so the bars fit properly
                        int x = 240; // the position of the X axis
                        int y = 0; // the position of the Y axis
                        
                        Bitmap bmp = new Bitmap(360, 290);
                        Graphics g = Graphics.FromImage(bmp);
                        
                        g.DrawLine (new Pen(Color.Red, 2), 5,5, 5,250);
                        g.DrawLine (new Pen(Color.Red, 2), 5,250, 300,250);
                        // let's draw a coordinate equivalent to (20,30) (20 up, 30 across)
            int customerX,customerY,customerInd;
            List<int> ordersAssignedToBranch;
            df.readDBOrders();
            bool found;
                        foreach (CustomerR c in customersR)
                        {
                            
                            
                            g.DrawString("o", new Font("Calibg.ri", 12), new SolidBrush(Color.Aqua), y + c.XCoordinate*10, x - c.YCoordinate*10);
                            g.DrawString( c.Customer_id.ToString(), new Font("Calibg.ri", 7), new SolidBrush(Color.Aqua), y + (c.XCoordinate * 10)+5, x - c.YCoordinate * 10);
                            
                        }
                        foreach (Branch b in branches)
                        {
                            found = false;
                            ordersAssignedToBranch = new List<int>();
                            ordersAssignedToBranch = df.getOrdersBeingServedBy(b.Branch_id);
                            g.DrawString("o", new Font("Calibg.ri", 12), new SolidBrush(Color.Red), y + int.Parse(b.Branch_postcode.Remove(2)) * 10, x - int.Parse(b.Branch_postcode.Remove(0, 3)) * 10);
                            g.DrawString(b.Branch_id.ToString(), new Font("Calibg.ri", 5), new SolidBrush(Color.Red), 5 + y + int.Parse(b.Branch_postcode.Remove(2)) * 10, x - int.Parse(b.Branch_postcode.Remove(0, 3)) * 10);




                            foreach (order o in df.dbOrders)
                            {

                                found = false;
                                for (int i = 0; i < ordersAssignedToBranch.Count; i++)
                                {
                                    if (ordersAssignedToBranch[i] == o.Order_id)
                                        found = true;
                                }
                                if (found)
                                {

                                    customerInd = df.getCustomerIndex(o.Customer_id);
                                    customerX = customersR[customerInd].XCoordinate;
                                    customerY = customersR[customerInd].YCoordinate;
                                    g.DrawLine(new Pen(Color.Green, 1), y + customerX * 10 + 10, x - customerY * 10 + 10, y + int.Parse(b.Branch_postcode.Remove(2)) * 10 + 10, x - int.Parse(b.Branch_postcode.Remove(0, 3)) * 10 + 10);
                                }
                            }
                            
                        }
                        //List<object[]> journeysDest = new List<object[]>();
                        //journeysDest = df.getJourneys();
                        //int branchindex;
                        //journey journeyTemp;
                        //List<journeyDestinations> jdsTemp;
                        //bool iDfound = false;
                        //int customerId = -1;
                        //int customerIndex = -1;
                        //int nextcX, nextcY;
                        //int vind=-1;
                        //foreach (object[] j in journeysDest)
                        //{
                        //    journeyTemp = (journey)j[0];
                        //    vind=df.getVehicleIndex(journeyTemp.Vehicle_id);
                            
                        //    branchindex = -1;
                        //    for (int i = 0; i < branches.Count; i++)
                        //    {
                        //        if (df.dbVehicles[vind].BranchId == branches[i].Branch_id)
                        //        {
                        //            branchindex = i;
                        //            break;
                        //        }

                        //    }
                            
                        //    jdsTemp = new List<journeyDestinations>();
                        //    jdsTemp = (List<journeyDestinations>)j[1];
                        //    for (int i = 0; i < jdsTemp.Count ; i++)
                        //    {
                        //        if (i == 0)//draw from branch
                        //        {

                        //            //getcustomerid
                        //            foreach (order o in df.dbOrders)
                        //            {
                        //                if (o.Order_id == jdsTemp[i].Order_id)
                        //                {
                        //                    customerId = o.Customer_id;
                        //                    break;
                        //                }

                        //            }
                        //            for (int k = 0; k < customersR.Count; k++)
                        //            {
                        //                if (customersR[k].Customer_id == customerId)
                        //                {
                        //                    customerIndex = k;
                        //                    break;
                        //                }
                        //            }
                                   
                                    
                        //            customerX = customersR[customerIndex].XCoordinate;
                        //            customerY = customersR[customerIndex].YCoordinate;
                        //            g.DrawLine(new Pen(Color.PaleGreen, 1), y + customerX * 10 + 10, x - customerY * 10 + 10, y + int.Parse(branches[branchindex].Branch_postcode.Remove(2)) * 10 + 10, x - int.Parse(branches[branchindex].Branch_postcode.Remove(0, 3)) * 10 + 10);

                        //        }

                        //        else if(i == jdsTemp.Count-1)
                        //        {
                        //            foreach (order o in df.dbOrders)
                        //            {
                        //                if (o.Order_id == jdsTemp[i].Order_id)
                        //                {
                        //                    customerId = o.Customer_id;
                        //                    break;
                        //                }

                        //            }
                        //            for (int k = 0; k < customersR.Count; k++)
                        //            {
                        //                if (customersR[k].Customer_id == customerId)
                        //                {
                        //                    customerIndex = k;
                        //                    break;
                        //                }
                        //            }


                        //            customerX = customersR[customerIndex].XCoordinate;
                        //            customerY = customersR[customerIndex].YCoordinate;
                        //            g.DrawLine(new Pen(Color.Green, 1), y + int.Parse(branches[branchindex].Branch_postcode.Remove(2)) * 10 + 10, x - int.Parse(branches[branchindex].Branch_postcode.Remove(0, 3)) * 10 + 10, y + customerX * 10 + 10, x - customerY * 10 + 10);

                        //        }
                        //        else
                                

                        //        {
                        //            foreach (order o in df.dbOrders)
                        //            {
                        //                if (o.Order_id == jdsTemp[i ].Order_id)
                        //                {
                        //                    customerId = o.Customer_id;
                        //                    break;
                        //                }

                        //            }
                        //            for (int k = 0; k < customersR.Count; k++)
                        //            {
                        //                if (customersR[k].Customer_id == customerId)
                        //                {
                        //                    customerIndex = k;
                        //                    break;
                        //                }
                        //            }
                        //            // customerInd = df.getCustomerIndex(o.Customer_id);
                        //            customerX = customersR[customerIndex].XCoordinate;
                        //            customerY = customersR[customerIndex].YCoordinate;
                        //            // customerInd = df.getCustomerIndex(o.Customer_id);
                        //            nextcX = customersR[customerIndex].XCoordinate;
                        //            nextcY = customersR[customerIndex].YCoordinate;
                        //            foreach (order o in df.dbOrders)
                        //            {
                        //                if (o.Order_id == jdsTemp[i + 1].Order_id)
                        //                {
                        //                    customerId = o.Customer_id;
                        //                    break;
                        //                }

                        //            }
                        //            for (int k = 0; k < customersR.Count; k++)
                        //            {
                        //                if (customersR[k].Customer_id == customerId)
                        //                {
                        //                    customerIndex = k;
                        //                    break;
                        //                }
                        //            }
                        //            nextcX = customersR[customerIndex].XCoordinate;
                        //            nextcY = customersR[customerIndex].YCoordinate;

                        //            g.DrawLine(new Pen(Color.Green, 1), y + customerX * 10 + 10, x - customerY * 10 + 10, y + nextcX * 10 + 10, x - nextcY * 10 + 10);
                        //            foreach (order o in df.dbOrders)
                        //            {
                        //                if (o.Order_id == jdsTemp[i - 1].Order_id)
                        //                {
                        //                    customerId = o.Customer_id;
                        //                    break;
                        //                }

                        //            }
                        //            for (int k = 0; k < customersR.Count; k++)
                        //            {
                        //                if (customersR[k].Customer_id == customerId)
                        //                {
                        //                    customerIndex = k;
                        //                    break;
                        //                }
                        //            }
                        //            int[] custprev = new int[2];
                        //            custprev[0] = customersR[customerIndex].XCoordinate; 
                        //            custprev[1] = customersR[customerIndex].YCoordinate;
                        //            g.DrawLine(new Pen(Color.Green, 1), y + customerX * 10 + 10, x - customerY * 10 + 10, y + custprev[0] * 10 + 10, x - custprev[1] * 10 + 10);
 

                        //        }
                        //    }

                        //}
                            
                        //    //g.dr
                        //}
                        return bmp;
                
        }

        private void Form1_Load(object sender, EventArgs e)
        {


            
        }

        private void button2_Click(object sender, EventArgs e)
        {
            df = new DataFeed();
            //if it is not the first time to test this will cause a problem if not cleared
            df.dbBranches.Clear();
            df.customersR.Clear();
            
            //df.customers.Clear();
            df.dbVehicles.Clear();
            //step2 create random store branches
            df.randomBranches((int)udNoStores.Value);
            df.insertRandomBranches();
            //step1 creat random customers
            if (cbCustomerIsClose.Checked)
                df.RandomCustomers((int)udNoCustomers.Value, true);
            else
                df.RandomCustomers((int)udNoCustomers.Value, false);
            df.insertCustomersR();

            //step3 clear the branches and customers then read them from the DB
            df.dbBranches.Clear();
            df.customersR.Clear();
//            df.customers.Clear();
            //df.
            //step4 read the customers and the branches
            df.readBranches();
            df.readCustomers();
            df.readProducts();
            // create random vehicles for branches
            df.randomVehiclesForBranches((int)udNoVehiclesMin.Value, (int)udNoVehiclesMax.Value, (int)udVehiclesCapacityMin.Value, (int)udVehiclesCapacityMax.Value);
            df.insertRandomVehicles();
            df.dbVehicles.Clear();
            df.readRandomVehicles();
            // create random staff for branches
            df.randomStaffForBranches((int)udStaffMin.Value, (int)udStaffMax.Value);
            df.insertRandomStaff();
            df.dbStaff.Clear();

            //read the branches again to get number of staff and vehicles updated;
            df.dbBranches.Clear();
            df.readBranches();
            // create Random Stock Levels
            df.randomStockLevels((int) udStaffMin.Value,(int)udStockMax.Value);
            //step5 place orders for the customers
            df.create_orders_for_the_customers();
            //
            //call serve orders eithe with a timer or without
            df.TimedServiceDelay = (int)udDelay.Value;
            df.maxjourneyDestinationTimeM = (int)numericUpDown1.Value;
            df.serveOrders();
            //df.readPostCodes();
            drawPieChart();
            pictureBox2.Image= plotPoints(df.dbBranches,df.customersR,df.queueOfOrders.ToList());
            dispalyStat();
        }

        private void dispalyStat()
        {
            //get max orders in a branch and min
            
            List<int[]> orders = new List<int[]>();
            int[] orderandbId ;
            List<int> orderlist;
            foreach(Branch b in df.dbBranches)
            {
                orderlist = new List<int>();
                orderlist= df.getOrdersBeingServedBy(b.Branch_id);
                orderandbId = new int[2];
                orderandbId[0] = b.Branch_id;
                orderandbId[1] = orderlist.Count;
                orders.Add(orderandbId);
            }
            int[] max = { orders[0][0], orders[0][1] };
            int[] min = { orders[0][0], orders[0][1] };
            
            for(int i=0;i<orders.Count;i++)
            {
                if (orders[i][1] > max[1])
                {
                    max[1] = orders[i][1];
                    max[0] = orders[i][0];
                }
                if (orders[i][1] < min[1])
                {
                    min[1] = orders[i][1];
                    min[0] = orders[i][0];
                }
            }

            List<object[]> journeysDest = new List<object[]>();
            journeysDest = df.getJourneys();
            int iTotalNumberOfJourneys = 0;
            int iLongestJourneyM=-1;
            int iShortestJourneyM = 99999;
            int iSumJourneyM = 0;
            int iAvgJourneyM = -1;
            int iSumJourneyDstnationsCount = 0;
            int iHighestJourneyDstnations = -1;
            int iLowestJourneyDstnations = 9999;
            int iAvgJourneyDstnations = -1;
            int iSumOfSurpassingDeliveryTimeDestinations=0;
            //int iSumJourneyM = -1;
            foreach (var jrnyAndJd in journeysDest)
            {
                journey jnyt = (journey )jrnyAndJd[0];
                List<journeyDestinations> jnyDt = (List<journeyDestinations>)jrnyAndJd[1];
                
                if (jnyDt.Count > iHighestJourneyDstnations)
                    iHighestJourneyDstnations = jnyDt.Count;
                if (jnyDt.Count < iLowestJourneyDstnations)
                    iLowestJourneyDstnations = jnyDt.Count;
                iSumJourneyDstnationsCount+=jnyDt.Count;
                foreach (var jd in jnyDt)
            {
                if (numericUpDown1.Value < jd.Duration_from_branch)
                    iSumOfSurpassingDeliveryTimeDestinations++;
                iTotalNumberOfJourneys++;
                iSumJourneyM += jd.Duration_from_branch;
                if (jd.Duration_from_branch > iLongestJourneyM)
                    iLongestJourneyM = jd.Duration_from_branch;
                if (jd.Duration_from_branch < iShortestJourneyM)
                    iShortestJourneyM = jd.Duration_from_branch;
                }
                
            }
            iAvgJourneyDstnations = iSumJourneyDstnationsCount/iTotalNumberOfJourneys;
            iAvgJourneyM = iSumJourneyM/iTotalNumberOfJourneys;
            string result = "number Of Orders :" + df.queueOfOrders.Count
                + "\t\n highest number oforders assigned to a branch: bId:" + max[0] + " #orders: "
                + max[1] + "\t\n lowest number of orders assigned to a branch: bId:" + min[0] + " #orders: "
                + min[1] + "\t\n average orders per branch: " + (df.queueOfOrders.Count / df.dbBranches.Count)
            + "n umber of orders surpassing the max delivery" + iSumOfSurpassingDeliveryTimeDestinations
            + "max journey" + iHighestJourneyDstnations
            + "min journey" + iLowestJourneyDstnations
            + "avg destinations per journey" + iAvgJourneyDstnations
            + "AVG journey time" + iAvgJourneyM;
            //get average
            textBox1.Text = result;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            df.clearDB();
            
        }

        private void button4_Click(object sender, EventArgs e)
        {
            df = new DataFeed();
            //if it is not the first time to test this will cause a problem if not cleared
            df.dbBranches.Clear();
            df.customersR.Clear();
            //df.customers.Clear();
            df.dbVehicles.Clear();
            //step1 creat customers
            List<CustomerR> customers = new List<CustomerR>();
            CustomerR temp;

            temp = new CustomerR("-", "-", "-", "-", -1, "-", "-", "--", "17,17", "-", 17, 17);
            customers.Add(temp);
            temp = new CustomerR("-", "-", "-", "-", -1, "-", "-", "--", "15,15", "-", 15, 15);
            customers.Add(temp);
            temp = new CustomerR("-", "-", "-", "-", -1, "-", "-", "--", "19,17", "-", 19, 17);
            customers.Add(temp);

            temp = new CustomerR("-", "-", "-", "-", -1, "-", "-", "--", "12,12", "-", 12, 12);
            customers.Add(temp);
            //temp = new CustomerR("-", "-", "-", "-", -1, "-", "-", "--", "01,05", "-", 01, 05);
            //customers.Add(temp);
            //temp = new CustomerR("-", "-", "-", "-", -1, "-", "-", "--", "05,02", "-", 05, 02);
            //customers.Add(temp);
            //temp = new CustomerR("-", "-", "-", "-", -1, "-", "-", "--", "00,00", "-", 00, 00);
            //customers.Add(temp);
            //temp = new CustomerR("-", "-", "-", "-", -1, "-", "-", "--", "10,12", "-", 10, 12);
            //customers.Add(temp);

            df.hardCodedCustomers(customers);
            
            df.insertCustomersR();
            //step2 create random store branches
            List<Branch> branches = new List<Branch>();
            Branch btemp;
            btemp = new Branch();
            btemp.Branch_postcode = "15,17";
            btemp.IsAvialable = true;
            branches.Add(btemp);
            btemp = new Branch();
            btemp.Branch_postcode = "20,20";
            branches.Add(btemp);
            btemp = new Branch();
            btemp.Branch_postcode = "08,08";
            branches.Add(btemp);

            df.hardCodedBranches(branches);
            df.insertRandomBranches();
            //step3 clear the branches and customers then read them from the DB
            df.dbBranches.Clear();
            df.customersR.Clear();
            //df.customers.Clear();
            //df.
            //step4 read the customers and the branches
            df.readBranches();
            df.readCustomers();
            df.readProducts();
            // create random vehicles for branches
            List<Vehicle> vehicleList = new List<Vehicle>();
            Vehicle tempv = new Vehicle(-1,-1,40,true);            
            vehicleList.Add(tempv);
            df.hardCodedVehiclesForBranches(vehicleList);
            df.randomStaffForBranches(1, 1);
            df.insertBranchRawStockLevel(df.dbBranches[0].Branch_id, 1, 200);
            //tempv = new Vehicle(-1, -1, 5, false);
            //vehicleList.Add(tempv);
            //df.hardCodedVehiclesForBranches(vehicleList);

            df.insertRandomVehicles();
            df.dbVehicles.Clear();
            df.readRandomVehicles();
            df.insertRandomStaff();
            df.dbBranches.Clear();
            df.readBranches();
            
            //step5 place orders for the customers
            Queue<DFOrder> qo = new Queue<DFOrder>();
            DFOrder ordr = new DFOrder();
            int[] oline = new int[2];
            oline[0] = 1;
            oline[1] = 7;

            ordr.order.Add( oline);
            qo.Enqueue(ordr);
            ordr = new DFOrder();
            oline = new int[2];
            oline[0] =1;
            oline[1]=4;
            ordr.order.Add(oline);
            qo.Enqueue(ordr);
            ordr = new DFOrder();
            oline = new int[2];
            oline[0] = 1;
            oline[1] = 5;
            ordr.order.Add(oline);
            qo.Enqueue(ordr);
            ordr = new DFOrder();
            oline = new int[2];
            oline[0] = 1;
            oline[1] = 4;
            ordr.order.Add(oline);
            qo.Enqueue(ordr);
            //ordr = new DFOrder();
            //oline = new int[2];
            //oline[0] = 1;
            //oline[1] = 4;
            //ordr.order.Add(oline);
            //qo.Enqueue(ordr);
            //ordr = new DFOrder();
            //oline = new int[2];
            //oline[0] = 1;
            //oline[1] = 4;
            //ordr.order.Add(oline);
            //qo.Enqueue(ordr);
            //ordr = new DFOrder();
            //oline = new int[2];
            //oline[0] = 1;
            //oline[1] = 4;
            //ordr.order.Add(oline);
            //qo.Enqueue(ordr);
            //ordr = new DFOrder();
            //oline = new int[2];
            //oline[0] = 1;
            //oline[1] = 4;
            //ordr.order.Add(oline);
           // qo.Enqueue(ordr);


            df.hardCodedOrders(qo);
    //        df.create_orders_for_the_customers();
            //
            //call serve orders eithe with a timer or without
           // df.TimedServiceDelay = (int)udDelay.Value;
            df.serveOrders();
            //df.readPostCodes();
            drawPieChart();
            pictureBox2.Image = plotPoints(df.dbBranches, df.customersR, df.queueOfOrders.ToList());
        }

        private void button5_Click(object sender, EventArgs e)
        {
            pictureBox2.Refresh();
            pictureBox2.Image= plotPoints(df.dbBranches,df.customersR,df.queueOfOrders.ToList());
        }

        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {
            if (radioButton1.Checked)
            {
                //radioButton2.Checked = false;
                panel1.Show();
                button4.Hide();
            }
        }

        private void radioButton2_CheckedChanged(object sender, EventArgs e)
        {
            if (radioButton2.Checked)
                panel1.Hide();
            button4.Show();
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            journey jr= new journey();
            Type type = jr.GetType();
            string cmd = " CREATE TABLE = dbo." + type.Name + " (";
            foreach (
       System.Reflection.PropertyInfo property in
           type.GetProperties())
            {
                cmd += " " + string.Format("{0} {1}, ", property.Name, getDBType(property.PropertyType.Name));
                System.Console.WriteLine(property.Name);
            }
            cmd += ")";
           
            string conStr = @"Data Source=|DataDirectory|\Database1.sdf";
            SqlConnection con = new SqlConnection(conStr);
            SqlCommand cmdd = new SqlCommand(cmd, con);
            con.Open();
            cmdd.ExecuteNonQuery();
            
            con.Close();
        }

        private string getDBType(string p)
        {
            string type = "";
            switch (p)
            {
                case "Int32": type = "int"; break;
                case "DateTime": type = "DateTime"; break;
                case "double": type = "decimal"; break;
                case "bool": type = "bit"; break;
                case "string": type = "varchar(250)"; break;
                

                default: break;
            }
            return type;
        }

        private void numericUpDown1_ValueChanged(object sender, EventArgs e)
        {

        }

        private void udNoVehiclesMax_ValueChanged(object sender, EventArgs e)
        {

        }
    }
}
