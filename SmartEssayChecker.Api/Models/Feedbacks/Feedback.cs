//=================================
// Copyright (c) Tarteeb LLC
// Check your essays esily
//=================================

using System;
using System.Text.Json.Serialization;
using SmartEssayChecker.Api.Models.Essays;

namespace SmartEssayChecker.Api.Models.Feedbacks
{
    public class Feedback
    {
        public Guid Id { get; set; }
        [JsonIgnore]
        public float Mark { get; set; }
        public string Comment { get; set; }
        [JsonIgnore]
        public Guid EssayId { get; set; }
        [JsonIgnore]
        public virtual Essay? Essay { get; set; }
    }
}
