//=================================
// Copyright (c) Tarteeb LLC
// Check your essays esily
//=================================

using System;
using Xeptions;

namespace SmartEssayChecker.Api.Services.Foundations.OpenAis.Exceptions
{
    public class FailedOpenAiServiceException : Xeption
    {
        public FailedOpenAiServiceException(Exception innerException)
            : base(message: "Failed analyse essay service error occured, contact support.",
                 innerException)
        { }
    }
}
