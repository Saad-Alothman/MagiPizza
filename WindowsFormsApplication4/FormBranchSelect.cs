using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace WindowsFormsApplication4
{
    public partial class FormBranchSelect : Form
    {
        DBHandler dbh = new DBHandler();
        List<Branch> branches = new List<Branch>();

        public FormBranchSelect()
        {
            InitializeComponent();
            branches = dbh.getBranches();
            foreach (Branch b in branches)
            {
                comboBox1.Items.Add(b.Branch_id);

            }

            
        }

        private void button1_Click(object sender, EventArgs e)
        {
            FormBranchMain bm = new FormBranchMain((int)comboBox1.SelectedItem); 
            //FormBranchMain bm = new FormBranchMain(int.Parse(comboBox1.Text));//delete this
            bm.Show();
            this.Hide();
            //this.Dispose();
        }

        private void FormBranchSelect_Load(object sender, EventArgs e)
        {

        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}
