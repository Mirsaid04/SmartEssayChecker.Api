//=================================
// Copyright (c) Tarteeb LLC
// Check your essays esily
//=================================

using System.Linq.Expressions;
using Moq;
using SmartEssayChecker.Api.Brokers.Loggings;
using SmartEssayChecker.Api.Brokers.OpenAis;
using SmartEssayChecker.Api.Services.Foundations.OpenAis;
using Standard.AI.OpenAI.Models.Services.Foundations.ChatCompletions;
using Tynamix.ObjectFiller;
using Xeptions;

namespace SmartEssayChecker.Api.Tests.Unit.Foundations.OpenAis
{
    public partial class OpenAiServiceTests
    {
        private readonly Mock<IOpenAiBroker> openAiBrokerMock;
        private readonly Mock<ILoggingBroker> loggingBrokerMock;
        private readonly IOpenAiService openAiService;

        public OpenAiServiceTests()
        {
            this.openAiBrokerMock = new Mock<IOpenAiBroker>();
            this.loggingBrokerMock = new Mock<ILoggingBroker>();

            this.openAiService =
                new OpenAiService(
                openAiBroker: this.openAiBrokerMock.Object,
                loggingBroker: this.loggingBrokerMock.Object);
        }
        private static string GetRandomString() =>
           new MnemonicString().GetValue();

        private static int GetRandomNumber() =>
            new IntRange(min: 2, max: 9).GetValue();

        private static Expression<Func<Xeption, bool>> SameExceptionAs(Xeption expectedException) =>
            actualException => actualException.SameExceptionAs(expectedException);

        private static ChatCompletion CreateOutputChatCompletion(string essay) =>
            ChatCompletionFiller(essay).Create();

        private static DateTimeOffset GetRandomDate() =>
          new DateTimeRange(earliestDate: new DateTime()).GetValue();

        private static Filler<ChatCompletion> ChatCompletionFiller(string essay)
        {
            var filler = new Filler<ChatCompletion>();

            filler.Setup().OnProperty(chatCompletion => chatCompletion.Response.Choices.FirstOrDefault().Message.Content)
                .Use(essay);

            filler.Setup().OnType<DateTimeOffset>().Use(GetRandomDate);

            return filler;
        }

    }
}
