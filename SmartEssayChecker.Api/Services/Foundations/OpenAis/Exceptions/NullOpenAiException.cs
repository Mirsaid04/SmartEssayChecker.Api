//=================================
// Copyright (c) Tarteeb LLC
// Check your essays esily
//=================================

using Xeptions;

namespace SmartEssayChecker.Api.Services.Foundations.OpenAis.Exceptions
{
    public class NullOpenAiException : Xeption
    {
        public NullOpenAiException()
            : base(message: "Chat completion is null.")
        { }

        public NullOpenAiException(string message, Xeption innerException)
            : base(message, innerException)
        { }
    }
}
