//=================================
// Copyright (c) Tarteeb LLC
// Check your essays esily
//=================================

using System;
using Xeptions;

namespace SmartEssayChecker.Api.Models.Essays.Exceptions
{
    public class EssayServiceException : Xeption
    {
        public EssayServiceException(Exception innerException)
            : base(message: "Essay service error occured , contact support.",
                  innerException)
        { }
    }
}
