namespace LibraryManagementSystem.Models
{
    public class Staff
    {
        public int StaffID { get; set; }
        public string Name { get; set; }
        public string Role { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        public DateTime HireDate { get; set; }
        public ICollection<Transactions> Transactions { get; set; }
    }
}