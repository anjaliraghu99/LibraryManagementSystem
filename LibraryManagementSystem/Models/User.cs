using System.ComponentModel.DataAnnotations;

namespace LibraryManagementSystem.Models
{
    public class User
    {
        [Key]
        public int UserId { get; set; }
        public string Email{ get; set; }
        public string Password { get; set; }
        public int CategoryId { get; set; }
        public string Name { get; set; }
        public UserCategory UserCategory { get; set; }
        public string PhoneNumber {  get; set; }


    }
}
