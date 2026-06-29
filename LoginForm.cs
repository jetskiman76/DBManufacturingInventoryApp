using System.Data;
using Microsoft.Data.SqlClient;

namespace GBManufacturingTracker;

/// <summary>
/// Provides user authentication for the GB Manufacturing Tracker.
/// Users must successfully log in before accessing the application.
/// </summary>
public partial class LoginForm : Form
{
    /// <summary>
    /// Initializes the Login form.
    /// </summary>
    public LoginForm()
    {
        InitializeComponent();

        // Hide password characters by default.
        txtPassword.UseSystemPasswordChar = true;

        // Default username for development/testing.
        txtUsername.Text = "admin";
    }

    /// <summary>
    /// Validates the user's credentials and opens the Dashboard
    /// if authentication is successful.
    /// </summary>
    private void btnLogin_Click(object? sender, EventArgs e)
    {
        string username = txtUsername.Text.Trim();
        string password = txtPassword.Text;

        // Ensure the username and password have been entered.
        if (username.Length == 0 || password.Length == 0)
        {
            MessageBox.Show(
                "Enter username and password.",
                "Login",
                MessageBoxButtons.OK,
                MessageBoxIcon.Warning);

            return;
        }

        // Retrieve the user account information.
        DataTable table = Db.GetTable(@"
            SELECT TOP 1
                u.UserID,
                u.Username,
                u.FullName,
                u.PasswordHash,
                r.RoleName
            FROM Users u
                INNER JOIN Roles r
                    ON u.RoleID = r.RoleID
            WHERE
                u.Username = @u
                AND u.IsActive = 1",
            new SqlParameter("@u", username));

        // Verify the password against the stored BCrypt hash.
        if (table.Rows.Count == 1 &&
            PasswordHasher.Verify(
                password,
                table.Rows[0]["PasswordHash"].ToString()!))
        {
            // Store user information in the application session.
            Session.UserId =
                Convert.ToInt32(table.Rows[0]["UserID"]);

            Session.Username =
                table.Rows[0]["Username"].ToString()!;

            Session.FullName =
                table.Rows[0]["FullName"].ToString()!;

            Session.RoleName =
                table.Rows[0]["RoleName"].ToString()!;

            // Hide the login form while the dashboard is open.
            Hide();

            using DashboardForm dashboard = new();
            dashboard.ShowDialog();

            // Show the login form after logout.
            Show();

            // Clear the password field for security.
            txtPassword.Clear();
        }
        else
        {
            MessageBox.Show(
                "Invalid username or password.",
                "Login Failed",
                MessageBoxButtons.OK,
                MessageBoxIcon.Error);
        }
    }

    /// <summary>
    /// Opens the Register User form.
    /// </summary>
    private void btnRegister_Click(object? sender, EventArgs e)
    {
        using RegisterForm registerForm = new();

        registerForm.ShowDialog();
    }

    /// <summary>
    /// Clears the username and password fields.
    /// </summary>
    private void btnClear_Click(object? sender, EventArgs e)
    {
        txtUsername.Clear();
        txtPassword.Clear();

        // Return focus to the username textbox.
        txtUsername.Focus();
    }

    /// <summary>
    /// Closes the application.
    /// </summary>
    private void btnClose_Click(object? sender, EventArgs e)
    {
        Close();
    }

    /// <summary>
    /// Shows or hides the password characters.
    /// </summary>
    private void chkShow_CheckedChanged(object? sender, EventArgs e)
    {
        txtPassword.UseSystemPasswordChar = !chkShow.Checked;
    }
}
