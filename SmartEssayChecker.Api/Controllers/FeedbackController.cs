//=================================
// Copyright (c) Tarteeb LLC
// Check your essays esily
//=================================

using System;
using System.Linq;
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
            catch (FeedbackDependencyValidationException feedbackDependencyValidationException)
                  when (feedbackDependencyValidationException.InnerException is AlreadyExitsFeedbackException)
            {
                return Conflict(feedbackDependencyValidationException.InnerException);
            }
            catch (FeedbackDependencyValidationException feedbackDependencyValidationException)
            {
                return BadRequest(feedbackDependencyValidationException.InnerException);
            }
            catch (FeedbackDependencyException feedbackDependencyException)
            {
                return InternalServerError(feedbackDependencyException.InnerException);
            }
            catch (FeedbackServiceException feedbackServiceException)
            {
                return InternalServerError(feedbackServiceException.InnerException);
            }
        }

        [HttpGet]

        public ActionResult<IQueryable<Feedback>> GetAllEssays()
        {
            try
            {
                IQueryable<Feedback> allFeedbacks = this.feedbackService.RetrieveFeedbacksAsync();

                return Ok(allFeedbacks);
            }
            catch (FeedbackDependencyException feedbackDependencyException)
            {
                return InternalServerError(feedbackDependencyException);
            }
            catch (FeedbackServiceException feedbackServiceException)
            {
                return InternalServerError(feedbackServiceException);
            }
        }

        [HttpGet("{feedbackId}")]

        public async ValueTask<ActionResult<Feedback>> GetFeedBackById(Guid feedbackId)
        {
            try
            {
                return await this.feedbackService.RetrieveFeedbackByIdAsync(feedbackId);
            }
            catch (FeedbackDependencyException feedbackDependencyException)
            {
                return InternalServerError(feedbackDependencyException.InnerException);
            }
            catch (FeedbackValidationException feedbackValidationException)
                 when (feedbackValidationException.InnerException is NotFoundFeedbackException)
            {
                return NotFound(feedbackValidationException.InnerException);
            }
            catch (FeedbackServiceException feedbackServiceException)
            {
                return InternalServerError(feedbackServiceException.InnerException);
            }
        }

        [HttpDelete("{feedbackId}")]

        public async ValueTask<ActionResult<Feedback>> DeleteFeedbackByIdAsync(Guid feedbackId)
        {
            try
            {
                Feedback deletedFeedback =
                    await this.feedbackService.RetrieveFeedbackByIdAsync(feedbackId);
                return Ok(deletedFeedback);
            }
            catch (FeedbackValidationException feedbackValidationException)
                when (feedbackValidationException.InnerException is NotFoundFeedbackException)
            {
                return NotFound(feedbackValidationException.InnerException);
            }
            catch (FeedbackValidationException feedbackValidationException)
            {
                return BadRequest(feedbackValidationException.InnerException);
            }
            catch (FeedbackDependencyValidationException feedbackDependencyValidationException)
                when (feedbackDependencyValidationException.InnerException is LockedFeedbackException)
            {
                return Locked(feedbackDependencyValidationException.InnerException);
            }
            catch (FeedbackDependencyValidationException feedbackDependencyValidationException)
            {
                return BadRequest(feedbackDependencyValidationException.InnerException);
            }
            catch (FeedbackDependencyException feedbackDependencyException)
            {
                return InternalServerError(feedbackDependencyException.InnerException);
            }
            catch (FeedbackServiceException feedbackServiceException)
            {
                return InternalServerError(feedbackServiceException.InnerException);
            }
        }
    }
}
