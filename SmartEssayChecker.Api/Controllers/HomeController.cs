//=================================
// Copyright (c) Tarteeb LLC
// Check your essays easily
//=================================

using System;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using RESTFulSense.Controllers;
using SmartEssayChecker.Api.Brokers.OpenAis;
using SmartEssayChecker.Api.Models.EssayAnalayses;
using SmartEssayChecker.Api.Models.Essays;
using SmartEssayChecker.Api.Models.Users.Exceptions;
using SmartEssayChecker.Api.Services.Foundations.Essays;
using SmartEssayChecker.Api.Services.Foundations.Users;
using SmartEssayChecker.Api.Services.Orchestrations;

namespace SmartEssayChecker.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class HomeController : RESTFulController
    {
        private readonly IEssayAnalysisOrchestrationService orchestrationService;
        private readonly IEssayService essayService;
        private readonly IOpenAiBroker broker;
        private readonly IUserService userService;

        public HomeController(IEssayAnalysisOrchestrationService orchestrationService,
            IEssayService essayService,
            IOpenAiBroker broker,
            IUserService userService)
        {
            this.orchestrationService = orchestrationService;
            this.essayService = essayService;
            this.broker = broker;
            this.userService = userService;
        }

        [HttpGet]
        public ActionResult<string> Get() =>
            Ok("Hello Mario, the princess is in another castle.");

        [HttpPost]

        public async Task<ActionResult<EssayAnalysis>> Post(string userName, string essay)
        {
            var user = this.userService.RetrieveUsers().FirstOrDefault(user => user.Name == userName);

            if (user == null)
            {
                throw new NotFoundUserByNameException(userName);
            }
            var essayAnalysis = await this.orchestrationService.AnalyzeEssay(new EssayAnalysis
            {
                Essay = new Essay
                {
                    Content = essay,
                    EssayId = Guid.NewGuid(),
                    UserId = user.Id
                },
            }, userName);

            return Ok(essayAnalysis);
        }
    }
}
