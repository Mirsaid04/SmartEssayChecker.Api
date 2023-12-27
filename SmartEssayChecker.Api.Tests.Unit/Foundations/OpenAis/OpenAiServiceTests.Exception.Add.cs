//=================================
// Copyright (c) Tarteeb LLC
// Check your essays easily
//=================================

using FluentAssertions;
using Moq;
using SmartEssayChecker.Api.Models.Essays;
using SmartEssayChecker.Api.Models.Feedbacks;
using SmartEssayChecker.Api.Services.Foundations.OpenAis.Exceptions;
using Standard.AI.OpenAI.Models.Services.Foundations.AIFiles.Exceptions;
using Standard.AI.OpenAI.Models.Services.Foundations.ChatCompletions;
using Xunit;

namespace SmartEssayChecker.Api.Tests.Unit.Foundations.OpenAis
{
    public partial class OpenAiServiceTests
    {
        [Fact]
        public async Task ShouldThrowServiceExceptionOnOpenAiIfServiceExceptionOccurredAndLogItAsync()
        {
            //given

            string randomText = GetRandomString();
            var essay = new Essay
            {
                EssayId = Guid.NewGuid(),
                Content = randomText,
                UserId = Guid.NewGuid(),
            };
            Exception serviceException = new Exception();
            var failedAIFileServiceException =
                new FailedAIFileServiceException(serviceException);
            var expectedOpenAiServiceException =
                new OpenAiServiceException(failedAIFileServiceException);

            this.openAiBrokerMock.Setup(broker =>
                broker.AnalyzeEssayAsync(It.IsAny<ChatCompletion>()))
                .Throws(expectedOpenAiServiceException);

            //when
            ValueTask<Feedback> addEssayTask = this.openAiService.AnalyzeEssayAsync(essay);

            var actualOpenAiServiceException =
                await Assert.ThrowsAsync<OpenAiServiceException>(addEssayTask.AsTask);

            //then
            actualOpenAiServiceException.Should().BeEquivalentTo(expectedOpenAiServiceException);

            this.loggingBrokerMock.Verify(broker =>
                broker.LogError(It.Is(SameExceptionAs(expectedOpenAiServiceException))),
                Times.Never);

            this.openAiBrokerMock.Verify(broker =>
                broker.AnalyzeEssayAsync(It.IsAny<ChatCompletion>()),
                Times.Once);

            this.loggingBrokerMock.VerifyNoOtherCalls();
            this.openAiBrokerMock.VerifyNoOtherCalls();
        }
    }
}
