//=================================
// Copyright (c) Tarteeb LLC
// Check your essays esily
//=================================

using SmartEssayChecker.Api.Services.Foundations.OpenAis.Exceptions;

namespace SmartEssayChecker.Api.Services.Foundations.OpenAis
{
    public partial class OpenAiService
    {
        private static void ValidateOpenAiOnAdd(string essay)
        {
            ValidateOpanAiIsNotNull(essay);
        }
        private static void ValidateOpanAiIsNotNull(string essay)
        {
            if (essay == null)
            {
                throw new NullOpenAiException();
            }
        }
    }
}
