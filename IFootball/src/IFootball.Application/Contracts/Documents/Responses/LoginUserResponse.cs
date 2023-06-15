using IFootball.Application.Contracts.Documents.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IFootball.Application.Contracts.Documents.Responses
{
    public class LoginUserResponse
    {
        public LoginUserDto? User{ get; set; }
        public string? Token { get; set; }
    }
}
