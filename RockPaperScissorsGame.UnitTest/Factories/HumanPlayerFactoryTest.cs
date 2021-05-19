using FluentAssertions;
using RockPaperScissorsGame.Factories;
using Xunit;

namespace RockPaperScissorsGame.UnitTest.Factories
{
    public class HumanPlayerFactoryTest
    {
        private HumanPlayerFactory _sut;

        [Theory]
        [InlineData("player")]
        [InlineData("Test1")]
        [InlineData("Player")]
        public void It_creates_human_player_object_with_specific_name(string name)
        {
            // Arrange
            _sut = new HumanPlayerFactory();

            // Act
            var result = _sut.Create(name);

            // Assert
            result.Should().NotBeNull();
            result.Should().BeOfType<HumanPlayer>();
            result.Name.Should().Be(name);
        }
    }
}