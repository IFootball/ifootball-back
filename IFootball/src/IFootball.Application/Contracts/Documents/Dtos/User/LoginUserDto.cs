using IFootball.Domain.Models.enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IFootball.Application.Contracts.Documents.Dtos
{
    public class LoginUserDto
    {
        public long Id { get; set; }
        public UserRole Role { get; set; }
    }
}
