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
        public Guid EssayId { get; set; }
        public Essay Essay { get; set; }
        public Guid ParentId { get; set; }
    }
}
