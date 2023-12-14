//=================================
// Copyright (c) Tarteeb LLC
// Check your essays esily
//=================================

using FluentAssertions;
using Moq;
using SmartEssayChecker.Api.Services.Foundations.OpenAis.Exceptions;
using Standard.AI.OpenAI.Models.Services.Foundations.AIFiles.Exceptions;
using Standard.AI.OpenAI.Models.Services.Foundations.ChatCompletions;
using Xunit;

namespace SmartEssayChecker.Api.Tests.Unit.Foundations.OpenAis
{
    public partial class OpenAiServiceTests
    {
        [Fact]
        public async Task ShouldThrowSeviceExceptionOnOpenAiIfServiceExceptionOccuredAndLogItAsync()
        {
            //given
            string randomText = GetRandomString();
            Exception serviceException = new Exception();
            var failedAIFileServiceException =
                new FailedAIFileServiceException(serviceException);
            var expectedOpenAiServiceException =
                new OpenAiServiceException(failedAIFileServiceException);

            this.openAiBrokerMock.Setup(broker =>
                broker.AnalyzeEssayAsync(It.IsAny<ChatCompletion>()))
                .Throws(serviceException);

            //when
            ValueTask<string> addEssayTask = this.openAiService.AnalyzeEssayAsync(randomText);

            OpenAiServiceException actualOpenAiServiceException =
                await Assert.ThrowsAsync<OpenAiServiceException>(addEssayTask.AsTask);

            //then
            actualOpenAiServiceException.Should().BeEquivalentTo(expectedOpenAiServiceException);

            this.loggingBrokerMock.Verify(broker =>
                broker.LogError(It.Is(SameExceptionAs(expectedOpenAiServiceException))),
                Times.Once);

            this.openAiBrokerMock.Verify(broker =>
                broker.AnalyzeEssayAsync(It.IsAny<ChatCompletion>()),
                Times.Once);

            this.loggingBrokerMock.VerifyNoOtherCalls();
            this.openAiBrokerMock.VerifyNoOtherCalls();
        }
    }
}
