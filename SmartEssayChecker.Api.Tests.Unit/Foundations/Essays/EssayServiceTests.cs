//=================================
// Copyright (c) Tarteeb LLC
// Check your essays esily
//=================================

using System.Linq.Expressions;
using Moq;
using SmartEssayChecker.Api.Brokers.Loggings;
using SmartEssayChecker.Api.Brokers.Storages;
using SmartEssayChecker.Api.Models.Essays;
using SmartEssayChecker.Api.Services.Foundations.Essays;
using Tynamix.ObjectFiller;
using Xeptions;

namespace SmartEssayChecker.Api.Tests.Unit.Foundations.Essays
{
    public partial class EssayServiceTests
    {
        private readonly Mock<IStorageBroker> storageBrokerMock;
        private readonly Mock<ILoggingBroker> loggingBrokerMock;
        private readonly IEssayService essayService;

        public EssayServiceTests()
        {
            this.storageBrokerMock = new Mock<IStorageBroker>();
            this.loggingBrokerMock = new Mock<ILoggingBroker>();

            this.essayService =
                new EssayService(
                storageBroker: this.storageBrokerMock.Object,
                loggingBroker: this.loggingBrokerMock.Object);
        }

        private static Expression<Func<Xeption, bool>> SameExceptionAs(Xeption expectedException) =>
            actualException => actualException.SameExceptionAs(expectedException);

        private static Essay CreateRandomEssay() =>
            CreateEssayFiller().Create();

        private static Filler<Essay> CreateEssayFiller() =>
            new Filler<Essay>();
    }
}
