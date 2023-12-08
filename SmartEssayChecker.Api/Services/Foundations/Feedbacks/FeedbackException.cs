//=================================
// Copyright (c) Tarteeb LLC
// Check your essays esily
//=================================

using System;
using System.Linq;
using System.Threading.Tasks;
using EFxceptions.Models.Exceptions;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using SmartEssayChecker.Api.Models.Feedbacks;
using SmartEssayChecker.Api.Models.Feedbacks.Exceptions;
using Xeptions;

namespace SmartEssayChecker.Api.Services.Foundations.Feedbacks
{
    public partial class FeedbackService
    {
        private delegate ValueTask<Feedback> ReturningFeedbackFunctions();
        private delegate IQueryable<Feedback> ReturningFeedbackFunction();

        private async ValueTask<Feedback> TryCatch(ReturningFeedbackFunctions returningFeedbackFunctions)
        {
            try
            {
                return await returningFeedbackFunctions();
            }
            catch (NullFeedbackException nullFeedbackException)
            {
                throw CreateAndLogValidationException(nullFeedbackException);
            }
            catch (InvalidFeedbackException invalidFeedbackException)
            {
                throw CreateAndLogValidationException(invalidFeedbackException);
            }
            catch (NotFoundFeedbackException notFoundFeedbackException)
            {
                throw CreateAndLogValidationException(notFoundFeedbackException);
            }
            catch (SqlException sqlException)
            {
                var failedFeedbackStorageException = new FailedFeedbackStorageException(sqlException);

                throw CreateAndLogCriticalDependencyException(failedFeedbackStorageException);
            }
            catch (DuplicateKeyException duplicateKeyException)
            {
                var alreadyExitsFeedbackException = new AlreadyExitsFeedbackException(duplicateKeyException);
                throw CreateAndLogDependencyValidationException(alreadyExitsFeedbackException);
            }
            catch (DbUpdateConcurrencyException dbUpdateConcurrencyException)
            {
                var lockedFeedbackException = new LockedFeedbackException(dbUpdateConcurrencyException);

                throw CreateAndLogDependencyValidationException(lockedFeedbackException);
            }
            catch (DbUpdateException dbUpdateException)
            {
                var failedFeedbackStorageException = new FailedFeedbackStorageException(dbUpdateException);

                throw CreateAndLogDependencyException(failedFeedbackStorageException);
            }
            catch (Exception exception)
            {
                var failedFeedbackServiceException = new FailedFeedbackServiceException(exception);

                throw CreateAndLogServiceException(failedFeedbackServiceException);
            }

        }

        private IQueryable<Feedback> TryCatch(ReturningFeedbackFunction returningFeedbackFunction)
        {
            try
            {
                return returningFeedbackFunction();
            }
            catch (SqlException sqlException)
            {
                var failedFeedbackStorageException = new FailedFeedbackStorageException(sqlException);

                throw CreateAndLogCriticalDependencyException(failedFeedbackStorageException);
            }
            catch (Exception serviceException)
            {
                var failedFeedbackServiceException = new FailedFeedbackServiceException(serviceException);

                throw CreateAndLogServiceException(failedFeedbackServiceException);
            }
        }

        private FeedbackDependencyException CreateAndLogCriticalDependencyException(Xeption exception)
        {
            var feedbackDependencyException = new FeedbackDependencyException(exception);
            this.loggingBroker.LogCritical(feedbackDependencyException);

            return feedbackDependencyException;
        }

        private FeedbackDependencyValidationException CreateAndLogDependencyValidationException(Xeption exception)
        {
            var feedbackDependencyValidationException = new FeedbackDependencyValidationException(exception);
            this.loggingBroker.LogError(feedbackDependencyValidationException);

            return feedbackDependencyValidationException;
        }

        private FeedbackServiceException CreateAndLogServiceException(Xeption xeption)
        {
            var feedbackServiceException = new FeedbackServiceException(xeption);
            this.loggingBroker.LogError(feedbackServiceException);

            return feedbackServiceException;
        }

        private FeedbackDependencyException CreateAndLogDependencyException(Xeption exception)
        {
            var feedbackDependencyException = new FeedbackDependencyException(exception);
            this.loggingBroker.LogError(feedbackDependencyException);

            return feedbackDependencyException;
        }
        private FeedbackValidationException CreateAndLogValidationException(Xeption xeption)
        {
            var feedbackValidationException = new FeedbackValidationException(xeption);
            this.loggingBroker.LogError(feedbackValidationException);

            return feedbackValidationException;
        }
    }
}
