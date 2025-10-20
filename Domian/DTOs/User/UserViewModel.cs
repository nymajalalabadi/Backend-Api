using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domian.DTOs.User
{
    public class UserViewModel
    {
        public string DisplayName { get; set; } = string.Empty;

        public string UserName { get; set; } = string.Empty;

        public string Avatar { get; set; } = string.Empty;

        public string Token { get; set; } = string.Empty;

    }
}
