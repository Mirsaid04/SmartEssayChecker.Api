using System;
using System.Threading.Tasks;
using SmartEssayChecker.Api.Services.Foundations.OpenAis.Exceptions;

namespace SmartEssayChecker.Api.Services.Foundations.OpenAis
{
    public partial class OpenAiService
    {
        private delegate ValueTask<string> ReturnOpenAiAsync();

        private async ValueTask<string> TryCatch(ReturnOpenAiAsync returnOpenAiAsync)
        {
            try
            {
                return await returnOpenAiAsync();
            }
            catch (NullOpenAiException nullOpenAiException)
            {
                throw CreateAndLogValidationException(nullOpenAiException);
            }
        }
        private OpenAiValidationException CreateAndLogValidationException(Exception exceptionn)
        {
            var openAiValidationException =
                new OpenAiValidationException(exceptionn);

            this.loggingBroker.LogError(openAiValidationException);
            return openAiValidationException;
        }
    }
}
