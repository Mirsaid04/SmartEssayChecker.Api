/*//=================================
// Copyright (c) Tarteeb LLC
// Check your essays easily
//=================================

using FluentAssertions;
using Moq;
using SmartEssayChecker.Api.Models.Essays;
using SmartEssayChecker.Api.Models.Feedbacks;
using SmartEssayChecker.Api.Services.Foundations.OpenAis.Exceptions;
using Xunit;

namespace SmartEssayChecker.Api.Tests.Unit.Foundations.OpenAis
{
    public partial class OpenAiServiceTests
    {
        [Fact]
        private async Task ShouldThrowValidationExceptionOnSendIfEssayChatCompletionIsNullASync()
        {
            //given
            Essay openAiException = null;


            var nullOpenAiException =
                new NullOpenAiException();

            var expectedEssayValidationException =
                new OpenAiValidationException(nullOpenAiException);


            //when

            ValueTask<Feedback> addEssayTask =
                this.openAiService.AnalyzeEssayAsync(openAiException);

            OpenAiValidationException actualOpenAiValidationException =
                await Assert.ThrowsAsync<OpenAiValidationException>(addEssayTask.AsTask);

            //then
            actualOpenAiValidationException.Should()
               .BeEquivalentTo(expectedEssayValidationException);

            this.loggingBrokerMock.Verify(broker =>
                broker.LogError(It.Is(SameExceptionAs(
                    expectedEssayValidationException))), Times.Once);

            this.openAiBrokerMock.VerifyNoOtherCalls();
            this.loggingBrokerMock.VerifyNoOtherCalls();
        }
    }
}
*/