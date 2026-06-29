using Microsoft.Data.SqlClient;

namespace GBManufacturingTracker;

/// <summary>
/// Provides functionality for checking equipment out to users,
/// returning equipment, and viewing checkout transactions.
/// </summary>
public partial class CheckoutForm : Form
{
    /// <summary>
    /// Initializes the Checkout form.
    /// </summary>
    public CheckoutForm()
    {
        InitializeComponent();

        // Load users, equipment, and existing transactions.
        LoadCombos();
        LoadTransactions();
    }

    /// <summary>
    /// Loads users and available equipment into their
    /// respective ComboBox controls.
    /// </summary>
    private void LoadCombos()
    {
        // Load users.
        cboUser.DataSource = Db.GetTable(@"
            SELECT
                UserID,
                FullName
            FROM Users
            ORDER BY FullName");

        cboUser.DisplayMember = "FullName";
        cboUser.ValueMember = "UserID";

        // Load equipment.
        cboEquipment.DataSource = Db.GetTable(@"
            SELECT
                EquipmentID,
                EquipmentName
            FROM Equipment
            WHERE Status IN ('Available', 'Checked Out')
            ORDER BY EquipmentName");

        cboEquipment.DisplayMember = "EquipmentName";
        cboEquipment.ValueMember = "EquipmentID";
    }

    /// <summary>
    /// Loads all equipment checkout transactions.
    /// </summary>
    private void LoadTransactions()
    {
        dgvTransactions.DataSource = Db.GetTable(@"
            SELECT
                t.TransactionID,
                u.FullName,
                e.EquipmentName,
                t.CheckoutDate,
                t.DueDate,
                t.ReturnDate,
                t.TransactionStatus
            FROM CheckoutTransactions t
                INNER JOIN Users u
                    ON t.UserID = u.UserID
                INNER JOIN Equipment e
                    ON t.EquipmentID = e.EquipmentID
            ORDER BY t.TransactionID DESC");
    }

    /// <summary>
    /// Checks equipment out to the selected user.
    /// </summary>
    private void btnCheckout_Click(object? sender, EventArgs e)
    {
        Db.Execute(@"
            INSERT INTO CheckoutTransactions
            (
                UserID,
                EquipmentID,
                CheckoutDate,
                DueDate,
                TransactionStatus
            )
            VALUES
            (
                @u,
                @eq,
                @c,
                @d,
                'Checked Out'
            );

            UPDATE Equipment
            SET Status = 'Checked Out'
            WHERE EquipmentID = @eq",
            new SqlParameter("@u", cboUser.SelectedValue),
            new SqlParameter("@eq", cboEquipment.SelectedValue),
            new SqlParameter("@c", dtCheckout.Value),
            new SqlParameter("@d", dtDue.Value));

        // Refresh the data.
        LoadCombos();
        LoadTransactions();
    }

    /// <summary>
    /// Returns the selected equipment.
    /// If the equipment is damaged, a Damage Report
    /// is opened automatically.
    /// </summary>
    private void btnReturn_Click(object? sender, EventArgs e)
    {
        if (string.IsNullOrWhiteSpace(txtTransactionId.Text))
            return;

        Db.Execute(@"
            UPDATE CheckoutTransactions
            SET
                ReturnDate = GETDATE(),
                TransactionStatus = 'Returned'
            WHERE TransactionID = @id;

            UPDATE Equipment
            SET Status =
                CASE
                    WHEN @damaged = 1 THEN 'Damaged'
                    ELSE 'Available'
                END
            WHERE EquipmentID =
            (
                SELECT EquipmentID
                FROM CheckoutTransactions
                WHERE TransactionID = @id
            )",
            new SqlParameter("@id", txtTransactionId.Text),
            new SqlParameter("@damaged", chkDamaged.Checked));

        // Open the Damage Report form if needed.
        if (chkDamaged.Checked)
        {
            using DamageReportForm damageForm =
                new(txtTransactionId.Text);

            damageForm.ShowDialog();
        }

        // Refresh the data.
        LoadCombos();
        LoadTransactions();
    }

    /// <summary>
    /// Loads the selected transaction ID into the textbox.
    /// </summary>
    private void dgvTransactions_CellClick(
        object? sender,
        DataGridViewCellEventArgs e)
    {
        if (e.RowIndex < 0)
            return;

        txtTransactionId.Text =
            dgvTransactions.Rows[e.RowIndex]
                .Cells["TransactionID"]
                .Value?
                .ToString();
    }

    /// <summary>
    /// Closes the Checkout form.
    /// </summary>
    private void btnClose_Click(object? sender, EventArgs e)
    {
        Close();
    }
}
