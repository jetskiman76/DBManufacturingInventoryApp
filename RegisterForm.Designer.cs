namespace GBManufacturingTracker;

partial class RegisterForm
{
    /// <summary>
    /// Required designer variable.
    /// </summary>
    private System.ComponentModel.IContainer? components = null;

    // Labels
    private Label lblTitle = null!;
    private Label lblUser = null!;
    private Label lblPass = null!;
    private Label lblFull = null!;
    private Label lblRole = null!;

    // Input Controls
    private TextBox txtUsername = null!;
    private TextBox txtPassword = null!;
    private TextBox txtFullName = null!;
    private ComboBox cboRole = null!;

    // Buttons
    private Button btnSave = null!;
    private Button btnClear = null!;
    private Button btnCancel = null!;

    /// <summary>
    /// Releases all resources used by the form.
    /// </summary>
    /// <param name="disposing">
    /// True to dispose managed resources; otherwise false.
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
    /// </summary>
    private void InitializeComponent()
    {
        components = new System.ComponentModel.Container();

        lblTitle = new Label();
        lblUser = new Label();
        lblPass = new Label();
        lblFull = new Label();
        lblRole = new Label();

        txtUsername = new TextBox();
        txtPassword = new TextBox();
        txtFullName = new TextBox();

        cboRole = new ComboBox();

        btnSave = new Button();
        btnClear = new Button();
        btnCancel = new Button();

        SuspendLayout();

        //---------------------------------------------------------
        // Title Label
        //---------------------------------------------------------
        lblTitle.Text = "Register New User";
        lblTitle.Font = new Font("Segoe UI", 16F, FontStyle.Bold);
        lblTitle.Location = new Point(25, 20);
        lblTitle.Name = "lblTitle";
        lblTitle.Size = new Size(350, 40);

        //---------------------------------------------------------
        // Username
        //---------------------------------------------------------
        lblUser.Text = "Username";
        lblUser.Location = new Point(30, 80);
        lblUser.Name = "lblUser";
        lblUser.AutoSize = true;

        txtUsername.Location = new Point(150, 77);
        txtUsername.Name = "txtUsername";
        txtUsername.Size = new Size(260, 27);
        txtUsername.TabIndex = 0;

        //---------------------------------------------------------
        // Password
        //---------------------------------------------------------
        lblPass.Text = "Password";
        lblPass.Location = new Point(30, 120);
        lblPass.Name = "lblPass";
        lblPass.AutoSize = true;

        txtPassword.Location = new Point(150, 117);
        txtPassword.Name = "txtPassword";
        txtPassword.Size = new Size(260, 27);
        txtPassword.TabIndex = 1;

        //---------------------------------------------------------
        // Full Name
        //---------------------------------------------------------
        lblFull.Text = "Full Name";
        lblFull.Location = new Point(30, 160);
        lblFull.Name = "lblFull";
        lblFull.AutoSize = true;

        txtFullName.Location = new Point(150, 157);
        txtFullName.Name = "txtFullName";
        txtFullName.Size = new Size(260, 27);
        txtFullName.TabIndex = 2;

        //---------------------------------------------------------
        // Role
        //---------------------------------------------------------
        lblRole.Text = "Role";
        lblRole.Location = new Point(30, 200);
        lblRole.Name = "lblRole";
        lblRole.AutoSize = true;

        cboRole.DropDownStyle = ComboBoxStyle.DropDownList;
        cboRole.Location = new Point(150, 197);
        cboRole.Name = "cboRole";
        cboRole.Size = new Size(260, 28);
        cboRole.TabIndex = 3;

        //---------------------------------------------------------
        // Save Button
        //---------------------------------------------------------
        btnSave.Text = "Save";
        btnSave.Location = new Point(80, 250);
        btnSave.Name = "btnSave";
        btnSave.Size = new Size(95, 35);
        btnSave.TabIndex = 4;
        btnSave.UseVisualStyleBackColor = true;
        btnSave.Click += btnSave_Click;

        //---------------------------------------------------------
        // Clear Button
        //---------------------------------------------------------
        btnClear.Text = "Clear";
        btnClear.Location = new Point(190, 250);
        btnClear.Name = "btnClear";
        btnClear.Size = new Size(95, 35);
        btnClear.TabIndex = 5;
        btnClear.UseVisualStyleBackColor = true;
        btnClear.Click += btnClear_Click;

        //---------------------------------------------------------
        // Cancel Button
        //---------------------------------------------------------
        btnCancel.Text = "Cancel";
        btnCancel.Location = new Point(300, 250);
        btnCancel.Name = "btnCancel";
        btnCancel.Size = new Size(95, 35);
        btnCancel.TabIndex = 6;
        btnCancel.UseVisualStyleBackColor = true;
        btnCancel.Click += btnCancel_Click;

        //---------------------------------------------------------
        // RegisterForm
        //---------------------------------------------------------
        AutoScaleDimensions = new SizeF(8F, 20F);
        AutoScaleMode = AutoScaleMode.Font;

        ClientSize = new Size(460, 320);

        Controls.Add(lblTitle);
        Controls.Add(lblUser);
        Controls.Add(txtUsername);

        Controls.Add(lblPass);
        Controls.Add(txtPassword);

        Controls.Add(lblFull);
        Controls.Add(txtFullName);

        Controls.Add(lblRole);
        Controls.Add(cboRole);

        Controls.Add(btnSave);
        Controls.Add(btnClear);
        Controls.Add(btnCancel);

        FormBorderStyle = FormBorderStyle.FixedDialog;
        MaximizeBox = false;
        MinimizeBox = false;

        Name = "RegisterForm";
        StartPosition = FormStartPosition.CenterParent;
        Text = "Register User";

        ResumeLayout(false);
        PerformLayout();
    }
}
