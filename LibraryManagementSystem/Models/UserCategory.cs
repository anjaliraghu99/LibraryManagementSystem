using System.ComponentModel.DataAnnotations;

namespace LibraryManagementSystem.Models
{
    public class UserCategory
    {
        [Key]
        public int CategoryId { get; set; }
        public string CategoryName { get; set; }
        public ICollection<User> User { get; set; }
    }
}
