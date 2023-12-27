//=================================
// Copyright (c) Tarteeb LLC
// Check your essays easily
//=================================

using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using RESTFulSense.Controllers;
using SmartEssayChecker.Api.Models.EssayAnalayses;
using SmartEssayChecker.Api.Services.Orchestrations;

namespace SmartEssayChecker.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class HomeController : RESTFulController
    {
        private readonly IEssayAnalysisOrchestrationService orchestrationService;

        public HomeController(IEssayAnalysisOrchestrationService orchestrationService)
        {
            this.orchestrationService = orchestrationService;
        }

        [HttpGet]
        public ActionResult<string> Get() =>
            Ok("Hello Mario, the princess is in another castle.");

        [HttpPost]
        [Consumes("text/plain")]
        public async Task<ActionResult<EssayAnalysis>> Post([FromBody] string essay)
        {
            var essayAnalyse = new EssayAnalysis();
            essayAnalyse.Essay.Content = essay;

            await orchestrationService.AnalyzeEssay(essayAnalyse);

            return Ok(essayAnalyse);
        }
    }
}
