//=================================
// Copyright (c) Tarteeb LLC
// Check your essays easily
//=================================

using System;
using System.Linq;
using System.Threading.Tasks;
using SmartEssayChecker.Api.Models.Users;

namespace SmartEssayChecker.Api.Brokers.Storages
{
    public partial interface IStorageBroker
    {
        ValueTask<User> InsertUserAsync(User user);
        IQueryable<User> SelectAllUsers();
        ValueTask<User> SelectUserByIdAsync(Guid userId);
        ValueTask<User> UpdateUserAsync(User user);
        ValueTask<User> DeleteUserAsync(User user);
    }
}
