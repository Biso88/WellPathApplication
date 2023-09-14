using BookBuddy_backend.Models;
using BookBuddy_backend.Services.nterfaces;
using Microsoft.AspNetCore.Mvc;

namespace BookBuddy_backend.Controllers
{
    [Route("[controller]")]
    public class BookController : Controller
    {
        private readonly IBookService _bookService;
        public BookController(IBookService bookService)
        {
            _bookService = bookService;
        }

        [HttpGet("getAllBooks")]
        public IActionResult GetAllBooks()
        {
            var books = _bookService.GetAllBooks();
            return Ok(books);
        }

        [HttpPost("addBook")]
        public IActionResult AddBook([FromBody] Book book)
        {
            var addedBook = _bookService.AddBook(book);
            return Ok(addedBook);
        }

        [HttpDelete("deleteBook")]
        public IActionResult DeleteBook(int id)
        {
            _bookService.RemoveBook(id);
            return Ok();
        }
    }
}