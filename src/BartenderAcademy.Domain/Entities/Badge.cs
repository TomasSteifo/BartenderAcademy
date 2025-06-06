using System;

namespace BartenderAcademy.Domain.Entities
{
    public class Badge
    {
        // Primary key
        public int Id { get; set; }

        // Foreign key to Certificate
        public Guid CertificateId { get; set; }
        public Certificate Certificate { get; set; } = null!;

        // URL to the badge image in blob storage (PNG)
        public string BadgeUrl { get; set; } = string.Empty;

        // Timestamp when the badge was created
        public DateTime CreatedDate { get; set; } = DateTime.UtcNow;
    }
}
