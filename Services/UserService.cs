using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using BookBuddy_backend.ApplicationContext;
using BookBuddy_backend.Models;
using BookBuddy_backend.Services.Interfaces;
using Microsoft.IdentityModel.Tokens;

namespace BookBuddy_backend.Services
{
    public class UserService : IUserService
    {
        private readonly BookBuddyDbContext _context;
        public UserService(BookBuddyDbContext context)
        {
            _context = context;
        }

        public User Register(User user)
        {
            if (string.IsNullOrEmpty(user.Username) || string.IsNullOrEmpty(user.Password))
            {
                throw new ArgumentException("Username or password cannot be empty.");
            }

            if (_context.Users.Any(u => u.Username == user.Username))
            {
                throw new InvalidOperationException("Username is already taken.");
            }

            // hash the password
            string hashedPassword = BCrypt.Net.BCrypt.HashPassword("my_password");

            // verify the password against the hashpassword
            bool verified = BCrypt.Net.BCrypt.Verify("my_password", hashedPassword);

            user.Password = BCrypt.Net.BCrypt.HashPassword(user.Password);

            user.Token = GenerateJwtToken(user);

            _context.Users.Add(user);
            _context.SaveChanges();

            return user;
        }

        public User Login(string username, string password)
        {
            var user = _context.Users.FirstOrDefault(u => u.Username == username);

            if (user == null || !BCrypt.Net.BCrypt.Verify(password, user.Password))
            {
                throw new UnauthorizedAccessException("Invalid user name or password.");
            }

            user.Token = GenerateJwtToken(user);

            _context.Users.Add(user);

            return user;
        }

        public IEnumerable<User> GetAllUsers()
        {
            return _context.Users.ToList();
        }

        public string GenerateJwtToken(User user)
        {
            var tokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.ASCII.GetBytes("YourSecretKeyHere");
            var claims = new ClaimsIdentity(new[]
            {
        new Claim("id", user.Id.ToString()),
        new Claim(ClaimTypes.Role, user.UserRole)
    });

            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = claims,
                Expires = DateTime.UtcNow.AddDays(7),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
            };

            var token = tokenHandler.CreateToken(tokenDescriptor);
            return tokenHandler.WriteToken(token);
        }
    }
}