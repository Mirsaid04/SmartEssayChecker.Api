//=================================
// Copyright (c) Tarteeb LLC
// Check your essays esily
//=================================

using System;
using System.Collections.Generic;
using SmartEssayChecker.Api.Models.Essays;

namespace SmartEssayChecker.Api.Models.Users
{
    public class User
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public List<Essay> Essays { get; set; }
    }
}
