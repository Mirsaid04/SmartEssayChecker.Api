﻿//=================================
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
        public async Task ShouldRemoveUserByIdAsync()
        {
            //given
            Guid randomId = Guid.NewGuid();
            Guid inputUserId = randomId;
            User randomUser = CreateRandomUser();
            User storageUser = randomUser;
            User expectedInputUser = storageUser;
            User deleteUser = expectedInputUser;
            User expectedUser = deleteUser.DeepClone();

            this.storageBrokerMock.Setup(broker =>
                broker.SelectUserByIdAsync(inputUserId))
                .ReturnsAsync(storageUser);

            this.storageBrokerMock.Setup(broker =>
                broker.DeleteUserAsync(expectedInputUser))
                .ReturnsAsync(deleteUser);

            //when
            User actualUser =
                await this.userService.RemoveUserAsync(inputUserId);

            //then
            actualUser.Should().BeEquivalentTo(expectedUser);

            this.storageBrokerMock.Verify(broker =>
                broker.SelectUserByIdAsync(inputUserId), Times.Once());

            this.storageBrokerMock.Verify(broker =>
                broker.DeleteUserAsync(expectedInputUser), Times.Once());

            this.storageBrokerMock.VerifyNoOtherCalls();
            this.loggingBrokerMock.VerifyNoOtherCalls();
        }
    }
}
