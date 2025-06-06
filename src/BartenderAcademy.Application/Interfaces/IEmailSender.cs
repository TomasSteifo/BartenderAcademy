using System.Collections.Generic;
using System.Threading.Tasks;

namespace BartenderAcademy.Application.Interfaces
{
    /// <summary>
    /// Abstraction for sending emails. Implemented in Infrastructure (e.g., SendGrid).
    /// </summary>
    public interface IEmailSender
    {
        /// <summary>
        /// Sends an email with optional attachments.
        /// </summary>
        /// <param name="toEmail">Recipient address.</param>
        /// <param name="subject">Email subject.</param>
        /// <param name="htmlContent">Email body as HTML.</param>
        /// <param name="attachments">
        /// Optional list of attachments. Each attachment has:
        /// - byte[] Content
        /// - string Filename
        /// - string ContentType (e.g., "application/pdf").
        /// </param>
        Task SendEmailAsync(string toEmail, string subject, string htmlContent, IEnumerable<EmailAttachment>? attachments = null);
    }

    /// <summary>
    /// Represents a file attachment for an email.
    /// </summary>
    public class EmailAttachment
    {
        /// <summary>Raw bytes of the file.</summary>
        public byte[] Content { get; set; } = System.Array.Empty<byte>();

        /// <summary>Filename of the attachment (e.g., "certificate.pdf").</summary>
        public string Filename { get; set; } = string.Empty;

        /// <summary>MIME content type (e.g., "application/pdf").</summary>
        public string ContentType { get; set; } = string.Empty;
    }
}
