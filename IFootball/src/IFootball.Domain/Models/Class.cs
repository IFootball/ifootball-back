using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IFootball.Domain.Models
{
    public class Class
    {
        public Class() { }
        public Guid Id { get; set; }
        public List<User> ClassUsers { get; set; }
    }
}
