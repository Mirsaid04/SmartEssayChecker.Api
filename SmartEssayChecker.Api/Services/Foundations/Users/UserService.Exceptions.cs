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
using SmartEssayChecker.Api.Models.Users;
using SmartEssayChecker.Api.Models.Users.Exceptions;
using Xeptions;

namespace SmartEssayChecker.Api.Services.Foundations.Users
{
    public partial class UserService
    {
        private delegate ValueTask<User> ReturningUserFunction();
        private delegate IQueryable<User> ReturningUserFunctions();

        private async ValueTask<User> TryCatch(ReturningUserFunction returningUserFunction)
        {
            try
            {
                return await returningUserFunction();
            }

            catch (NullUserException nullUserException)
            {
                throw CreateAndLogValidationException(nullUserException);
            }
            catch (InvalidUserException invalidUserException)
            {
                throw CreateAndLogValidationException(invalidUserException);
            }
            catch (NotFoundUserException notFoundUserException)
            {
                throw CreateAndLogValidationException(notFoundUserException);
            }
            catch (SqlException sqlException)
            {
                var failedUserStorageException = new FailedUserStorageException(sqlException);
                throw CreateAndLogCriticalDependencyException(failedUserStorageException);
            }
            catch (DuplicateKeyException duplicateKeyException)
            {
                var alreadyExistsUserException =
                    new AlreadyExistsUserException(duplicateKeyException);

                throw CreateAndLogDependencyValidationException(alreadyExistsUserException);
            }
            catch (DbUpdateConcurrencyException dbUpdateConcurrencyException)
            {
                var lockedUserException = new LockedUserException(dbUpdateConcurrencyException);

                throw CreateAndDependencyValidationException(lockedUserException);
            }
            catch (DbUpdateException dbUpdateException)
            {
                var failedUserStorageException = new FailedUserStorageException(dbUpdateException);

                throw CreateAndDependencyValidationException(failedUserStorageException);
            }
            catch (Exception exception)
            {
                var failedStorageServiceException = new FailedUserStorageException(exception);

                throw CreateAndLogServiceException(failedStorageServiceException);
            }
        }

        private IQueryable<User> TryCatch(ReturningUserFunctions returningUserFunctions)
        {
            try
            {
                return returningUserFunctions();
            }
            catch (SqlException sqlException)
            {
                var failedUserStorageException = new FailedUserStorageException(sqlException);

                throw CreateAndLogCriticalDependencyException(failedUserStorageException);
            }
            catch (Exception serviceException)
            {
                var failedUserServiceException = new FailedUserServiceException(serviceException);

                throw CreateAndLogServiceException(failedUserServiceException);
            }
        }

        private UserDependencyValidationException CreateAndDependencyValidationException(Xeption exception)
        {
            var userDependencyValidationException = new UserDependencyValidationException(exception);
            this.loggingBroker.LogError(userDependencyValidationException);

            return userDependencyValidationException;
        }

        private UserDependencyException CreateAndLogCriticalDependencyException(Xeption xeption)
        {
            var userDependencyException = new UserDependencyException(xeption);
            this.loggingBroker.LogCritical(userDependencyException);

            return userDependencyException;
        }

        private UserDependencyValidationException CreateAndLogDependencyValidationException(Xeption exception)
        {
            var userDependencyValidationException = new UserDependencyValidationException(exception);
            this.loggingBroker.LogError(userDependencyValidationException);

            return userDependencyValidationException;
        }

        private UserServiceException CreateAndLogServiceException(Xeption exception)
        {
            var userServiceException = new UserServiceException(exception);
            this.loggingBroker.LogError(userServiceException);

            return userServiceException;
        }

        private UserDependencyException CreateAndLogDependencyException(Xeption exception)
        {
            var userDependencyException = new UserDependencyException(exception);
            this.loggingBroker.LogError(userDependencyException);

            return userDependencyException;
        }

        private UserValidationException CreateAndLogValidationException(Xeption xeption)
        {
            var userValidationException = new UserValidationException(xeption);
            this.loggingBroker.LogError(userValidationException);

            return userValidationException;
        }
    }
}
