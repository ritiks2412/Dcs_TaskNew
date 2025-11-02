namespace TaskManager.Application.DTOs.Submission
{
    public class SubmissionDto
    {
        public int Id { get; set; }
        public int FormId { get; set; }
        public string FormTitle { get; set; } = string.Empty;
        public int UserId { get; set; }
        public string UserName { get; set; } = string.Empty;
        public string Answers { get; set; } = "{}";
        public string Status { get; set; } = "Pending";
        public DateTime CreatedAt { get; set; }
    }
}
