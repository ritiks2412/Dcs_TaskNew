namespace TaskManager.Application.DTOs.Submission
{
    public class CreateSubmissionDto
    {
        public int FormId { get; set; }
        public string Answers { get; set; } = "{}";

    }
    public class UpdateSubmissionStatusDto
    {
        public int SubmissionId { get; set; }
        public string Status { get; set; } = "Approved"; 
    }
}
