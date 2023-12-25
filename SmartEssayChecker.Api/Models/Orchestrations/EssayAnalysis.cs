//=================================
// Copyright (c) Tarteeb LLC
// Check your essays esily
//=================================

using SmartEssayChecker.Api.Models.Essays;
using SmartEssayChecker.Api.Models.Feedbacks;

namespace SmartEssayChecker.Api.Models.EssayAnalayses
{
    public class EssayAnalysis
    {
        public Essay? Essay { get; set; }
        public Feedback? Feedback { get; set; }
    }
}
