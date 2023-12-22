//=================================
// Copyright (c) Tarteeb LLC
// Check your essays easily
//=================================


using System;
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
            catch (EssayDependencyValidationException essayDependencyValidationException)
                  when (essayDependencyValidationException.InnerException is AlreadyExitsEssayException)
            {
                return Conflict(essayDependencyValidationException.InnerException);
            }
            catch (EssayDependencyValidationException essayDependencyValidationException)
            {
                return BadRequest(essayDependencyValidationException.InnerException);
            }
            catch (EssayDependencyException essayDependencyException)
            {
                return InternalServerError(essayDependencyException.InnerException);
            }
            catch (EssayServiceException essayServiceException)
            {
                return InternalServerError(essayServiceException.InnerException);
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
            catch (EssayDependencyException essayDependencyException)
            {
                return InternalServerError(essayDependencyException);
            }
            catch (EssayServiceException essayServiceException)
            {
                return InternalServerError(essayServiceException);
            }
        }

        [HttpGet("{essayId}")]

        public async ValueTask<ActionResult<Essay>> GetEssayById(Guid essayId)
        {
            try
            {
                return await this.essayService.RetrieveEssayByIdAsync(essayId);
            }
            catch (EssayDependencyException essayDependencyException)
            {
                return InternalServerError(essayDependencyException.InnerException);
            }
            catch (EssayValidationException essayValidationException)
                 when (essayValidationException.InnerException is NotFoundEssayException)
            {
                return NotFound(essayValidationException.InnerException);
            }
            catch (EssayServiceException essayServiceException)
            {
                return InternalServerError(essayServiceException.InnerException);
            }
        }

        [HttpDelete("{essayId}")]

        public async ValueTask<ActionResult<Essay>> DeleteEssayByIdAsync(Guid essayId)
        {
            try
            {
                Essay deletedEssay =
                    await this.essayService.RetrieveEssayByIdAsync(essayId);

                return Ok(deletedEssay);
            }
            catch (EssayValidationException essayValidationException)
                when (essayValidationException.InnerException is NotFoundEssayException)
            {
                return NotFound(essayValidationException.InnerException);
            }
            catch (EssayValidationException essayValidationException)
            {
                return BadRequest(essayValidationException.InnerException);
            }
            catch (EssayDependencyValidationException essayDependencyValidationException)
                when (essayDependencyValidationException.InnerException is LockedEssayException)
            {
                return Locked(essayDependencyValidationException.InnerException);
            }
            catch (EssayDependencyValidationException essayDependencyValidationException)
            {
                return BadRequest(essayDependencyValidationException.InnerException);
            }
            catch (EssayDependencyException essayDependencyException)
            {
                return InternalServerError(essayDependencyException.InnerException);
            }
            catch (EssayServiceException essayServiceException)
            {
                return InternalServerError(essayServiceException.InnerException);
            }
        }
    }
}
