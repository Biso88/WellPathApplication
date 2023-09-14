using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BookBuddy_backend.Models;

namespace BookBuddy_backend.Services.nterfaces
{
    public interface ILoanService
    {
        Loan CreateLoan(Loan loan);
        IEnumerable<Loan> GetAllLoans();
        bool ReturnBook(int loanId);
    }
}