﻿//=================================
// Copyright (c) Tarteeb LLC
// Check your essays esily
//=================================

using System;
using SmartEssayChecker.Api.Models.Essays;

namespace SmartEssayChecker.Api.Models.Feedbacks
{
    public class Feedback
    {
        public Guid Id { get; set; }
        public float Mark { get; set; }
        public string Comment { get; set; }
        public Essay EssayId { get; set; }
    }
}
