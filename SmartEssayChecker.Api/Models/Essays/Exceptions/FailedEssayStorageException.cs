//=================================
// Copyright (c) Tarteeb LLC
// Check your essays esily
//=================================

using System;
using Xeptions;

namespace SmartEssayChecker.Api.Models.Essays.Exceptions
{
    public class FailedEssayStorageException : Xeption
    {
        public FailedEssayStorageException(Exception innerException)
            : base(message: "Failed essay storage exception occurred, contact support",
                  innerException)
        { }
    }
}
