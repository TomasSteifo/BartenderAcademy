using System.Threading.Tasks;

namespace BartenderAcademy.Application.Interfaces
{
    /// <summary>
    /// Generates a badge image (PNG) for a certificate. Implemented in Infrastructure (e.g., via SkiaSharp).
    /// </summary>
    public interface IBadgeGenerator
    {
        /// <summary>
        /// Generates a badge PNG given the course title, user initials, and year.
        /// Returns the raw PNG bytes.
        /// </summary>
        /// <param name="courseTitle">“Advanced Mixology”</param>
        /// <param name="userInitials">“JD”</param>
        /// <param name="year">e.g., 2025</param>
        Task<byte[]> GenerateBadgeAsync(string courseTitle, string userInitials, int year);
    }
}
