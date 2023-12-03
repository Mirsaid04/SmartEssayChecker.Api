//=================================
// Copyright (c) Tarteeb LLC
// Check your essays esily
//=================================

using System.Threading.Tasks;
using SmartEssayChecker.Api.Models.Feedbacks;
using SmartEssayChecker.Api.Models.Feedbacks.Exceptions;
using Xeptions;

namespace SmartEssayChecker.Api.Services.Foundations.Feedbacks
{
    public partial class FeedbackService
    {
        private delegate ValueTask<Feedback> ReturningFeedbackFunctions();

        private async ValueTask<Feedback> TryCatch(ReturningFeedbackFunctions returningFeedbackFunctions)
        {
            try
            {
                return await returningFeedbackFunctions();
            }
            catch (NullFeedbackException nullFeedbackException)
            {
                throw CreateAndLogValidationException(nullFeedbackException);
            }
            catch (InvalidFeedbackException invalidFeedbackException)
            {
                throw CreateAndLogValidationException(invalidFeedbackException);
            }
        }

        private FeedbackValidationException CreateAndLogValidationException(Xeption xeption)
        {
            var feedbackValidationException = new FeedbackValidationException(xeption);
            this.loggingBroker.LogError(feedbackValidationException);

            return feedbackValidationException;
        }
    }
}
