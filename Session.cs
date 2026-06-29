namespace GBManufacturingTracker;

public static class Session
{
    public static int UserId { get; set; }
    public static string Username { get; set; } = string.Empty;
    public static string FullName { get; set; } = string.Empty;
    public static string RoleName { get; set; } = string.Empty;

    public static void Clear()
    {
        UserId = 0;
        Username = string.Empty;
        FullName = string.Empty;
        RoleName = string.Empty;
    }
}
