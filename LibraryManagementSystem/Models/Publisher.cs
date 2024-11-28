namespace LibraryManagementSystem.Models
{
    public class Publisher
    {
        public int PublisherID { get; set; }
        public string Name { get; set; }
        public string Address { get; set; }

        // Navigation Property
        public ICollection<Book> Book { get; set; }
    }
}