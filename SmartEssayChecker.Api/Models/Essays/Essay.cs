//=================================
// Copyright (c) Tarteeb LLC
// Check your essays esily
//=================================

using System;
using System.Text.Json.Serialization;
using SmartEssayChecker.Api.Models.Feedbacks;
using SmartEssayChecker.Api.Models.Users;

namespace SmartEssayChecker.Api.Models.Essays
{
    public class Essay
    {
        [JsonIgnore]
        public Guid EssayId { get; set; }
        public string Content { get; set; }
        [JsonIgnore]
        public Guid UserId { get; set; }
        [JsonIgnore]
        public virtual User? User { get; set; }
        [JsonIgnore]
        public virtual Feedback? Feedback { get; set; }
    }
}
