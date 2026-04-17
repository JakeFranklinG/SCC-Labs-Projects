using StateClassLibrary;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace StateDatabase.DataAccess
{
    public class StateRepository
    {
        private readonly string _connectionString;

        public StateRepository(string connectionString)
        {
            if (string.IsNullOrWhiteSpace(connectionString))
                throw new ArgumentException("Connection string cannot be null or empty.", nameof(connectionString));

            _connectionString = connectionString;
        }

        // Get all states
        public List<State> GetAllStates()
        {
            List<State> states = new List<State>();

            try
            {
                using (SqlConnection conn = new SqlConnection(_connectionString))
                {
                    string query = "SELECT * FROM States ORDER BY StateName";
                    SqlCommand cmd = new SqlCommand(query, conn);

                    conn.Open();
                    SqlDataReader reader = cmd.ExecuteReader();

                    while (reader.Read())
                    {
                        states.Add(MapReaderToState(reader));
                    }
                }
            }
            catch (SqlException ex)
            {
                throw new Exception("Database error while retrieving states: " + ex.Message, ex);
            }
            catch (Exception ex)
            {
                throw new Exception("Error retrieving states: " + ex.Message, ex);
            }

            return states;
        }

        // Get state by ID
        public State GetStateById(int stateId)
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(_connectionString))
                {
                    string query = "SELECT * FROM States WHERE StateId = @StateId";
                    SqlCommand cmd = new SqlCommand(query, conn);
                    cmd.Parameters.AddWithValue("@StateId", stateId);

                    conn.Open();
                    SqlDataReader reader = cmd.ExecuteReader();

                    if (reader.Read())
                    {
                        return MapReaderToState(reader);
                    }
                }
            }
            catch (SqlException ex)
            {
                throw new Exception("Database error while retrieving state: " + ex.Message, ex);
            }
            catch (Exception ex)
            {
                throw new Exception("Error retrieving state: " + ex.Message, ex);
            }

            return null;
        }

        // Insert new state
        public int InsertState(State state)
        {
            ValidateState(state);

            try
            {
                using (SqlConnection conn = new SqlConnection(_connectionString))
                {
                    string query = @"INSERT INTO States 
                        (StateName, Population, FlagDescription, StateFlower, StateBird, StateColors, 
                         LargestCity1, LargestCity2, LargestCity3, StateCapitol, MedianIncome, ComputerJobsPercentage)
                        VALUES 
                        (@StateName, @Population, @FlagDescription, @StateFlower, @StateBird, @StateColors,
                         @LargestCity1, @LargestCity2, @LargestCity3, @StateCapitol, @MedianIncome, @ComputerJobsPercentage);
                        SELECT CAST(SCOPE_IDENTITY() as int)";

                    SqlCommand cmd = new SqlCommand(query, conn);
                    AddStateParameters(cmd, state);

                    conn.Open();
                    return (int)cmd.ExecuteScalar();
                }
            }
            catch (SqlException ex)
            {
                if (ex.Number == 2627) // Duplicate key
                    throw new Exception("A state with this name already exists.", ex);
                throw new Exception("Database error while inserting state: " + ex.Message, ex);
            }
            catch (Exception ex)
            {
                throw new Exception("Error inserting state: " + ex.Message, ex);
            }
        }

        // Update existing state
        public void UpdateState(State state)
        {
            ValidateState(state);

            try
            {
                using (SqlConnection conn = new SqlConnection(_connectionString))
                {
                    string query = @"UPDATE States SET 
                        StateName = @StateName, 
                        Population = @Population, 
                        FlagDescription = @FlagDescription, 
                        StateFlower = @StateFlower, 
                        StateBird = @StateBird, 
                        StateColors = @StateColors,
                        LargestCity1 = @LargestCity1, 
                        LargestCity2 = @LargestCity2, 
                        LargestCity3 = @LargestCity3, 
                        StateCapitol = @StateCapitol, 
                        MedianIncome = @MedianIncome, 
                        ComputerJobsPercentage = @ComputerJobsPercentage
                        WHERE StateId = @StateId";

                    SqlCommand cmd = new SqlCommand(query, conn);
                    cmd.Parameters.AddWithValue("@StateId", state.StateId);
                    AddStateParameters(cmd, state);

                    conn.Open();
                    int rowsAffected = cmd.ExecuteNonQuery();

                    if (rowsAffected == 0)
                        throw new Exception("State not found or no changes were made.");
                }
            }
            catch (SqlException ex)
            {
                throw new Exception("Database error while updating state: " + ex.Message, ex);
            }
            catch (Exception ex)
            {
                throw new Exception("Error updating state: " + ex.Message, ex);
            }
        }

        // Delete state
        public void DeleteState(int stateId)
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(_connectionString))
                {
                    string query = "DELETE FROM States WHERE StateId = @StateId";
                    SqlCommand cmd = new SqlCommand(query, conn);
                    cmd.Parameters.AddWithValue("@StateId", stateId);

                    conn.Open();
                    int rowsAffected = cmd.ExecuteNonQuery();

                    if (rowsAffected == 0)
                        throw new Exception("State not found.");
                }
            }
            catch (SqlException ex)
            {
                throw new Exception("Database error while deleting state: " + ex.Message, ex);
            }
            catch (Exception ex)
            {
                throw new Exception("Error deleting state: " + ex.Message, ex);
            }
        }

        // Search states
        public List<State> SearchStates(string searchTerm)
        {
            List<State> states = new List<State>();

            try
            {
                using (SqlConnection conn = new SqlConnection(_connectionString))
                {
                    string query = @"SELECT * FROM States 
                        WHERE StateName LIKE @Search 
                        OR StateFlower LIKE @Search 
                        OR StateBird LIKE @Search 
                        OR StateCapitol LIKE @Search
                        ORDER BY StateName";

                    SqlCommand cmd = new SqlCommand(query, conn);
                    cmd.Parameters.AddWithValue("@Search", "%" + searchTerm + "%");

                    conn.Open();
                    SqlDataReader reader = cmd.ExecuteReader();

                    while (reader.Read())
                    {
                        states.Add(MapReaderToState(reader));
                    }
                }
            }
            catch (SqlException ex)
            {
                throw new Exception("Database error while searching states: " + ex.Message, ex);
            }
            catch (Exception ex)
            {
                throw new Exception("Error searching states: " + ex.Message, ex);
            }

            return states;
        }

        // Helper method to map SqlDataReader to State object
        private State MapReaderToState(SqlDataReader reader)
        {
            return new State
            {
                StateId = (int)reader["StateId"],
                StateName = reader["StateName"].ToString(),
                Population = (int)reader["Population"],
                FlagDescription = reader["FlagDescription"].ToString(),
                StateFlower = reader["StateFlower"].ToString(),
                StateBird = reader["StateBird"].ToString(),
                StateColors = reader["StateColors"].ToString(),
                LargestCity1 = reader["LargestCity1"].ToString(),
                LargestCity2 = reader["LargestCity2"].ToString(),
                LargestCity3 = reader["LargestCity3"].ToString(),
                StateCapitol = reader["StateCapitol"].ToString(),
                MedianIncome = (decimal)reader["MedianIncome"],
                ComputerJobsPercentage = (decimal)reader["ComputerJobsPercentage"]
            };
        }

        // Helper method to add parameters to command
        private void AddStateParameters(SqlCommand cmd, State state)
        {
            cmd.Parameters.AddWithValue("@StateName", state.StateName);
            cmd.Parameters.AddWithValue("@Population", state.Population);
            cmd.Parameters.AddWithValue("@FlagDescription", state.FlagDescription);
            cmd.Parameters.AddWithValue("@StateFlower", state.StateFlower);
            cmd.Parameters.AddWithValue("@StateBird", state.StateBird);
            cmd.Parameters.AddWithValue("@StateColors", state.StateColors);
            cmd.Parameters.AddWithValue("@LargestCity1", state.LargestCity1);
            cmd.Parameters.AddWithValue("@LargestCity2", state.LargestCity2);
            cmd.Parameters.AddWithValue("@LargestCity3", state.LargestCity3);
            cmd.Parameters.AddWithValue("@StateCapitol", state.StateCapitol);
            cmd.Parameters.AddWithValue("@MedianIncome", state.MedianIncome);
            cmd.Parameters.AddWithValue("@ComputerJobsPercentage", state.ComputerJobsPercentage);
        }

        // Validation method
        private void ValidateState(State state)
        {
            if (state == null)
                throw new ArgumentNullException(nameof(state), "State cannot be null.");

            if (string.IsNullOrWhiteSpace(state.StateName))
                throw new ArgumentException("State name is required.");

            if (state.Population < 0)
                throw new ArgumentException("Population cannot be negative.");

            if (state.MedianIncome < 0)
                throw new ArgumentException("Median income cannot be negative.");

            if (state.ComputerJobsPercentage < 0 || state.ComputerJobsPercentage > 100)
                throw new ArgumentException("Computer jobs percentage must be between 0 and 100.");
        }
    }
}
