//=================================
// Copyright (c) Tarteeb LLC
// Check your essays esily
//=================================

using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using RESTFulSense.Controllers;
using SmartEssayChecker.Api.Models.Essays;
using SmartEssayChecker.Api.Models.Essays.Exceptions;
using SmartEssayChecker.Api.Services.Foundations.Essays;

namespace SmartEssayChecker.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class EssayController : RESTFulController
    {
        private readonly IEssayService essayService;

        public EssayController(IEssayService essayService) =>
            this.essayService = essayService;

        [HttpPost]

        public async ValueTask<ActionResult<Essay>> Post(Essay essay)
        {
            try
            {
                Essay persistedEssay = await this.essayService.AddEssayAsync(essay);

                return Created(persistedEssay);
            }
            catch (EssayValidationException essayValidationException)
            {
                return BadRequest(essayValidationException.InnerException);
            }
        }

        [HttpGet]

        public ActionResult<IQueryable<Essay>> GetAllEssays()
        {
            try
            {
                IQueryable<Essay> allEssays = this.essayService.RetrieveAllEssays(); 

                return Ok(allEssays);
            }
        }
    }
}
