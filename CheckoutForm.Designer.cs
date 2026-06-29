namespace GBManufacturingTracker;

partial class CheckoutForm
{
    /// <summary>
    /// Required designer variable.
    /// </summary>
    private System.ComponentModel.IContainer? components = null;

    //=========================================================
    // Labels
    //=========================================================
    private Label lblUser = null!;
    private Label lblEq = null!;
    private Label lblCheckout = null!;
    private Label lblDue = null!;
    private Label lblTrans = null!;

    //=========================================================
    // Input Controls
    //=========================================================
    private ComboBox cboUser = null!;
    private ComboBox cboEquipment = null!;

    private DateTimePicker dtCheckout = null!;
    private DateTimePicker dtDue = null!;

    private TextBox txtTransactionId = null!;

    private CheckBox chkDamaged = null!;

    //=========================================================
    // Buttons
    //=========================================================
    private Button btnCheckout = null!;
    private Button btnReturn = null!;
    private Button btnClose = null!;

    //=========================================================
    // Transaction Grid
    //=========================================================
    private DataGridView dgvTransactions = null!;

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

        lblUser = new Label();
        lblEq = new Label();
        lblCheckout = new Label();
        lblDue = new Label();
        lblTrans = new Label();

        cboUser = new ComboBox();
        cboEquipment = new ComboBox();

        dtCheckout = new DateTimePicker();
        dtDue = new DateTimePicker();

        txtTransactionId = new TextBox();

        chkDamaged = new CheckBox();

        btnCheckout = new Button();
        btnReturn = new Button();
        btnClose = new Button();

        dgvTransactions = new DataGridView();

        ((System.ComponentModel.ISupportInitialize)dgvTransactions).BeginInit();
        SuspendLayout();

        //---------------------------------------------------------
        // Employee
        //---------------------------------------------------------
        lblUser.AutoSize = true;
        lblUser.Location = new Point(25, 25);
        lblUser.Name = "lblUser";
        lblUser.Text = "Employee";

        cboUser.DropDownStyle = ComboBoxStyle.DropDownList;
        cboUser.Location = new Point(115, 22);
        cboUser.Name = "cboUser";
        cboUser.Size = new Size(220, 28);
        cboUser.TabIndex = 0;

        //---------------------------------------------------------
        // Equipment
        //---------------------------------------------------------
        lblEq.AutoSize = true;
        lblEq.Location = new Point(360, 25);
        lblEq.Name = "lblEq";
        lblEq.Text = "Equipment";

        cboEquipment.DropDownStyle = ComboBoxStyle.DropDownList;
        cboEquipment.Location = new Point(455, 22);
        cboEquipment.Name = "cboEquipment";
        cboEquipment.Size = new Size(260, 28);
        cboEquipment.TabIndex = 1;

        //---------------------------------------------------------
        // Checkout Date
        //---------------------------------------------------------
        lblCheckout.AutoSize = true;
        lblCheckout.Location = new Point(25, 70);
        lblCheckout.Name = "lblCheckout";
        lblCheckout.Text = "Checkout Date";

        dtCheckout.Location = new Point(115, 67);
        dtCheckout.Name = "dtCheckout";
        dtCheckout.Size = new Size(220, 27);
        dtCheckout.TabIndex = 2;

        //---------------------------------------------------------
        // Due Date
        //---------------------------------------------------------
        lblDue.AutoSize = true;
        lblDue.Location = new Point(360, 70);
        lblDue.Name = "lblDue";
        lblDue.Text = "Due Date";

        dtDue.Location = new Point(455, 67);
        dtDue.Name = "dtDue";
        dtDue.Size = new Size(260, 27);
        dtDue.TabIndex = 3;

        //---------------------------------------------------------
        // Return Transaction
        //---------------------------------------------------------
        lblTrans.AutoSize = true;
        lblTrans.Location = new Point(25, 115);
        lblTrans.Name = "lblTrans";
        lblTrans.Text = "Return Transaction ID";

        txtTransactionId.Location = new Point(180, 112);
        txtTransactionId.Name = "txtTransactionId";
        txtTransactionId.Size = new Size(90, 27);
        txtTransactionId.TabIndex = 4;

        //---------------------------------------------------------
        // Damaged Checkbox
        //---------------------------------------------------------
        chkDamaged.AutoSize = true;
        chkDamaged.Location = new Point(290, 112);
        chkDamaged.Name = "chkDamaged";
        chkDamaged.Size = new Size(170, 24);
        chkDamaged.TabIndex = 5;
        chkDamaged.Text = "Damaged on Return";
        chkDamaged.UseVisualStyleBackColor = true;

        //---------------------------------------------------------
        // Checkout Button
        //---------------------------------------------------------
        btnCheckout.Location = new Point(485, 108);
        btnCheckout.Name = "btnCheckout";
        btnCheckout.Size = new Size(110, 35);
        btnCheckout.TabIndex = 6;
        btnCheckout.Text = "Check Out";
        btnCheckout.UseVisualStyleBackColor = true;
        btnCheckout.Click += btnCheckout_Click;

        //---------------------------------------------------------
        // Return Button
        //---------------------------------------------------------
        btnReturn.Location = new Point(610, 108);
        btnReturn.Name = "btnReturn";
        btnReturn.Size = new Size(100, 35);
        btnReturn.TabIndex = 7;
        btnReturn.Text = "Return";
        btnReturn.UseVisualStyleBackColor = true;
        btnReturn.Click += btnReturn_Click;

        //---------------------------------------------------------
        // Close Button
        //---------------------------------------------------------
        btnClose.Location = new Point(725, 108);
        btnClose.Name = "btnClose";
        btnClose.Size = new Size(100, 35);
        btnClose.TabIndex = 8;
        btnClose.Text = "Close";
        btnClose.UseVisualStyleBackColor = true;
        btnClose.Click += btnClose_Click;

        //---------------------------------------------------------
        // Transaction DataGridView
        //---------------------------------------------------------
        dgvTransactions.AllowUserToAddRows = false;
        dgvTransactions.AllowUserToDeleteRows = false;
        dgvTransactions.AllowUserToResizeRows = false;
        dgvTransactions.AutoSizeColumnsMode =
            DataGridViewAutoSizeColumnsMode.Fill;
        dgvTransactions.Location = new Point(20, 165);
        dgvTransactions.MultiSelect = false;
        dgvTransactions.Name = "dgvTransactions";
        dgvTransactions.ReadOnly = true;
        dgvTransactions.SelectionMode =
            DataGridViewSelectionMode.FullRowSelect;
        dgvTransactions.Size = new Size(920, 360);
        dgvTransactions.TabIndex = 9;
        dgvTransactions.CellClick += dgvTransactions_CellClick;

        //---------------------------------------------------------
        // CheckoutForm
        //---------------------------------------------------------
        AcceptButton = btnCheckout;
        CancelButton = btnClose;

        AutoScaleDimensions = new SizeF(8F, 20F);
        AutoScaleMode = AutoScaleMode.Font;

        ClientSize = new Size(965, 550);

        Controls.Add(lblUser);
        Controls.Add(cboUser);

        Controls.Add(lblEq);
        Controls.Add(cboEquipment);

        Controls.Add(lblCheckout);
        Controls.Add(dtCheckout);

        Controls.Add(lblDue);
        Controls.Add(dtDue);

        Controls.Add(lblTrans);
        Controls.Add(txtTransactionId);

        Controls.Add(chkDamaged);

        Controls.Add(btnCheckout);
        Controls.Add(btnReturn);
        Controls.Add(btnClose);

        Controls.Add(dgvTransactions);

        FormBorderStyle = FormBorderStyle.FixedDialog;
        MaximizeBox = false;
        MinimizeBox = false;

        Name = "CheckoutForm";
        StartPosition = FormStartPosition.CenterParent;
        Text = "Equipment Checkout / Return";

        ((System.ComponentModel.ISupportInitialize)dgvTransactions).EndInit();

        ResumeLayout(false);
        PerformLayout();
    }
}
