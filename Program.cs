namespace GBManufacturingTracker;

/// <summary>
/// The main entry point for the GB Manufacturing Tracker application.
/// This class is responsible for initializing the Windows Forms
/// environment and launching the Login form.
/// </summary>
internal static class Program
{
    /// <summary>
    /// The application's main entry point.
    /// </summary>
    /// <remarks>
    /// The <see cref="STAThreadAttribute"/> indicates that the application
    /// uses a single-threaded apartment, which is required for many
    /// Windows Forms controls and COM components.
    /// </remarks>
    [STAThread]
    private static void Main()
    {
        // Initialize the Windows Forms application.
        // This configures visual styles, default fonts,
        // high DPI settings, and other application-wide settings.
        ApplicationConfiguration.Initialize();

        // Start the application by displaying the Login form.
        // Users must successfully authenticate before
        // accessing the rest of the application.
        Application.Run(new LoginForm());
    }
}
