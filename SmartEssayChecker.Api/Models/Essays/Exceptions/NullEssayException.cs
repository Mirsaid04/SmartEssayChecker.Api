//=================================
// Copyright (c) Tarteeb LLC
// Check your essays esily
//=================================

using Xeptions;

namespace SmartEssayChecker.Api.Models.Essays.Exceptions
{
    public class NullEssayException : Xeption
    {
        public NullEssayException()
            : base(message: "Essay is null.")
        { }
    }
}
