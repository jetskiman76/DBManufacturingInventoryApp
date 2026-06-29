using Microsoft.Data.SqlClient;

namespace GBManufacturingTracker;

public partial class RegisterForm : Form
{
    public RegisterForm(){ InitializeComponent(); txtPassword.UseSystemPasswordChar = true; LoadRoles(); }
    private void LoadRoles(){ cboRole.DataSource = Db.GetTable("SELECT RoleID, RoleName FROM Roles ORDER BY RoleName"); cboRole.DisplayMember="RoleName"; cboRole.ValueMember="RoleID"; }
    private void btnSave_Click(object? sender, EventArgs e)
    {
        if (txtUsername.Text.Trim()=="" || txtPassword.Text=="") { MessageBox.Show("Username and password are required."); return; }
        try
        {
            Db.Execute(@"INSERT INTO Users(Username, PasswordHash, FullName, RoleID) VALUES(@u,@p,@f,@r)",
                new SqlParameter("@u", txtUsername.Text.Trim()), new SqlParameter("@p", PasswordHasher.Hash(txtPassword.Text)), new SqlParameter("@f", txtFullName.Text.Trim()), new SqlParameter("@r", cboRole.SelectedValue));
            MessageBox.Show("User registered."); Close();
        }
        catch(Exception ex){ MessageBox.Show("Registration failed: " + ex.Message); }
    }
    private void btnClear_Click(object? sender, EventArgs e){ txtUsername.Clear(); txtPassword.Clear(); txtFullName.Clear(); }
    private void btnCancel_Click(object? sender, EventArgs e)=>Close();
}
