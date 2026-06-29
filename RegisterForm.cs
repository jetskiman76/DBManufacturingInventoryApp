using Microsoft.Data.SqlClient;

namespace GBManufacturingTracker;

/// <summary>
/// Provides functionality for registering new users
/// into the GB Manufacturing Tracker application.
/// Passwords are securely hashed before being stored
/// in the database.
/// </summary>
public partial class RegisterForm : Form
{
    /// <summary>
    /// Initializes the Register User form.
    /// </summary>
    public RegisterForm()
    {
        InitializeComponent();

        // Hide password characters.
        txtPassword.UseSystemPasswordChar = true;

        // Load available user roles.
        LoadRoles();
    }

    /// <summary>
    /// Loads all security roles into the Role ComboBox.
    /// </summary>
    private void LoadRoles()
    {
        cboRole.DataSource = Db.GetTable(@"
            SELECT
                RoleID,
                RoleName
            FROM Roles
            ORDER BY RoleName");

        cboRole.DisplayMember = "RoleName";
        cboRole.ValueMember = "RoleID";
    }

    /// <summary>
    /// Saves a new user account to the database.
    /// The user's password is hashed using BCrypt
    /// before being stored.
    /// </summary>
    private void btnSave_Click(object? sender, EventArgs e)
    {
        // Validate required fields.
        if (string.IsNullOrWhiteSpace(txtUsername.Text) ||
            string.IsNullOrWhiteSpace(txtPassword.Text))
        {
            MessageBox.Show(
                "Username and password are required.",
                "Validation",
                MessageBoxButtons.OK,
                MessageBoxIcon.Warning);

            return;
        }

        try
        {
            Db.Execute(@"
                INSERT INTO Users
                (
                    Username,
                    PasswordHash,
                    FullName,
                    RoleID
                )
                VALUES
                (
                    @u,
                    @p,
                    @f,
                    @r
                )",
                new SqlParameter("@u", txtUsername.Text.Trim()),
                new SqlParameter("@p", PasswordHasher.Hash(txtPassword.Text)),
                new SqlParameter("@f", txtFullName.Text.Trim()),
                new SqlParameter("@r", cboRole.SelectedValue));

            MessageBox.Show(
                "User registered successfully.",
                "Registration Complete",
                MessageBoxButtons.OK,
                MessageBoxIcon.Information);

            Close();
        }
        catch (Exception ex)
        {
            MessageBox.Show(
                "Registration failed.\n\n" + ex.Message,
                "Database Error",
                MessageBoxButtons.OK,
                MessageBoxIcon.Error);
        }
    }

    /// <summary>
    /// Clears all user input fields.
    /// </summary>
    private void btnClear_Click(object? sender, EventArgs e)
    {
        txtUsername.Clear();
        txtPassword.Clear();
        txtFullName.Clear();

        txtUsername.Focus();
    }

    /// <summary>
    /// Cancels registration and closes the form.
    /// </summary>
    private void btnCancel_Click(object? sender, EventArgs e)
    {
        Close();
    }
}
