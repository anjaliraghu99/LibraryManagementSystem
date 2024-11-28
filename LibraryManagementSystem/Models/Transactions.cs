namespace LibraryManagementSystem.Models
{
    public class Transactions
    {
        public int TransactionID { get; set; }
        public int BookID { get; set; }
        public int MemberID { get; set; }
        public DateTime BorrowDate { get; set; }
        public DateTime DueDate { get; set; }
        public DateTime? ReturnDate { get; set; }
        public int StaffID { get; set; }

        // Navigation Properties
        public Book Book { get; set; }
        public Member Member { get; set; }
        public Staff Staff { get; set; }
    }
}