using BookBuddy_backend.Models;
using BookBuddy_backend.Services.nterfaces;
using Microsoft.AspNetCore.Mvc;

namespace BookBuddy_backend.Controllers
{
    [Route("[controller]")]
    public class LoanController : Controller
    {
        private readonly ILoanService _loanService;
        public LoanController(ILoanService loanService)
        {
            _loanService = loanService;
        }

        [HttpGet("getAllLoans")]
        public ActionResult<IEnumerable<Loan>> GetAllLoans()
        {
            return Ok(_loanService.GetAllLoans());
        }

        [HttpPost("createLoan")]
        public ActionResult<Loan> CreateLoan([FromBody] Loan newLoan)
        {
            var loan = _loanService.CreateLoan(newLoan);

            if (loan == null)
            {
                return BadRequest("Could not create loan");
            }

            return CreatedAtAction(nameof(GetAllLoans), new { id = loan.Id }, loan);
        }

        [HttpPut("returnBook")]
        public IActionResult ReturnBook(int id)
        {
            if (_loanService.ReturnBook(id))
            {
                return NoContent();
            }

            return BadRequest("Could not return the book");
        }
    }
}