using IFootball.Domain.Models.enums;
using IFootball.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IFootball.Application.Contracts.Documents.Requests
{
    public class RegisterUserRequest
    {
        public long IdClass { get; set; }
        public string? Name { get; set; }
        public string? Email { get; set; }
        public string? Password { get; set; }
    }
}
