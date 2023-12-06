//=================================
// Copyright (c) Tarteeb LLC
// Check your essays esily
//=================================

using System;
using Xeptions;

namespace SmartEssayChecker.Api.Models.Essays.Exceptions
{
    public class EssayDependencyException : Xeption
    {
        public EssayDependencyException(Exception innerException)
            : base(message: "Essay dependency error occured, contact support.",
                  innerException)
        { }
    }
}
