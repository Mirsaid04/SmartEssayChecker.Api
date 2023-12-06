//=================================
// Copyright (c) Tarteeb LLC
// Check your essays esily
//=================================

using System;
using Xeptions;

namespace SmartEssayChecker.Api.Models.Users.Exceptions
{
    public class NotFoundUserException : Xeption
    {
        public NotFoundUserException(Guid userId)
            : base(message: $"Couldn't found user with id: {userId}")
        { }
    }
}
