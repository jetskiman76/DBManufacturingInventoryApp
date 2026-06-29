using System.Data;
using Microsoft.Data.SqlClient;

namespace GBManufacturingTracker;

/// <summary>
/// Provides centralized database access methods for the
/// GB Manufacturing Tracker application.
///
/// This class is responsible for creating SQL Server connections,
/// executing queries, and returning results.
/// </summary>
public static class Db
{
    /// <summary>
    /// SQL Server connection string used throughout the application.
    /// Modify this value if the SQL Server instance or database changes.
    /// </summary>
    public static string ConnectionString { get; set; } =
        @"Data Source=(localdb)\MSSQLLocalDB;
          Initial Catalog=GBManufacturingTrackerDB;
          Integrated Security=True;
          Encrypt=False;
          TrustServerCertificate=True";

    /// <summary>
    /// Creates and returns a new SQL Server connection.
    /// </summary>
    /// <returns>
    /// A new <see cref="SqlConnection"/> object.
    /// </returns>
    public static SqlConnection GetConnection()
    {
        return new SqlConnection(ConnectionString);
    }

    /// <summary>
    /// Executes a SQL SELECT statement and returns the results
    /// as a <see cref="DataTable"/>.
    /// </summary>
    /// <param name="sql">
    /// SQL SELECT statement.
    /// </param>
    /// <param name="parameters">
    /// Optional SQL parameters.
    /// </param>
    /// <returns>
    /// A populated <see cref="DataTable"/>.
    /// </returns>
    public static DataTable GetTable(
        string sql,
        params SqlParameter[] parameters)
    {
        using SqlConnection con = GetConnection();
        using SqlCommand cmd = new(sql, con);

        // Add SQL parameters if supplied.
        if (parameters.Length > 0)
        {
            cmd.Parameters.AddRange(parameters);
        }

        using SqlDataAdapter adapter = new(cmd);

        DataTable table = new();

        adapter.Fill(table);

        return table;
    }

    /// <summary>
    /// Executes an INSERT, UPDATE, or DELETE SQL statement.
    /// </summary>
    /// <param name="sql">
    /// SQL command to execute.
    /// </param>
    /// <param name="parameters">
    /// Optional SQL parameters.
    /// </param>
    /// <returns>
    /// The number of rows affected.
    /// </returns>
    public static int Execute(
        string sql,
        params SqlParameter[] parameters)
    {
        using SqlConnection con = GetConnection();
        using SqlCommand cmd = new(sql, con);

        // Add SQL parameters if supplied.
        if (parameters.Length > 0)
        {
            cmd.Parameters.AddRange(parameters);
        }

        con.Open();

        return cmd.ExecuteNonQuery();
    }

    /// <summary>
    /// Executes a SQL statement that returns a single value.
    /// Examples include COUNT(*), SUM(), MAX(), MIN(), and EXISTS().
    /// </summary>
    /// <param name="sql">
    /// SQL statement to execute.
    /// </param>
    /// <param name="parameters">
    /// Optional SQL parameters.
    /// </param>
    /// <returns>
    /// The value returned by the query, or null if no value exists.
    /// </returns>
    public static object? Scalar(
        string sql,
        params SqlParameter[] parameters)
    {
        using SqlConnection con = GetConnection();
        using SqlCommand cmd = new(sql, con);

        // Add SQL parameters if supplied.
        if (parameters.Length > 0)
        {
            cmd.Parameters.AddRange(parameters);
        }

        con.Open();

        return cmd.ExecuteScalar();
    }
}
