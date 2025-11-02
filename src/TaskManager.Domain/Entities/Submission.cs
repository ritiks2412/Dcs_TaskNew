using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace TaskManager.Domain.Entities
{
    public class Submission
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public int FormId { get; set; }
        public string Answers { get; set; } = "{}";

        public string Status { get; set; } = "Pending"; 
        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
        [ForeignKey(nameof(UserId))]
        [JsonIgnore]
        public User? User { get; set; }
        [ForeignKey(nameof(FormId))]
        [JsonIgnore]
        public Form? Form { get; set; }

    }
}
