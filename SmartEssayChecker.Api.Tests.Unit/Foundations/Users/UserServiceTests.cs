//=================================
// Copyright (c) Tarteeb LLC
// Check your essays esily
//=================================

using System.Data;
using Moq;
using SmartEssayChecker.Api.Brokers.Loggings;
using SmartEssayChecker.Api.Brokers.Storages;
using SmartEssayChecker.Api.Models.Users;
using SmartEssayChecker.Api.Services.Foundations.Users;
using Tynamix.ObjectFiller;

namespace SmartEssayChecker.Api.Tests.Unit.Foundations.Users
{
    public partial class UserServiceTests
    {
        private readonly Mock<IStorageBroker> storageBrokerMock;
        private readonly Mock<ILoggingBroker> loggingBrokerMock;
        private readonly IUserService userService;

        public UserServiceTests()
        {
            this.storageBrokerMock = new Mock<IStorageBroker>();
            this.loggingBrokerMock = new Mock<ILoggingBroker>();

            this.userService = new UserService(
                storageBroker: this.storageBrokerMock.Object,
                loggingBroker: this.loggingBrokerMock.Object);
        }

        private static User CreateRandomUser() =>
            CreateUserFiller().Create();

        private static Filler<User> CreateUserFiller() =>
             new Filler<User>();
    }
}
