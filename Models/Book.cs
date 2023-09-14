using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace BookBuddy_backend.Models
{
    public class Book
    {
        [Key]
        public int Id { get; set; }

        [MaxLength(200)]
        public required string Title { get; set; }

        [MaxLength(100)]
        public required string Author { get; set; }

        [Required]
        public bool IsAvailable { get; set; } = true;

        public ICollection<Loan>? Loans { get; set; }
    }
}