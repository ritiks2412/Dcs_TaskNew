namespace TaskManager.Web.Models
{
    public class FormDto
    {
        public int Id { get; set; }
        public string? Title { get; set; }
        public string? Description { get; set; }
        public string? Fields { get; set; }
    }


    public class CreateFormDto
    {
        public string Title { get; set; }
        public string? Description { get; set; }
        public string Fields { get; set; } = "{}"; 
    }
}
