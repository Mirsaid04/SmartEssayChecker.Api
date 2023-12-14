//=================================
// Copyright (c) Tarteeb LLC
// Check your essays esily
//=================================

using System;
using Xeptions;

namespace SmartEssayChecker.Api.Services.Foundations.OpenAis.Exceptions
{
    public class OpenAiValidationException : Xeption
    {
        public OpenAiValidationException(Exception innerException)
            : base("Chat completion validation error occurred, fix errors and try again.", innerException)
        { }
    }
}
