//=================================
// Copyright (c) Tarteeb LLC
// Check your essays esily
//=================================

using System;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;
using SmartEssayChecker.Api.Models.Essays;

namespace SmartEssayChecker.Api.Models.Feedbacks
{
    public class Feedback
    {
        public Guid Id { get; set; }
        public float Mark { get; set; }
        public string Comment { get; set; }
        [ForeignKey("EssayId")]
        public Guid EssayId { get; set; }
        [JsonIgnore]
        public Essay? Essay { get; set; }
    }
}
