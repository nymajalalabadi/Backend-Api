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

        public async Task<RegisterResult> RegisterAsync(RegisterViewModel model)
        {
            var existingUserByEmail = await _userRepository.GetUserByEmail(model.Email.ToLower().Trim());

            if (existingUserByEmail != null)
            {
                return RegisterResult.EmailExists;
            }

            var existingUserByUsername = await _userRepository.GetUserByUserName(model.UserName.ToLower().Trim());

            if (existingUserByUsername != null)
            {
                return RegisterResult.UserNameExists;
            }

            var hashedPassword = model.Password;

            var newUser = new User
            {
                Email = model.Email.ToLower().Trim(),
                Username = model.UserName.ToLower().Trim(),
                DisplayName = model.DisplayName.Trim(),
                Avatar = null,
                Mobile = null,
                Password = hashedPassword,
                IsEmailActive = false,
                RegisterDate = DateTime.UtcNow
            };

            await _userRepository.AddUser(newUser);
            await _userRepository.SaveChangesAsync();

            return RegisterResult.Success;
        }


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

        public async Task<User> GetUserById(int Id)
        {
            return await _userRepository.GetUserById(Id);
        }

    }
}
