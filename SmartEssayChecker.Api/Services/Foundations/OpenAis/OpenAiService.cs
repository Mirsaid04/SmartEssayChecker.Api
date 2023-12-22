﻿//=================================
// Copyright (c) Tarteeb LLC
// Check your essays easily
//=================================

using System.Linq;
using System.Threading.Tasks;
using SmartEssayChecker.Api.Brokers.Loggings;
using SmartEssayChecker.Api.Brokers.OpenAis;
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

        public ValueTask<string> AnalyzeEssayAsync(string essay) =>
            TryCatch(async () =>
        {
            ValidateOpenAiOnAdd(essay);

            ChatCompletion request = CreateRequest(essay);
            ChatCompletion response =
            await this.openAiBroker.AnalyzeEssayAsync(request);

            return response.Response.Choices.FirstOrDefault().Message.Content;
        });

        public static ChatCompletion CreateRequest(string essay)
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
                            Content = "You are IELTS Writing examiner. Give detailed IELTS feedback based on marking criteria of IELTS",
                            Role = "system",
                        },
                        new ChatCompletionMessage
                        {
                            Content = essay,
                            Role = "user",
                        }
                    },

                }
            };
        }

    }
}
