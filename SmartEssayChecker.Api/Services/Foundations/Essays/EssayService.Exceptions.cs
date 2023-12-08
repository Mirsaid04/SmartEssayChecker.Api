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
using SmartEssayChecker.Api.Models.Essays;
using SmartEssayChecker.Api.Models.Essays.Exceptions;
using Xeptions;

namespace SmartEssayChecker.Api.Services.Foundations.Essays
{
    public partial class EssayService
    {
        private delegate ValueTask<Essay> ReturningEssayFunction();
        private delegate IQueryable<Essay> ReturningEssayFunctions();
        private async ValueTask<Essay> TryCatch(ReturningEssayFunction returningEssayFunction)
        {
            try
            {
                return await returningEssayFunction();
            }

            catch (NullEssayException nullEssayException)
            {
                throw CreateAndLogValidationException(nullEssayException);
            }
            catch (InvalidEssayException invalidEssayException)
            {
                throw CreateAndLogValidationException(invalidEssayException);
            }
            catch (NotFoundEssayException notFoundEssayException)
            {
                throw CreateAndLogValidationException(notFoundEssayException);
            }
            catch (SqlException sqlException)
            {
                var failedEssayStorageException = new FailedEssayStorageException(sqlException);

                throw CreateAndLogCriticalDependencyException(failedEssayStorageException);
            }
            catch (DuplicateKeyException duplicateKeyException)
            {
                var alreadyExistsEssayException = new AlreadyExitsEssayException(duplicateKeyException);

                throw CreateAndLogDependencyValidationException(alreadyExistsEssayException);
            }
            catch (DbUpdateConcurrencyException dbUpdateConcurrencyException)
            {
                var lockedEssayException = new LockedEssayException(dbUpdateConcurrencyException);

                throw CreateAndLogDependencyValidationException(lockedEssayException);
            }
            catch (DbUpdateException dbUpdateException)
            {
                var failedEssayStorageException = new FailedEssayStorageException(dbUpdateException);

                throw CreateAndLogDependencyException(failedEssayStorageException);
            }
            catch (Exception exception)
            {
                var failedEssayServiceException = new FailedEssayServiceException(exception);

                throw CreateAndLogServiceException(failedEssayServiceException);
            }

        }

        private IQueryable<Essay> TryCatch(ReturningEssayFunctions returningEssayFunctions)
        {
            try
            {
                return returningEssayFunctions();
            }
            catch (SqlException sqlException)
            {
                var failedEssayStorageException = new FailedEssayStorageException(sqlException);

                throw CreateAndLogCriticalDependencyException(failedEssayStorageException);
            }
            catch (Exception serviceException)
            {
                var failedEssayServiceException = new FailedEssayServiceException(serviceException);

                throw CreateAndLogServiceException(failedEssayServiceException);
            }
        }

        private EssayDependencyException CreateAndLogCriticalDependencyException(Xeption exception)
        {
            var essayDependencyException = new EssayDependencyException(exception);
            this.loggingBroker.LogCritical(essayDependencyException);

            return essayDependencyException;
        }

        private EssayDependencyValidationException CreateAndLogDependencyValidationException(Xeption exception)
        {
            var essayDependencyValidationException = new EssayDependencyValidationException(exception);
            this.loggingBroker.LogError(essayDependencyValidationException);

            return essayDependencyValidationException;
        }

        private EssayServiceException CreateAndLogServiceException(Xeption xeption)
        {
            var essayServiceException = new EssayServiceException(xeption);
            this.loggingBroker.LogError(essayServiceException);

            return essayServiceException;
        }

        private EssayDependencyException CreateAndLogDependencyException(Xeption exception)
        {
            var essayDependencyException = new EssayDependencyException(exception);
            this.loggingBroker.LogError(essayDependencyException);

            return essayDependencyException;
        }
        private EssayValidationException CreateAndLogValidationException(Xeption xeption)
        {
            var essayValidationException = new EssayValidationException(xeption);
            this.loggingBroker.LogError(essayValidationException);

            return essayValidationException;
        }

    }
}
