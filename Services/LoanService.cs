using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BookBuddy_backend.ApplicationContext;
using BookBuddy_backend.Models;
using BookBuddy_backend.Services.nterfaces;
using Microsoft.EntityFrameworkCore;

namespace BookBuddy_backend.Services
{
    public class LoanService : ILoanService
    {
        private readonly BookBuddyDbContext _context;
        public LoanService(BookBuddyDbContext context)
        {
            _context = context;
        }

        public Loan CreateLoan(Loan loan)
        {
            _context.Loans.Add(loan);
            _context.SaveChanges();
            return loan;
        }

        public IEnumerable<Loan> GetAllLoans()
        {
            return _context.Loans.Include(l => l.User).Include(l => l.Book).ToList();
        }

        public void ReturnBook(int loanId)
        {
            var loan = _context.Loans.FirstOrDefault(l => l.Id == loanId);
            if (loan != null)
            {
                _context.Loans.Remove(loan);
                _context.SaveChanges();
            }
        }

        bool ILoanService.ReturnBook(int loanId)
        {
            throw new NotImplementedException();
        }
    }
}