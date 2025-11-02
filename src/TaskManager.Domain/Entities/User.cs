using System.Text.Json.Serialization;

namespace TaskManager.Domain.Entities
{
    public class User
    {
        public int Id { get; set; }
        public string Name { get; set; } = null!;
        public string Email { get; set; } = null!;
        public string PasswordHash { get; set; } = null!;
        public string Role { get; set; } = "User";

        [JsonIgnore]
        public ICollection<Form>? Forms { get; set; }
        [JsonIgnore]
        public ICollection<Submission>? Submissions { get; set; }
    }
}
