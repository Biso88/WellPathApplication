using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace BookBuddy_backend.Models
{
    public class User
    {
        [Key]
        public int Id { get; set; }

        [MaxLength(100)]
        public required string Username { get; set; }

        [MaxLength(300)]
        public required string Email { get; set; }

        [MaxLength(150)]
        public required string Password { get; set; }

        public string? PasswordHash { get; set; }

        public required string UserRole { get; set; }
        public string? Token { get; set; }
        public ICollection<Loan>? Loans { get; set; }
    }
}