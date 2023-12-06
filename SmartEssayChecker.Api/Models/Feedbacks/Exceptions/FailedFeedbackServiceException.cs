//=================================
// Copyright (c) Tarteeb LLC
// Check your essays esily
//=================================

using System;
using Xeptions;

namespace SmartEssayChecker.Api.Models.Feedbacks.Exceptions
{
    public class FailedFeedbackServiceException : Xeption
    {
            public FailedFeedbackServiceException(Exception innerException)
                : base(message: "Failed feedback service error occured, please contact support",
                      innerException)
            { }
    }
}
