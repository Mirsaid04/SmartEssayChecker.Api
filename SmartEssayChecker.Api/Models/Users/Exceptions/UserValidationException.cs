//=================================
// Copyright (c) Tarteeb LLC
// Check your essays esily
//=================================

using Xeptions;

namespace SmartEssayChecker.Api.Models.Users.Exceptions
{
    public class UserValidationException : Xeption
    {
        public UserValidationException(Xeption innerException)
            : base(message: "User validation error occured, fix the errors and try again.",
                 innerException)
        { }
    }
}
