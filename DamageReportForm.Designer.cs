namespace GBManufacturingTracker;

partial class DamageReportForm
{
    /// <summary>
    /// Required designer variable.
    /// </summary>
    private System.ComponentModel.IContainer? components = null;

    // Labels
    private Label lblEq = null!;
    private Label lblTrans = null!;
    private Label lblDate = null!;
    private Label lblSeverity = null!;
    private Label lblDesc = null!;
    private Label lblAction = null!;

    // Input controls
    private ComboBox cboEquipment = null!;
    private ComboBox cboSeverity = null!;
    private TextBox txtTransactionId = null!;
    private TextBox txtDescription = null!;
    private TextBox txtAction = null!;
    private DateTimePicker dtDamage = null!;

    // Buttons
    private Button btnSave = null!;
    private Button btnExport = null!;
    private Button btnClear = null!;
    private Button btnClose = null!;

    // Report grid
    private DataGridView dgvReports = null!;

    /// <summary>
    /// Releases all resources used by the form.
    /// </summary>
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

        lblEq = new Label();
        lblTrans = new Label();
        lblDate = new Label();
        lblSeverity = new Label();
        lblDesc = new Label();
        lblAction = new Label();

        cboEquipment = new ComboBox();
        cboSeverity = new ComboBox();

        txtTransactionId = new TextBox();
        txtDescription = new TextBox();
        txtAction = new TextBox();

        dtDamage = new DateTimePicker();

        btnSave = new Button();
        btnExport = new Button();
        btnClear = new Button();
        btnClose = new Button();

        dgvReports = new DataGridView();

        ((System.ComponentModel.ISupportInitialize)dgvReports).BeginInit();
        SuspendLayout();

        // Equipment Label
        lblEq.AutoSize = true;
        lblEq.Location = new Point(20, 20);
        lblEq.Name = "lblEq";
        lblEq.Text = "Equipment";

        // Equipment ComboBox
        cboEquipment.DropDownStyle = ComboBoxStyle.DropDownList;
        cboEquipment.Location = new Point(135, 17);
        cboEquipment.Name = "cboEquipment";
        cboEquipment.Size = new Size(245, 28);
        cboEquipment.TabIndex = 0;

        // Transaction ID Label
        lblTrans.AutoSize = true;
        lblTrans.Location = new Point(400, 20);
        lblTrans.Name = "lblTrans";
        lblTrans.Text = "Transaction ID";

        // Transaction ID TextBox
        txtTransactionId.Location = new Point(520, 17);
        txtTransactionId.Name = "txtTransactionId";
        txtTransactionId.Size = new Size(100, 27);
        txtTransactionId.TabIndex = 1;

        // Damage Date Label
        lblDate.AutoSize = true;
        lblDate.Location = new Point(20, 60);
        lblDate.Name = "lblDate";
        lblDate.Text = "Damage Date";

        // Damage Date Picker
        dtDamage.Location = new Point(135, 57);
        dtDamage.Name = "dtDamage";
        dtDamage.Size = new Size(245, 27);
        dtDamage.TabIndex = 2;

        // Severity Label
        lblSeverity.AutoSize = true;
        lblSeverity.Location = new Point(400, 60);
        lblSeverity.Name = "lblSeverity";
        lblSeverity.Text = "Severity";

        // Severity ComboBox
        cboSeverity.DropDownStyle = ComboBoxStyle.DropDownList;
        cboSeverity.Items.AddRange(new object[]
        {
            "Low",
            "Medium",
            "High",
            "Critical"
        });
        cboSeverity.Location = new Point(520, 57);
        cboSeverity.Name = "cboSeverity";
        cboSeverity.Size = new Size(160, 28);
        cboSeverity.TabIndex = 3;
        cboSeverity.SelectedIndex = 0;

        // Description Label
        lblDesc.AutoSize = true;
        lblDesc.Location = new Point(20, 105);
        lblDesc.Name = "lblDesc";
        lblDesc.Text = "Description";

        // Description TextBox
        txtDescription.Location = new Point(135, 102);
        txtDescription.Multiline = true;
        txtDescription.Name = "txtDescription";
        txtDescription.Size = new Size(545, 70);
        txtDescription.TabIndex = 4;

        // Action Taken Label
        lblAction.AutoSize = true;
        lblAction.Location = new Point(20, 185);
        lblAction.Name = "lblAction";
        lblAction.Text = "Action Taken";

        // Action Taken TextBox
        txtAction.Location = new Point(135, 182);
        txtAction.Multiline = true;
        txtAction.Name = "txtAction";
        txtAction.Size = new Size(545, 70);
        txtAction.TabIndex = 5;

        // Save Button
        btnSave.Location = new Point(710, 25);
        btnSave.Name = "btnSave";
        btnSave.Size = new Size(130, 35);
        btnSave.Text = "Save Report";
        btnSave.UseVisualStyleBackColor = true;
        btnSave.TabIndex = 6;
        btnSave.Click += btnSave_Click;

        // Export Button
        btnExport.Location = new Point(710, 70);
        btnExport.Name = "btnExport";
        btnExport.Size = new Size(130, 35);
        btnExport.Text = "Export Selected";
        btnExport.UseVisualStyleBackColor = true;
        btnExport.TabIndex = 7;
        btnExport.Click += btnExport_Click;

        // Clear Button
        btnClear.Location = new Point(710, 115);
        btnClear.Name = "btnClear";
        btnClear.Size = new Size(130, 35);
        btnClear.Text = "Clear";
        btnClear.UseVisualStyleBackColor = true;
        btnClear.TabIndex = 8;
        btnClear.Click += btnClear_Click;

        // Close Button
        btnClose.Location = new Point(710, 160);
        btnClose.Name = "btnClose";
        btnClose.Size = new Size(130, 35);
        btnClose.Text = "Close";
        btnClose.UseVisualStyleBackColor = true;
        btnClose.TabIndex = 9;
        btnClose.Click += btnClose_Click;

        // Reports DataGridView
        dgvReports.AllowUserToAddRows = false;
        dgvReports.AllowUserToDeleteRows = false;
        dgvReports.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
        dgvReports.Location = new Point(20, 275);
        dgvReports.MultiSelect = false;
        dgvReports.Name = "dgvReports";
        dgvReports.ReadOnly = true;
        dgvReports.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
        dgvReports.Size = new Size(920, 300);
        dgvReports.TabIndex = 10;

        // DamageReportForm
        AutoScaleDimensions = new SizeF(8F, 20F);
        AutoScaleMode = AutoScaleMode.Font;
        ClientSize = new Size(965, 600);

        Controls.Add(lblEq);
        Controls.Add(cboEquipment);
        Controls.Add(lblTrans);
        Controls.Add(txtTransactionId);
        Controls.Add(lblDate);
        Controls.Add(dtDamage);
        Controls.Add(lblSeverity);
        Controls.Add(cboSeverity);
        Controls.Add(lblDesc);
        Controls.Add(txtDescription);
        Controls.Add(lblAction);
        Controls.Add(txtAction);
        Controls.Add(btnSave);
        Controls.Add(btnExport);
        Controls.Add(btnClear);
        Controls.Add(btnClose);
        Controls.Add(dgvReports);

        FormBorderStyle = FormBorderStyle.FixedDialog;
        MaximizeBox = false;
        Name = "DamageReportForm";
        StartPosition = FormStartPosition.CenterParent;
        Text = "Damage Reports";

        ((System.ComponentModel.ISupportInitialize)dgvReports).EndInit();
        ResumeLayout(false);
        PerformLayout();
    }
}
