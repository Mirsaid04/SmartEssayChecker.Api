//=================================
// Copyright (c) Tarteeb LLC
// Check your essays esily
//=================================

using System;
using System.Threading.Tasks;
using Azure.Core;
using Standard.AI.OpenAI.Models.Services.Foundations.ChatCompletions;

namespace SmartEssayChecker.Api.Brokers.OpenAis
{
    internal partial class OpenAiBroker
    {
        public async ValueTask<ChatCompletion> AnalyzeEssayAsync(ChatCompletion chatCompletion)
        {
            return await openAIClient.ChatCompletions.SendChatCompletionAsync(chatCompletion);
        }
    }
}
