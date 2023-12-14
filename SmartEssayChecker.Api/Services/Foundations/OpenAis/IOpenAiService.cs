//=================================
// Copyright (c) Tarteeb LLC
// Check your essays esily
//=================================

using System.Threading.Tasks;

namespace SmartEssayChecker.Api.Services.Foundations.OpenAis
{
    public interface IOpenAiService
    {
        ValueTask<string> AnalyzeEssayAsync(string essay);
    }
}