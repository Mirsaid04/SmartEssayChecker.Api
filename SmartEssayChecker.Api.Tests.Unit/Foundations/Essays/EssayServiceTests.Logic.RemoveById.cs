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
        public async Task ShouldRemoveEssayByIdAsync()
        {
            //given
            Guid randomId = Guid.NewGuid();
            Guid inputEssayId = randomId;
            Essay randomEssay = CreateRandomEssay();
            Essay storageEssay = randomEssay;
            Essay expectedInputEssay = storageEssay;
            Essay deleteEssay = expectedInputEssay;
            Essay expectedEssay = deleteEssay.DeepClone();

            this.storageBrokerMock.Setup(broker =>
                broker.SelectEssayByIdAsync(inputEssayId))
                .ReturnsAsync(storageEssay);

            this.storageBrokerMock.Setup(broker =>
                broker.DeleteEssayAsync(expectedInputEssay))
                .ReturnsAsync(deleteEssay);

            //when
            Essay actualEssay = await
                this.essayService.RemoveEssayAsync(inputEssayId);

            //then
            actualEssay.Should().BeEquivalentTo(expectedEssay);

            this.storageBrokerMock.Verify(broker =>
                broker.SelectEssayByIdAsync(inputEssayId), Times.Once());

            this.storageBrokerMock.Verify(broker =>
                 broker.DeleteEssayAsync(expectedInputEssay), Times.Once());

            this.storageBrokerMock.VerifyNoOtherCalls();
            this.loggingBrokerMock.VerifyNoOtherCalls();
        }
    }
}
