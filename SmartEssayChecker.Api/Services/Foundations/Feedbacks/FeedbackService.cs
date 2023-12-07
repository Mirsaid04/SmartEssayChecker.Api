using System;
using System.Linq;
using System.Threading.Tasks;
using SmartEssayChecker.Api.Brokers.Loggings;
using SmartEssayChecker.Api.Brokers.Storages;
using SmartEssayChecker.Api.Models.Feedbacks;

namespace SmartEssayChecker.Api.Services.Foundations.Feedbacks
{
    public partial class FeedbackService : IFeedbackService
    {
        private readonly IStorageBroker storageBroker;
        private readonly ILoggingBroker loggingBroker;

        public FeedbackService(
            IStorageBroker storageBroker,
            ILoggingBroker loggingBroker)
        {
            this.storageBroker = storageBroker;
            this.loggingBroker = loggingBroker;
        }

        public ValueTask<Feedback> AddFeedbackAsync(Feedback feedback) =>
        TryCatch(async () =>
        {
            ValidationOnAdd(feedback);

            return await this.storageBroker.InsertFeedbackAsync(feedback);
        });

        public IQueryable<Feedback> RetrieveFeedbacksAsync() =>
            this.storageBroker.SelectAllFeedbacks();

        public ValueTask<Feedback> RetrieveFeedbackByIdAsync(Guid feedbackId) =>
        TryCatch(async () =>
        {
            ValidateFeedbackId(feedbackId);

            Feedback feedback = await this.storageBroker.SelectFeedbackByIdAsync(feedbackId);

            return feedback;
        });
        public ValueTask<Feedback> RemoveFeedbackAsync(Guid feedbackId) =>
        TryCatch(async () =>
        {
            ValidateFeedbackId(feedbackId);

            Feedback feedback = await this.storageBroker.SelectFeedbackByIdAsync(feedbackId);

            return await this.storageBroker.DeleteFeedbackAsync(feedback);
        });

    }
}
