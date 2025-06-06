using System.Collections.Generic;

namespace BartenderAcademy.Domain.Entities
{
    public class Category
    {
        // Primary key
        public int Id { get; set; }

        // Name of the category (e.g., "Cocktails", "Working at a Bar")
        public string Name { get; set; } = string.Empty;

        // Optional longer description
        public string? Description { get; set; }

        // Navigation property: A category can include multiple courses
        public ICollection<Course> Courses { get; set; } = new List<Course>();
    }
}
