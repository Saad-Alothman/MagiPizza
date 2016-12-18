using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data.Odbc;
using System.Timers;
using System.IO;
using MagiPizza.Domain.Models;
using MagiPizza.Persistance;

namespace WindowsFormsApplication4
{
    public partial class FormBranchMain : Form
    {
             System.Timers.Timer t ;
             delegate void SetTextCallback(string text);


        int branchId;
        DBHandler dbhHandle= new DBHandler();
        List<order> orders = new List<order>();
        List<Employee> emps = new List<Employee>();
        List<Vehicle> vehicles;
        Branch bInfo = new Branch();
        double qtime;
        System.Drawing.Font m ;
        public FormBranchMain()

        {
            InitializeComponent();
            
            
            
        }
        public FormBranchMain(int bId)
        {
            
            InitializeComponent();
            this.branchId = bId;
            this.orders = dbhHandle.getOrders(bId);
            this.bInfo = dbhHandle.getBranchInfo(bId);
            this.vehicles = new List<Vehicle>();
            this.setBranchData();
            this.t = new System.Timers.Timer();
           this.t.Interval = 10000;
           this.t.AutoReset = true;
            this.t.Elapsed += new ElapsedEventHandler(onTimerEvent);
            this.t.Start();
            //this.comboBox1.DataSource = orders;
            emps = new List<Employee>();
              
            
            readData();
             m = new Font(this.Font.FontFamily, this.Font.Size, this.Font.Style);
             toolStripComboBox1.Text = "change font size";

        }
        private void SetText(string text)
        {
            this.readData();
        }
        public void setBranchData()
        {
            
            emps = bInfo.BranchEmployees;
            vehicles = bInfo.BranchVehicles;
            this.cbVehicles.DataSource = vehicles;
            this.comboBox3.DataSource = emps;
            this.txt_pnlBranchID.Text = bInfo.Branch_id.ToString();
            this.textBox4.Text = bInfo.Branch_id.ToString();
            this.textBox5.Text = bInfo.Branch_postcode;
            this.textBox2.Text=
            this.txt_pnlBranchAddress.Text = bInfo.Branch_postcode;
            this.bInfo.NumberOfStaff = bInfo.BranchEmployees.Count();
            this.bInfo.NumberOfVehicles = bInfo.BranchVehicles.Count();
            string status;
            if (bInfo.IsAvialable)
            {
                status = "available";

            }
            else
            {
                status = "unavailable";
                
            }


            this.textBox2.Text = status;
            this.textBox1.Text = status;
            this.txtBx_NumberOfStaff.Text = bInfo.NumberOfStaff.ToString();
            this.txtBx_NumberOfVehicile.Text = bInfo.NumberOfVehicles.ToString();
            
        }

                private void button4_Click(object sender, EventArgs e)
        {
            t = new System.Timers.Timer();
            t.Interval = 5000;
            t.AutoReset = true;
            t.Elapsed += new ElapsedEventHandler(onTimerEvent);
            t.Start();
            //timerSet = true;

            
        }
        public void onTimerEvent(object source, ElapsedEventArgs e)
        {
            
            if (this.comboBox1.InvokeRequired)
            {
                // It's on a different thread, so use Invoke.
                SetTextCallback d = new SetTextCallback(SetText);
                this.Invoke
                    (d, new object[] {  " (Invoke)" });
            }
            else
            {
                // It's on the same thread, no need for Invoke
                readData();
            }


            //comboBox1.Text = "fdjgdshfj";
        }
        private void SetText(List<order> orders)
        {

            //this.comboBox1.DataSource = orders;
            this.orders.Clear();
            List<order> ordersnew = new List<order>();
            //comboBox1.Items.Clear();
            ordersnew = dbhHandle.getOrders(branchId);
//            populate_Order(ordersnew);


            //this.orders = dbhHandle.getOrders(branchId);

            
        }
        public void populate_Order(List<order> newOrders)
        {/*
            this.comboBox1.Items.Clear();
            foreach (order o in newOrders)
            {
                comboBox1.Items.Add(o);
            }
            */
        }
        public void readData()
        
        {
          //  MessageBox.Show("yo");
            List<order> ordersnew = new List<order>();
            //comboBox1.Items.Clear();
            ordersnew = dbhHandle.getOrders(branchId);
           // populate_Order(ordersnew);
            this.comboBox1.Items.Clear();
            foreach (order o in ordersnew)
                comboBox1.Items.Add(o);



            //this.comboBox1.FormattingEnabled = true;

            
          /*  DataFeed df = new DataFeed();
            List<int> orderids = new List<int>();
            foreach(order o in orders)
                orderids.Add(o.Order_id);
             qtime = df.getBranchQueueTime(orderids);

             if (this.comboBox1.InvokeRequired)
             {
                 // It's on a different thread, so use Invoke.
                 SetTextCallback d = new SetTextCallback(SetText);
                 this.Invoke
                     (d, new object[] { orders});
             }
             else
             {
                 // It's on the same thread, no need for Invoke
                 this.comboBox1.Text =  " (No jhlllInvoke)";
                 this.comboBox1.DataSource = orders;
             }
            
//            
            */
           // MessageBox.Show("444");
        }
       /* public void fillcombo(List<order> orderslist)
        {
            comboBox2.Items.Clear();
            foreach (order o in orderslist)
            {

                comboBox2.Items.Add(o);
                comboBox2.ValueMember = o.Order_id.ToString();
                comboBox2.DisplayMember = o.Order_id.ToString();
            }
            

        }
        */
        private void readOrders()
        {
            
        }

        private void flowLayoutPanel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void btn_MarkAsCreated_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            //staffManagment.TextBox1.Text = "hello";
            
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            
            bool found = false;
            foreach (order o in orders)
            {
                order or = (order)(comboBox1.SelectedItem);
                if (o.Order_id == or.Order_id)
                {
                    
                    found = true;
                    displayOrder(o);
                }
                if (found)
                    break;


            }

            
        }
        public void displayOrder(order theOrder)
        {
            bool testRun = cbIsTestRun.Checked;
            txtBx_OrderNo.Text = theOrder.Order_id.ToString();
            txtBx_OrderDetails.Text = printOrderDetails(theOrder);
            
            if (testRun)
            {
                CustomerR customer = new CustomerR();
                customer = dbhHandle.getCustomerR(theOrder.Customer_id);
                txtBx_customerName.Text = customer.FirstName + "," + customer.LastName;
                txtBx_CustomerPhone.Text = customer.Telephone;
                txtBx_CustomerAddress.Text = customer.XCoordinate + "," + customer.YCoordinate;
            }
            else
            {
                Customer customer = new Customer();
                customer = dbhHandle.getCustomer(theOrder.Customer_id);
                txtBx_customerName.Text = customer.FirstName + "," + customer.LastName;
                txtBx_CustomerPhone.Text = customer.Telephone;
                txtBx_CustomerAddress.Text = customer.AddressLine1 + "\t\n"
                    + customer.AddressLine2 + "\t\n" + customer.City +"\t\n" + customer.County;

            }
            

        }
        public string printOrderDetails(order rder)
        {
            string details = "start Time :" + rder.Order_processing_startTime + "\r\n" + "Finish Time: " + rder.Order_processing_FinishTime;
            return details;

        }

        private void button2_Click(object sender, EventArgs e)
        {

        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {
            readData();
        }

        private void comboBox1_SelectedIndexChanged_1(object sender, EventArgs e)
        {

        }

        private void button4_Click_1(object sender, EventArgs e)
        {
        //    MessageBox.Show("yo", "m", MessageBoxButtons.OKCancel, MessageBoxIcon.Hand);
        }

        private void button5_Click(object sender, EventArgs e)
        {
            Console.WriteLine(this.Font.Size);
        }

        private void toolStripComboBox1_Click(object sender, EventArgs e)
        {

            if (toolStripComboBox1.SelectedIndex != 0)
            {

                System.Drawing.Font newfont;
                int choice = toolStripComboBox1.SelectedIndex;
                switch (choice)
                {
                    case 1:
                        newfont = new Font(this.Font.FontFamily, m.Size, m.Style); 
                        this.Font = newfont;
                        break;
                case 2:
                        newfont = new Font(this.Font.FontFamily, m.Size * 1.3f, m.Style);
                         
                        this.Font = newfont;
                        break;
                case 3:
                        newfont = new Font(this.Font.FontFamily, m.Size * 1.55f, m.Style);
                        
                        this.Font = newfont;
                        break;
                    default:
                        break;
                }
                

                
            }
        }

        private void toolStripLabel1_Click(object sender, EventArgs e)
        {

        }

        private void cbIsTestRun_CheckedChanged(object sender, EventArgs e)
        {
            if (cbIsTestRun.Checked)
            {
                notifyIcon1.BalloonTipText = "test";
                notifyIcon1.ShowBalloonTip(500);
                
                notifyIcon1.Visible = true;
            }
            notifyIcon1.Visible = false              ;
        }

        private void comboBox3_SelectedIndexChanged(object sender, EventArgs e)
        {
            Employee emp = (Employee)comboBox3.SelectedItem;
            tbEID.Text = emp.EmployeeId.ToString();
            tbEname.Text=emp.First_Name +","+emp.Last_name;
            if (emp.IsAvailable)
                tbEstatus.Text = "available";
            else
                tbEstatus.Text = "unavailable";
            
        }

        private void btnAvailability_Click(object sender, EventArgs e)
        {
            Employee emp = (Employee)comboBox3.SelectedItem;
            if (emp.IsAvailable)
            {
                tbEstatus.Text = "unavailable";
                dbhHandle.setStaffAs(emp.EmployeeId, emp.BranchId, "unavailable");
                foreach (Employee em in comboBox3.Items)
                {
                    if (em.EmployeeId == emp.EmployeeId)
                    {
                        em.IsAvailable = false;
                    }
                }
            }
            else
            {
                tbEstatus.Text = "available";
                dbhHandle.setStaffAs(emp.EmployeeId, emp.BranchId, "available");
                foreach (Employee em in comboBox3.Items)
                {
                    if (em.EmployeeId == emp.EmployeeId)
                    {
                        em.IsAvailable = true;
                    }
                }
            }
            //comboBox3.DataSource = emps;
        }

        private void button3_Click_1(object sender, EventArgs e)
        {
            Vehicle v = (Vehicle)cbVehicles.SelectedItem;
            if (v.IsAvailable)
            {

                tbVStatus.Text = "unavailable";
                dbhHandle.setVehicleAs(v.VehicleId, v.BranchId, "unavailable");
                foreach (Vehicle em in cbVehicles.Items)
                {
                    if (em.VehicleId == v.VehicleId)
                    {
                        em.IsAvailable = false;
                    }
                }
            }
            else
            {
                tbVStatus.Text = "available";
                dbhHandle.setStaffAs(v.VehicleId, v.BranchId, "available");
                foreach (Vehicle em in cbVehicles.Items)
                {
                    if (em.VehicleId == v.VehicleId)
                    {
                        em.IsAvailable = true;
                    }
                }
            }
        }

        private void cbVehicles_SelectedIndexChanged(object sender, EventArgs e)
        {
            Vehicle v = (Vehicle)cbVehicles.SelectedItem;
            tbVID.Text = v.VehicleId.ToString();
            tbVCapacity.Text = v.Capacity.ToString();
            if (v.IsAvailable)
                tbVStatus.Text = "available";
            else
                tbVStatus.Text = "unavailable";
        }

        private void button5_Click_1(object sender, EventArgs e)
        {
            if (bInfo.IsAvialable)
            {
                dbhHandle.setBranchAs(branchId, "unavailable");
                textBox1.Text = "unavailable";
                textBox2.Text = "unavailable";
                bInfo.IsAvialable = false;
            }
            else
            {
                dbhHandle.setBranchAs(branchId, "available");
                textBox1.Text = "available";
                textBox2.Text = "available";
                bInfo.IsAvialable = true;
            }
        }

        private void FormBranchMain_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            if(!(textBox1.Text=="available"))
                label17.ForeColor = Color.Red;
            else
                label17.ForeColor = Color.DarkGreen;
        }
    }
}
