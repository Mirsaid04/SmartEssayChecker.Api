//=================================
// Copyright (c) Tarteeb LLC
// Check your essays esily
//=================================

using System;
using Microsoft.Extensions.Configuration;
using Standard.AI.OpenAI.Clients.OpenAIs;
using Standard.AI.OpenAI.Models.Configurations;

namespace SmartEssayChecker.Api.Brokers.OpenAis
{
    internal partial class OpenAiBroker : IOpenAiBroker
    {
        private readonly OpenAIClient openAIClient;
        private readonly IConfiguration configuration;

        public OpenAiBroker(
            IConfiguration configuration)
        {
            this.configuration = configuration;
            this.openAIClient = ConfigureOpenAIClient();
        }
        private OpenAIClient ConfigureOpenAIClient()
        {
            string apiKey = this.configuration.GetValue<String>(key: "OpenAiKey");
            var openAIConfiguration = new OpenAIConfigurations
            {
                ApiKey = apiKey,
            };

            return new OpenAIClient(openAIConfiguration);
        }
    }
}
