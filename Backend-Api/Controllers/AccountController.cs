using Application.Extentions;
using Application.Services.Interfaces;
using Backend_Api.Services.Interfaces;
using Domian.DTOs.User;
using Microsoft.AspNetCore.Authorization;
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
                            Avatar = user.Avatar,
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


        [HttpPost("RegisterAsync")]
        [AllowAnonymous]
        public async Task<IActionResult> RegisterAsync([FromBody] RegisterViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return new JsonResult(new
                {
                    code = 101,
                    message = ModelState.Values.SelectMany(v => v.Errors).Select(e => e.ErrorMessage)
                });
            }

            var result = await _userService.RegisterAsync(model);

            switch (result)
            {
                case RegisterResult.Success:

                    var user = await _userService.GetUserByEmailAsync(model.Email);

                    return new JsonResult(new
                    {
                        code = 100,
                        Data = new UserViewModel()
                        {
                            DisplayName = user.DisplayName,
                            UserName = user.Username,
                            Avatar = user.Avatar,
                            Token = _tokenService.CreateToken(user)
                        },
                        message = "Register successful."
                    });

                case RegisterResult.EmailExists:
                    return new JsonResult(new
                    {
                        code = 102,
                        message = "Email already exists."
                    });

                case RegisterResult.UserNameExists:
                    return new JsonResult(new
                    {
                        code = 103,
                        message = "Username already exists."
                    });

                case RegisterResult.Error:
                    return new JsonResult(new
                    {
                        code = 104,
                        message = "An error occurred during registration."
                    });
            }

            return new JsonResult(new
            {
                code = 104,
                message = "An unknown error occurred."
            });
        }

        [HttpGet("GetCurrentUserAsync")]
        [Authorize]
        public async Task<IActionResult> GetCurrentUserAsync()
        {
            var user = await _userService.GetUserById(User.GetUserId());

            return new JsonResult(new
            {
                code = 100,
                Data = new UserViewModel()
                {
                    DisplayName = user.DisplayName,
                    UserName = user.Username,
                    Avatar = user.Avatar,
                },
                message = "User retrieved successfully."
            });
        }

        #endregion
    }
}
