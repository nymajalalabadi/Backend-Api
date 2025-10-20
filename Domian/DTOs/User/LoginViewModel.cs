using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domian.DTOs.User
{
    public class LoginViewModel
    {
        public string Email { get; set; } = string.Empty;

        public string Password { get; set; } = string.Empty;
    }

    public enum LoginResult
    {
        Success,
        Error,
        UserNotFound
    }
}
