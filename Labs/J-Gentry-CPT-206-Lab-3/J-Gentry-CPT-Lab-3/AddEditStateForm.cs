using System;
using System.Windows.Forms;
using StateClassLibrary;
using StateDatabase.DataAccess;

namespace StateDatabase
{
    public partial class AddEditStateForm : Form
    {
        private StateRepository _repository;
        private State _editingState;
        private bool _isEditMode;

        public AddEditStateForm(StateRepository repository, State existingState = null)
        {
            InitializeComponent();
            _repository = repository;
            _editingState = existingState;
            _isEditMode = existingState != null;

            if (_isEditMode)
            {
                this.Text = "Edit State";
                LoadStateData();
            }
            else
            {
                this.Text = "Add New State";
            }
        }

        private void LoadStateData()
        {
            txtStateName.Text = _editingState.StateName;
            txtPopulation.Text = _editingState.Population.ToString();
            txtCapitol.Text = _editingState.StateCapitol;
            txtFlower.Text = _editingState.StateFlower;
            txtBird.Text = _editingState.StateBird;
            txtColors.Text = _editingState.StateColors;
            txtCity1.Text = _editingState.LargestCity1;
            txtCity2.Text = _editingState.LargestCity2;
            txtCity3.Text = _editingState.LargestCity3;
            txtMedianIncome.Text = _editingState.MedianIncome.ToString();
            txtComputerJobs.Text = _editingState.ComputerJobsPercentage.ToString();
            txtFlagDescription.Text = _editingState.FlagDescription;
        }

        private bool ValidateInputs()
        {
            // Check required fields
            if (string.IsNullOrWhiteSpace(txtStateName.Text))
            {
                MessageBox.Show("State Name is required.", "Validation Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtStateName.Focus();
                return false;
            }

            if (string.IsNullOrWhiteSpace(txtPopulation.Text))
            {
                MessageBox.Show("Population is required.", "Validation Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtPopulation.Focus();
                return false;
            }

            // Validate population
            if (!int.TryParse(txtPopulation.Text.Trim(), out int population) || population < 0)
            {
                MessageBox.Show("Please enter a valid positive number for Population.", "Validation Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtPopulation.Focus();
                return false;
            }

            if (string.IsNullOrWhiteSpace(txtCapitol.Text))
            {
                MessageBox.Show("Capitol is required.", "Validation Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtCapitol.Focus();
                return false;
            }

            if (string.IsNullOrWhiteSpace(txtFlower.Text))
            {
                MessageBox.Show("State Flower is required.", "Validation Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtFlower.Focus();
                return false;
            }

            if (string.IsNullOrWhiteSpace(txtBird.Text))
            {
                MessageBox.Show("State Bird is required.", "Validation Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtBird.Focus();
                return false;
            }

            if (string.IsNullOrWhiteSpace(txtColors.Text))
            {
                MessageBox.Show("State Colors is required.", "Validation Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtColors.Focus();
                return false;
            }

            if (string.IsNullOrWhiteSpace(txtCity1.Text) ||
                string.IsNullOrWhiteSpace(txtCity2.Text) ||
                string.IsNullOrWhiteSpace(txtCity3.Text))
            {
                MessageBox.Show("All three largest cities are required.", "Validation Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }

            if (string.IsNullOrWhiteSpace(txtMedianIncome.Text))
            {
                MessageBox.Show("Median Income is required.", "Validation Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtMedianIncome.Focus();
                return false;
            }

            // Validate median income
            if (!decimal.TryParse(txtMedianIncome.Text.Trim(), out decimal income) || income < 0)
            {
                MessageBox.Show("Please enter a valid positive number for Median Income.", "Validation Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtMedianIncome.Focus();
                return false;
            }

            if (string.IsNullOrWhiteSpace(txtComputerJobs.Text))
            {
                MessageBox.Show("Computer Jobs Percentage is required.", "Validation Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtComputerJobs.Focus();
                return false;
            }

            // Validate computer jobs percentage
            if (!decimal.TryParse(txtComputerJobs.Text.Trim(), out decimal percentage) ||
                percentage < 0 || percentage > 100)
            {
                MessageBox.Show("Computer Jobs Percentage must be between 0 and 100.", "Validation Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtComputerJobs.Focus();
                return false;
            }

            if (string.IsNullOrWhiteSpace(txtFlagDescription.Text))
            {
                MessageBox.Show("Flag Description is required.", "Validation Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtFlagDescription.Focus();
                return false;
            }

            return true;
        }

        private void btnSave_Click_1(object sender, EventArgs e)
        {
            try
            {
                // Validate inputs
                if (!ValidateInputs())
                    return;

                // Create state object
                State state = new State
                {
                    StateName = txtStateName.Text.Trim(),
                    Population = int.Parse(txtPopulation.Text.Trim()),
                    StateCapitol = txtCapitol.Text.Trim(),
                    StateFlower = txtFlower.Text.Trim(),
                    StateBird = txtBird.Text.Trim(),
                    StateColors = txtColors.Text.Trim(),
                    LargestCity1 = txtCity1.Text.Trim(),
                    LargestCity2 = txtCity2.Text.Trim(),
                    LargestCity3 = txtCity3.Text.Trim(),
                    MedianIncome = decimal.Parse(txtMedianIncome.Text.Trim()),
                    ComputerJobsPercentage = decimal.Parse(txtComputerJobs.Text.Trim()),
                    FlagDescription = txtFlagDescription.Text.Trim()
                };

                if (_isEditMode)
                {
                    state.StateId = _editingState.StateId;
                    _repository.UpdateState(state);
                    MessageBox.Show("State updated successfully.", "Success",
                        MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    _repository.InsertState(state);
                    MessageBox.Show("State added successfully.", "Success",
                        MessageBoxButtons.OK, MessageBoxIcon.Information);
                }

                this.DialogResult = DialogResult.OK;
                this.Close();
            }
            catch (FormatException)
            {
                MessageBox.Show("Please enter valid numeric values for Population, Median Income, and Computer Jobs Percentage.",
                    "Invalid Input", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error saving state: " + ex.Message, "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnCancel_Click_1(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }
    }
}
