namespace GBManufacturingTracker;

/// <summary>
/// Stores information about the currently logged-in user.
/// This static class provides application-wide access to
/// the user's session information after successful authentication.
/// </summary>
public static class Session
{
    /// <summary>
    /// Gets or sets the unique identifier of the logged-in user.
    /// </summary>
    public static int UserId { get; set; }

    /// <summary>
    /// Gets or sets the username of the logged-in user.
    /// </summary>
    public static string Username { get; set; } = string.Empty;

    /// <summary>
    /// Gets or sets the full name of the logged-in user.
    /// </summary>
    public static string FullName { get; set; } = string.Empty;

    /// <summary>
    /// Gets or sets the security role assigned to the user.
    /// Examples include Administrator, Supervisor, and Employee.
    /// </summary>
    public static string RoleName { get; set; } = string.Empty;

    /// <summary>
    /// Clears the current user session.
    /// This method is typically called when the user logs out
    /// or when the application needs to reset authentication.
    /// </summary>
    public static void Clear()
    {
        UserId = 0;
        Username = string.Empty;
        FullName = string.Empty;
        RoleName = string.Empty;
    }
}
