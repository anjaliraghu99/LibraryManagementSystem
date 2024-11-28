

using System.ComponentModel.DataAnnotations;

namespace LibraryManagementSystem.Models
{
    public class Fine
    {
        [Key]
        public int FineID { get; set; }
        public int TransactionID { get; set; }
        public decimal Amount { get; set; }
        public string? PaidStatus { get; set; }
        public DateTime? PaymentDate { get; set; }

        // Navigation Property
        public Transactions Transactions { get; set; }
    }
}