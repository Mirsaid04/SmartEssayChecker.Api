//=================================
// Copyright (c) Tarteeb LLC
// Check your essays esily
//=================================

using System;
using SmartEssayChecker.Api.Models.Users;

namespace SmartEssayChecker.Api.Models.Essays
{
    public class Essay
    {
        public Guid EssayId { get; set; }
        public string Content { get; set; }
        public User UserId { get; set; }
    }
}
