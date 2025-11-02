namespace TaskManager.Application.DTOs
{
    public class UpdateFormDto
    {
        public int Id { get; set; }
        public string Title { get; set; } = null!;
        public string? Description { get; set; }
        public string Fields { get; set; } = "{}";
        public bool IsActive { get; set; }

    }
}
