using StateDatabase.DataAccess;
using System;
using System.Drawing;
using System.Windows.Forms;
using StateClassLibrary;
using static System.Net.Mime.MediaTypeNames;
using static System.Windows.Forms.LinkLabel;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace StateDatabase
{
    public partial class StateDetailsForm : Form
    {
        public StateDetailsForm(State state)
        {
            InitializeComponent();
            LoadStateDetails(state);
        }

        private void LoadStateDetails(State state)
        {
            if (state == null)
            {
                MessageBox.Show("Invalid state data.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                this.Close();
                return;
            }

            this.Text = $"State Details - {state.StateName}";
            txtStateName.Text = state.StateName;
            txtPopulation.Text = state.Population.ToString("N0");
            txtCapitol.Text = state.StateCapitol;
            txtFlower.Text = state.StateFlower;
            txtBird.Text = state.StateBird;
            txtColors.Text = state.StateColors;
            txtCity1.Text = state.LargestCity1;
            txtCity2.Text = state.LargestCity2;
            txtCity3.Text = state.LargestCity3;
            txtMedianIncome.Text = state.MedianIncome.ToString("C0");
            txtComputerJobs.Text = state.ComputerJobsPercentage.ToString("N2") + "%";
            txtFlagDescription.Text = state.FlagDescription;
        }

        private void btnClose_Click_1(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
