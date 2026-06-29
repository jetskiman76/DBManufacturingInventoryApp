using Microsoft.Data.SqlClient;

namespace GBManufacturingTracker;

/// <summary>
/// Manages equipment damage reports, including creating,
/// viewing, and exporting reports.
/// </summary>
public partial class DamageReportForm : Form
{
    /// <summary>
    /// Initializes the Damage Report form.
    /// </summary>
    public DamageReportForm()
    {
        InitializeComponent();

        // Load equipment list and existing damage reports.
        LoadEquipment();
        LoadReports();
    }

    /// <summary>
    /// Initializes the form using an existing transaction ID.
    /// </summary>
    /// <param name="transactionId">
    /// Equipment checkout transaction ID.
    /// </param>
    public DamageReportForm(string transactionId)
        : this()
    {
        txtTransactionId.Text = transactionId;
    }

    /// <summary>
    /// Loads all equipment into the Equipment combo box.
    /// </summary>
    private void LoadEquipment()
    {
        cboEquipment.DataSource = Db.GetTable(@"
            SELECT
                EquipmentID,
                EquipmentName
            FROM Equipment
            ORDER BY EquipmentName");

        cboEquipment.DisplayMember = "EquipmentName";
        cboEquipment.ValueMember = "EquipmentID";
    }

    /// <summary>
    /// Loads all damage reports into the DataGridView.
    /// </summary>
    private void LoadReports()
    {
        dgvReports.DataSource = Db.GetTable(@"
            SELECT
                d.DamageReportID,
                e.EquipmentName,
                d.TransactionID,
                d.DamageDate,
                d.Severity,
                d.Description,
                d.ActionTaken,
                d.ReportSavedPath
            FROM DamageReports d
                INNER JOIN Equipment e
                    ON d.EquipmentID = e.EquipmentID
            ORDER BY d.DamageReportID DESC");
    }

    /// <summary>
    /// Saves a new damage report to the database.
    /// Also updates the equipment status to Damaged.
    /// </summary>
    private void btnSave_Click(object? sender, EventArgs e)
    {
        Db.Execute(@"
            INSERT INTO DamageReports
            (
                EquipmentID,
                TransactionID,
                ReportedByUserID,
                DamageDate,
                Severity,
                Description,
                ActionTaken
            )
            VALUES
            (
                @eq,
                NULLIF(@tid, ''),
                @u,
                @date,
                @sev,
                @desc,
                @action
            )",
            new SqlParameter("@eq", cboEquipment.SelectedValue),
            new SqlParameter("@tid", txtTransactionId.Text),
            new SqlParameter("@u", Session.UserId == 0 ? 1 : Session.UserId),
            new SqlParameter("@date", dtDamage.Value),
            new SqlParameter("@sev", cboSeverity.Text),
            new SqlParameter("@desc", txtDescription.Text),
            new SqlParameter("@action", txtAction.Text));

        // Update the equipment status.
        Db.Execute(@"
            UPDATE Equipment
            SET Status = 'Damaged'
            WHERE EquipmentID = @eq",
            new SqlParameter("@eq", cboEquipment.SelectedValue));

        LoadReports();

        MessageBox.Show(
            "Damage report saved successfully.",
            "Save Complete",
            MessageBoxButtons.OK,
            MessageBoxIcon.Information);
    }

    /// <summary>
    /// Exports the selected damage report to a text file.
    /// The exported file path is stored in the database.
    /// </summary>
    private void btnExport_Click(object? sender, EventArgs e)
    {
        if (dgvReports.CurrentRow == null)
            return;

        int reportId =
            Convert.ToInt32(
                dgvReports.CurrentRow.Cells["DamageReportID"].Value);

        string filePath = Path.Combine(
            Environment.GetFolderPath(
                Environment.SpecialFolder.MyDocuments),
            $"DamageReport_{reportId}.txt");

        File.WriteAllText(
            filePath,
$@"GB Manufacturing Damage Report #{reportId}

Equipment: {dgvReports.CurrentRow.Cells["EquipmentName"].Value}
Date: {dgvReports.CurrentRow.Cells["DamageDate"].Value}
Severity: {dgvReports.CurrentRow.Cells["Severity"].Value}

Description:
{dgvReports.CurrentRow.Cells["Description"].Value}

Action Taken:
{dgvReports.CurrentRow.Cells["ActionTaken"].Value}");

        // Save the exported file location.
        Db.Execute(@"
            UPDATE DamageReports
            SET ReportSavedPath = @path
            WHERE DamageReportID = @id",
            new SqlParameter("@path", filePath),
            new SqlParameter("@id", reportId));

        LoadReports();

        MessageBox.Show(
            $"Report exported successfully.\n\n{filePath}",
            "Export Complete",
            MessageBoxButtons.OK,
            MessageBoxIcon.Information);
    }

    /// <summary>
    /// Clears all entry fields.
    /// </summary>
    private void btnClear_Click(object? sender, EventArgs e)
    {
        txtTransactionId.Clear();
        txtDescription.Clear();
        txtAction.Clear();

        if (cboSeverity.Items.Count > 0)
        {
            cboSeverity.SelectedIndex = 0;
        }
    }

    /// <summary>
    /// Closes the Damage Report form.
    /// </summary>
    private void btnClose_Click(object? sender, EventArgs e)
    {
        Close();
    }
}
