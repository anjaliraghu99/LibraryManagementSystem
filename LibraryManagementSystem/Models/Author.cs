namespace LibraryManagementSystem.Models
{
    public class Author
    {
        public int AuthorID { get; set; }
        public string Name { get; set; }
        public string Bio { get; set; }

        // Navigation Property
        public ICollection<Book> Book { get; set; }
    }
}