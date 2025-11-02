using System.ComponentModel.DataAnnotations.Schema;

namespace TaskManager.Domain.Entities
{
    public class Payment
    {
        public int Id { get; set; }

        public int SubmissionId { get; set; }
        [ForeignKey(nameof(SubmissionId))]
        public Submission? Submission { get; set; }

        public string Provider { get; set; } = "Razorpay"; // Razorpay, Stripe, PayPal
        public string OrderId { get; set; } = null!;
        public string? PaymentId { get; set; }

        public decimal Amount { get; set; }
        public string Currency { get; set; } = "INR";

        public string Status { get; set; } = "Created"; // Created, Paid, Failed
        public string? Signature { get; set; }

        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
    }
}
