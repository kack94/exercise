using FluentAssertions;
using Xunit;

namespace RockPaperScissorsGame.UnitTest
{
    public class UserInputValidatorTest
    {
        private readonly PlayerInputValidator _sut = new PlayerInputValidator();

        [Theory]
        [InlineData(null)]
        [InlineData("")]
        public void It_returns_false_for_invalid_player_name(string playerName)
        {
            // Arrange & Act
            var result = _sut.IsNameValid(playerName);

            // Assert
            result.Should().BeFalse();
        }

        [Theory]
        [InlineData(null)]
        [InlineData("12")]
        [InlineData("")]
        [InlineData("4")]
        public void It_returns_false_for_invalid_player_choice(string playerChoice)
        {
            // Arrange & Act
            var result = _sut.IsChoiceValid(playerChoice);

            // Assert
            result.Should().BeFalse();
        }

        [Theory]
        [InlineData("1")]
        [InlineData("3")]
        [InlineData("2")]
        public void It_returns_true_for_valid_player_choice(string playerChoice)
        {
            // Arrange & Act
            var result = _sut.IsNameValid(playerChoice);

            // Assert
            result.Should().BeTrue();
        }
    }
}
