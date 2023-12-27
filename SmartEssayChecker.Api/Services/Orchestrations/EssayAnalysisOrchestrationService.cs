//=================================
// Copyright (c) Tarteeb LLC
// Check your essays esily
//=================================

using System.Threading.Tasks;
using SmartEssayChecker.Api.Brokers.Loggings;
using SmartEssayChecker.Api.Models.EssayAnalayses;
using SmartEssayChecker.Api.Services.Foundations.Essays;
using SmartEssayChecker.Api.Services.Foundations.Feedbacks;
using SmartEssayChecker.Api.Services.Foundations.OpenAis;

namespace SmartEssayChecker.Api.Services.Orchestrations
{
    public class EssayAnalysisOrchestrationService : IEssayAnalysisOrchestrationService
    {
        private readonly IOpenAiService openAiService;
        private readonly IEssayService essayService;
        private readonly IFeedbackService feedbackService;
        private readonly ILoggingBroker loggingBroker;

        public EssayAnalysisOrchestrationService(
            IOpenAiService openAiService,
            IEssayService essayService,
            IFeedbackService feedbackService,
            ILoggingBroker loggingBroker)
        {
            this.openAiService = openAiService;
            this.essayService = essayService;
            this.feedbackService = feedbackService;
            this.loggingBroker = loggingBroker;
        }
        public async ValueTask<EssayAnalysis> AnalyzeEssay(EssayAnalysis essayAnalysis)
        {
            essayAnalysis.Feedback = await this.openAiService.AnalyzeEssayAsync(essayAnalysis.Essay);

            await this.essayService.AddEssayAsync(essayAnalysis.Essay);
            await this.feedbackService.AddFeedbackAsync(essayAnalysis.Feedback);

            return essayAnalysis;
        }
    }
}