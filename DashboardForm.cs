namespace GBManufacturingTracker;
public partial class DashboardForm : Form
{
    public DashboardForm(){ InitializeComponent(); lblWelcome.Text = $"Welcome {Session.FullName} ({Session.RoleName})"; }
    private void btnEquipment_Click(object? s, EventArgs e){ using EquipmentForm f=new(); f.ShowDialog(); }
    private void btnCheckout_Click(object? s, EventArgs e){ using CheckoutForm f=new(); f.ShowDialog(); }
    private void btnDamage_Click(object? s, EventArgs e){ using DamageReportForm f=new(); f.ShowDialog(); }
    private void btnReports_Click(object? s, EventArgs e){ using ReportsForm f=new(); f.ShowDialog(); }
    private void btnLogout_Click(object? s, EventArgs e){ Session.Clear(); Close(); }
}
