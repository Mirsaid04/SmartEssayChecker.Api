//=================================
// Copyright (c) Tarteeb LLC
// Check your essays esily
//=================================

using System.Linq.Expressions;
using Moq;
using SmartEssayChecker.Api.Brokers.Loggings;
using SmartEssayChecker.Api.Brokers.Storages;
using SmartEssayChecker.Api.Models.Feedbacks;
using SmartEssayChecker.Api.Services.Foundations.Feedbacks;
using Tynamix.ObjectFiller;
using Xeptions;

namespace SmartEssayChecker.Api.Tests.Unit.Foundations.Feedbacks
{
    public partial class FeedbackServiceTests
    {
        private readonly Mock<IStorageBroker> storageBrokerMock;
        private readonly Mock<ILoggingBroker> loggingBrokerMock;
        private readonly IFeedbackService feedbackService;

        public FeedbackServiceTests()
        {
            this.storageBrokerMock = new Mock<IStorageBroker>();
            this.loggingBrokerMock = new Mock<ILoggingBroker>();

            this.feedbackService =
                new FeedbackService(
                storageBroker: this.storageBrokerMock.Object,
                loggingBroker: this.loggingBrokerMock.Object);
        }

        private string GetRandomString() =>
            new MnemonicString().GetValue();

        private static int GetRandomNumber() =>
            new IntRange(min: 2, max: 9).GetValue();

        private static Expression<Func<Xeption, bool>> SameExceptionAs(Xeption expectedException) =>
            actualException => actualException.SameExceptionAs(expectedException);

        private static Feedback CreateRandomFeedback() =>
            CreateFeedbackFiller().Create();

        private static Filler<Feedback> CreateFeedbackFiller() =>
            new Filler<Feedback>();
    }
}
