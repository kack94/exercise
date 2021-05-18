using FluentAssertions;
using RockPaperScissorsGame.Enums;
using Xunit;

namespace RockPaperScissorsGame.UnitTest
{
    public class ComputerPlayerTest
    {
        private ComputerPlayer _sut;
        
        [Fact]
        public void It_generates_correct_choice()
        {
            // Arrange
            _sut = new ComputerPlayer();
            
            // Act
            var result =_sut.GenerateChoice();
            
            // Assert
            result.Should().NotBeNull();
            result.Should().BeOfType<Choice>();
        }

        [Theory]
        [InlineData(Choice.Rock)]
        [InlineData(Choice.Paper)]
        [InlineData(Choice.Scissors)]
        public void It_sets_correct_choice(Choice choice)
        {
            // Arrange
            _sut = new ComputerPlayer();

            // Act
            _sut.SetChoice(choice);

            // Assert
            _sut.Choice.Should().Be(choice);
        }
    }
}
