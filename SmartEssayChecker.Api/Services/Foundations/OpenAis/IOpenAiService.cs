//=================================
// Copyright (c) Tarteeb LLC
// Check your essays easily
//=================================

using System.Threading.Tasks;
using SmartEssayChecker.Api.Models.Essays;

namespace SmartEssayChecker.Api.Services.Foundations.OpenAis
{
    public interface IOpenAiService
    {
        public ValueTask<string> AnalyzeEssayAsync(Essay essay);
    }
}