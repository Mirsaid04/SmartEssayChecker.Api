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
        public async Task ShouldAddEssayAsync()
        {
            // given
            Essay randomEssay = CreateRandomEssay();
            Essay inputEssay = randomEssay;
            Essay persistedEssay = inputEssay;
            Essay expectedEssay = persistedEssay.DeepClone();

            this.storageBrokerMock.Setup(broker =>
            broker.InsertEssayAsync(inputEssay))
            .ReturnsAsync(expectedEssay);

            // when
            Essay actualEssay = await this.essayService.AddEssayAsync(inputEssay);

            //then
            actualEssay.Should().BeEquivalentTo(expectedEssay);

            this.storageBrokerMock.Verify(broker =>
            broker.InsertEssayAsync(inputEssay), Times.Once());

            this.storageBrokerMock.VerifyNoOtherCalls();
        }
    }
}
