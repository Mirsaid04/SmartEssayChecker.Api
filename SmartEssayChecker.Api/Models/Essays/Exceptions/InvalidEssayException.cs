//=================================
// Copyright (c) Tarteeb LLC
// Check your essays esily
//=================================

using Xeptions;

namespace SmartEssayChecker.Api.Models.Essays.Exceptions
{
    public class InvalidEssayException : Xeption
    {
        public InvalidEssayException()
            : base(message: "Essay is invalid.")
        { }
    }
}
