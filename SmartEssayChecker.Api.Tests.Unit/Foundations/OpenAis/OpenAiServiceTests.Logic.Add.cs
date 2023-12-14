//=================================
// Copyright (c) Tarteeb LLC
// Check your essays esily
//=================================

using FluentAssertions;
using Moq;
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
            string inputEssay = randomText;
            string anotherRandomText = GetRandomString();
            string expectedAnalysis = anotherRandomText;
            ChatCompletion analyzedChatCompletion = CreateOutputChatCompletion(expectedAnalysis);

            this.openAiBrokerMock.Setup(broker =>
                broker.AnalyzeEssayAsync(It.IsAny<ChatCompletion>()))
                .ReturnsAsync(analyzedChatCompletion);

            //when
            string actualAnalysis = await this.openAiService.AnalyzeEssayAsync(inputEssay);


            //then
            actualAnalysis.Should().BeEquivalentTo(expectedAnalysis);

            this.openAiBrokerMock.Verify(broker =>
                broker.AnalyzeEssayAsync(It.IsAny<ChatCompletion>()),
                Times.Once());

            this.openAiBrokerMock.VerifyNoOtherCalls();
            this.loggingBrokerMock.VerifyNoOtherCalls();
        }
    }
}
