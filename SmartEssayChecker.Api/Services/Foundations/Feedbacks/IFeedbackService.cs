using System;
using System.Linq;
using System.Threading.Tasks;
using SmartEssayChecker.Api.Models.Feedbacks;

namespace SmartEssayChecker.Api.Services.Foundations.Feedbacks
{
    public interface IFeedbackService
    {
        ///  /// <exception cref="Models.Feedbacks.Exceptions.FeedbackValidationException"></exception>
        /// <exception cref="Models.Feedbacks.Exceptions.FeedbackDependencyValidationException"></exception>
        /// <exception cref="Models.Feedbacks.Exceptions.FeedbackDependencyException"></exception>
        /// <exception cref="Models.Feedbacks.Exceptions.FeedbackServiceException"></exception>
        ValueTask<Feedback> AddFeedbackAsync(Feedback feedback);
        /// <exception cref="Models.Feedbacks.Exceptions.FeedbackDependencyException"></exception>
        /// <exception cref="Models.Feedbacks.Exceptions.FeedbackServiceException"></exception>  
        IQueryable<Feedback> RetrieveFeedbacksAsync();
        /// <exception cref="Models.Feedbacks.Exceptions.FeedbackDependencyException"></exception>
        /// <exception cref="Models.Feedbacks.Exceptions.FeedbackServiceException"></exception>
        ValueTask<Feedback> RetrieveFeedbackByIdAsync(Guid feedbackId);
        /// <exception cref="Models.Feedbacks.Exceptions.FeedbackDependencyValidationException"></exception>
        /// <exception cref="Models.Feedbacks.Exceptions.FeedbackDependencyException"></exception>
        /// <exception cref="Models.Feedbacks.Exceptions.FeedbackServiceException"></exception>
        ValueTask<Feedback> RemoveFeedbackAsync(Guid feedbackId);
        /// <exception cref="Models.Feedbacks.Exceptions.FeedbackValidationException"></exception>
        /// <exception cref="Models.Feedbacks.Exceptions.FeedbackDependencyValidationException"></exception>
        /// <exception cref="Models.Feedbacks.Exceptions.FeedbackDependencyException"></exception>
        /// <exception cref="Models.Feedbacks.Exceptions.FeedbackServiceException"></exception>
    }
}
