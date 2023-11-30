//=================================
// Copyright (c) Tarteeb LLC
// Check your essays esily
//=================================

using Xeptions;

namespace SmartEssayChecker.Api.Models.Feedbacks.Exceptions
{
    public class FeedbackValidationException : Xeption
    {
        public FeedbackValidationException(Xeption innerException)
            : base(message: "Feedback is invalid, fix the the error and try again.",
                  innerException)
        { }
    }
}
