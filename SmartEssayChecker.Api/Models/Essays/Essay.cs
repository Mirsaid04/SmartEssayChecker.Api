//=================================
// Copyright (c) Tarteeb LLC
// Check your essays esily
//=================================

using System;

namespace SmartEssayChecker.Api.Models.Essays
{
    public class Essay
    {
        public Guid EssayId { get; set; }
        public string Content { get; set; }
        public Guid UserId { get; set; }
    }
}
