using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BookBuddy_backend.Models;

namespace BookBuddy_backend.Services.nterfaces
{
    public interface IBookService
    {
        IEnumerable<Book> GetAllBooks();
        Book AddBook(Book book);
        void RemoveBook(int bookId);
    }
}