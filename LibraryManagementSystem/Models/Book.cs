namespace LibraryManagementSystem.Models
{
    public class Book
    {
        public int BookID { get; set; }
        public string Title { get; set; }
        public int AuthorID { get; set; }
        public int PublisherID { get; set; }
        public string ISBN { get; set; }
        public int CategoryID { get; set; }
        public string Language { get; set; }
        public int PublicationYear { get; set; }
        public int CopiesAvailable { get; set; }

        // Navigation Properties
        public Author Author { get; set; }
        public Publisher Publisher { get; set; }
        public Category Category { get; set; }
    }
}