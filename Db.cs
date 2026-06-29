using System.Data;
using Microsoft.Data.SqlClient;

namespace GBManufacturingTracker;

public static class Db
{
    public static string ConnectionString { get; set; } =
        @"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=GBManufacturingTrackerDB;Integrated Security=True;Encrypt=False;TrustServerCertificate=True";

    public static SqlConnection GetConnection() => new(ConnectionString);

    public static DataTable GetTable(string sql, params SqlParameter[] parameters)
    {
        using SqlConnection con = GetConnection();
        using SqlCommand cmd = new(sql, con);
        if (parameters.Length > 0) cmd.Parameters.AddRange(parameters);
        using SqlDataAdapter adapter = new(cmd);
        DataTable table = new();
        adapter.Fill(table);
        return table;
    }

    public static int Execute(string sql, params SqlParameter[] parameters)
    {
        using SqlConnection con = GetConnection();
        using SqlCommand cmd = new(sql, con);
        if (parameters.Length > 0) cmd.Parameters.AddRange(parameters);
        con.Open();
        return cmd.ExecuteNonQuery();
    }

    public static object? Scalar(string sql, params SqlParameter[] parameters)
    {
        using SqlConnection con = GetConnection();
        using SqlCommand cmd = new(sql, con);
        if (parameters.Length > 0) cmd.Parameters.AddRange(parameters);
        con.Open();
        return cmd.ExecuteScalar();
    }
}
