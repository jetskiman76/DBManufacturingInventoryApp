namespace GBManufacturingTracker;

/// <summary>
/// Main dashboard displayed after a successful user login.
/// Provides navigation to all major modules of the
/// GB Manufacturing Tracker application.
/// </summary>
public partial class DashboardForm : Form
{
    /// <summary>
    /// Initializes the Dashboard form and displays
    /// the currently logged-in user's information.
    /// </summary>
    public DashboardForm()
    {
        InitializeComponent();

        // Display the current user's full name and role.
        lblWelcome.Text =
            $"Welcome {Session.FullName} ({Session.RoleName})";
    }

    /// <summary>
    /// Opens the Equipment Management window.
    /// </summary>
    private void btnEquipment_Click(object? sender, EventArgs e)
    {
        using EquipmentForm equipmentForm = new();

        equipmentForm.ShowDialog();
    }

    /// <summary>
    /// Opens the Equipment Checkout and Return window.
    /// </summary>
    private void btnCheckout_Click(object? sender, EventArgs e)
    {
        using CheckoutForm checkoutForm = new();

        checkoutForm.ShowDialog();
    }

    /// <summary>
    /// Opens the Damage Report Management window.
    /// </summary>
    private void btnDamage_Click(object? sender, EventArgs e)
    {
        using DamageReportForm damageReportForm = new();

        damageReportForm.ShowDialog();
    }

    /// <summary>
    /// Opens the Reports window.
    /// </summary>
    private void btnReports_Click(object? sender, EventArgs e)
    {
        using ReportsForm reportsForm = new();

        reportsForm.ShowDialog();
    }

    /// <summary>
    /// Logs the current user out of the application.
    /// Clears the active session and closes the dashboard,
    /// returning control to the Login form.
    /// </summary>
    private void btnLogout_Click(object? sender, EventArgs e)
    {
        // Clear all session information.
        Session.Clear();

        // Close the dashboard.
        Close();
    }
}
