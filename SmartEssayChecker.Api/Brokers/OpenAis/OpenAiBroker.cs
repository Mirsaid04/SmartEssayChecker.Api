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
