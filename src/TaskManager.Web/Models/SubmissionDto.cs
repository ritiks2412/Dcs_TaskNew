namespace TaskManager.Web.Models
{
    public class SubmissionDto
    {
        public int Id { get; set; }
        public int FormId { get; set; }
        public string FormTitle { get; set; } = string.Empty;
        public string Answers { get; set; } = string.Empty;
        public string Status { get; set; } = "Pending";
        public DateTime CreatedAt { get; set; }
    }
    public class CreateSubmissionDto
    {
        public int FormId { get; set; }
        public string Answers { get; set; } = string.Empty; 
    }
}
