//=================================
// Copyright (c) Tarteeb LLC
// Check your essays esily
//=================================

using Xeptions;

namespace SmartEssayChecker.Api.Models.Feedbacks.Exceptions
{
    public class FeedbackDependencyValidationException : Xeption
    {
        public FeedbackDependencyValidationException(Xeption innerException)
           : base(message: "Feedback dependency validation exception occured, fix the errors and try again.",
                 innerException)
        { }
    }
}
