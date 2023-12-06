//=================================
// Copyright (c) Tarteeb LLC
// Check your essays esily
//=================================

using Xeptions;

namespace SmartEssayChecker.Api.Models.Essays.Exceptions
{
    public class EssayDependencyValidationException : Xeption
    {
        public EssayDependencyValidationException(Xeption innerException)
            : base(message: "EssayDependency validation error occured , fix the errors and try again",
                  innerException)
        { }
    }
}
