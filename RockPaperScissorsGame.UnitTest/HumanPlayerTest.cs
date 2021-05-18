using FluentAssertions;
using RockPaperScissorsGame.Enums;
using Xunit;

namespace RockPaperScissorsGame.UnitTest
{
    public class HumanPlayerTest
    {
        private HumanPlayer _sut;
        
        [Theory]
        [InlineData(Choice.Rock)]
        [InlineData(Choice.Paper)]
        [InlineData(Choice.Scissors)]
        public void It_sets_correct_choice(Choice choice)
        {
            // Arrange
            _sut = new HumanPlayer("TestPlayer");
            
            // Act
            _sut.SetChoice(choice);
            
            // Assert
            _sut.Choice.Should().Be(choice);
        }
    }
}
