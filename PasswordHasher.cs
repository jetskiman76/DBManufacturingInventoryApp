namespace GBManufacturingTracker;

/// <summary>
/// Provides methods for securely hashing and verifying user passwords
/// using the BCrypt hashing algorithm.
///
/// Passwords should never be stored in plain text. Instead, a BCrypt
/// hash is generated and stored in the database. During login,
/// the entered password is compared against the stored hash.
/// </summary>
public static class PasswordHasher
{
    /// <summary>
    /// Generates a BCrypt hash for the specified password.
    /// </summary>
    /// <param name="password">
    /// The plain-text password entered by the user.
    /// </param>
    /// <returns>
    /// A securely hashed password containing a unique salt.
    /// </returns>
    public static string Hash(string password)
    {
        return BCrypt.Net.BCrypt.HashPassword(password);
    }

    /// <summary>
    /// Verifies that the supplied password matches the stored BCrypt hash.
    /// </summary>
    /// <param name="password">
    /// The plain-text password entered by the user.
    /// </param>
    /// <param name="hash">
    /// The BCrypt password hash stored in the database.
    /// </param>
    /// <returns>
    /// True if the password matches the stored hash; otherwise, false.
    /// </returns>
    public static bool Verify(string password, string hash)
    {
        return BCrypt.Net.BCrypt.Verify(password, hash);
    }
}
