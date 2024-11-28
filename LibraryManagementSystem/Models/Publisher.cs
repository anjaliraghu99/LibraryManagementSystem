using System.ComponentModel.DataAnnotations;

namespace LibraryManagementSystem.Models
{
    public class Publisher
    {
        [Key]
        public int PublisherID { get; set; }
        public string? Name { get; set; }
        public string? Address { get; set; }

        // Navigation Property
        public ICollection<Book> Book { get; set; }
    }
}