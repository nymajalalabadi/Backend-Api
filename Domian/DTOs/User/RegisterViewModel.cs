using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domian.DTOs.User
{
    public class RegisterViewModel
    {
        public string Email { get; set; }

        public string UserName { get; set; }

        public string DisplayName { get; set; }

        public string Password { get; set; }
    }

    public enum RegisterResult
    {
        Success,
        EmailExists,
        UserNameExists,
        Error
    }
}
