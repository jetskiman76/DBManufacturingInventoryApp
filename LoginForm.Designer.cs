namespace GBManufacturingTracker;

partial class LoginForm
{
    private System.ComponentModel.IContainer components = null!;
    private Label lblTitle, lblUsername, lblPassword;
    private TextBox txtUsername, txtPassword;
    private CheckBox chkShow;
    private Button btnLogin, btnRegister, btnClear, btnClose;

    protected override void Dispose(bool disposing){ if(disposing) components?.Dispose(); base.Dispose(disposing); }

    private void InitializeComponent()
    {
        components = new System.ComponentModel.Container();
        lblTitle = new Label(); lblUsername = new Label(); lblPassword = new Label(); txtUsername = new TextBox(); txtPassword = new TextBox(); chkShow = new CheckBox(); btnLogin = new Button(); btnRegister = new Button(); btnClear = new Button(); btnClose = new Button();
        SuspendLayout();
        lblTitle.Text = "GB Manufacturing Tracker Login"; lblTitle.Font = new Font("Segoe UI", 18F, FontStyle.Bold); lblTitle.Location = new Point(30, 25); lblTitle.Size = new Size(460, 40);
        lblUsername.Text = "Username"; lblUsername.Location = new Point(55, 95); lblUsername.Size = new Size(120, 25);
        txtUsername.Location = new Point(180, 92); txtUsername.Size = new Size(260, 27);
        lblPassword.Text = "Password"; lblPassword.Location = new Point(55, 140); lblPassword.Size = new Size(120, 25);
        txtPassword.Location = new Point(180, 137); txtPassword.Size = new Size(260, 27);
        chkShow.Text = "Show password"; chkShow.Location = new Point(180, 172); chkShow.Size = new Size(180, 25); chkShow.CheckedChanged += chkShow_CheckedChanged;
        btnLogin.Text = "Login"; btnLogin.Location = new Point(55, 220); btnLogin.Size = new Size(95, 35); btnLogin.Click += btnLogin_Click;
        btnRegister.Text = "Register"; btnRegister.Location = new Point(165, 220); btnRegister.Size = new Size(95, 35); btnRegister.Click += btnRegister_Click;
        btnClear.Text = "Clear"; btnClear.Location = new Point(275, 220); btnClear.Size = new Size(95, 35); btnClear.Click += btnClear_Click;
        btnClose.Text = "Close"; btnClose.Location = new Point(385, 220); btnClose.Size = new Size(95, 35); btnClose.Click += btnClose_Click;
        AutoScaleDimensions = new SizeF(8F, 20F); AutoScaleMode = AutoScaleMode.Font; ClientSize = new Size(540, 300); Controls.AddRange(new Control[]{lblTitle,lblUsername,txtUsername,lblPassword,txtPassword,chkShow,btnLogin,btnRegister,btnClear,btnClose}); FormBorderStyle = FormBorderStyle.FixedDialog; MaximizeBox = false; StartPosition = FormStartPosition.CenterScreen; Text = "Login";
        ResumeLayout(false); PerformLayout();
    }
}
