//=================================
// Copyright (c) Tarteeb LLC
// Check your essays esily
//=================================

using Xeptions;

namespace SmartEssayChecker.Api.Models.Users.Exceptions
{
    public class NotFoundUserByNameException : Xeption
    {
        public NotFoundUserByNameException(string userName)
            : base(message: $"User is not found by name: {userName}")
        { }
    }
}
