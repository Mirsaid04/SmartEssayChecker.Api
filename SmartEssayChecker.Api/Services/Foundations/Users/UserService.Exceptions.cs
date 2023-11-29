//=================================
// Copyright (c) Tarteeb LLC
// Check your essays esily
//=================================

using System.Net.Sockets;
using System.Threading.Tasks;
using SmartEssayChecker.Api.Models.Users;
using SmartEssayChecker.Api.Services.Foundations.Users.Exceptions;

namespace SmartEssayChecker.Api.Services.Foundations.Users
{
    internal partial class UserService
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
                UserValidationException userValidationException =
                    new UserValidationException(nullUserException);

                this.loggingBroker.LogError(userValidationException);

                throw userValidationException;
            }
        }

    }
}
