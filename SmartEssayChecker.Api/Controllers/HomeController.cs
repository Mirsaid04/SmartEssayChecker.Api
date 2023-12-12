//=================================
// Copyright (c) Tarteeb LLC
// Check your essays esily
//=================================

using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using RESTFulSense.Controllers;
using SmartEssayChecker.Api.Brokers.OpenAis;
using Standard.AI.OpenAI.Models.Services.Foundations.ChatCompletions;

namespace SmartEssayChecker.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class HomeController : RESTFulController
    {
        private readonly IOpenAiBroker openAiBroker;

        public HomeController(IOpenAiBroker openAiBroker)
        {
            this.openAiBroker = openAiBroker;
        }

        [HttpGet]
        public ActionResult<string> Get() =>
            Ok("Hello Mario, the princess is in another castle.");

        [HttpPost]
        public async ValueTask<ActionResult<ChatCompletion>> Post(ChatCompletion chatCompletion)
        {
            return await this.openAiBroker.AnalyzeEssayAsync(chatCompletion);
        }
    }
}
