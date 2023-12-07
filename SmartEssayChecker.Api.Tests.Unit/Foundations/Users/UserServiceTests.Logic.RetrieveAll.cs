//=================================
// Copyright (c) Tarteeb LLC
// Check your essays esily
//=================================

using FluentAssertions;
using Force.DeepCloner;
using Moq;
using SmartEssayChecker.Api.Models.Users;
using Xunit;

namespace SmartEssayChecker.Api.Tests.Unit.Foundations.Users
{
    public partial class UserServiceTests
    {
        [Fact]
        public void ShouldRetrieveAllUsers()
        {
            //given
            IQueryable<User> randomUsers = CreateRandomUsers();
            IQueryable<User> persistedUsers = randomUsers;
            IQueryable<User> expectedUsers = persistedUsers.DeepClone();

            this.storageBrokerMock.Setup(broker =>
                broker.SelectAllUsers()).Returns(persistedUsers);

            //when
            IQueryable<User> actualUsers =
                this.userService.RetrieveUsers();

            //then
            actualUsers.Should().BeEquivalentTo(expectedUsers);

            this.storageBrokerMock.Verify(broker =>
                broker.SelectAllUsers(), Times.Once());

            this.storageBrokerMock.VerifyNoOtherCalls();
            this.loggingBrokerMock.VerifyNoOtherCalls();
        }
    }
}
