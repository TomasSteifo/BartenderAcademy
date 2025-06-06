namespace BartenderAcademy.Application.Interfaces
{
    /// <summary>
    /// Provides information about the currently authenticated user.
    /// Implemented in API layer (e.g., by reading HttpContext.User.Claims).
    /// </summary>
    public interface ICurrentUserService
    {
        /// <summary>
        /// Returns the current user’s ID (string) from JWT claims.
        /// </summary>
        string UserId { get; }

        /// <summary>
        /// Returns the current user’s email (if available).
        /// </summary>
        string? Email { get; }
    }
}
