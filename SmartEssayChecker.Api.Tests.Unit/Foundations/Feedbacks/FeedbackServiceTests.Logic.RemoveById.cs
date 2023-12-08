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
        public async Task ShouldRemoveFeedbackByIdAsync()
        {
            //given
            Guid randomId = Guid.NewGuid();
            Guid inputFeedbackId = randomId;
            Feedback randomFeedback = CreateRandomFeedback();
            Feedback storageFeedback = randomFeedback;
            Feedback expectedInputFeedback = storageFeedback;
            Feedback deleteFeedback = expectedInputFeedback;
            Feedback expectedFeedback = deleteFeedback.DeepClone();

            this.storageBrokerMock.Setup(broker =>
                broker.SelectFeedbackByIdAsync(inputFeedbackId))
                .ReturnsAsync(storageFeedback);

            this.storageBrokerMock.Setup(broker =>
                broker.DeleteFeedbackAsync(expectedInputFeedback))
                .ReturnsAsync(deleteFeedback);

            //when
            Feedback actualFeedback = await
                this.feedbackService.RemoveFeedbackAsync(inputFeedbackId);

            //then
            actualFeedback.Should().BeEquivalentTo(expectedFeedback);

            this.storageBrokerMock.Verify(broker =>
                broker.SelectFeedbackByIdAsync(inputFeedbackId), Times.Once);

            this.storageBrokerMock.Verify(broker =>
                broker.DeleteFeedbackAsync(expectedInputFeedback), Times.Once);

            this.storageBrokerMock.VerifyNoOtherCalls();
            this.loggingBrokerMock.VerifyNoOtherCalls();
        }
    }
}
