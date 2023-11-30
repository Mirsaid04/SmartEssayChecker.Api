//=================================
// Copyright (c) Tarteeb LLC
// Check your essays esily
//=================================

using Xeptions;

namespace SmartEssayChecker.Api.Models.Essays.Exceptions
{
    public class EssayValidationException : Xeption
    {
        public EssayValidationException(Xeption innerException) 
            :base(message: "Essay validation error occured, fix the error and try again",
                 innerException)
        { }
    }
}
