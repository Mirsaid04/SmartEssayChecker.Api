//=================================
// Copyright (c) Tarteeb LLC
// Check your essays esily
//=================================

using System;
using Xeptions;

namespace SmartEssayChecker.Api.Models.Essays.Exceptions
{
    public class LockedEssayException : Xeption
    {
        public LockedEssayException(Exception innerException)
            : base(message: "Locked essay record occured, contact support",
                  innerException)
        { }
    }
}
