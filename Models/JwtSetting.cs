using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BookBuddy_backend.Models
{
    public class JwtSetting
    {
        public string? Key { get; set; }
        public string? Issuer { get; set; }
        public string? Audience { get; set; }
    }
}