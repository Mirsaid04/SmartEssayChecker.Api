//=================================
// Copyright (c) Tarteeb LLC
// Check your essays easily
//=================================

using System;
using System.Linq;
using System.Threading.Tasks;
using SmartEssayChecker.Api.Brokers.Loggings;
using SmartEssayChecker.Api.Brokers.OpenAis;
using SmartEssayChecker.Api.Models.Essays;
using SmartEssayChecker.Api.Models.Feedbacks;
using Standard.AI.OpenAI.Models.Services.Foundations.ChatCompletions;

namespace SmartEssayChecker.Api.Services.Foundations.OpenAis
{
    public partial class OpenAiService : IOpenAiService
    {
        private readonly IOpenAiBroker openAiBroker;
        private readonly ILoggingBroker loggingBroker;

        public OpenAiService(
            IOpenAiBroker openAiBroker,
            ILoggingBroker loggingBroker)
        {
            this.openAiBroker = openAiBroker;
            this.loggingBroker = loggingBroker;
        }

        public ValueTask<Feedback> AnalyzeEssayAsync(Essay essay) =>
            TryCatch(async () =>
        {
            ValidateOpenAiOnAdd(essay);

            ChatCompletion request = CreateRequest(essay);
            ChatCompletion response =
                await this.openAiBroker.AnalyzeEssayAsync(request);

            string? comment = response.Response.Choices
            .FirstOrDefault()
            ?.Message.Content;

            Feedback feedback = new Feedback()
            {
                Id = Guid.NewGuid(),
                EssayId = essay.EssayId,
                Essay = essay,
                Comment = comment
            };

            return feedback;

        });

        public static ChatCompletion CreateRequest(Essay essay)
        {
            return new ChatCompletion
            {
                Request = new ChatCompletionRequest
                {
                    Model = "gpt-4-1106-preview",
                    MaxTokens = 1500,
                    Messages = new ChatCompletionMessage[]
                    {
                        new ChatCompletionMessage
                        {
                            Content = "You are an IELTS Writing examiner. Give detailed an IELTS feedback based on " +
                                  "marking criteria of IELTS and give potential band score for each criteria" +
                                  "and give the overall band score in new line",
                            Role = "system",
                        },
                        new ChatCompletionMessage
                        {
                            Content = essay.Content,
                            Role = "user",
                        }
                    },
                }
            };
        }
    }
}
