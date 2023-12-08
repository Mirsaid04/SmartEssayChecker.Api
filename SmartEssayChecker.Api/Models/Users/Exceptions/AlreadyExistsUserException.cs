//=================================
// Copyright (c) Tarteeb LLC
// Check your essays esily
//=================================

using System;
using Xeptions;

namespace SmartEssayChecker.Api.Models.Users.Exceptions
{
    public class AlreadyExistsUserException : Xeption
    {
        public AlreadyExistsUserException(Exception innerException)
            : base(message: "Already exits exception", innerException)
        { }
    }
}
