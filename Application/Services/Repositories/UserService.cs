using Application.Services.Interfaces;
using Domian.DTOs.User;
using Domian.Entities.User;
using Domian.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Services.Repositories
{
    public class UserService : IUserService
    {
        #region Constructor

        private readonly IUserRepository _userRepository;

        public UserService(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        #endregion

        public async Task<LoginResult> LoginAsync(LoginViewModel model)
        {
            var user = await _userRepository.GetUserByEmail(model.Email.ToLower().Trim());

            if (user == null)
            {
                return LoginResult.UserNotFound;
            }

            string hashedPassword = model.Password;

            if (user.Password != hashedPassword)
            {
                return LoginResult.Error;
            }

            return LoginResult.Success;
        }

        public async Task<User> GetUserByEmailAsync(string email)
        {
            return await _userRepository.GetUserByEmail(email.ToLower().Trim());
        }

    }
}
