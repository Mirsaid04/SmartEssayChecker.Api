//=================================
// Copyright (c) Tarteeb LLC
// Check your essays esily
//=================================

using SmartEssayChecker.Api.Models.Users;
using System.Threading.Tasks;
using System;

namespace SmartEssayChecker.Api.Brokers.Storages
{
    public partial interface IStorageBroker
    {
        ValueTask<User> InsertUserAsync(User user);
        ValueTask<User> SelectAllAsync();
        ValueTask<User> SelectUserByIdAsync(Guid userId);
        ValueTask<User> UpdateUserAsync(User user);
        ValueTask<User> DeleteUserAsync(User user);
    }
}
