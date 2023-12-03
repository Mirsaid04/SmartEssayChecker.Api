//=================================
// Copyright (c) Tarteeb LLC
// Check your essays esily
//=================================

using System.Threading.Tasks;
using SmartEssayChecker.Api.Models.Essays;
using SmartEssayChecker.Api.Models.Essays.Exceptions;
using Xeptions;

namespace SmartEssayChecker.Api.Services.Foundations.Essays
{
    public partial class EssayService
    {
        private delegate ValueTask<Essay> ReturningEssayFunction();
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
        }

        private EssayValidationException CreateAndLogValidationException(Xeption xeption)
        {
            var essayValidationException = new EssayValidationException(xeption);
            this.loggingBroker.LogError(essayValidationException);

            return essayValidationException;
        }

    }
}
