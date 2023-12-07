//=================================
// Copyright (c) Tarteeb LLC
// Check your essays esily
//=================================

using System;
using System.Linq;
using System.Threading.Tasks;
using SmartEssayChecker.Api.Brokers.Loggings;
using SmartEssayChecker.Api.Brokers.Storages;
using SmartEssayChecker.Api.Models.Users;

namespace SmartEssayChecker.Api.Services.Foundations.Users
{
    public partial class UserService : IUserService
    {

        private readonly IStorageBroker storageBroker;
        private readonly ILoggingBroker loggingBroker;

        public UserService(
            IStorageBroker storageBroker,
            ILoggingBroker loggingBroker)
        {
            this.storageBroker = storageBroker;
            this.loggingBroker = loggingBroker;
        }

        public ValueTask<User> AddUserAsync(User user) =>
        TryCatch(async () =>
        {
            ValidationOnAdd(user);

            return await this.storageBroker.InsertUserAsync(user);
        });

        public IQueryable<User> RetrieveUsers() =>
            throw new NotImplementedException();

        public async ValueTask<User> RetrieveUserByIdAsync(Guid userId)
        {
            ValidateUserId(userId);

            User user = await this.storageBroker.SelectUserByIdAsync(userId);

            return user;
        }

        public async ValueTask<User> ModifyUserAsync(User user)
        {
            ValidateUserOnModify(user);

            User maybeUser =
                await this.storageBroker.SelectUserByIdAsync(user.Id);

            ValidateAgainstStorageUserOnModify(user, maybeUser);

            return await this.storageBroker.UpdateUserAsync(user);
        }

        public async ValueTask<User> RemoveUserAsync(Guid userId)
        {
            ValidateUserId(userId);

            User user = await this.storageBroker.SelectUserByIdAsync(userId);

            return await this.storageBroker.DeleteUserAsync(user);
        }
    }
}
