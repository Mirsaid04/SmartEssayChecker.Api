//=================================
// Copyright (c) Tarteeb LLC
// Check your essays easily
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
            if (string.IsNullOrWhiteSpace(essay))
            {
                throw new NullOpenAiException();
            }
        }
    }
}
