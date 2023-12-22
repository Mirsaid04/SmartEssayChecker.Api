//=================================
// Copyright (c) Tarteeb LLC
// Check your essays esily
//=================================

using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using SmartEssayChecker.Api.Models.Feedbacks;
using SmartEssayChecker.Api.Models.Users;

namespace SmartEssayChecker.Api.Models.Essays
{
    public class Essay
    {
        public Guid EssayId { get; set; }
        public string Content { get; set; }
        public Guid UserId { get; set; }
        [JsonIgnore]
        public User User { get; set; }
        [JsonIgnore]
        public List<Feedback> Feedbacks { get; set; } = new List<Feedback>();
    }
}
