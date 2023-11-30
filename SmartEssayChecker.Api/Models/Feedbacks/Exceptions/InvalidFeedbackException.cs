using Xeptions;

namespace SmartEssayChecker.Api.Models.Feedbacks.Exceptions
{
    public class InvalidFeedbackException :Xeption
    {
        public InvalidFeedbackException()
            :base(message: "Feedback is invalid.")
        { }
    }
}
