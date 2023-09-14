using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BookBuddy_backend.Models;

namespace BookBuddy_backend.Services.Interfaces
{
    public interface IUserService
    {
        User Register(User user);
        User Login(string username, string password);
        IEnumerable<User> GetAllUsers();
        string GenerateJwtToken(User user);
    }
}