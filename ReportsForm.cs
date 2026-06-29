using System.Data;
using System.Text;

namespace GBManufacturingTracker;

/// <summary>
/// Displays equipment, damage, and overdue checkout reports.
/// Provides functionality to export the currently displayed
/// report to a CSV file.
/// </summary>
public partial class ReportsForm : Form
{
    /// <summary>
    /// Initializes the Reports form.
    /// </summary>
    public ReportsForm()
    {
        InitializeComponent();

        // Load the default Equipment report.
        LoadEquipment();
    }

    /// <summary>
    /// Binds a DataTable to the report grid.
    /// </summary>
    /// <param name="table">The data to display.</param>
    private void Bind(DataTable table)
    {
        dgvReport.DataSource = table;
    }

    /// <summary>
    /// Loads the Equipment Status report.
    /// </summary>
    private void LoadEquipment()
    {
        Bind(Db.GetTable(@"
            SELECT
                EquipmentID,
                EquipmentName,
                Category,
                WarehouseLocation,
                Status
            FROM Equipment
            ORDER BY EquipmentName"));
    }

    /// <summary>
    /// Displays the Equipment Status report.
    /// </summary>
    private void btnEquipment_Click(object? sender, EventArgs e)
    {
        LoadEquipment();
    }

    /// <summary>
    /// Displays all damage reports.
    /// </summary>
    private void btnDamage_Click(object? sender, EventArgs e)
    {
        Bind(Db.GetTable(@"
            SELECT
                d.DamageReportID,
                e.EquipmentName,
                d.DamageDate,
                d.Severity,
                d.Description,
                d.ActionTaken
            FROM DamageReports d
                INNER JOIN Equipment e
                    ON d.EquipmentID = e.EquipmentID
            ORDER BY d.DamageDate DESC"));
    }

    /// <summary>
    /// Displays all overdue equipment checkouts.
    /// </summary>
    private void btnOverdue_Click(object? sender, EventArgs e)
    {
        Bind(Db.GetTable(@"
            SELECT
                t.TransactionID,
                u.FullName,
                e.EquipmentName,
                t.CheckoutDate,
                t.DueDate
            FROM CheckoutTransactions t
                INNER JOIN Users u
                    ON t.UserID = u.UserID
                INNER JOIN Equipment e
                    ON t.EquipmentID = e.EquipmentID
            WHERE
                t.ReturnDate IS NULL
                AND t.DueDate < GETDATE()"));
    }

    /// <summary>
    /// Exports the current report to a CSV file.
    /// </summary>
    private void btnExport_Click(object? sender, EventArgs e)
    {
        if (dgvReport.DataSource is not DataTable table)
            return;

        string filePath = Path.Combine(
            Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments),
            $"GBM_Report_{DateTime.Now:yyyyMMdd_HHmmss}.csv");

        StringBuilder csv = new();

        // Write column headers.
        foreach (DataColumn column in table.Columns)
        {
            csv.Append(column.ColumnName);
            csv.Append(",");
        }

        csv.AppendLine();

        // Write report rows.
        foreach (DataRow row in table.Rows)
        {
            foreach (object item in row.ItemArray)
            {
                csv.Append('"');
                csv.Append(item.ToString()?.Replace("\"", "\"\""));
                csv.Append("\",");
            }

            csv.AppendLine();
        }

        // Save the report.
        File.WriteAllText(filePath, csv.ToString());

        MessageBox.Show(
            $"Report saved successfully.\n\n{filePath}",
            "Export Complete",
            MessageBoxButtons.OK,
            MessageBoxIcon.Information);
    }

    /// <summary>
    /// Closes the Reports form.
    /// </summary>
    private void btnClose_Click(object? sender, EventArgs e)
    {
        Close();
    }
}
