//=================================
// Copyright (c) Tarteeb LLC
// Check your essays esily
//=================================

using SmartEssayChecker.Api.Brokers.Loggings;
using SmartEssayChecker.Api.Brokers.Storages;
using SmartEssayChecker.Api.Models.Users;
using SmartEssayChecker.Api.Services.Foundations.Users.Exceptions;
using System.Threading.Tasks;

namespace SmartEssayChecker.Api.Services.Foundations.Users
{
    internal partial class UserService : IUserService
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
            ValidateUserNotNull(user);

            return await this.storageBroker.InsertUserAsync(user);
        });
    }
}
