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
        public async Task ShouldRetrieveByIdAsync()
        {
            //given
            Guid randomFeedbackId = Guid.NewGuid();
            Guid inputFeedbackId = randomFeedbackId;
            Feedback randomFeedback = CreateRandomFeedback();
            Feedback persistedFeedback = randomFeedback;
            Feedback expectedFeedback = persistedFeedback.DeepClone();

            this.storageBrokerMock.Setup(broker =>
                broker.SelectFeedbackByIdAsync(inputFeedbackId)).
                ReturnsAsync(persistedFeedback);

            //when
            Feedback actualFeedback = await this.feedbackService
                .RetrieveFeedbackByIdAsync(inputFeedbackId);

            //then 
            actualFeedback.Should().BeEquivalentTo(expectedFeedback);

            this.storageBrokerMock.Verify(broker =>
                broker.SelectFeedbackByIdAsync(inputFeedbackId), Times.Once());
        }
    }
}
