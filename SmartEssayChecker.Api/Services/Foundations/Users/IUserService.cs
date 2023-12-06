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
        /// <summary>
        /// Save into Database
        /// </summary>
        /// <param name="user"></param>
        /// <returns></returns>
        /// <exception cref="Models.Users.Exceptions.UserValidationException"></exception>

        ValueTask<User> AddUserAsync(User user);
        IQueryable<User> RetrieveUsers();
        ValueTask<User> RetrieveUserByIdAsync(Guid userId);
        ValueTask<User> ModifyUserAsync(User user);
        ValueTask<User> RemoveUserAsync(Guid userId);
    }
}