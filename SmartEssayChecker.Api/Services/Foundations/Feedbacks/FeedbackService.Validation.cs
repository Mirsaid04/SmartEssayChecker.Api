using System;
using SmartEssayChecker.Api.Models.Feedbacks;
using SmartEssayChecker.Api.Models.Feedbacks.Exceptions;

namespace SmartEssayChecker.Api.Services.Foundations.Feedbacks
{
    public partial class FeedbackService
    {
        private void ValidationOnAdd(Feedback feedback)
        {
            ValidateFeedbackNotNull(feedback);

            Validate(
                (Rule: IsInvalid(feedback.Id), Parameter: nameof(feedback.Id)),
                (Rule: IsInvalid(feedback.Comment), Parameter: nameof(feedback.Comment)));
        }

        private void ValidateFeedbackId(Guid feedbackId)
        {
            Validate((Rule: IsInvalid(feedbackId), Parameter: nameof(feedbackId)));
        }

        private static dynamic IsInvalid(Guid feedbackId) => new
        {
            Condition = feedbackId == default,
            Message = "Id is required"
        };

        private static dynamic IsInvalid(string comment) => new
        {
            Condition = string.IsNullOrWhiteSpace(comment),
            Message = "Comment is required"
        };

        private static dynamic IsInvalid(float number) => new
        {
            Condition = number == default,
            Message = "Number is required"
        };

        private static void ValidateFeedbackNotNull(Feedback feedback)
        {
            if (feedback == null)
            {
                throw new NullFeedbackException();
            }
        }

        private static void Validate(params (dynamic Rule, string Parameter)[] validations)
        {
            var invalidFeedbackException = new InvalidFeedbackException();

            foreach ((dynamic rule, string parameter) in validations)
            {
                if (rule.Condition)
                {
                    invalidFeedbackException.UpsertDataList(
                        key: parameter,
                        value: rule.Message);
                }
            }
            invalidFeedbackException.ThrowIfContainsErrors();

        }
    }
}
