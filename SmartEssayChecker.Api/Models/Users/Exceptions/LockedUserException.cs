//=================================
// Copyright (c) Tarteeb LLC
// Check your essays esily
//=================================

using System;
using Xeptions;

namespace SmartEssayChecker.Api.Models.Users.Exceptions
{
    public class LockedUserException : Xeption
    {
        public LockedUserException(Exception innerException)
         : base(message: "User is locked , please try again.",
               innerException)
        { }
    }
}
