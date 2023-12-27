//=================================
// Copyright (c) Tarteeb LLC
// Check your essays easily
//=================================

using FluentAssertions;
using Moq;
using SmartEssayChecker.Api.Models.Essays;
using SmartEssayChecker.Api.Models.Feedbacks;
using Standard.AI.OpenAI.Models.Services.Foundations.ChatCompletions;
using Xunit;

namespace SmartEssayChecker.Api.Tests.Unit.Foundations.OpenAis
{
    public partial class OpenAiServiceTests
    {
        [Fact]
        public async Task ShouldAnalyzeEssayAsync()
        {
            //given
            string randomText = GetRandomString();
            var inputEssay = new Essay
            {
                EssayId = Guid.NewGuid(),
                Content = randomText,
                UserId = Guid.NewGuid(),
            };
            string anotherRandomText = GetRandomString();
            string expectedAnalysis = anotherRandomText;
            ChatCompletion analyzedChatCompletion = CreateOutputChatCompletion(expectedAnalysis);

            this.openAiBrokerMock.Setup(broker =>
                broker.AnalyzeEssayAsync(It.IsAny<ChatCompletion>()))
                .ReturnsAsync(analyzedChatCompletion);

            //when
            Feedback actualAnalysis = await this.openAiService.AnalyzeEssayAsync(inputEssay);

            //then
            actualAnalysis.Comment.Should().BeEquivalentTo(expectedAnalysis);

            this.openAiBrokerMock.Verify(broker =>
                broker.AnalyzeEssayAsync(It.IsAny<ChatCompletion>()),
                Times.Once());

            this.openAiBrokerMock.VerifyNoOtherCalls();
            this.loggingBrokerMock.VerifyNoOtherCalls();
        }
    }
}
