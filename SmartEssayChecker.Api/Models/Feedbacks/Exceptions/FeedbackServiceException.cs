//=================================
// Copyright (c) Tarteeb LLC
// Check your essays esily
//=================================

using Xeptions;

namespace SmartEssayChecker.Api.Models.Feedbacks.Exceptions
{
    public class FeedbackServiceException : Xeption
    {
        public FeedbackServiceException(Xeption innerException)
           : base(message: "Feedback service error occured , contact support.",
                innerException)
        { }
    }
}
