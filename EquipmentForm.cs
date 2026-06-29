using Microsoft.Data.SqlClient;
namespace GBManufacturingTracker;
public partial class EquipmentForm : Form
{
    public EquipmentForm(){ InitializeComponent(); LoadData(); }
    private void LoadData(){ dgvEquipment.DataSource=Db.GetTable("SELECT EquipmentID, Barcode, EquipmentName, Category, SerialNumber, WarehouseLocation, Status FROM Equipment ORDER BY EquipmentName"); }
    private void btnSave_Click(object? s, EventArgs e){ Db.Execute(@"INSERT INTO Equipment(Barcode,EquipmentName,Category,SerialNumber,WarehouseLocation,Status) VALUES(@b,@n,@c,@sn,@w,@st)",new SqlParameter("@b",txtBarcode.Text),new SqlParameter("@n",txtName.Text),new SqlParameter("@c",txtCategory.Text),new SqlParameter("@sn",txtSerial.Text),new SqlParameter("@w",txtLocation.Text),new SqlParameter("@st",cboStatus.Text)); LoadData(); }
    private void btnUpdate_Click(object? s, EventArgs e){ if(txtId.Text=="")return; Db.Execute(@"UPDATE Equipment SET Barcode=@b, EquipmentName=@n, Category=@c, SerialNumber=@sn, WarehouseLocation=@w, Status=@st WHERE EquipmentID=@id",new SqlParameter("@id",txtId.Text),new SqlParameter("@b",txtBarcode.Text),new SqlParameter("@n",txtName.Text),new SqlParameter("@c",txtCategory.Text),new SqlParameter("@sn",txtSerial.Text),new SqlParameter("@w",txtLocation.Text),new SqlParameter("@st",cboStatus.Text)); LoadData(); }
    private void btnDelete_Click(object? s, EventArgs e){ if(txtId.Text=="")return; Db.Execute("DELETE FROM Equipment WHERE EquipmentID=@id",new SqlParameter("@id",txtId.Text)); Clear(); LoadData(); }
    private void btnClear_Click(object? s, EventArgs e)=>Clear(); private void btnClose_Click(object? s, EventArgs e)=>Close();
    private void Clear(){foreach(Control c in grpDetails.Controls) if(c is TextBox t)t.Clear(); cboStatus.SelectedIndex=0;}
    private void dgvEquipment_CellClick(object? s, DataGridViewCellEventArgs e){ if(e.RowIndex<0)return; var r=dgvEquipment.Rows[e.RowIndex]; txtId.Text=r.Cells["EquipmentID"].Value?.ToString(); txtBarcode.Text=r.Cells["Barcode"].Value?.ToString(); txtName.Text=r.Cells["EquipmentName"].Value?.ToString(); txtCategory.Text=r.Cells["Category"].Value?.ToString(); txtSerial.Text=r.Cells["SerialNumber"].Value?.ToString(); txtLocation.Text=r.Cells["WarehouseLocation"].Value?.ToString(); cboStatus.Text=r.Cells["Status"].Value?.ToString(); }
}
