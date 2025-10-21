using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domian.Entities.User
{
    public class User
    {
        [Key]
        public int Id { get; set; }

        [DisplayName("Username")]
        [MaxLength(50, ErrorMessage = "{0} must be at most {1} characters long")]
        [Required(ErrorMessage = "{0} is required")]
        public string Username { get; set; } = string.Empty;

        [DisplayName("DisplayName")]
        [MaxLength(70, ErrorMessage = "{0} must be at most {1} characters long")]
        [Required(ErrorMessage = "{0} is required")]
        public string DisplayName { get; set; } = string.Empty;

        [DisplayName("Email Address")]
        [EmailAddress]
        [MaxLength(256, ErrorMessage = "{0} must be at most {1} characters long")]
        [Required(ErrorMessage = "{0} is required")]
        public string Email { get; set; } = string.Empty;

        [DisplayName("Mobile Number")]
        [MaxLength(20, ErrorMessage = "{0} must be at most {1} characters long")]
        public string Mobile { get; set; } = string.Empty;

        [DisplayName("Password")]
        [Required(ErrorMessage = "{0} is required")]
        public string Password { get; set; } = string.Empty;

        public bool IsEmailActive { get; set; }

        [DisplayName("Avatar")]
        public string? Avatar { get; set; }

        public DateTime RegisterDate { get; set; }
    }
}
