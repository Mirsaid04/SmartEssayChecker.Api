//=================================
// Copyright (c) Tarteeb LLC
// Check your essays esily
//=================================

using Microsoft.EntityFrameworkCore;
using SmartEssayChecker.Api.Models.Users;
using System.Linq;
using System.Threading.Tasks;
using System;

namespace SmartEssayChecker.Api.Brokers.Storages
{
    public partial class StorageBroker
    {
        public DbSet<User> Users { get; set; }
        public async ValueTask<User> InsertUserAsync(User user) =>
            await InsertAsync(user);

        public IQueryable<User> SelectAllUsers() =>
            SelectAll<User>().AsQueryable();

        public async ValueTask<User> SelectUserByIdAsync(Guid userId) =>
            await SelectAsync<User>(userId);

        public async ValueTask<User> UpdateUserAsync(User user) =>
            await UpdateAsync(user);

        public async ValueTask<User> DeleteUserAsync(User user) =>
            await DeleteAsync(user);
    }
}
