using Domian.DTOs.User;
using Domian.Entities.User;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Services.Interfaces
{
    public interface IUserService
    {
        Task<RegisterResult> RegisterAsync(RegisterViewModel model);

        Task<LoginResult> LoginAsync(LoginViewModel model);

        Task<User> GetUserByEmailAsync(string email);

        Task<User> GetUserById(int Id);
    }
}
