//=================================
// Copyright (c) Tarteeb LLC
// Check your essays esily
//=================================

using System;
using Xeptions;

namespace SmartEssayChecker.Api.Models.Feedbacks.Exceptions
{
    public class FailedFeedbackStorageException : Xeption
    {
        public FailedFeedbackStorageException(Exception innerException)
          : base(message: "Failed feedback storage exception occured, contact support",
                innerException)
        { }
    }
}
