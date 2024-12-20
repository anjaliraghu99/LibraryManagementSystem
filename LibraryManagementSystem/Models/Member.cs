﻿using System.ComponentModel.DataAnnotations;

namespace LibraryManagementSystem.Models
{
    public class Member

    {
        [Key]
        public int MemberID { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        public string Address { get; set; }
        public DateTime MembershipDate { get; set; }

        // Navigation Property
        public ICollection<Transactions> Transactions { get; set; }
    }
}