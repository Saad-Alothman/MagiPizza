using MagiPizza.Domain.Models;

namespace WindowsFormsApplication4
{
    partial class FormBranchMain
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.txtBx_OrderNo = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.txtBx_OrderDetails = new System.Windows.Forms.TextBox();
            this.txtBx_customerName = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.txtBx_CustomerPhone = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.txtBx_Status = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.txtBx_CustomerAddress = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.txt_pnlBranchAddress = new System.Windows.Forms.TextBox();
            this.label17 = new System.Windows.Forms.Label();
            this.txt_pnlBranchID = new System.Windows.Forms.TextBox();
            this.txtBx_NumberOfVehicile = new System.Windows.Forms.TextBox();
            this.txtBx_NumberOfStaff = new System.Windows.Forms.TextBox();
            this.label13 = new System.Windows.Forms.Label();
            this.label14 = new System.Windows.Forms.Label();
            this.cbIsTestRun = new System.Windows.Forms.CheckBox();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.panel2 = new System.Windows.Forms.Panel();
            this.orderBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.comboBox1 = new System.Windows.Forms.ComboBox();
            this.label16 = new System.Windows.Forms.Label();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.textBox2 = new System.Windows.Forms.TextBox();
            this.button5 = new System.Windows.Forms.Button();
            this.textBox5 = new System.Windows.Forms.TextBox();
            this.textBox4 = new System.Windows.Forms.TextBox();
            this.label9 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.tabPage3 = new System.Windows.Forms.TabPage();
            this.comboBox3 = new System.Windows.Forms.ComboBox();
            this.employeeBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.tbEstatus = new System.Windows.Forms.TextBox();
            this.label18 = new System.Windows.Forms.Label();
            this.label19 = new System.Windows.Forms.Label();
            this.label20 = new System.Windows.Forms.Label();
            this.label21 = new System.Windows.Forms.Label();
            this.tbEname = new System.Windows.Forms.TextBox();
            this.tbEID = new System.Windows.Forms.TextBox();
            this.btnAvailability = new System.Windows.Forms.Button();
            this.tabPage4 = new System.Windows.Forms.TabPage();
            this.cbVehicles = new System.Windows.Forms.ComboBox();
            this.vehicleBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.tbVStatus = new System.Windows.Forms.TextBox();
            this.label25 = new System.Windows.Forms.Label();
            this.label24 = new System.Windows.Forms.Label();
            this.label23 = new System.Windows.Forms.Label();
            this.label22 = new System.Windows.Forms.Label();
            this.tbVCapacity = new System.Windows.Forms.TextBox();
            this.tbVID = new System.Windows.Forms.TextBox();
            this.button3 = new System.Windows.Forms.Button();
            this.orderBindingSource1 = new System.Windows.Forms.BindingSource(this.components);
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.toolStripComboBox1 = new System.Windows.Forms.ToolStripComboBox();
            this.notifyIcon1 = new System.Windows.Forms.NotifyIcon(this.components);
            this.panel1.SuspendLayout();
            this.tabControl1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.orderBindingSource)).BeginInit();
            this.tabPage2.SuspendLayout();
            this.tabPage3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.employeeBindingSource)).BeginInit();
            this.tabPage4.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.vehicleBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.orderBindingSource1)).BeginInit();
            this.toolStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // txtBx_OrderNo
            // 
            this.txtBx_OrderNo.Enabled = false;
            this.txtBx_OrderNo.Location = new System.Drawing.Point(94, 193);
            this.txtBx_OrderNo.Name = "txtBx_OrderNo";
            this.txtBx_OrderNo.Size = new System.Drawing.Size(144, 20);
            this.txtBx_OrderNo.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(3, 199);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(76, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "Order Number:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(3, 227);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(68, 13);
            this.label2.TabIndex = 3;
            this.label2.Text = "Order Details";
            // 
            // txtBx_OrderDetails
            // 
            this.txtBx_OrderDetails.Enabled = false;
            this.txtBx_OrderDetails.Location = new System.Drawing.Point(94, 219);
            this.txtBx_OrderDetails.Multiline = true;
            this.txtBx_OrderDetails.Name = "txtBx_OrderDetails";
            this.txtBx_OrderDetails.Size = new System.Drawing.Size(144, 88);
            this.txtBx_OrderDetails.TabIndex = 2;
            // 
            // txtBx_customerName
            // 
            this.txtBx_customerName.Enabled = false;
            this.txtBx_customerName.Location = new System.Drawing.Point(94, 76);
            this.txtBx_customerName.Name = "txtBx_customerName";
            this.txtBx_customerName.Size = new System.Drawing.Size(144, 20);
            this.txtBx_customerName.TabIndex = 0;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(3, 76);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(85, 13);
            this.label3.TabIndex = 1;
            this.label3.Text = "Customer Name:";
            // 
            // txtBx_CustomerPhone
            // 
            this.txtBx_CustomerPhone.Enabled = false;
            this.txtBx_CustomerPhone.Location = new System.Drawing.Point(94, 102);
            this.txtBx_CustomerPhone.Name = "txtBx_CustomerPhone";
            this.txtBx_CustomerPhone.Size = new System.Drawing.Size(144, 20);
            this.txtBx_CustomerPhone.TabIndex = 2;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(3, 104);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(85, 13);
            this.label4.TabIndex = 3;
            this.label4.Text = "Customer Phone";
            // 
            // txtBx_Status
            // 
            this.txtBx_Status.Enabled = false;
            this.txtBx_Status.Location = new System.Drawing.Point(94, 313);
            this.txtBx_Status.Name = "txtBx_Status";
            this.txtBx_Status.Size = new System.Drawing.Size(144, 20);
            this.txtBx_Status.TabIndex = 2;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(3, 313);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(66, 13);
            this.label5.TabIndex = 3;
            this.label5.Text = "Order Status";
            // 
            // txtBx_CustomerAddress
            // 
            this.txtBx_CustomerAddress.Enabled = false;
            this.txtBx_CustomerAddress.Location = new System.Drawing.Point(94, 128);
            this.txtBx_CustomerAddress.Multiline = true;
            this.txtBx_CustomerAddress.Name = "txtBx_CustomerAddress";
            this.txtBx_CustomerAddress.Size = new System.Drawing.Size(144, 59);
            this.txtBx_CustomerAddress.TabIndex = 2;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(3, 132);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(45, 13);
            this.label6.TabIndex = 3;
            this.label6.Text = "Address";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(1, 7);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(53, 13);
            this.label7.TabIndex = 5;
            this.label7.Text = "Branch Id";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(1, 33);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(82, 13);
            this.label8.TabIndex = 6;
            this.label8.Text = "Branch Address";
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.Silver;
            this.panel1.Controls.Add(this.textBox1);
            this.panel1.Controls.Add(this.txt_pnlBranchAddress);
            this.panel1.Controls.Add(this.label17);
            this.panel1.Controls.Add(this.txt_pnlBranchID);
            this.panel1.Controls.Add(this.label7);
            this.panel1.Controls.Add(this.label8);
            this.panel1.Controls.Add(this.txtBx_NumberOfVehicile);
            this.panel1.Controls.Add(this.txtBx_NumberOfStaff);
            this.panel1.Controls.Add(this.label13);
            this.panel1.Controls.Add(this.label14);
            this.panel1.Location = new System.Drawing.Point(1, 29);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(403, 77);
            this.panel1.TabIndex = 7;
            this.panel1.Paint += new System.Windows.Forms.PaintEventHandler(this.panel1_Paint);
            // 
            // textBox1
            // 
            this.textBox1.Enabled = false;
            this.textBox1.Location = new System.Drawing.Point(98, 52);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(100, 20);
            this.textBox1.TabIndex = 14;
            this.textBox1.TextChanged += new System.EventHandler(this.textBox1_TextChanged);
            // 
            // txt_pnlBranchAddress
            // 
            this.txt_pnlBranchAddress.Enabled = false;
            this.txt_pnlBranchAddress.Location = new System.Drawing.Point(98, 30);
            this.txt_pnlBranchAddress.Name = "txt_pnlBranchAddress";
            this.txt_pnlBranchAddress.Size = new System.Drawing.Size(100, 20);
            this.txt_pnlBranchAddress.TabIndex = 9;
            // 
            // label17
            // 
            this.label17.AutoSize = true;
            this.label17.Location = new System.Drawing.Point(1, 55);
            this.label17.Name = "label17";
            this.label17.Size = new System.Drawing.Size(71, 13);
            this.label17.TabIndex = 13;
            this.label17.Text = "branch status";
            // 
            // txt_pnlBranchID
            // 
            this.txt_pnlBranchID.Enabled = false;
            this.txt_pnlBranchID.Location = new System.Drawing.Point(98, 4);
            this.txt_pnlBranchID.Name = "txt_pnlBranchID";
            this.txt_pnlBranchID.Size = new System.Drawing.Size(100, 20);
            this.txt_pnlBranchID.TabIndex = 8;
            // 
            // txtBx_NumberOfVehicile
            // 
            this.txtBx_NumberOfVehicile.Enabled = false;
            this.txtBx_NumberOfVehicile.Location = new System.Drawing.Point(340, 30);
            this.txtBx_NumberOfVehicile.Name = "txtBx_NumberOfVehicile";
            this.txtBx_NumberOfVehicile.Size = new System.Drawing.Size(52, 20);
            this.txtBx_NumberOfVehicile.TabIndex = 9;
            // 
            // txtBx_NumberOfStaff
            // 
            this.txtBx_NumberOfStaff.Enabled = false;
            this.txtBx_NumberOfStaff.Location = new System.Drawing.Point(340, 4);
            this.txtBx_NumberOfStaff.Name = "txtBx_NumberOfStaff";
            this.txtBx_NumberOfStaff.Size = new System.Drawing.Size(52, 20);
            this.txtBx_NumberOfStaff.TabIndex = 8;
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Location = new System.Drawing.Point(222, 33);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(96, 13);
            this.label13.TabIndex = 6;
            this.label13.Text = "number of vehicles";
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Location = new System.Drawing.Point(236, 7);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(77, 13);
            this.label14.TabIndex = 5;
            this.label14.Text = "number of staff";
            // 
            // cbIsTestRun
            // 
            this.cbIsTestRun.AutoSize = true;
            this.cbIsTestRun.Location = new System.Drawing.Point(226, 0);
            this.cbIsTestRun.Name = "cbIsTestRun";
            this.cbIsTestRun.Size = new System.Drawing.Size(141, 17);
            this.cbIsTestRun.TabIndex = 11;
            this.cbIsTestRun.Text = "this is a part of a test run";
            this.cbIsTestRun.UseVisualStyleBackColor = true;
            this.cbIsTestRun.CheckedChanged += new System.EventHandler(this.cbIsTestRun_CheckedChanged);
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Controls.Add(this.tabPage2);
            this.tabControl1.Controls.Add(this.tabPage3);
            this.tabControl1.Controls.Add(this.tabPage4);
            this.tabControl1.HotTrack = true;
            this.tabControl1.Location = new System.Drawing.Point(12, 112);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(403, 376);
            this.tabControl1.TabIndex = 8;
            // 
            // tabPage1
            // 
            this.tabPage1.BackColor = System.Drawing.Color.WhiteSmoke;
            this.tabPage1.Controls.Add(this.panel2);
            this.tabPage1.Controls.Add(this.txtBx_customerName);
            this.tabPage1.Controls.Add(this.txtBx_OrderNo);
            this.tabPage1.Controls.Add(this.label6);
            this.tabPage1.Controls.Add(this.label1);
            this.tabPage1.Controls.Add(this.label5);
            this.tabPage1.Controls.Add(this.label3);
            this.tabPage1.Controls.Add(this.label4);
            this.tabPage1.Controls.Add(this.txtBx_OrderDetails);
            this.tabPage1.Controls.Add(this.label2);
            this.tabPage1.Controls.Add(this.txtBx_CustomerPhone);
            this.tabPage1.Controls.Add(this.txtBx_CustomerAddress);
            this.tabPage1.Controls.Add(this.txtBx_Status);
            this.tabPage1.Location = new System.Drawing.Point(4, 22);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(395, 350);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "orders";
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.comboBox1);
            this.panel2.Controls.Add(this.label16);
            this.panel2.Location = new System.Drawing.Point(4, 4);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(384, 66);
            this.panel2.TabIndex = 4;
            // 
            // orderBindingSource
            // 
            this.orderBindingSource.DataSource = typeof(order);
            // 
            // comboBox1
            // 
            this.comboBox1.DisplayMember = "Order_id";
            this.comboBox1.FormattingEnabled = true;
            this.comboBox1.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.comboBox1.Location = new System.Drawing.Point(123, 6);
            this.comboBox1.Name = "comboBox1";
            this.comboBox1.Size = new System.Drawing.Size(121, 21);
            this.comboBox1.TabIndex = 0;
            this.comboBox1.ValueMember = "Order_id";
            this.comboBox1.SelectedIndexChanged += new System.EventHandler(this.comboBox1_SelectedIndexChanged);
            // 
            // label16
            // 
            this.label16.AutoSize = true;
            this.label16.Location = new System.Drawing.Point(2, 9);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(115, 13);
            this.label16.TabIndex = 1;
            this.label16.Text = "List of Available Orders";
            // 
            // tabPage2
            // 
            this.tabPage2.BackColor = System.Drawing.Color.WhiteSmoke;
            this.tabPage2.Controls.Add(this.textBox2);
            this.tabPage2.Controls.Add(this.button5);
            this.tabPage2.Controls.Add(this.textBox5);
            this.tabPage2.Controls.Add(this.textBox4);
            this.tabPage2.Controls.Add(this.label9);
            this.tabPage2.Controls.Add(this.label11);
            this.tabPage2.Controls.Add(this.label10);
            this.tabPage2.Location = new System.Drawing.Point(4, 22);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(395, 350);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "store Details";
            // 
            // textBox2
            // 
            this.textBox2.Enabled = false;
            this.textBox2.Location = new System.Drawing.Point(147, 136);
            this.textBox2.Name = "textBox2";
            this.textBox2.Size = new System.Drawing.Size(100, 20);
            this.textBox2.TabIndex = 17;
            // 
            // button5
            // 
            this.button5.Location = new System.Drawing.Point(270, 133);
            this.button5.Name = "button5";
            this.button5.Size = new System.Drawing.Size(107, 27);
            this.button5.TabIndex = 16;
            this.button5.Text = "Toggle status";
            this.button5.UseVisualStyleBackColor = true;
            this.button5.Click += new System.EventHandler(this.button5_Click_1);
            // 
            // textBox5
            // 
            this.textBox5.Enabled = false;
            this.textBox5.Location = new System.Drawing.Point(147, 45);
            this.textBox5.Multiline = true;
            this.textBox5.Name = "textBox5";
            this.textBox5.Size = new System.Drawing.Size(151, 72);
            this.textBox5.TabIndex = 9;
            // 
            // textBox4
            // 
            this.textBox4.Enabled = false;
            this.textBox4.Location = new System.Drawing.Point(147, 19);
            this.textBox4.Name = "textBox4";
            this.textBox4.Size = new System.Drawing.Size(100, 20);
            this.textBox4.TabIndex = 8;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(9, 140);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(72, 13);
            this.label9.TabIndex = 7;
            this.label9.Text = "Branch status";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(9, 23);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(53, 13);
            this.label11.TabIndex = 5;
            this.label11.Text = "Branch Id";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(7, 49);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(82, 13);
            this.label10.TabIndex = 6;
            this.label10.Text = "Branch Address";
            // 
            // tabPage3
            // 
            this.tabPage3.Controls.Add(this.comboBox3);
            this.tabPage3.Controls.Add(this.tbEstatus);
            this.tabPage3.Controls.Add(this.label18);
            this.tabPage3.Controls.Add(this.label19);
            this.tabPage3.Controls.Add(this.label20);
            this.tabPage3.Controls.Add(this.label21);
            this.tabPage3.Controls.Add(this.tbEname);
            this.tabPage3.Controls.Add(this.tbEID);
            this.tabPage3.Controls.Add(this.btnAvailability);
            this.tabPage3.Location = new System.Drawing.Point(4, 22);
            this.tabPage3.Name = "tabPage3";
            this.tabPage3.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage3.Size = new System.Drawing.Size(395, 350);
            this.tabPage3.TabIndex = 2;
            this.tabPage3.Text = "Staff Managment";
            this.tabPage3.UseVisualStyleBackColor = true;
            // 
            // comboBox3
            // 
            this.comboBox3.DataSource = this.employeeBindingSource;
            this.comboBox3.DisplayMember = "First_Name";
            this.comboBox3.FormattingEnabled = true;
            this.comboBox3.Location = new System.Drawing.Point(96, 6);
            this.comboBox3.Name = "comboBox3";
            this.comboBox3.Size = new System.Drawing.Size(100, 21);
            this.comboBox3.TabIndex = 15;
            this.comboBox3.ValueMember = "EmployeeId";
            this.comboBox3.SelectedIndexChanged += new System.EventHandler(this.comboBox3_SelectedIndexChanged);
            // 
            // employeeBindingSource
            // 
            this.employeeBindingSource.DataSource = typeof(Employee);
            // 
            // tbEstatus
            // 
            this.tbEstatus.Enabled = false;
            this.tbEstatus.Location = new System.Drawing.Point(96, 89);
            this.tbEstatus.Name = "tbEstatus";
            this.tbEstatus.Size = new System.Drawing.Size(100, 20);
            this.tbEstatus.TabIndex = 14;
            // 
            // label18
            // 
            this.label18.AutoSize = true;
            this.label18.Location = new System.Drawing.Point(6, 92);
            this.label18.Name = "label18";
            this.label18.Size = new System.Drawing.Size(37, 13);
            this.label18.TabIndex = 12;
            this.label18.Text = "Status";
            // 
            // label19
            // 
            this.label19.AutoSize = true;
            this.label19.Location = new System.Drawing.Point(6, 65);
            this.label19.Name = "label19";
            this.label19.Size = new System.Drawing.Size(84, 13);
            this.label19.TabIndex = 13;
            this.label19.Text = "Employee Name";
            // 
            // label20
            // 
            this.label20.AutoSize = true;
            this.label20.Location = new System.Drawing.Point(6, 9);
            this.label20.Name = "label20";
            this.label20.Size = new System.Drawing.Size(57, 13);
            this.label20.TabIndex = 11;
            this.label20.Text = "Store Staff";
            // 
            // label21
            // 
            this.label21.AutoSize = true;
            this.label21.Location = new System.Drawing.Point(6, 39);
            this.label21.Name = "label21";
            this.label21.Size = new System.Drawing.Size(67, 13);
            this.label21.TabIndex = 10;
            this.label21.Text = "Employee ID";
            // 
            // tbEname
            // 
            this.tbEname.Enabled = false;
            this.tbEname.Location = new System.Drawing.Point(96, 62);
            this.tbEname.Name = "tbEname";
            this.tbEname.Size = new System.Drawing.Size(100, 20);
            this.tbEname.TabIndex = 9;
            // 
            // tbEID
            // 
            this.tbEID.Enabled = false;
            this.tbEID.Location = new System.Drawing.Point(96, 36);
            this.tbEID.Name = "tbEID";
            this.tbEID.Size = new System.Drawing.Size(100, 20);
            this.tbEID.TabIndex = 8;
            // 
            // btnAvailability
            // 
            this.btnAvailability.Location = new System.Drawing.Point(202, 87);
            this.btnAvailability.Name = "btnAvailability";
            this.btnAvailability.Size = new System.Drawing.Size(111, 23);
            this.btnAvailability.TabIndex = 7;
            this.btnAvailability.Text = "Toggle Availability\r\n";
            this.btnAvailability.UseVisualStyleBackColor = true;
            this.btnAvailability.Click += new System.EventHandler(this.btnAvailability_Click);
            // 
            // tabPage4
            // 
            this.tabPage4.Controls.Add(this.cbVehicles);
            this.tabPage4.Controls.Add(this.tbVStatus);
            this.tabPage4.Controls.Add(this.label25);
            this.tabPage4.Controls.Add(this.label24);
            this.tabPage4.Controls.Add(this.label23);
            this.tabPage4.Controls.Add(this.label22);
            this.tabPage4.Controls.Add(this.tbVCapacity);
            this.tabPage4.Controls.Add(this.tbVID);
            this.tabPage4.Controls.Add(this.button3);
            this.tabPage4.Location = new System.Drawing.Point(4, 22);
            this.tabPage4.Name = "tabPage4";
            this.tabPage4.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage4.Size = new System.Drawing.Size(395, 350);
            this.tabPage4.TabIndex = 3;
            this.tabPage4.Text = "Vehicles Managment";
            this.tabPage4.UseVisualStyleBackColor = true;
            // 
            // cbVehicles
            // 
            this.cbVehicles.DataSource = this.vehicleBindingSource;
            this.cbVehicles.DisplayMember = "VehicleId";
            this.cbVehicles.FormattingEnabled = true;
            this.cbVehicles.Location = new System.Drawing.Point(116, 15);
            this.cbVehicles.Name = "cbVehicles";
            this.cbVehicles.Size = new System.Drawing.Size(100, 21);
            this.cbVehicles.TabIndex = 24;
            this.cbVehicles.ValueMember = "VehicleId";
            this.cbVehicles.SelectedIndexChanged += new System.EventHandler(this.cbVehicles_SelectedIndexChanged);
            // 
            // vehicleBindingSource
            // 
            this.vehicleBindingSource.DataSource = typeof(Vehicle);
            // 
            // tbVStatus
            // 
            this.tbVStatus.Enabled = false;
            this.tbVStatus.Location = new System.Drawing.Point(116, 98);
            this.tbVStatus.Name = "tbVStatus";
            this.tbVStatus.Size = new System.Drawing.Size(100, 20);
            this.tbVStatus.TabIndex = 23;
            // 
            // label25
            // 
            this.label25.AutoSize = true;
            this.label25.Location = new System.Drawing.Point(26, 101);
            this.label25.Name = "label25";
            this.label25.Size = new System.Drawing.Size(37, 13);
            this.label25.TabIndex = 21;
            this.label25.Text = "Status";
            // 
            // label24
            // 
            this.label24.AutoSize = true;
            this.label24.Location = new System.Drawing.Point(26, 74);
            this.label24.Name = "label24";
            this.label24.Size = new System.Drawing.Size(86, 13);
            this.label24.TabIndex = 22;
            this.label24.Text = "Vehicle Capacity";
            // 
            // label23
            // 
            this.label23.AutoSize = true;
            this.label23.Location = new System.Drawing.Point(26, 18);
            this.label23.Name = "label23";
            this.label23.Size = new System.Drawing.Size(75, 13);
            this.label23.TabIndex = 20;
            this.label23.Text = "Store Vehicles";
            // 
            // label22
            // 
            this.label22.AutoSize = true;
            this.label22.Location = new System.Drawing.Point(26, 48);
            this.label22.Name = "label22";
            this.label22.Size = new System.Drawing.Size(56, 13);
            this.label22.TabIndex = 19;
            this.label22.Text = "Vehicle ID";
            // 
            // tbVCapacity
            // 
            this.tbVCapacity.Enabled = false;
            this.tbVCapacity.Location = new System.Drawing.Point(116, 71);
            this.tbVCapacity.Name = "tbVCapacity";
            this.tbVCapacity.Size = new System.Drawing.Size(100, 20);
            this.tbVCapacity.TabIndex = 18;
            // 
            // tbVID
            // 
            this.tbVID.Enabled = false;
            this.tbVID.Location = new System.Drawing.Point(116, 45);
            this.tbVID.Name = "tbVID";
            this.tbVID.Size = new System.Drawing.Size(100, 20);
            this.tbVID.TabIndex = 17;
            // 
            // button3
            // 
            this.button3.Location = new System.Drawing.Point(222, 96);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(111, 23);
            this.button3.TabIndex = 16;
            this.button3.Text = "Toggle Availability\r\n";
            this.button3.UseVisualStyleBackColor = true;
            this.button3.Click += new System.EventHandler(this.button3_Click_1);
            // 
            // orderBindingSource1
            // 
            this.orderBindingSource1.DataSource = typeof(order);
            // 
            // toolStrip1
            // 
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripComboBox1});
            this.toolStrip1.Location = new System.Drawing.Point(0, 0);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(405, 25);
            this.toolStrip1.TabIndex = 13;
            this.toolStrip1.Text = "toolStrip1";
            // 
            // toolStripComboBox1
            // 
            this.toolStripComboBox1.Items.AddRange(new object[] {
            "change Font Size",
            "small",
            "medium",
            "large"});
            this.toolStripComboBox1.Name = "toolStripComboBox1";
            this.toolStripComboBox1.Size = new System.Drawing.Size(121, 25);
            this.toolStripComboBox1.SelectedIndexChanged += new System.EventHandler(this.toolStripComboBox1_Click);
            // 
            // notifyIcon1
            // 
            this.notifyIcon1.Text = "notifyIcon1";
            this.notifyIcon1.Visible = true;
            // 
            // FormBranchMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(405, 505);
            this.Controls.Add(this.cbIsTestRun);
            this.Controls.Add(this.toolStrip1);
            this.Controls.Add(this.tabControl1);
            this.Controls.Add(this.panel1);
            this.Name = "FormBranchMain";
            this.Text = "Magi Pizza";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.FormBranchMain_FormClosed);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.tabControl1.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.tabPage1.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.orderBindingSource)).EndInit();
            this.tabPage2.ResumeLayout(false);
            this.tabPage2.PerformLayout();
            this.tabPage3.ResumeLayout(false);
            this.tabPage3.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.employeeBindingSource)).EndInit();
            this.tabPage4.ResumeLayout(false);
            this.tabPage4.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.vehicleBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.orderBindingSource1)).EndInit();
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox txtBx_OrderNo;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtBx_OrderDetails;
        private System.Windows.Forms.TextBox txtBx_customerName;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtBx_CustomerPhone;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txtBx_Status;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox txtBx_CustomerAddress;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.ComboBox comboBox1;
        private System.Windows.Forms.Label label16;
        private System.Windows.Forms.TextBox txt_pnlBranchAddress;
        private System.Windows.Forms.TextBox txt_pnlBranchID;
        private System.Windows.Forms.TextBox textBox5;
        private System.Windows.Forms.TextBox textBox4;
        private System.Windows.Forms.TextBox txtBx_NumberOfVehicile;
        private System.Windows.Forms.TextBox txtBx_NumberOfStaff;
        private System.Windows.Forms.BindingSource orderBindingSource;
        private System.Windows.Forms.BindingSource orderBindingSource1;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Label label17;
        private System.Windows.Forms.CheckBox cbIsTestRun;
        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripComboBox toolStripComboBox1;
        private System.Windows.Forms.NotifyIcon notifyIcon1;
        private System.Windows.Forms.TabPage tabPage3;
        private System.Windows.Forms.ComboBox comboBox3;
        private System.Windows.Forms.TextBox tbEstatus;
        private System.Windows.Forms.Label label18;
        private System.Windows.Forms.Label label19;
        private System.Windows.Forms.Label label20;
        private System.Windows.Forms.Label label21;
        private System.Windows.Forms.TextBox tbEname;
        private System.Windows.Forms.TextBox tbEID;
        private System.Windows.Forms.Button btnAvailability;
        private System.Windows.Forms.BindingSource employeeBindingSource;
        private System.Windows.Forms.TabPage tabPage4;
        private System.Windows.Forms.ComboBox cbVehicles;
        private System.Windows.Forms.TextBox tbVStatus;
        private System.Windows.Forms.Label label25;
        private System.Windows.Forms.Label label24;
        private System.Windows.Forms.Label label23;
        private System.Windows.Forms.Label label22;
        private System.Windows.Forms.TextBox tbVCapacity;
        private System.Windows.Forms.TextBox tbVID;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.BindingSource vehicleBindingSource;
        private System.Windows.Forms.TextBox textBox2;
        private System.Windows.Forms.Button button5;
        private System.Windows.Forms.Label label9;
    }
}

