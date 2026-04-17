using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace J_Gentry_206_lab_2
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void cityBindingNavigatorSaveItem_Click(object sender, EventArgs e)
        {
            this.Validate();
            this.cityBindingSource.EndEdit();
            this.tableAdapterManager.UpdateAll(this.cityDBDataSet);

        }

        private void Form1_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'cityDBDataSet.City' table. You can move, or remove it, as needed.
            this.cityTableAdapter.Fill(this.cityDBDataSet.City);

        }
        private void TotalPopAverage()
        {
            //total and average methods
            decimal total = 0;
            int count = cityBindingSource.Count;
            foreach (DataRowView row in cityBindingSource)
            {
                total += Convert.ToDecimal(row["Population"]);
            }
            decimal average = total / count;
            lblOutputTotal.Text = total.ToString("N0");
            lblOutputAver.Text = average.ToString("N0");
        }
        private void HighestLowest()
        {
            //the highest and lowest population methods
            decimal highest = 0;
            decimal lowest = decimal.MaxValue;
            foreach (DataRowView row in cityBindingSource)
            {
                decimal pop = Convert.ToDecimal(row["Population"]);
                if (pop > highest)
                    highest = pop;
                if (pop < lowest)
                    lowest = pop;
            }
            lblOutputHigh.Text = highest.ToString("N0");
            lblOutputLow.Text = lowest.ToString("N0");
        }

        private void butSortAscen_Click_1(object sender, EventArgs e)
        {
            //ascending order sort
            cityBindingSource.Sort = "Population ASC";
        }

        private void butSortDescen_Click_1(object sender, EventArgs e)
        {
            //descending order sort
            cityBindingSource.Sort = "Population DESC";
        }


        private void butCal_Click(object sender, EventArgs e)
        {
            try
            {

                TotalPopAverage();
                HighestLowest();
            }
            catch
            {
                MessageBox.Show("Error Please Try Again!");
            }
        }

        private void butSortCity_Click(object sender, EventArgs e)
        {
            //city ascending order sort
            cityBindingSource.Sort = "City ASC";
        }

        private void butClear_Click(object sender, EventArgs e)
        {
            //clears the label output
            foreach (Control c in this.Controls)
            {
                if (c is Label && c.Name.StartsWith("lblOutput"))
                {
                    c.Text = "";
                }
            }
        }

        private void butExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
