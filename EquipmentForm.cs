using Microsoft.Data.SqlClient;

namespace GBManufacturingTracker;

/// <summary>
/// Provides equipment management functionality including
/// adding, updating, deleting, clearing, and viewing equipment records.
/// </summary>
public partial class EquipmentForm : Form
{
    /// <summary>
    /// Initializes the Equipment form.
    /// </summary>
    public EquipmentForm()
    {
        InitializeComponent();

        // Load equipment records when the form opens.
        LoadData();
    }

    /// <summary>
    /// Loads all equipment records into the DataGridView.
    /// </summary>
    private void LoadData()
    {
        dgvEquipment.DataSource = Db.GetTable(@"
            SELECT
                EquipmentID,
                Barcode,
                EquipmentName,
                Category,
                SerialNumber,
                WarehouseLocation,
                Status
            FROM Equipment
            ORDER BY EquipmentName");
    }

    /// <summary>
    /// Saves a new equipment record.
    /// </summary>
    private void btnSave_Click(object? sender, EventArgs e)
    {
        Db.Execute(@"
            INSERT INTO Equipment
            (
                Barcode,
                EquipmentName,
                Category,
                SerialNumber,
                WarehouseLocation,
                Status
            )
            VALUES
            (
                @b,
                @n,
                @c,
                @sn,
                @w,
                @st
            )",
            new SqlParameter("@b", txtBarcode.Text),
            new SqlParameter("@n", txtName.Text),
            new SqlParameter("@c", txtCategory.Text),
            new SqlParameter("@sn", txtSerial.Text),
            new SqlParameter("@w", txtLocation.Text),
            new SqlParameter("@st", cboStatus.Text));

        // Refresh the equipment list.
        LoadData();
    }

    /// <summary>
    /// Updates the selected equipment record.
    /// </summary>
    private void btnUpdate_Click(object? sender, EventArgs e)
    {
        if (string.IsNullOrWhiteSpace(txtId.Text))
            return;

        Db.Execute(@"
            UPDATE Equipment
            SET
                Barcode = @b,
                EquipmentName = @n,
                Category = @c,
                SerialNumber = @sn,
                WarehouseLocation = @w,
                Status = @st
            WHERE EquipmentID = @id",
            new SqlParameter("@id", txtId.Text),
            new SqlParameter("@b", txtBarcode.Text),
            new SqlParameter("@n", txtName.Text),
            new SqlParameter("@c", txtCategory.Text),
            new SqlParameter("@sn", txtSerial.Text),
            new SqlParameter("@w", txtLocation.Text),
            new SqlParameter("@st", cboStatus.Text));

        // Refresh the equipment list.
        LoadData();
    }

    /// <summary>
    /// Deletes the selected equipment record.
    /// </summary>
    private void btnDelete_Click(object? sender, EventArgs e)
    {
        if (string.IsNullOrWhiteSpace(txtId.Text))
            return;

        Db.Execute(@"
            DELETE FROM Equipment
            WHERE EquipmentID = @id",
            new SqlParameter("@id", txtId.Text));

        // Clear the entry controls.
        Clear();

        // Refresh the equipment list.
        LoadData();
    }

    /// <summary>
    /// Clears all entry controls.
    /// </summary>
    private void btnClear_Click(object? sender, EventArgs e)
    {
        Clear();
    }

    /// <summary>
    /// Closes the Equipment form.
    /// </summary>
    private void btnClose_Click(object? sender, EventArgs e)
    {
        Close();
    }

    /// <summary>
    /// Clears all input fields and resets the status selection.
    /// </summary>
    private void Clear()
    {
        foreach (Control control in grpDetails.Controls)
        {
            if (control is TextBox textBox)
            {
                textBox.Clear();
            }
        }

        cboStatus.SelectedIndex = 0;
    }

    /// <summary>
    /// Loads the selected equipment record into the input controls.
    /// </summary>
    private void dgvEquipment_CellClick(
        object? sender,
        DataGridViewCellEventArgs e)
    {
        if (e.RowIndex < 0)
            return;

        DataGridViewRow row = dgvEquipment.Rows[e.RowIndex];

        txtId.Text = row.Cells["EquipmentID"].Value?.ToString();
        txtBarcode.Text = row.Cells["Barcode"].Value?.ToString();
        txtName.Text = row.Cells["EquipmentName"].Value?.ToString();
        txtCategory.Text = row.Cells["Category"].Value?.ToString();
        txtSerial.Text = row.Cells["SerialNumber"].Value?.ToString();
        txtLocation.Text = row.Cells["WarehouseLocation"].Value?.ToString();
        cboStatus.Text = row.Cells["Status"].Value?.ToString();
    }
}
