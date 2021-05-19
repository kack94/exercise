using FluentAssertions;
using RockPaperScissorsGame.Factories;
using Xunit;

namespace RockPaperScissorsGame.UnitTest.Factories
{
    public class ComputerPlayerFactoryTest
    {
        private ComputerPlayerFactory _sut;

        [Fact]
        public void It_creates_computer_player_object_with_default_name()
        {
            // Arrange
            _sut = new ComputerPlayerFactory();

            // Act
            var result = _sut.Create();

            // Assert
            result.Should().NotBeNull();
            result.Should().BeOfType<ComputerPlayer>();
            result.Name.Should().Be("Computer");
        }
    }
}