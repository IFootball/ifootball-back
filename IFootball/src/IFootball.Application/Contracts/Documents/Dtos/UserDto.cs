﻿using IFootball.Domain.Models.enums;
using IFootball.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IFootball.Application.Contracts.Documents.Dtos
{
    public class UserDto
    {
        public Guid IdClass { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
    }
}
