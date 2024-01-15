//=================================
// Copyright (c) Tarteeb LLC
// Check your essays esily
//=================================

using Microsoft.Extensions.Configuration;
using Standard.AI.OpenAI.Clients.OpenAIs;
using Standard.AI.OpenAI.Models.Configurations;

namespace SmartEssayChecker.Api.Brokers.OpenAis
{
    public partial class OpenAiBroker : IOpenAiBroker
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
            string apiKey = "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";

            var openAIConfiguration = new OpenAIConfigurations
            {
                ApiKey = apiKey,
            };
            return new OpenAIClient(openAIConfiguration);
        }
    }
}
