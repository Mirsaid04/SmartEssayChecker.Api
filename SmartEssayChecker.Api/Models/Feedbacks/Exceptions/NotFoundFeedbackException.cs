//=================================
// Copyright (c) Tarteeb LLC
// Check your essays esily
//=================================

using System;
using Xeptions;

namespace SmartEssayChecker.Api.Models.Feedbacks.Exceptions
{
    public class NotFoundFeedbackException : Xeption
    {
        public NotFoundFeedbackException(Guid feedbackId)
           : base(message: $"Couldn't find feedback with id : {feedbackId}.")
        { }
    }
}
