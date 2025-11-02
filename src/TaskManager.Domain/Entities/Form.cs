using System.ComponentModel.DataAnnotations.Schema;

namespace TaskManager.Domain.Entities
{

    public class Form
    {
        public int Id { get; set; }
        public string Title { get; set; } = null!;
        public string? Description { get; set; }
        public string Fields { get; set; } = "{}";
        public bool IsActive { get; set; } = true;  
        public int CreatedBy { get; set; }

        [ForeignKey(nameof(CreatedBy))]
        public User? CreatedByUser { get; set; }
    }
}
