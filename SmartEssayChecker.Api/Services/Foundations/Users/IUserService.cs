//=================================
// Copyright (c) Tarteeb LLC
// Check your essays esily
//=================================

using System;
using System.Linq;
using System.Threading.Tasks;
using SmartEssayChecker.Api.Models.Users;

namespace SmartEssayChecker.Api.Services.Foundations.Users
{
    public interface IUserService
    {
        /// <exception cref="Models.Users.Exceptions.UserValidationException"></exception>
        /// <exception cref="Models.Users.Exceptions.UserDependencyValidationException"></exception>
        /// <exception cref="Models.Users.Exceptions.UserDependencyException"></exception>
        /// <exception cref="Models.Users.Exceptions.UserServiceException"></exception>
        ValueTask<User> AddUserAsync(User user);
        /// <exception cref="Models.Users.Exceptions.UserDependencyException"></exception>
        /// <exception cref="Models.Users.Exceptions.UserServiceException"></exception> 
        IQueryable<User> RetrieveUsers();
        /// <exception cref="Models.Users.Exceptions.UserDependencyException"></exception>
        /// <exception cref="Models.Users.Exceptions.UserServiceException"></exception>
        ValueTask<User> RetrieveUserByIdAsync(Guid userId);
        /// <exception cref="Models.Users.Exceptions.UserDependencyValidationException"></exception>
        /// <exception cref="Models.Users.Exceptions.UserDependencyException"></exception>
        /// <exception cref="Models.Users.Exceptions.UserServiceException"></exception>
        ValueTask<User> RemoveUserAsync(Guid userId);
        /// <exception cref="Models.Users.Exceptions.UserValidationException"></exception>
        /// <exception cref="Models.Users.Exceptions.UserDependencyValidationException"></exception>
        /// <exception cref="Models.Users.Exceptions.UserDependencyException"></exception>
        /// <exception cref="Models.Users.Exceptions.UserServiceException"></exception>
        ValueTask<User> ModifyUserAsync(User user);
    }
}