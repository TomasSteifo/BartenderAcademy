using System;
using System.Diagnostics.Metrics;

namespace BartenderAcademy.Domain.Entities
{
    public class Certificate
    {
        // Primary key (GUID)
        public Guid Id { get; set; }

        // Foreign key to User (will map to ApplicationUser in Infrastructure)
        public string UserId { get; set; } = string.Empty;
        public object? User { get; set; }

        // Foreign key to Course
        public int CourseId { get; set; }
        public Course Course { get; set; } = null!;

        // When the certificate was generated
        public DateTime GeneratedDate { get; set; } = DateTime.UtcNow;

        // URL to the PDF in Blob storage
        public string PdfBlobUrl { get; set; } = string.Empty;

        // Unique code for verification (e.g., 12-character string)
        public string CertificateCode { get; set; } = string.Empty;

        // Navigation: Each certificate has one badge
        public Badge? Badge { get; set; }
    }
}
