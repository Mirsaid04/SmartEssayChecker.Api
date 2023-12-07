//=================================
// Copyright (c) Tarteeb LLC
// Check your essays esily
//=================================

using FluentAssertions;
using Force.DeepCloner;
using Moq;
using SmartEssayChecker.Api.Models.Feedbacks;
using Xunit;

namespace SmartEssayChecker.Api.Tests.Unit.Foundations.Feedbacks
{
    public partial class FeedbackServiceTests
    {
        [Fact]
        public async Task ShouldAddFeedbackAsync()
        {
            // given
            Feedback randomFeedback = CreateRandomFeedback();
            Feedback inputFeedback = randomFeedback;
            Feedback persistedFeedback = inputFeedback;
            Feedback expectedFeedback = persistedFeedback.DeepClone();

            this.storageBrokerMock.Setup(broker =>
            broker.InsertFeedbackAsync(inputFeedback))
                .ReturnsAsync(inputFeedback);

            // when
            Feedback actualFeedback = await this.feedbackService.AddFeedbackAsync(inputFeedback);

            // then
            actualFeedback.Should().BeEquivalentTo(expectedFeedback);

            this.storageBrokerMock.Verify(broker =>
            broker.InsertFeedbackAsync(inputFeedback), Times.Once());

            this.storageBrokerMock.VerifyNoOtherCalls();
        }
    }
}
