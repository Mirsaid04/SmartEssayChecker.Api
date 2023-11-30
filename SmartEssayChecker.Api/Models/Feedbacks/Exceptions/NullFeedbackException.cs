//=================================
// Copyright (c) Tarteeb LLC
// Check your essays esily
//=================================

using Xeptions;

namespace SmartEssayChecker.Api.Models.Feedbacks.Exceptions
{
    public class NullFeedbackException : Xeption
    {
        public NullFeedbackException()
            : base(message: "Feedback is null.")
        { }
    }
}
