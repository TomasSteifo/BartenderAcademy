namespace BartenderAcademy.Application.DTOs
{
    /// <summary>
    /// Data Transfer Object for Category. Returned by queries and handlers.
    /// </summary>
    public class CategoryDto
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public string? Description { get; set; }
    }
}
