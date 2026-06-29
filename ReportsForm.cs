using System.Data;
using System.Text;
namespace GBManufacturingTracker;
public partial class ReportsForm:Form
{ public ReportsForm(){InitializeComponent();LoadEquipment();}
 private void Bind(DataTable t)=>dgvReport.DataSource=t;
 private void LoadEquipment()=>Bind(Db.GetTable("SELECT EquipmentID,EquipmentName,Category,WarehouseLocation,Status FROM Equipment ORDER BY EquipmentName"));
 private void btnEquipment_Click(object? s,EventArgs e)=>LoadEquipment();
 private void btnDamage_Click(object? s,EventArgs e)=>Bind(Db.GetTable(@"SELECT d.DamageReportID,e.EquipmentName,d.DamageDate,d.Severity,d.Description,d.ActionTaken FROM DamageReports d JOIN Equipment e ON d.EquipmentID=e.EquipmentID ORDER BY d.DamageDate DESC"));
 private void btnOverdue_Click(object? s,EventArgs e)=>Bind(Db.GetTable(@"SELECT t.TransactionID,u.FullName,e.EquipmentName,t.CheckoutDate,t.DueDate FROM CheckoutTransactions t JOIN Users u ON t.UserID=u.UserID JOIN Equipment e ON t.EquipmentID=e.EquipmentID WHERE t.ReturnDate IS NULL AND t.DueDate<GETDATE()"));
 private void btnExport_Click(object? s,EventArgs e){if(dgvReport.DataSource is not DataTable t)return; string file=Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments),"GBM_Report_"+DateTime.Now.ToString("yyyyMMdd_HHmmss")+".csv"); StringBuilder sb=new(); foreach(DataColumn c in t.Columns) sb.Append(c.ColumnName+","); sb.AppendLine(); foreach(DataRow r in t.Rows){ foreach(var item in r.ItemArray) sb.Append('"'+item.ToString()?.Replace("\"","\"\"")+'"'+","); sb.AppendLine(); } File.WriteAllText(file,sb.ToString()); MessageBox.Show("Report saved: "+file);}
 private void btnClose_Click(object? s,EventArgs e)=>Close(); }
