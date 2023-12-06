//=================================
// Copyright (c) Tarteeb LLC
// Check your essays esily
//=================================

using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using RESTFulSense.Controllers;
using SmartEssayChecker.Api.Models.Feedbacks;
using SmartEssayChecker.Api.Models.Feedbacks.Exceptions;
using SmartEssayChecker.Api.Services.Foundations.Feedbacks;

namespace SmartEssayChecker.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]

    public class FeedbackController : RESTFulController
    {
        private readonly IFeedbackService feedbackService;

        public FeedbackController(IFeedbackService feedbackService) =>
            this.feedbackService = feedbackService;

        [HttpPost]

        public async ValueTask<ActionResult<Feedback>> Post(Feedback feedback)
        {
            try
            {
                Feedback persistedFeedback = await this.feedbackService.AddFeedbackAsync(feedback);

                return Created(persistedFeedback);
            }
            catch (FeedbackValidationException feedbackValidationException)
            {
                return BadRequest(feedbackValidationException.InnerException);
            }
        }
    }
}
