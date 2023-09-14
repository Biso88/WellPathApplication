using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BookBuddy_backend.ApplicationContext;
using BookBuddy_backend.Models;
using BookBuddy_backend.Services.nterfaces;

namespace BookBuddy_backend.Services
{
    public class BookService : IBookService
    {
        private readonly BookBuddyDbContext _context;
        public BookService(BookBuddyDbContext context)
        {
            _context = context;
        }

        public IEnumerable<Book> GetAllBooks()
        {
            return _context.Books.ToList();
        }

        public Book AddBook(Book book)
        {
            _context.Books.Add(book);
            _context.SaveChanges();
            return book;
        }

        public void RemoveBook(int bookId)
        {
            var book = _context.Books.FirstOrDefault(b => b.Id == bookId);
            if (book != null)
            {
                _context.Books.Remove(book);
                _context.SaveChanges();
            }
        }
    }
}