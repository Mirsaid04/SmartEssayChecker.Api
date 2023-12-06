//=================================
// Copyright (c) Tarteeb LLC
// Check your essays esily
//=================================

using System;
using Xeptions;

namespace SmartEssayChecker.Api.Models.Feedbacks.Exceptions
{
    public class AlreadyExitsFeedbackException : Xeption
    {
        public AlreadyExitsFeedbackException(Exception innerException)
          : base(message: "Feedback already exists.",
            innerException)
        { }
    }
}
