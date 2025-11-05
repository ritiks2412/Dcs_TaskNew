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

    public class FormDtos
    {
        public int Id { get; set; }
        public string? Title { get; set; }
        public string? Description { get; set; }
        public string? Fields { get; set; }
        public bool IsActive { get; set; }
        public int CreatedBy { get; set; }
        public CreatedByUserDto? CreatedByUser { get; set; }
    }

    public class CreatedByUserDto
    {
        public int Id { get; set; }
        public string? Name { get; set; }
        public string? Email { get; set; }
        public string? PasswordHash { get; set; }
        public string? Role { get; set; }
    }




}
