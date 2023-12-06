//=================================
// Copyright (c) Tarteeb LLC
// Check your essays esily
//=================================

using System;
using Xeptions;

namespace SmartEssayChecker.Api.Models.Essays.Exceptions
{
    public class NotFoundEssayException : Xeption
    {
        public NotFoundEssayException(Guid essayId)
            : base(message: $"Couldn't find essay with id : {essayId}.")
        { }
    }
}
