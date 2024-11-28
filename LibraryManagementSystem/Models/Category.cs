namespace LibraryManagementSystem.Models
{
    public class Category
    {
        public int CategoryID { get; set; }
        public string CategoryName { get; set; }

        // Navigation Property
        public ICollection<Book> Book { get; set; }
    }
}