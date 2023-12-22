//=================================
// Copyright (c) Tarteeb LLC
// Check your essays esily
//=================================

using System;
using System.Linq;
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

        public async ValueTask<ActionResult<User>> PostUserAsync(User user)
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
            catch (UserDependencyValidationException userDependencyValidationException)
                when (userDependencyValidationException.InnerException is AlreadyExistsUserException)
            {
                return Conflict(userDependencyValidationException.InnerException);
            }
            catch (UserDependencyException userDependencyException)
            {
                return InternalServerError(userDependencyException.InnerException);
            }
            catch (UserServiceException userServiceException)
            {
                return InternalServerError(userServiceException.InnerException);
            }
        }

        [HttpGet("ById")]

        public async ValueTask<ActionResult<User>> GetUserByIdAsync(Guid userId)
        {
            try
            {
                return await this.userService.RetrieveUserByIdAsync(userId);
            }
            catch (UserDependencyException userDependencyException)
            {
                return InternalServerError(userDependencyException.InnerException);
            }
            catch (UserValidationException userValidationException)
                when (userValidationException.InnerException is InvalidUserException)
            {
                return BadRequest(userValidationException.InnerException);
            }
            catch (UserValidationException userValidationException)
                when (userValidationException.InnerException is NotFoundUserException)
            {
                return NotFound(userValidationException.InnerException);
            }
            catch (UserServiceException userServiceException)
            {
                return InternalServerError(userServiceException.InnerException);
            }
        }

        [HttpGet("All")]

        public ActionResult<IQueryable<User>> GetAllUsers()
        {
            try
            {
                IQueryable<User> allUsers =
                    this.userService.RetrieveUsers();

                return Ok(allUsers);
            }
            catch (UserDependencyException userDependencyException)
            {
                return InternalServerError(userDependencyException.InnerException);
            }
            catch (UserServiceException userServiceException)
            {
                return InternalServerError(userServiceException.InnerException);
            }
        }

        [HttpPut]

        public async ValueTask<ActionResult<User>> PutUserAsync(User user)
        {
            try
            {
                User modifyUser =
                    await this.userService.ModifyUserAsync(user);

                return Ok(modifyUser);
            }
            catch (UserValidationException userValidationException)
                when (userValidationException.InnerException is NotFoundUserException)
            {
                return NotFound(userValidationException.InnerException);
            }
            catch (UserValidationException userValidationException)
            {
                return BadRequest(userValidationException.InnerException);
            }
            catch (UserDependencyValidationException userDependencyValidationException)
            {
                return Conflict(userDependencyValidationException.InnerException);
            }
            catch (UserDependencyException userDependencyException)
            {
                return InternalServerError(userDependencyException.InnerException);
            }
            catch (UserServiceException userServiceException)
            {
                return InternalServerError(userServiceException.InnerException);
            }

        }

        [HttpDelete]

        public async ValueTask<ActionResult<User>> DeleteUserAsync(Guid userId)
        {
            try
            {
                User deleteUser =
                    await this.userService.RemoveUserAsync(userId);

                return Ok(deleteUser);
            }
            catch (UserValidationException userValidationException)
                when (userValidationException.InnerException is NotFoundUserException)
            {
                return NotFound(userValidationException.InnerException);
            }
            catch (UserValidationException userValidationException)
            {
                return BadRequest(userValidationException.InnerException);
            }
            catch (UserDependencyValidationException userDependencyValidationException)
                when (userDependencyValidationException.InnerException is LockedUserException)
            {
                return Locked(userDependencyValidationException.InnerException);
            }
            catch (UserDependencyValidationException userDependencyValidationException)
            {
                return BadRequest(userDependencyValidationException.InnerException);
            }
            catch (UserDependencyException userDependencyException)
            {
                return InternalServerError(userDependencyException.InnerException);
            }
            catch (UserServiceException userServiceException)
            {
                return InternalServerError(userServiceException.InnerException);
            }
        }
    }
}
