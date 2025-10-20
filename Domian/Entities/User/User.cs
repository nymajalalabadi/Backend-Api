using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domian.Entities.User
{
    public class User
    {
        public int Id { get; set; }

        public string Username { get; set; } = string.Empty;

        public string DisplayName { get; set; } = string.Empty;

        public string Email { get; set; } = string.Empty;

        public string Mobile { get; set; } = string.Empty;

        public string Password { get; set; } = string.Empty;

        public bool IsEmailActive { get; set; }

        public string? Avatar { get; set; }

        public DateTime RegisterDate { get; set; }
    }
}
