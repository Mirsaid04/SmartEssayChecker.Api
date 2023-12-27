//=================================
// Copyright (c) Tarteeb LLC
// Check your essays easily
//=================================

using System.Threading.Tasks;
using SmartEssayChecker.Api.Models.Essays;
using SmartEssayChecker.Api.Models.Feedbacks;

namespace SmartEssayChecker.Api.Services.Foundations.OpenAis
{
    public interface IOpenAiService
    {
        public ValueTask<Feedback> AnalyzeEssayAsync(Essay essay);
    }
}