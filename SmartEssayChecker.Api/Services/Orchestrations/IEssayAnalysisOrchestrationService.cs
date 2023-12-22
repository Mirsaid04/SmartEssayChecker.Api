//=================================
// Copyright (c) Tarteeb LLC
// Check your essays esily
//=================================

using System.Threading.Tasks;
using SmartEssayChecker.Api.Models.EssayAnalayses;

namespace SmartEssayChecker.Api.Services.Orchestrations
{
    public interface IEssayAnalysisOrchestrationService
    {
        ValueTask<EssayAnalysis> AnalyzeEssay(EssayAnalysis essayAnalysis, string userName);
    }
}