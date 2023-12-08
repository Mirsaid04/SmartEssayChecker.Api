//=================================
// Copyright (c) Tarteeb LLC
// Check your essays esily
//=================================

using FluentAssertions;
using Force.DeepCloner;
using Moq;
using SmartEssayChecker.Api.Models.Essays;
using Xunit;

namespace SmartEssayChecker.Api.Tests.Unit.Foundations.Essays
{
    public partial class EssayServiceTests
    {
        [Fact]
        public void SHouldRetrieveAllEssays()
        {
            //given
            IQueryable<Essay> randomEssays = CreateRandomEssays();
            IQueryable<Essay> persistedEssays = randomEssays;
            IQueryable<Essay> expectedEssays = persistedEssays.DeepClone();

            this.storageBrokerMock.Setup(broker =>
                broker.SelectAllEssays()).Returns(expectedEssays);

            //when
            IQueryable<Essay> actualEssays =
                this.essayService.RetrieveAllEssays();

            //then
            actualEssays.Should().BeEquivalentTo(expectedEssays);

            this.storageBrokerMock.Verify(broker =>
                broker.SelectAllEssays(), Times.Once());

            this.storageBrokerMock.VerifyNoOtherCalls();
            this.loggingBrokerMock.VerifyNoOtherCalls();
        }
    }
}
