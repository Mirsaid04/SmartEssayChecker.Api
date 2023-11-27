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
        public async Task ShouldAddUserAsync()
        {
            // given
            User randomUser = CreateRandomUser();
            User inputUser = randomUser;
            User persistedUser = inputUser;
            User expectedUser = persistedUser.DeepClone();

            this.storageBrokerMock.Setup(broker =>
                broker.InsertUserAsync(inputUser))
                .ReturnsAsync(expectedUser);

            // when
            User actualUser = await this.userService.AddUserAsync(inputUser);


            // then
            actualUser.Should().BeEquivalentTo(expectedUser);

            this.storageBrokerMock.Verify(broker =>
            broker.InsertUserAsync(inputUser), Times.Once());

            this.storageBrokerMock.VerifyNoOtherCalls();
        }
    }
}
