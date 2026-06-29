using System.Data;
using Microsoft.Data.SqlClient;

namespace GBManufacturingTracker;

public partial class LoginForm : Form
{
    public LoginForm()
    {
        InitializeComponent();
        txtPassword.UseSystemPasswordChar = true;
        txtUsername.Text = "admin";
    }

    private void btnLogin_Click(object? sender, EventArgs e)
    {
        string username = txtUsername.Text.Trim();
        string password = txtPassword.Text;
        if (username.Length == 0 || password.Length == 0)
        {
            MessageBox.Show("Enter username and password.", "Login", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            return;
        }
        DataTable table = Db.GetTable(@"
            SELECT TOP 1 u.UserID, u.Username, u.FullName, u.PasswordHash, r.RoleName
            FROM Users u INNER JOIN Roles r ON u.RoleID=r.RoleID
            WHERE u.Username=@u AND u.IsActive=1", new SqlParameter("@u", username));
        if (table.Rows.Count == 1 && PasswordHasher.Verify(password, table.Rows[0]["PasswordHash"].ToString()!))
        {
            Session.UserId = Convert.ToInt32(table.Rows[0]["UserID"]);
            Session.Username = table.Rows[0]["Username"].ToString()!;
            Session.FullName = table.Rows[0]["FullName"].ToString()!;
            Session.RoleName = table.Rows[0]["RoleName"].ToString()!;
            Hide();
            using DashboardForm form = new();
            form.ShowDialog();
            Show();
            txtPassword.Clear();
        }
        else MessageBox.Show("Invalid username or password.", "Login Failed", MessageBoxButtons.OK, MessageBoxIcon.Error);
    }

    private void btnRegister_Click(object? sender, EventArgs e)
    {
        using RegisterForm form = new();
        form.ShowDialog();
    }

    private void btnClear_Click(object? sender, EventArgs e)
    {
        txtUsername.Clear(); txtPassword.Clear(); txtUsername.Focus();
    }

    private void btnClose_Click(object? sender, EventArgs e) => Close();
    private void chkShow_CheckedChanged(object? sender, EventArgs e) => txtPassword.UseSystemPasswordChar = !chkShow.Checked;
}
