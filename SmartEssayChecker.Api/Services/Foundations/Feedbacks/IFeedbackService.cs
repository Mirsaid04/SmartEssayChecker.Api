﻿using System;
using System.Linq;
using System.Threading.Tasks;
using SmartEssayChecker.Api.Models.Feedbacks;

namespace SmartEssayChecker.Api.Services.Foundations.Feedbacks
{
    public interface IFeedbackService
    {
        /// <summary>
        /// Save into database
        /// </summary>
        /// <param name="feedback"></param>
        /// <returns></returns>
        /// <exception cref="Models.Feedbacks.Exceptions.FeedbackValidationException"></exception> 
        ValueTask<Feedback> AddFeedbackAsync(Feedback feedback);
        IQueryable<Feedback> RetrieveFeedbacksAsync();
        ValueTask<Feedback> RetrieveFeedbackByIdAsync(Guid feedbackId);
        ValueTask<Feedback> RemoveFeedbackAsync(Guid feedbackId);
    }
}
