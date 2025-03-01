using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using BatteryTestingSystem.Models;

namespace BatteryTestingSystem.Data
{
    public class DatabaseManager
    {
        private static string _connectionString = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=|DataDirectory|\BatteryTestingDB.mdf;Integrated Security=True";

        public static void SetConnectionString(string connectionString)
        {
            _connectionString = connectionString;
        }

        #region User Management

        public static User? AuthenticateUser(string username, string password)
        {
            User? user = null;

            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                string query = "SELECT * FROM Users WHERE Username = @Username AND Password = @Password";
                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@Username", username);
                command.Parameters.AddWithValue("@Password", password); // In a real app, use hashed passwords

                try
                {
                    connection.Open();
                    SqlDataReader reader = command.ExecuteReader();

                    if (reader.Read())
                    {
                        user = new User
                        {
                            Id = Convert.ToInt32(reader["Id"]),
                            Username = reader["Username"].ToString(),
                            Email = reader["Email"].ToString(),
                            FirstName = reader["FirstName"].ToString(),
                            LastName = reader["LastName"].ToString(),
                            Role = (UserRole)Enum.Parse(typeof(UserRole), reader["Role"].ToString()),
                            CreatedAt = Convert.ToDateTime(reader["CreatedAt"])
                        };
                    }

                    reader.Close();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error authenticating user: " + ex.Message, "Database Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }

            return user;
        }

        public static List<User> GetAllUsers()
        {
            List<User> users = new List<User>();

            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                string query = "SELECT * FROM Users ORDER BY Username";
                SqlCommand command = new SqlCommand(query, connection);

                try
                {
                    connection.Open();
                    SqlDataReader reader = command.ExecuteReader();

                    while (reader.Read())
                    {
                        User user = new User
                        {
                            Id = Convert.ToInt32(reader["Id"]),
                            Username = reader["Username"].ToString(),
                            Email = reader["Email"].ToString(),
                            FirstName = reader["FirstName"].ToString(),
                            LastName = reader["LastName"].ToString(),
                            Role = (UserRole)Enum.Parse(typeof(UserRole), reader["Role"].ToString()),
                            CreatedAt = Convert.ToDateTime(reader["CreatedAt"])
                        };
                        users.Add(user);
                    }

                    reader.Close();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error retrieving users: " + ex.Message, "Database Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }

            return users;
        }

        public static bool CreateUser(User user)
        {
            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                string query = @"INSERT INTO Users (Username, Password, Email, FirstName, LastName, Role, CreatedAt) 
                               VALUES (@Username, @Password, @Email, @FirstName, @LastName, @Role, @CreatedAt)";
                
                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@Username", user.Username);
                command.Parameters.AddWithValue("@Password", user.Password); // In a real app, use hashed passwords
                command.Parameters.AddWithValue("@Email", user.Email);
                command.Parameters.AddWithValue("@FirstName", user.FirstName);
                command.Parameters.AddWithValue("@LastName", user.LastName);
                command.Parameters.AddWithValue("@Role", user.Role.ToString());
                command.Parameters.AddWithValue("@CreatedAt", user.CreatedAt);

                try
                {
                    connection.Open();
                    int result = command.ExecuteNonQuery();
                    return result > 0;
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error creating user: " + ex.Message, "Database Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return false;
                }
            }
        }

        public static bool UpdateUser(User user)
        {
            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                string query = @"UPDATE Users SET Username = @Username, Email = @Email, 
                               FirstName = @FirstName, LastName = @LastName, Role = @Role 
                               WHERE Id = @Id";
                
                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@Id", user.Id);
                command.Parameters.AddWithValue("@Username", user.Username);
                command.Parameters.AddWithValue("@Email", user.Email);
                command.Parameters.AddWithValue("@FirstName", user.FirstName);
                command.Parameters.AddWithValue("@LastName", user.LastName);
                command.Parameters.AddWithValue("@Role", user.Role.ToString());

                try
                {
                    connection.Open();
                    int result = command.ExecuteNonQuery();
                    return result > 0;
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error updating user: " + ex.Message, "Database Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return false;
                }
            }
        }

        public static bool DeleteUser(int userId)
        {
            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                string query = "DELETE FROM Users WHERE Id = @Id";
                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@Id", userId);

                try
                {
                    connection.Open();
                    int result = command.ExecuteNonQuery();
                    return result > 0;
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error deleting user: " + ex.Message, "Database Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return false;
                }
            }
        }

        #endregion

        #region Battery Parameters

        public static List<BatteryParameter> GetAllParameters()
        {
            List<BatteryParameter> parameters = new List<BatteryParameter>();

            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                string query = "SELECT * FROM BatteryParameters ORDER BY DisplayOrder";
                SqlCommand command = new SqlCommand(query, connection);

                try
                {
                    connection.Open();
                    SqlDataReader reader = command.ExecuteReader();

                    while (reader.Read())
                    {
                        BatteryParameter parameter = new BatteryParameter
                        {
                            Id = Convert.ToInt32(reader["Id"]),
                            Name = reader["Name"].ToString(),
                            Unit = reader["Unit"].ToString(),
                            MinThreshold = Convert.ToDouble(reader["MinThreshold"]),
                            MaxThreshold = Convert.ToDouble(reader["MaxThreshold"]),
                            DisplayOrder = Convert.ToInt32(reader["DisplayOrder"]),
                            IsActive = Convert.ToBoolean(reader["IsActive"])
                        };
                        parameters.Add(parameter);
                    }

                    reader.Close();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error retrieving battery parameters: " + ex.Message, "Database Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }

            return parameters;
        }

        public static List<BatteryParameter> GetActiveParameters()
        {
            List<BatteryParameter> parameters = new List<BatteryParameter>();

            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                string query = "SELECT * FROM BatteryParameters WHERE IsActive = 1 ORDER BY DisplayOrder";
                SqlCommand command = new SqlCommand(query, connection);

                try
                {
                    connection.Open();
                    SqlDataReader reader = command.ExecuteReader();

                    while (reader.Read())
                    {
                        BatteryParameter parameter = new BatteryParameter
                        {
                            Id = Convert.ToInt32(reader["Id"]),
                            Name = reader["Name"].ToString(),
                            Unit = reader["Unit"].ToString(),
                            MinThreshold = Convert.ToDouble(reader["MinThreshold"]),
                            MaxThreshold = Convert.ToDouble(reader["MaxThreshold"]),
                            DisplayOrder = Convert.ToInt32(reader["DisplayOrder"]),
                            IsActive = Convert.ToBoolean(reader["IsActive"])
                        };
                        parameters.Add(parameter);
                    }

                    reader.Close();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error retrieving active battery parameters: " + ex.Message, "Database Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }

            return parameters;
        }

        public static bool UpdateParameterOrder(int parameterId, int newOrder)
        {
            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                string query = "UPDATE BatteryParameters SET DisplayOrder = @DisplayOrder WHERE Id = @Id";
                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@Id", parameterId);
                command.Parameters.AddWithValue("@DisplayOrder", newOrder);

                try
                {
                    connection.Open();
                    int result = command.ExecuteNonQuery();
                    return result > 0;
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error updating parameter order: " + ex.Message, "Database Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return false;
                }
            }
        }

        public static bool UpdateParameterActiveStatus(int parameterId, bool isActive)
        {
            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                string query = "UPDATE BatteryParameters SET IsActive = @IsActive WHERE Id = @Id";
                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@Id", parameterId);
                command.Parameters.AddWithValue("@IsActive", isActive);

                try
                {
                    connection.Open();
                    int result = command.ExecuteNonQuery();
                    return result > 0;
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error updating parameter active status: " + ex.Message, "Database Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return false;
                }
            }
        }

        #endregion

        #region Battery Tests

        public static bool SaveBatteryTest(BatteryTest test)
        {
            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                connection.Open();
                SqlTransaction transaction = connection.BeginTransaction();

                try
                {
                    // Insert the test record
                    string testQuery = @"INSERT INTO BatteryTests (BatteryId, OperatorId, TestDate, PassedTest, Notes) 
                                      VALUES (@BatteryId, @OperatorId, @TestDate, @PassedTest, @Notes);
                                      SELECT SCOPE_IDENTITY();";
                    
                    SqlCommand testCommand = new SqlCommand(testQuery, connection, transaction);
                    testCommand.Parameters.AddWithValue("@BatteryId", test.BatteryId);
                    testCommand.Parameters.AddWithValue("@OperatorId", test.OperatorId);
                    testCommand.Parameters.AddWithValue("@TestDate", test.TestDate);
                    testCommand.Parameters.AddWithValue("@PassedTest", test.PassedTest);
                    testCommand.Parameters.AddWithValue("@Notes", test.Notes);

                    // Get the inserted test ID
                    int testId = Convert.ToInt32(testCommand.ExecuteScalar());

                    // Insert test results
                    foreach (var result in test.Results)
                    {
                        string resultQuery = @"INSERT INTO BatteryTestResults (TestId, ParameterId, Value, IsWithinThreshold) 
                                           VALUES (@TestId, @ParameterId, @Value, @IsWithinThreshold)";
                        
                        SqlCommand resultCommand = new SqlCommand(resultQuery, connection, transaction);
                        resultCommand.Parameters.AddWithValue("@TestId", testId);
                        resultCommand.Parameters.AddWithValue("@ParameterId", result.ParameterId);
                        resultCommand.Parameters.AddWithValue("@Value", result.Value);
                        resultCommand.Parameters.AddWithValue("@IsWithinThreshold", result.IsWithinThreshold);

                        resultCommand.ExecuteNonQuery();
                    }

                    transaction.Commit();
                    return true;
                }
                catch (Exception ex)
                {
                    transaction.Rollback();
                    MessageBox.Show("Error saving battery test: " + ex.Message, "Database Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return false;
                }
            }
        }

        public static DataTable GetTestReports(DateTime startDate, DateTime endDate, int? operatorId = null)
        {
            DataTable reportTable = new DataTable();

            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                string query = @"
                    SELECT 
                        bt.Id AS TestId, 
                        bt.BatteryId, 
                        bt.TestDate, 
                        bt.PassedTest,
                        u.Username AS OperatorName,
                        u.FirstName + ' ' + u.LastName AS OperatorFullName
                    FROM 
                        BatteryTests bt
                    INNER JOIN 
                        Users u ON bt.OperatorId = u.Id
                    WHERE 
                        bt.TestDate BETWEEN @StartDate AND @EndDate";

                if (operatorId.HasValue)
                {
                    query += " AND bt.OperatorId = @OperatorId";
                }

                query += " ORDER BY bt.TestDate DESC";

                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@StartDate", startDate);
                command.Parameters.AddWithValue("@EndDate", endDate);

                if (operatorId.HasValue)
                {
                    command.Parameters.AddWithValue("@OperatorId", operatorId.Value);
                }

                try
                {
                    connection.Open();
                    SqlDataAdapter adapter = new SqlDataAdapter(command);
                    adapter.Fill(reportTable);
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error retrieving test reports: " + ex.Message, "Database Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }

            return reportTable;
        }

        public static DataTable GetTestDetails(int testId)
        {
            DataTable detailsTable = new DataTable();

            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                string query = @"
                    SELECT 
                        bp.Name AS ParameterName,
                        bp.Unit,
                        btr.Value,
                        bp.MinThreshold,
                        bp.MaxThreshold,
                        btr.IsWithinThreshold
                    FROM 
                        BatteryTestResults btr
                    INNER JOIN 
                        BatteryParameters bp ON btr.ParameterId = bp.Id
                    WHERE 
                        btr.TestId = @TestId
                    ORDER BY 
                        bp.DisplayOrder";

                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@TestId", testId);

                try
                {
                    connection.Open();
                    SqlDataAdapter adapter = new SqlDataAdapter(command);
                    adapter.Fill(detailsTable);
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error retrieving test details: " + ex.Message, "Database Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }

            return detailsTable;
        }

        #endregion

        #region Database Setup

        public static void InitializeDatabase()
        {
            // Create database if it doesn't exist
            string dbFilePath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "BatteryTestingDB.mdf");
            
            if (!File.Exists(dbFilePath))
            {
                CreateDatabase();
                CreateTables();
                SeedInitialData();
            }
        }

        private static void CreateDatabase()
        {
            string connectionString = @"Data Source=(LocalDB)\MSSQLLocalDB;Integrated Security=True";
            string dbFilePath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "BatteryTestingDB.mdf");
            
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                
                string createDbQuery = $"CREATE DATABASE BatteryTestingDB ON PRIMARY (NAME = BatteryTestingDB, FILENAME = '{dbFilePath}')";
                
                try
                {
                    SqlCommand command = new SqlCommand(createDbQuery, connection);
                    command.ExecuteNonQuery();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error creating database: " + ex.Message, "Database Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private static void CreateTables()
        {
            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                try
                {
                    connection.Open();
                    
                    // Create Users table
                    string createUsersTable = @"
                        CREATE TABLE Users (
                            Id INT PRIMARY KEY IDENTITY(1,1),
                            Username NVARCHAR(50) NOT NULL UNIQUE,
                            Password NVARCHAR(100) NOT NULL,
                            Email NVARCHAR(100) NOT NULL,
                            FirstName NVARCHAR(50) NOT NULL,
                            LastName NVARCHAR(50) NOT NULL,
                            Role NVARCHAR(20) NOT NULL,
                            CreatedAt DATETIME NOT NULL
                        )";
                    
                    SqlCommand usersCommand = new SqlCommand(createUsersTable, connection);
                    usersCommand.ExecuteNonQuery();
                    
                    // Create BatteryParameters table
                    string createParametersTable = @"
                        CREATE TABLE BatteryParameters (
                            Id INT PRIMARY KEY IDENTITY(1,1),
                            Name NVARCHAR(100) NOT NULL,
                            Unit NVARCHAR(20) NOT NULL,
                            MinThreshold FLOAT NOT NULL,
                            MaxThreshold FLOAT NOT NULL,
                            DisplayOrder INT NOT NULL,
                            IsActive BIT NOT NULL DEFAULT 1
                        )";
                    
                    SqlCommand parametersCommand = new SqlCommand(createParametersTable, connection);
                    parametersCommand.ExecuteNonQuery();
                    
                    // Create BatteryTests table
                    string createTestsTable = @"
                        CREATE TABLE BatteryTests (
                            Id INT PRIMARY KEY IDENTITY(1,1),
                            BatteryId NVARCHAR(50) NOT NULL,
                            OperatorId INT NOT NULL,
                            TestDate DATETIME NOT NULL,
                            PassedTest BIT NOT NULL,
                            Notes NVARCHAR(500),
                            FOREIGN KEY (OperatorId) REFERENCES Users(Id)
                        )";
                    
                    SqlCommand testsCommand = new SqlCommand(createTestsTable, connection);
                    testsCommand.ExecuteNonQuery();
                    
                    // Create BatteryTestResults table
                    string createResultsTable = @"
                        CREATE TABLE BatteryTestResults (
                            Id INT PRIMARY KEY IDENTITY(1,1),
                            TestId INT NOT NULL,
                            ParameterId INT NOT NULL,
                            Value FLOAT NOT NULL,
                            IsWithinThreshold BIT NOT NULL,
                            FOREIGN KEY (TestId) REFERENCES BatteryTests(Id),
                            FOREIGN KEY (ParameterId) REFERENCES BatteryParameters(Id)
                        )";
                    
                    SqlCommand resultsCommand = new SqlCommand(createResultsTable, connection);
                    resultsCommand.ExecuteNonQuery();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error creating tables: " + ex.Message, "Database Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private static void SeedInitialData()
        {
            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                try
                {
                    connection.Open();
                    
                    // Add default users
                    string insertUsers = @"
                        INSERT INTO Users (Username, Password, Email, FirstName, LastName, Role, CreatedAt)
                        VALUES 
                        ('admin', 'admin123', 'admin@company.com', 'Admin', 'User', 'Admin', GETDATE()),
                        ('manufacturer', 'mfg123', 'manufacturer@company.com', 'Manufacturer', 'User', 'Manufacturer', GETDATE())";
                    
                    SqlCommand usersCommand = new SqlCommand(insertUsers, connection);
                    usersCommand.ExecuteNonQuery();
                    
                    // Add default battery parameters
                    string insertParameters = @"
                        INSERT INTO BatteryParameters (Name, Unit, MinThreshold, MaxThreshold, DisplayOrder, IsActive)
                        VALUES 
                        ('Voltage', 'V', 11.5, 12.8, 1, 1),
                        ('Current', 'A', 0.5, 5.0, 2, 1),
                        ('Internal Resistance', 'mΩ', 5.0, 30.0, 3, 1),
                        ('Temperature', '°C', 15.0, 45.0, 4, 1),
                        ('Capacity', 'mAh', 2000, 3000, 5, 1),
                        ('Self-Discharge Rate', '%/month', 0, 3, 6, 1),
                        ('Charge Efficiency', '%', 90, 100, 7, 1),
                        ('Cycle Life', 'cycles', 300, 1000, 8, 1),
                        ('Energy Density', 'Wh/kg', 100, 250, 9, 1),
                        ('Power Density', 'W/kg', 250, 500, 10, 1)";
                    
                    SqlCommand parametersCommand = new SqlCommand(insertParameters, connection);
                    parametersCommand.ExecuteNonQuery();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error seeding initial data: " + ex.Message, "Database Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        #endregion
    }
}