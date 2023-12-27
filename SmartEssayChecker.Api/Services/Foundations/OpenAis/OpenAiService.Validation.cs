//=================================
// Copyright (c) Tarteeb LLC
// Check your essays easily
//=================================

using SmartEssayChecker.Api.Models.Essays;
using SmartEssayChecker.Api.Services.Foundations.OpenAis.Exceptions;

namespace SmartEssayChecker.Api.Services.Foundations.OpenAis
{
    public partial class OpenAiService
    {
        private static void ValidateOpenAiOnAdd(Essay essay)
        {
            ValidateOpanAiIsNotNull(essay);
        }
        private static void ValidateOpanAiIsNotNull(Essay essay)
        {
            if (essay == null || string.IsNullOrWhiteSpace(essay.Content))
            {
                throw new NullOpenAiException();
            }
        }
    }
}
