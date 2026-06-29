namespace GBManufacturingTracker;

partial class ReportsForm
{
    /// <summary>
    /// Required designer variable.
    /// </summary>
    private System.ComponentModel.IContainer? components = null;

    // Form Controls
    private Label lblTitle = null!;

    private Button btnEquipment = null!;
    private Button btnDamage = null!;
    private Button btnOverdue = null!;
    private Button btnExport = null!;
    private Button btnClose = null!;

    private DataGridView dgvReport = null!;

    /// <summary>
    /// Releases all resources used by the form.
    /// </summary>
    /// <param name="disposing">
    /// True if managed resources should be disposed;
    /// otherwise, false.
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

        btnEquipment = new Button();
        btnDamage = new Button();
        btnOverdue = new Button();
        btnExport = new Button();
        btnClose = new Button();

        dgvReport = new DataGridView();

        ((System.ComponentModel.ISupportInitialize)dgvReport).BeginInit();

        SuspendLayout();

        //---------------------------------------------------------
        // Title Label
        //---------------------------------------------------------
        lblTitle.Text = "Saved Reports";
        lblTitle.Name = "lblTitle";
        lblTitle.Font = new Font(
            "Segoe UI",
            16F,
            FontStyle.Bold);

        lblTitle.Location = new Point(25, 20);
        lblTitle.Size = new Size(300, 35);

        //---------------------------------------------------------
        // Configure Buttons
        //---------------------------------------------------------
        Button[] buttons =
        {
            btnEquipment,
            btnDamage,
            btnOverdue,
            btnExport,
            btnClose
        };

        string[] captions =
        {
            "Equipment",
            "Damage Reports",
            "Overdue",
            "Export CSV",
            "Close"
        };

        for (int i = 0; i < buttons.Length; i++)
        {
            buttons[i].Name = $"btn{i}";
            buttons[i].Text = captions[i];

            buttons[i].Location =
                new Point(25 + (i * 130), 70);

            buttons[i].Size = new Size(120, 35);

            buttons[i].UseVisualStyleBackColor = true;
        }

        //---------------------------------------------------------
        // Button Events
        //---------------------------------------------------------
        btnEquipment.Click += btnEquipment_Click;
        btnDamage.Click += btnDamage_Click;
        btnOverdue.Click += btnOverdue_Click;
        btnExport.Click += btnExport_Click;
        btnClose.Click += btnClose_Click;

        //---------------------------------------------------------
        // Report Grid
        //---------------------------------------------------------
        dgvReport.Name = "dgvReport";
        dgvReport.Location = new Point(25, 125);
        dgvReport.Size = new Size(850, 380);

        dgvReport.ReadOnly = true;
        dgvReport.AllowUserToAddRows = false;
        dgvReport.AllowUserToDeleteRows = false;
        dgvReport.AllowUserToResizeRows = false;

        dgvReport.SelectionMode =
            DataGridViewSelectionMode.FullRowSelect;

        dgvReport.MultiSelect = false;

        dgvReport.AutoSizeColumnsMode =
            DataGridViewAutoSizeColumnsMode.Fill;

        //---------------------------------------------------------
        // Reports Form
        //---------------------------------------------------------
        AutoScaleDimensions = new SizeF(8F, 20F);
        AutoScaleMode = AutoScaleMode.Font;

        ClientSize = new Size(900, 530);

        Controls.Add(lblTitle);
        Controls.Add(btnEquipment);
        Controls.Add(btnDamage);
        Controls.Add(btnOverdue);
        Controls.Add(btnExport);
        Controls.Add(btnClose);
        Controls.Add(dgvReport);

        Name = "ReportsForm";
        StartPosition = FormStartPosition.CenterParent;
        Text = "Reports";

        ((System.ComponentModel.ISupportInitialize)dgvReport).EndInit();

        ResumeLayout(false);
    }
}
