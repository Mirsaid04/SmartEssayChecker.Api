//=================================
// Copyright (c) Tarteeb LLC
// Check your essays esily
//=================================

using Xeptions;

namespace SmartEssayChecker.Api.Models.Feedbacks.Exceptions
{
    public class FeedbackDependencyException : Xeption
    {
        public FeedbackDependencyException(Xeption innerException)
            : base(message: "Feedback dependency exception occured , contact support",
                  innerException)
        { }
    }
}
