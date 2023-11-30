//=================================
// Copyright (c) Tarteeb LLC
// Check your essays esily
//=================================

using System.Buffers.Text;
using Azure.Messaging;
using Xeptions;

namespace SmartEssayChecker.Api.Models.Users.Exceptions
{
    public class InvalidUserException : Xeption
    {
        public InvalidUserException()
         : base(message: "User is invalid.")
        { }
    }
}
