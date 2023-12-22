//=================================
// Copyright (c) Tarteeb LLC
// Check your essays easily
//=================================

using System.Threading.Tasks;
using Standard.AI.OpenAI.Models.Services.Foundations.ChatCompletions;

namespace SmartEssayChecker.Api.Brokers.OpenAis
{
    public partial interface IOpenAiBroker
    {
        ValueTask<ChatCompletion> AnalyzeEssayAsync(ChatCompletion chatCompletion);
    }
}
