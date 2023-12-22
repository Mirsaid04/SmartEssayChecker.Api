//=================================
// Copyright (c) Tarteeb LLC
// Check your essays esily
//=================================

using System;
using System.Linq;
using System.Threading.Tasks;
using SmartEssayChecker.Api.Models.EssayAnalayses;
using SmartEssayChecker.Api.Models.Feedbacks;
using SmartEssayChecker.Api.Models.Users.Exceptions;
using SmartEssayChecker.Api.Services.Foundations.Essays;
using SmartEssayChecker.Api.Services.Foundations.Feedbacks;
using SmartEssayChecker.Api.Services.Foundations.OpenAis;
using SmartEssayChecker.Api.Services.Foundations.Users;

namespace SmartEssayChecker.Api.Services.Orchestrations
{
    public class EssayAnalysisOrchestrationService : IEssayAnalysisOrchestrationService
    {
        private readonly IOpenAiService openAiService;
        private readonly IEssayService essayService;
        private readonly IFeedbackService feedbackService;
        private readonly IUserService userService;

        public EssayAnalysisOrchestrationService(
            IOpenAiService openAiService,
            IEssayService essayService,
            IFeedbackService feedbackService,
            IUserService userService)
        {
            this.openAiService = openAiService;
            this.essayService = essayService;
            this.feedbackService = feedbackService;
            this.userService = userService;
        }
        public async ValueTask<EssayAnalysis> AnalyzeEssay(EssayAnalysis essayAnalysis, string userName)
        {
            var user = this.userService.RetrieveUsers().FirstOrDefault(user => user.Name == userName);

            if (user == null)
            {
                throw new NotFoundUserByNameException(userName);
            }
            string comment = await this.openAiService.AnalyzeEssayAsync(essayAnalysis.Essay.Content);

            var feedback = new Feedback
            {
                Id = Guid.NewGuid(),
                Comment = comment,
                Mark = 4.5f,
                EssayId = essayAnalysis.Essay.EssayId,
            };

            essayAnalysis.Feedback = feedback;
            essayAnalysis.Essay.UserId = user.Id;

            await this.essayService.AddEssayAsync(essayAnalysis.Essay);
            await this.feedbackService.AddFeedbackAsync(essayAnalysis.Feedback);

            return essayAnalysis;
        }
    }
}