//=================================
// Copyright (c) Tarteeb LLC
// Check your essays esily
//=================================

using System;
using Xeptions;

namespace SmartEssayChecker.Api.Services.Foundations.OpenAis.Exceptions
{
    public class OpenAiServiceException : Xeption
    {
        public OpenAiServiceException(Exception innerException)
            : base(message: "OpenAi Service error occured, contact support.", innerException)
        { }
    }
}
