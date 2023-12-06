//=================================
// Copyright (c) Tarteeb LLC
// Check your essays esily
//=================================

using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using RESTFulSense.Controllers;
using SmartEssayChecker.Api.Models.Users;
using SmartEssayChecker.Api.Models.Users.Exceptions;
using SmartEssayChecker.Api.Services.Foundations.Users;

namespace SmartEssayChecker.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class UserController : RESTFulController
    {
        private readonly IUserService userService;

        public UserController(IUserService userService) =>
            this.userService = userService;

        [HttpPost]

        public async ValueTask<ActionResult<User>> Post(User user)
        {
            try
            {
                User persistedUser = await this.userService.AddUserAsync(user);

                return Created(persistedUser);
            }
            catch (UserValidationException userValidationException)
            {
                return BadRequest(userValidationException.InnerException);
            }
        }

    }
}
