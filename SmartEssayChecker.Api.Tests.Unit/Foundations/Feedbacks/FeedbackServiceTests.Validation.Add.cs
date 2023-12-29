/*//=================================
// Copyright (c) Tarteeb LLC
// Check your essays esily
//=================================

using FluentAssertions;
using Moq;
using SmartEssayChecker.Api.Models.Feedbacks;
using SmartEssayChecker.Api.Models.Feedbacks.Exceptions;
using Xunit;

namespace SmartEssayChecker.Api.Tests.Unit.Foundations.Feedbacks
{
    public partial class FeedbackServiceTests
    {
        [Fact]
        public async Task ShouldThrowValidationExceptionOnAddIfFeedbackIsNullAndLogItAsync()
        {
            //given
            Feedback nullFeedback = null;

            var nullFeedbackException = new NullFeedbackException();

            var expectedFeedbackValidationException =
                new FeedbackValidationException(nullFeedbackException);

            //when
            ValueTask<Feedback> addFeedbackTask =
                this.feedbackService.AddFeedbackAsync(nullFeedback);

            FeedbackValidationException actualFeedbackValidationException =
                await Assert.ThrowsAsync<FeedbackValidationException>(addFeedbackTask.AsTask);


            //then
            actualFeedbackValidationException.Should().BeEquivalentTo(
                expectedFeedbackValidationException);

            this.loggingBrokerMock.Verify(broker =>
                broker.LogError(It.Is(SameExceptionAs(
                    expectedFeedbackValidationException))), Times.Once());

            this.loggingBrokerMock.VerifyNoOtherCalls();
            this.storageBrokerMock.VerifyNoOtherCalls();
        }
        [Theory]
        [InlineData(null)]
        [InlineData("")]
        [InlineData(" ")]

        public async Task ShouldThrowValidationExceptionOnAddIfFeedbackInvalidAndLogItAsync(
            string invalidText)
        {
            //given
            var invalidFeedback = new Feedback
            {
                Comment = invalidText,
            };

            var invalidFeedbackException = new InvalidFeedbackException();

            invalidFeedbackException.AddData(
                key: nameof(Feedback.Id),
                values: "Id is required");

            invalidFeedbackException.AddData(
                key: nameof(Feedback.Comment),
                values: "Comment is required");

            invalidFeedbackException.AddData(
                key: nameof(Feedback.Mark),
                values: "Number is required");

            var expectedFeedbackValidationException =
                new FeedbackValidationException(invalidFeedbackException);

            //when
            ValueTask<Feedback> addFeedbackTask =
                this.feedbackService.AddFeedbackAsync(invalidFeedback);

            FeedbackValidationException actualFeedbackValidationException =
                await Assert.ThrowsAsync<FeedbackValidationException>(addFeedbackTask.AsTask);

            //then
            actualFeedbackValidationException.Should().BeEquivalentTo(
                expectedFeedbackValidationException);

            this.loggingBrokerMock.Verify(broker =>
                broker.LogError(It.Is(SameExceptionAs(
                expectedFeedbackValidationException))), Times.Once());

            this.storageBrokerMock.VerifyNoOtherCalls();
        }
    }
}
*/