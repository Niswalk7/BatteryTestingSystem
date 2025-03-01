using System;
using System.Windows.Forms;

namespace BatteryTestingSystem
{
    public partial class UserForm : Form
    {
        private bool _isEditMode = false; // Fixed missing declaration
        private User _user; // Fixed missing declaration
        private DatabaseManager _dbManager; // Fixed missing declaration

        public UserForm(User user = null)
        {
            InitializeComponent();
            _dbManager = new DatabaseManager(); // Ensure DatabaseManager is instantiated

            // If editing, load user details
            if (user != null)
            {
                _isEditMode = true;
                _user = user;
                LoadUserData();
            }
            else
            {
                _user = new User();
            }
        }

        private void LoadUserData()
        {
            txtUsername.Text = _user.Username;
            txtPassword.Text = "********"; // Mask password
            txtEmail.Text = _user.Email;
            txtFirstName.Text = _user.FirstName;
            txtLastName.Text = _user.LastName;
            cboRole.SelectedItem = _user.Role;
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            // Validate input
            if (string.IsNullOrWhiteSpace(txtUsername.Text) ||
                (!_isEditMode && string.IsNullOrWhiteSpace(txtPassword.Text)) ||
                string.IsNullOrWhiteSpace(txtEmail.Text) ||
                string.IsNullOrWhiteSpace(txtFirstName.Text) ||
                string.IsNullOrWhiteSpace(txtLastName.Text))
            {
                MessageBox.Show("Please fill in all required fields.", "Validation Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Update user object
            _user.Username = txtUsername.Text.Trim();
            if (!_isEditMode || txtPassword.Text != "********")
            {
                _user.Password = txtPassword.Text;
            }
            _user.Email = txtEmail.Text.Trim();
            _user.FirstName = txtFirstName.Text.Trim();
            _user.LastName = txtLastName.Text.Trim();

            // Fix: Properly cast selected item to UserRole
            if (cboRole.SelectedItem is UserRole selectedRole)
            {
                _user.Role = selectedRole;
            }
            else
            {
                MessageBox.Show("Invalid role selected.", "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            bool success;
            if (_isEditMode)
            {
                success = _dbManager.UpdateUser(_user); // Ensure DatabaseManager method exists
            }
            else
            {
                _user.CreatedAt = DateTime.Now;
                success = _dbManager.CreateUser(_user); // Ensure DatabaseManager method exists
            }

            if (success)
            {
                this.DialogResult = DialogResult.OK;
                this.Close();
            }
            else
            {
                MessageBox.Show("Failed to save user. Please try again.", "Save Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }

    public class User
    {
        public string Username { get; set; }
        public string Password { get; set; }
        public string Email { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public UserRole Role { get; set; }
        public DateTime CreatedAt { get; set; }
    }

    public enum UserRole
    {
        Admin,
        Operator,
        Supervisor,
        Manufacturer
    }

    public class DatabaseManager
    {
        public bool CreateUser(User user)
        {
            // Add your database logic here
            return true;
        }

        public bool UpdateUser(User user)
        {
            // Add your database logic here
            return true;
        }
    }
}
