//=================================
// Copyright (c) Tarteeb LLC
// Check your essays esily
//=================================

using System.Threading.Tasks;
using SmartEssayChecker.Api.Models.Users;
using SmartEssayChecker.Api.Models.Users.Exceptions;
using Xeptions;

namespace SmartEssayChecker.Api.Services.Foundations.Users
{
    public partial class UserService
    {
        private delegate ValueTask<User> ReturningUserFunction();

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
        }

        private UserValidationException CreateAndLogValidationException(Xeption xeption)
        {
            var userValidationException = new UserValidationException(xeption);
            this.loggingBroker.LogError(userValidationException);

            return userValidationException;
        }
    }
}
