//=================================
// Copyright (c) Tarteeb LLC
// Check your essays esily
//=================================

using System;
using Xeptions;

namespace SmartEssayChecker.Api.Models.Feedbacks.Exceptions
{
    public class LockedFeedbackException : Xeption
    {
        public LockedFeedbackException(Exception innerException)
         : base(message: "Feedback is locked , please try again.",
               innerException)
        { }
    }
}
