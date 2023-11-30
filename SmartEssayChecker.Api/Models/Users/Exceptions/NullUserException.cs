//=================================
// Copyright (c) Tarteeb LLC
// Check your essays esily
//=================================

using Xeptions;

namespace SmartEssayChecker.Api.Models.Users.Exceptions
{
    public class NullUserException : Xeption
    {
        public NullUserException()
            : base(message: "User is null.")
        { }
    }
}
