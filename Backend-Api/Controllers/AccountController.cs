using Application.Services.Interfaces;
using Backend_Api.Services.Interfaces;
using Domian.DTOs.User;
using Microsoft.AspNetCore.Mvc;

namespace Backend_Api.Controllers
{
    public class AccountController : BaseController
    {
        #region Constructor

        private readonly IUserService _userService;

        private readonly ITokenService _tokenService;

        public AccountController(IUserService userService, ITokenService tokenService)
        {
            _userService = userService;
            _tokenService = tokenService;
        }

        #endregion

        #region Actions

        [HttpPost("LoginAsync")]
        public async Task<IActionResult> LoginAsync([FromBody] LoginViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return new JsonResult(new
                {
                    code = 101,
                    message = ModelState.Values.SelectMany(v => v.Errors).Select(e => e.ErrorMessage)
                });
            }

            var result = await _userService.LoginAsync(model);

            switch (result)
            {
                case LoginResult.Success:

                    var user = await _userService.GetUserByEmailAsync(model.Email);

                    return new JsonResult(new
                    {
                        code = 100,
                        Data = new UserViewModel()
                        {
                            DisplayName = user.DisplayName,
                            UserName = user.Username,
                            Avatar = null,
                            Token = _tokenService.CreateToken(user)
                        },
                        message = "Login successful."
                    });

                case LoginResult.Error:
                    return new JsonResult(new
                    {
                        code = 102,
                        message = "Invalid password."
                    });

                case LoginResult.UserNotFound:
                    return new JsonResult(new
                    {
                        code = 103,
                        message = "User not found."
                    });
            }

            return new JsonResult(new
            {
                code = 104,
                message = "An unknown error occurred."
            });
        }

        #endregion
    }
}
