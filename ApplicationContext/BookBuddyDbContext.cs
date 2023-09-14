using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BookBuddy_backend.Models;
using Microsoft.EntityFrameworkCore;

namespace BookBuddy_backend.ApplicationContext
{
    public class BookBuddyDbContext : DbContext
    {
        public BookBuddyDbContext(DbContextOptions<BookBuddyDbContext> options)
        : base(options)
        {
        }

        public DbSet<User> Users { get; set; }
        public DbSet<Book> Books { get; set; }
        public DbSet<Loan> Loans { get; set; }
    }
}