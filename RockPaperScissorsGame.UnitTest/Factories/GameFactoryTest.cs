using FluentAssertions;
using RockPaperScissorsGame.Factories;
using RockPaperScissorsGame.Interfaces;
using Xunit;

namespace RockPaperScissorsGame.UnitTest.Factories
{
    public class GameFactoryTest
    {
        private GameFactory _sut;

        [Fact]
        public void It_creates_game_object_with_2_players()
        {
            // Arrange 
            var humanPlayer = new HumanPlayer("humanPlayerTest");
            var computerPlayer = new ComputerPlayer();
            _sut = new GameFactory();

            // Act
            var result = _sut.CreateGame(humanPlayer, computerPlayer);

            // Assert
            result.Should().NotBeNull();
            result.Should().BeOfType<Game>();
        }
    }
}