namespace TaskManager.Application.DTOs
{
    public class CreateFormDto
    {
        public string Title { get; set; } = null!;
        public string? Description { get; set; }
        public string Fields { get; set; } = "{}";
    }
}
