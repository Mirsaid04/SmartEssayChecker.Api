//=================================
// Copyright (c) Tarteeb LLC
// Check your essays esily
//=================================

using SmartEssayChecker.Api.Brokers.Loggings;
using SmartEssayChecker.Api.Brokers.Storages;
using SmartEssayChecker.Api.Models.Users;
using System.Threading.Tasks;

namespace SmartEssayChecker.Api.Services.Foundations.Users
{
    public class UserService : IUserService
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

       public async ValueTask<User> AddUserAsync(User user) =>
           await this.storageBroker.InsertUserAsync(user);
    }
}
