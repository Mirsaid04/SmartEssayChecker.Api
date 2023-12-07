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
        public void ShouldRetrieveAllFeedbacks()
        {
            //given
            IQueryable<Feedback> randomFeedbacks = CreateRandomFeedbacks();
            IQueryable<Feedback> persistedFeedbacks = randomFeedbacks;
            IQueryable<Feedback> expectedFeedbacks = persistedFeedbacks.DeepClone();

            this.storageBrokerMock.Setup(broker =>
                broker.SelectAllFeedbacks()).Returns(expectedFeedbacks);

            //when
            IQueryable<Feedback> actualFeedback =
                this.feedbackService.RetrieveFeedbacksAsync();

            //then 
            actualFeedback.Should().BeEquivalentTo(expectedFeedbacks);

            this.storageBrokerMock.Verify(broker =>
                broker.SelectAllFeedbacks(), Times.Once);

            this.storageBrokerMock.VerifyNoOtherCalls();
            this.loggingBrokerMock.VerifyNoOtherCalls();
        }
    }
}
