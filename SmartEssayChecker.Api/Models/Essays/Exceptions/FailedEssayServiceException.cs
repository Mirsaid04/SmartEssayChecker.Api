//=================================
// Copyright (c) Tarteeb LLC
// Check your essays esily
//=================================

using System;
using Xeptions;

namespace SmartEssayChecker.Api.Models.Essays.Exceptions
{
    public class FailedEssayServiceException : Xeption
    {
        public FailedEssayServiceException(Exception innerException)
            : base(message: "Failed essay service error occured, please contanct support",
                 innerException)
        { }
    }
}
