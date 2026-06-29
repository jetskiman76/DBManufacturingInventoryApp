namespace GBManufacturingTracker;

partial class DashboardForm
{
    /// <summary>
    /// Required designer variable.
    /// </summary>
    private System.ComponentModel.IContainer? components = null;

    //=========================================================
    // Labels
    //=========================================================
    private Label lblTitle = null!;
    private Label lblWelcome = null!;

    //=========================================================
    // Buttons
    //=========================================================
    private Button btnEquipment = null!;
    private Button btnCheckout = null!;
    private Button btnDamage = null!;
    private Button btnReports = null!;
    private Button btnLogout = null!;

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

        lblTitle = new Label();
        lblWelcome = new Label();

        btnEquipment = new Button();
        btnCheckout = new Button();
        btnDamage = new Button();
        btnReports = new Button();
        btnLogout = new Button();

        SuspendLayout();

        //---------------------------------------------------------
        // Title Label
        //---------------------------------------------------------
        lblTitle.AutoSize = false;
        lblTitle.Name = "lblTitle";
        lblTitle.Text = "GB Manufacturing Equipment and Inventory Tracking";
        lblTitle.Font = new Font("Segoe UI", 18F, FontStyle.Bold);
        lblTitle.Location = new Point(30, 25);
        lblTitle.Size = new Size(650, 45);
        lblTitle.TextAlign = ContentAlignment.MiddleLeft;

        //---------------------------------------------------------
        // Welcome Label
        //---------------------------------------------------------
        lblWelcome.AutoSize = false;
        lblWelcome.Name = "lblWelcome";
        lblWelcome.Location = new Point(35, 75);
        lblWelcome.Size = new Size(600, 30);
        lblWelcome.Font = new Font("Segoe UI", 10F);
        lblWelcome.TextAlign = ContentAlignment.MiddleLeft;

        //---------------------------------------------------------
        // Configure Dashboard Buttons
        //---------------------------------------------------------
        Button[] buttons =
        {
            btnEquipment,
            btnCheckout,
            btnDamage,
            btnReports,
            btnLogout
        };

        string[] captions =
        {
            "Equipment / Inventory",
            "Checkout / Return",
            "Damage Reports",
            "Saved Reports",
            "Logout"
        };

        string[] names =
        {
            "btnEquipment",
            "btnCheckout",
            "btnDamage",
            "btnReports",
            "btnLogout"
        };

        for (int i = 0; i < buttons.Length; i++)
        {
            buttons[i].Name = names[i];
            buttons[i].Text = captions[i];
            buttons[i].Size = new Size(250, 55);

            buttons[i].Location = new Point(
                60 + ((i % 2) * 300),
                125 + ((i / 2) * 80));

            buttons[i].Font =
                new Font("Segoe UI", 10F, FontStyle.Bold);

            buttons[i].UseVisualStyleBackColor = true;
            buttons[i].TabIndex = i;
        }

        //---------------------------------------------------------
        // Button Events
        //---------------------------------------------------------
        btnEquipment.Click += btnEquipment_Click;
        btnCheckout.Click += btnCheckout_Click;
        btnDamage.Click += btnDamage_Click;
        btnReports.Click += btnReports_Click;
        btnLogout.Click += btnLogout_Click;

        //---------------------------------------------------------
        // Dashboard Form
        //---------------------------------------------------------
        AutoScaleDimensions = new SizeF(8F, 20F);
        AutoScaleMode = AutoScaleMode.Font;

        ClientSize = new Size(720, 390);

        Controls.Add(lblTitle);
        Controls.Add(lblWelcome);

        Controls.Add(btnEquipment);
        Controls.Add(btnCheckout);
        Controls.Add(btnDamage);
        Controls.Add(btnReports);
        Controls.Add(btnLogout);

        FormBorderStyle = FormBorderStyle.FixedDialog;
        MaximizeBox = false;
        MinimizeBox = false;

        Name = "DashboardForm";
        StartPosition = FormStartPosition.CenterScreen;
        Text = "GB Manufacturing Dashboard";

        ResumeLayout(false);
    }
}
