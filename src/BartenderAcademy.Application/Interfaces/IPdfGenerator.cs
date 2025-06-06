using System;
using System.Threading.Tasks;

namespace BartenderAcademy.Application.Interfaces
{
    /// <summary>
    /// Generates PDF byte arrays (e.g., certificates). Implemented via a PDF library (QuestPDF) in Infrastructure.
    /// </summary>
    public interface IPdfGenerator
    {
        /// <summary>
        /// Generates a certificate PDF given user name, course title, completion date, and a unique code.
        /// Returns the raw PDF bytes.
        /// </summary>
        /// <param name="userFullName">“John Doe”</param>
        /// <param name="courseTitle">“Advanced Mixology”</param>
        /// <param name="completionDate">Date of completion</param>
        /// <param name="certificateCode">Unique code for verification</param>
        Task<byte[]> GenerateCertificatePdfAsync(string userFullName, string courseTitle, DateTime completionDate, string certificateCode);
    }
}
