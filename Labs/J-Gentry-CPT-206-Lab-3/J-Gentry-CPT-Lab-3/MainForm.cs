using System;
using System.Configuration;
using System.Windows.Forms;
using StateClassLibrary;
using StateDatabase.DataAccess;

namespace StateDatabase
{
    public partial class MainForm : Form
    {
        private StateRepository _repository;

        public MainForm()
        {
            InitializeComponent();
            InitializeDatabase();
            LoadStates();
            SetupDataGridView();
        }

        private void InitializeDatabase()
        {
            try
            {
                string connectionString = ConfigurationManager.ConnectionStrings["StateDatabase"]?.ConnectionString;

                if (string.IsNullOrEmpty(connectionString))
                {
                    connectionString = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=|DataDirectory|\StateDatabase.mdf;Integrated Security=True";
                }

                _repository = new StateRepository(connectionString);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error initializing database: " + ex.Message, "Database Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                Application.Exit();
            }
        }

        private void SetupDataGridView()
        {
            dgvStates.AutoGenerateColumns = false;
            dgvStates.Columns.Clear();

            dgvStates.Columns.Add(new DataGridViewTextBoxColumn
            {
                DataPropertyName = "StateId",
                HeaderText = "ID",
                Width = 50,
                Visible = false
            });

            dgvStates.Columns.Add(new DataGridViewTextBoxColumn
            {
                DataPropertyName = "StateName",
                HeaderText = "State Name",
                Width = 150
            });

            dgvStates.Columns.Add(new DataGridViewTextBoxColumn
            {
                DataPropertyName = "Population",
                HeaderText = "Population",
                Width = 100,
                DefaultCellStyle = new DataGridViewCellStyle { Format = "N0" }
            });

            dgvStates.Columns.Add(new DataGridViewTextBoxColumn
            {
                DataPropertyName = "StateCapitol",
                HeaderText = "Capitol",
                Width = 120
            });

            dgvStates.Columns.Add(new DataGridViewTextBoxColumn
            {
                DataPropertyName = "MedianIncome",
                HeaderText = "Median Income",
                Width = 120,
                DefaultCellStyle = new DataGridViewCellStyle { Format = "C0" }
            });

            dgvStates.Columns.Add(new DataGridViewTextBoxColumn
            {
                DataPropertyName = "ComputerJobsPercentage",
                HeaderText = "Computer Jobs %",
                Width = 130,
                DefaultCellStyle = new DataGridViewCellStyle { Format = "N2" }
            });

            dgvStates.Columns.Add(new DataGridViewTextBoxColumn
            {
                DataPropertyName = "StateFlower",
                HeaderText = "State Flower",
                Width = 150
            });

            dgvStates.Columns.Add(new DataGridViewTextBoxColumn
            {
                DataPropertyName = "StateBird",
                HeaderText = "State Bird",
                Width = 150
            });

            // Enable sorting
            foreach (DataGridViewColumn column in dgvStates.Columns)
            {
                column.SortMode = DataGridViewColumnSortMode.Automatic;
            }
        }

        private void LoadStates()
        {
            try
            {
                var states = _repository.GetAllStates();
                dgvStates.DataSource = states;

                if (states.Count == 0)
                {
                    MessageBox.Show("No states found in the database. Click 'Add New State' to add states.",
                        "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error loading states: " + ex.Message, "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

   

        
        private void btnAddNew_Click_1(object sender, EventArgs e)
        {
            AddEditStateForm form = new AddEditStateForm(_repository);
            if (form.ShowDialog() == DialogResult.OK)
            {
                LoadStates();
            }
        }

        private void btnEdit_Click_1(object sender, EventArgs e)
        {
            if (dgvStates.SelectedRows.Count == 0)
            {
                MessageBox.Show("Please select a state to edit.", "Validation",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            State selectedState = (State)dgvStates.SelectedRows[0].DataBoundItem;
            AddEditStateForm form = new AddEditStateForm(_repository, selectedState);

            if (form.ShowDialog() == DialogResult.OK)
            {
                LoadStates();
            }
        }

        private void btnDelete_Click_1(object sender, EventArgs e)
        {
            if (dgvStates.SelectedRows.Count == 0)
            {
                MessageBox.Show("Please select a state to delete.", "Validation",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            State selectedState = (State)dgvStates.SelectedRows[0].DataBoundItem;

            DialogResult result = MessageBox.Show(
                $"Are you sure you want to delete {selectedState.StateName}?",
                "Confirm Delete",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question);

            if (result == DialogResult.Yes)
            {
                try
                {
                    _repository.DeleteState(selectedState.StateId);
                    MessageBox.Show("State deleted successfully.", "Success",
                        MessageBoxButtons.OK, MessageBoxIcon.Information);
                    LoadStates();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error deleting state: " + ex.Message, "Error",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void btnRefresh_Click_1(object sender, EventArgs e)
        {
            LoadStates();
            txtSearch.Clear();
        }

        private void btnView_Click_1(object sender, EventArgs e)
        {
            if (dgvStates.SelectedRows.Count == 0)
            {
                MessageBox.Show("Please select a state to view.", "Validation",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            State selectedState = (State)dgvStates.SelectedRows[0].DataBoundItem;
            StateDetailsForm detailsForm = new StateDetailsForm(selectedState);
            detailsForm.ShowDialog();
        }

        private void btnClear_Click_1(object sender, EventArgs e)
        {
            txtSearch.Clear();
            LoadStates();
        }

        private void btnSearch_Click_1(object sender, EventArgs e)
        {
            try
            {
                string searchTerm = txtSearch.Text.Trim();

                if (string.IsNullOrWhiteSpace(searchTerm))
                {
                    MessageBox.Show("Please enter a search term.", "Validation",
                        MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                var results = _repository.SearchStates(searchTerm);
                dgvStates.DataSource = results;

                if (results.Count == 0)
                {
                    MessageBox.Show("No states found matching your search criteria.", "Search Results",
                        MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error searching states: " + ex.Message, "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}