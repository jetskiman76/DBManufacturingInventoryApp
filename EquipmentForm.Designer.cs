namespace GBManufacturingTracker;

partial class EquipmentForm
{
    /// <summary>
    /// Required designer variable.
    /// </summary>
    private System.ComponentModel.IContainer? components = null;

    //=========================================================
    // Group Box
    //=========================================================
    private GroupBox grpDetails = null!;

    //=========================================================
    // Labels
    //=========================================================
    private Label lblId = null!;
    private Label lblBarcode = null!;
    private Label lblName = null!;
    private Label lblCategory = null!;
    private Label lblSerial = null!;
    private Label lblLocation = null!;
    private Label lblStatus = null!;

    //=========================================================
    // Text Boxes
    //=========================================================
    private TextBox txtId = null!;
    private TextBox txtBarcode = null!;
    private TextBox txtName = null!;
    private TextBox txtCategory = null!;
    private TextBox txtSerial = null!;
    private TextBox txtLocation = null!;

    //=========================================================
    // Combo Box
    //=========================================================
    private ComboBox cboStatus = null!;

    //=========================================================
    // Buttons
    //=========================================================
    private Button btnSave = null!;
    private Button btnUpdate = null!;
    private Button btnDelete = null!;
    private Button btnClear = null!;
    private Button btnClose = null!;

    //=========================================================
    // Data Grid
    //=========================================================
    private DataGridView dgvEquipment = null!;

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

        grpDetails = new GroupBox();

        lblId = new Label();
        lblBarcode = new Label();
        lblName = new Label();
        lblCategory = new Label();
        lblSerial = new Label();
        lblLocation = new Label();
        lblStatus = new Label();

        txtId = new TextBox();
        txtBarcode = new TextBox();
        txtName = new TextBox();
        txtCategory = new TextBox();
        txtSerial = new TextBox();
        txtLocation = new TextBox();

        cboStatus = new ComboBox();

        btnSave = new Button();
        btnUpdate = new Button();
        btnDelete = new Button();
        btnClear = new Button();
        btnClose = new Button();

        dgvEquipment = new DataGridView();

        ((System.ComponentModel.ISupportInitialize)dgvEquipment).BeginInit();
        grpDetails.SuspendLayout();
        SuspendLayout();

        //---------------------------------------------------------
        // Group Box
        //---------------------------------------------------------
        grpDetails.Location = new Point(20, 20);
        grpDetails.Name = "grpDetails";
        grpDetails.Size = new Size(940, 150);
        grpDetails.TabIndex = 0;
        grpDetails.TabStop = false;
        grpDetails.Text = "Equipment Details";

        //---------------------------------------------------------
        // Labels and Controls
        //---------------------------------------------------------
        Label[] labels =
        {
            lblId,
            lblBarcode,
            lblName,
            lblCategory,
            lblSerial,
            lblLocation,
            lblStatus
        };

        string[] captions =
        {
            "ID",
            "Barcode",
            "Name",
            "Category",
            "Serial #",
            "Location",
            "Status"
        };

        Control[] controls =
        {
            txtId,
            txtBarcode,
            txtName,
            txtCategory,
            txtSerial,
            txtLocation,
            cboStatus
        };

        for (int i = 0; i < labels.Length; i++)
        {
            labels[i].AutoSize = true;
            labels[i].Name = $"lbl{i}";
            labels[i].Text = captions[i];

            labels[i].Location =
                new Point(15 + ((i % 4) * 230),
                          30 + ((i / 4) * 45));

            controls[i].Name = $"ctl{i}";
            controls[i].Location =
                new Point(95 + ((i % 4) * 230),
                          27 + ((i / 4) * 45));

            controls[i].Size = new Size(120, 27);

            grpDetails.Controls.Add(labels[i]);
            grpDetails.Controls.Add(controls[i]);
        }

        //---------------------------------------------------------
        // TextBox ID
        //---------------------------------------------------------
        txtId.Name = "txtId";
        txtId.ReadOnly = true;

        //---------------------------------------------------------
        // ComboBox Status
        //---------------------------------------------------------
        cboStatus.Name = "cboStatus";
        cboStatus.DropDownStyle = ComboBoxStyle.DropDownList;

        cboStatus.Items.AddRange(new object[]
        {
            "Available",
            "Checked Out",
            "Damaged",
            "Retired"
        });

        cboStatus.SelectedIndex = 0;

        //---------------------------------------------------------
        // Buttons
        //---------------------------------------------------------
        btnSave.Name = "btnSave";
        btnSave.Text = "Save";

        btnUpdate.Name = "btnUpdate";
        btnUpdate.Text = "Update";

        btnDelete.Name = "btnDelete";
        btnDelete.Text = "Delete";

        btnClear.Name = "btnClear";
        btnClear.Text = "Clear";

        btnClose.Name = "btnClose";
        btnClose.Text = "Close";

        Button[] buttons =
        {
            btnSave,
            btnUpdate,
            btnDelete,
            btnClear,
            btnClose
        };

        for (int i = 0; i < buttons.Length; i++)
        {
            buttons[i].Location =
                new Point(275 + (i * 120), 105);

            buttons[i].Size = new Size(100, 32);
            buttons[i].UseVisualStyleBackColor = true;

            grpDetails.Controls.Add(buttons[i]);
        }

        //---------------------------------------------------------
        // Button Events
        //---------------------------------------------------------
        btnSave.Click += btnSave_Click;
        btnUpdate.Click += btnUpdate_Click;
        btnDelete.Click += btnDelete_Click;
        btnClear.Click += btnClear_Click;
        btnClose.Click += btnClose_Click;

        //---------------------------------------------------------
        // Equipment Data Grid
        //---------------------------------------------------------
        dgvEquipment.Name = "dgvEquipment";
        dgvEquipment.Location = new Point(20, 185);
        dgvEquipment.Size = new Size(940, 350);

        dgvEquipment.ReadOnly = true;
        dgvEquipment.AllowUserToAddRows = false;
        dgvEquipment.AllowUserToDeleteRows = false;
        dgvEquipment.AllowUserToResizeRows = false;

        dgvEquipment.AutoSizeColumnsMode =
            DataGridViewAutoSizeColumnsMode.Fill;

        dgvEquipment.SelectionMode =
            DataGridViewSelectionMode.FullRowSelect;

        dgvEquipment.MultiSelect = false;

        dgvEquipment.CellClick += dgvEquipment_CellClick;

        //---------------------------------------------------------
        // Equipment Form
        //---------------------------------------------------------
        AutoScaleDimensions = new SizeF(8F, 20F);
        AutoScaleMode = AutoScaleMode.Font;

        ClientSize = new Size(985, 560);

        Controls.Add(grpDetails);
        Controls.Add(dgvEquipment);

        FormBorderStyle = FormBorderStyle.FixedDialog;
        MaximizeBox = false;
        MinimizeBox = false;

        Name = "EquipmentForm";
        StartPosition = FormStartPosition.CenterParent;
        Text = "Equipment / Inventory";

        ((System.ComponentModel.ISupportInitialize)dgvEquipment).EndInit();
        grpDetails.ResumeLayout(false);
        grpDetails.PerformLayout();
        ResumeLayout(false);
    }
}
