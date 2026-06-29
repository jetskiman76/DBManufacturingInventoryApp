namespace GBManufacturingTracker;

partial class LoginForm
{
    /// <summary>
    /// Required designer variable.
    /// </summary>
    private System.ComponentModel.IContainer? components = null;

    // Labels
    private Label lblTitle = null!;
    private Label lblUsername = null!;
    private Label lblPassword = null!;

    // Textboxes
    private TextBox txtUsername = null!;
    private TextBox txtPassword = null!;

    // CheckBox
    private CheckBox chkShow = null!;

    // Buttons
    private Button btnLogin = null!;
    private Button btnRegister = null!;
    private Button btnClear = null!;
    private Button btnClose = null!;

    /// <summary>
    /// Releases all resources used by the form.
    /// </summary>
    /// <param name="disposing">
    /// True to dispose managed resources; otherwise, false.
    /// </param>
    protected override void Dispose(bool disposing)
    {
        if (disposing)
        {
            components?.Dispose();
        }

        base.Dispose(disposing);
    }

    /// <summary>
    /// Required method for Designer support.
    /// Do not modify the contents of this method with the code editor.
    /// </summary>
    private void InitializeComponent()
    {
        components = new System.ComponentModel.Container();

        lblTitle = new Label();
        lblUsername = new Label();
        lblPassword = new Label();

        txtUsername = new TextBox();
        txtPassword = new TextBox();

        chkShow = new CheckBox();

        btnLogin = new Button();
        btnRegister = new Button();
        btnClear = new Button();
        btnClose = new Button();

        SuspendLayout();

        //---------------------------------------------------------
        // Title Label
        //---------------------------------------------------------
        lblTitle.AutoSize = true;
        lblTitle.Font = new Font(
            "Segoe UI",
            18F,
            FontStyle.Bold);

        lblTitle.Location = new Point(30, 25);
        lblTitle.Name = "lblTitle";
        lblTitle.Size = new Size(430, 41);
        lblTitle.TabIndex = 0;
        lblTitle.Text = "GB Manufacturing Tracker Login";

        //---------------------------------------------------------
        // Username Label
        //---------------------------------------------------------
        lblUsername.AutoSize = true;
        lblUsername.Location = new Point(55, 95);
        lblUsername.Name = "lblUsername";
        lblUsername.Size = new Size(78, 20);
        lblUsername.TabIndex = 1;
        lblUsername.Text = "Username";

        //---------------------------------------------------------
        // Username TextBox
        //---------------------------------------------------------
        txtUsername.Location = new Point(180, 92);
        txtUsername.Name = "txtUsername";
        txtUsername.Size = new Size(260, 27);
        txtUsername.TabIndex = 2;

        //---------------------------------------------------------
        // Password Label
        //---------------------------------------------------------
        lblPassword.AutoSize = true;
        lblPassword.Location = new Point(55, 140);
        lblPassword.Name = "lblPassword";
        lblPassword.Size = new Size(70, 20);
        lblPassword.TabIndex = 3;
        lblPassword.Text = "Password";

        //---------------------------------------------------------
        // Password TextBox
        //---------------------------------------------------------
        txtPassword.Location = new Point(180, 137);
        txtPassword.Name = "txtPassword";
        txtPassword.Size = new Size(260, 27);
        txtPassword.TabIndex = 4;

        //---------------------------------------------------------
        // Show Password CheckBox
        //---------------------------------------------------------
        chkShow.AutoSize = true;
        chkShow.Location = new Point(180, 172);
        chkShow.Name = "chkShow";
        chkShow.Size = new Size(133, 24);
        chkShow.TabIndex = 5;
        chkShow.Text = "Show Password";
        chkShow.UseVisualStyleBackColor = true;
        chkShow.CheckedChanged += chkShow_CheckedChanged;

        //---------------------------------------------------------
        // Login Button
        //---------------------------------------------------------
        btnLogin.Location = new Point(55, 220);
        btnLogin.Name = "btnLogin";
        btnLogin.Size = new Size(95, 35);
        btnLogin.TabIndex = 6;
        btnLogin.Text = "Login";
        btnLogin.UseVisualStyleBackColor = true;
        btnLogin.Click += btnLogin_Click;

        //---------------------------------------------------------
        // Register Button
        //---------------------------------------------------------
        btnRegister.Location = new Point(165, 220);
        btnRegister.Name = "btnRegister";
        btnRegister.Size = new Size(95, 35);
        btnRegister.TabIndex = 7;
        btnRegister.Text = "Register";
        btnRegister.UseVisualStyleBackColor = true;
        btnRegister.Click += btnRegister_Click;

        //---------------------------------------------------------
        // Clear Button
        //---------------------------------------------------------
        btnClear.Location = new Point(275, 220);
        btnClear.Name = "btnClear";
        btnClear.Size = new Size(95, 35);
        btnClear.TabIndex = 8;
        btnClear.Text = "Clear";
        btnClear.UseVisualStyleBackColor = true;
        btnClear.Click += btnClear_Click;

        //---------------------------------------------------------
        // Close Button
        //---------------------------------------------------------
        btnClose.Location = new Point(385, 220);
        btnClose.Name = "btnClose";
        btnClose.Size = new Size(95, 35);
        btnClose.TabIndex = 9;
        btnClose.Text = "Close";
        btnClose.UseVisualStyleBackColor = true;
        btnClose.Click += btnClose_Click;

        //---------------------------------------------------------
        // Login Form
        //---------------------------------------------------------
        AcceptButton = btnLogin;
        CancelButton = btnClose;

        AutoScaleDimensions = new SizeF(8F, 20F);
        AutoScaleMode = AutoScaleMode.Font;

        ClientSize = new Size(540, 300);

        Controls.Add(lblTitle);
        Controls.Add(lblUsername);
        Controls.Add(txtUsername);
        Controls.Add(lblPassword);
        Controls.Add(txtPassword);
        Controls.Add(chkShow);
        Controls.Add(btnLogin);
        Controls.Add(btnRegister);
        Controls.Add(btnClear);
        Controls.Add(btnClose);

        FormBorderStyle = FormBorderStyle.FixedDialog;
        MaximizeBox = false;
        MinimizeBox = false;

        Name = "LoginForm";
        StartPosition = FormStartPosition.CenterScreen;
        Text = "GB Manufacturing Tracker - Login";

        ResumeLayout(false);
        PerformLayout();
    }
}
