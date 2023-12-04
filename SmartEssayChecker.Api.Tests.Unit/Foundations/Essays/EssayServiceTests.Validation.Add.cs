using FluentAssertions;
using Moq;
using SmartEssayChecker.Api.Models.Essays;
using SmartEssayChecker.Api.Models.Essays.Exceptions;
using Xunit;

namespace SmartEssayChecker.Api.Tests.Unit.Foundations.Essays
{
    public partial class EssayServiceTests
    {
        [Fact]
        public async Task ShouldThrowValidationExceptionOnAddIfEssayIsNullAndLogItAsync()
        {
            // given 
            Essay nullEssay = null;

            var nullEssayException = new NullEssayException();

            var expectedEssayValidationException =
                new EssayValidationException(nullEssayException);

            // when
            ValueTask<Essay> addEssayTask =
                this.essayService.AddEssayAsync(nullEssay);

            EssayValidationException actualEssayValidationException =
                await Assert.ThrowsAsync<EssayValidationException>(addEssayTask.AsTask);

            // then 
            actualEssayValidationException.Should().BeEquivalentTo(
                expectedEssayValidationException);

            this.loggingBrokerMock.Verify(broker =>
               broker.LogError(It.Is(SameExceptionAs(
                   expectedEssayValidationException))), Times.Once);

            this.loggingBrokerMock.VerifyNoOtherCalls();
            this.storageBrokerMock.VerifyNoOtherCalls();
        }

        [Theory]
        [InlineData(null)]
        [InlineData("")]
        [InlineData(" ")]
        public async Task ShoudlThrowValidationExceptionOnAddIfEssayInvalidAndLogItAsync(
          string invalidText)
        {
            //given
            var invalidEssay = new Essay
            {
                Content = invalidText,
            };

            var invalidEssayException = new InvalidEssayException();

            invalidEssayException.AddData(
                key: nameof(Essay.EssayId),
                values: "Id is required");

            invalidEssayException.AddData(
                key: nameof(Essay.Content),
                values: "Text is required");

            var expectedEssayValidationException =
                new EssayValidationException(invalidEssayException);

            //when
            ValueTask<Essay> addEssayTask =
                this.essayService.AddEssayAsync(invalidEssay);

            EssayValidationException actualEssayValidationException =
                await Assert.ThrowsAsync<EssayValidationException>(addEssayTask.AsTask);

            //then
            actualEssayValidationException.Should().BeEquivalentTo(
                expectedEssayValidationException);

            this.loggingBrokerMock.Verify(broker =>
            broker.LogError(It.Is(SameExceptionAs(
                expectedEssayValidationException))), Times.Once());

            this.storageBrokerMock.VerifyNoOtherCalls();
        }
    }
}
