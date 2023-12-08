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
        public async Task ShouldRetrieveByIdAsync()
        {
            //given
            Guid randomEssayId = Guid.NewGuid();
            Guid inputEssayId = randomEssayId;
            Essay randomEssay = CreateRandomEssay();
            Essay persistedEssay = randomEssay;
            Essay expectedEssay = persistedEssay.DeepClone();

            this.storageBrokerMock.Setup(broker =>
                broker.SelectEssayByIdAsync(inputEssayId))
                .ReturnsAsync(persistedEssay);

            //when
            Essay actualEssay = await this.essayService
                .RetrieveEssayByIdAsync(inputEssayId);

            //then
            actualEssay.Should().BeEquivalentTo(expectedEssay);

            this.storageBrokerMock.Verify(broker =>
                broker.SelectUserByIdAsync(inputEssayId), Times.Once());
        }
    }
}
