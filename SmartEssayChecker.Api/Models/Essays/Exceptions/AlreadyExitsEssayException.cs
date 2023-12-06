//=================================
// Copyright (c) Tarteeb LLC
// Check your essays esily
//=================================

using System;
using Xeptions;

namespace SmartEssayChecker.Api.Models.Essays.Exceptions
{
    public class AlreadyExitsEssayException : Xeption
    {
        public AlreadyExitsEssayException(Exception innerException)
            : base(message: "Essay already exists.",
              innerException)
        { }
    }
}
