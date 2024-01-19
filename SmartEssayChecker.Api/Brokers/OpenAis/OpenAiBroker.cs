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
            try
            {
            string apiKey = configuration["AppSettings:ApiKey"];
            Console.WriteLine($"API Key retrieved: {apiKey}");

                var openAIConfiguration = new OpenAIConfigurations
            {
                ApiKey = apiKey,
            };
            return new OpenAIClient(openAIConfiguration);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error configuring OpenAIClient: {ex.Message}");
                throw; // Rethrow the exception to indicate a configuration error
            }
        }
    }
}
