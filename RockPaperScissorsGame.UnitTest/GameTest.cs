using FluentAssertions;
using RockPaperScissorsGame.Enums;
using System;
using Xunit;

namespace RockPaperScissorsGame.UnitTest
{
    public class GameTest
    {
        private Game _sut;

        [Theory]
        [InlineData(GameResult.ComputerPlayerWon,typeof(ComputerPlayer))]
        [InlineData(GameResult.HumanPlayerWon, typeof(HumanPlayer))]
        public void It_correctly_gets_round_winner(GameResult gameResult, Type expectedResult)
        {
            // Arrange
            _sut = new Game(new HumanPlayer("HumanPlayer"), new ComputerPlayer());

            // Act
            var result = _sut.GetRoundWinner(gameResult);

            // Assert
            result.Should().NotBeNull();
            result.Should().BeOfType(expectedResult);
        }

        [Fact]
        public void It_correctly_gets_human_game_winner()
        {
            // Arrange
            var humanPlayer = new HumanPlayer("HumanPlayer");
            var computerPlayer = new ComputerPlayer();
            _sut = new Game(humanPlayer, computerPlayer);
            _sut.AddPointToTheWinner(humanPlayer);

            // Act
            var winner = _sut.GetGameWinner();

            // Assert
            winner.Should().NotBeNull();
            winner.Should().BeSameAs(humanPlayer);
        }

        [Fact]
        public void It_correctly_gets_computer_game_winner()
        {
            // Arrange
            var humanPlayer = new HumanPlayer("HumanPlayer");
            var computerPlayer = new ComputerPlayer();
            _sut = new Game(humanPlayer, computerPlayer);
            _sut.AddPointToTheWinner(computerPlayer);

            // Act
            var winner = _sut.GetGameWinner();

            // Assert
            winner.Should().NotBeNull();
            winner.Should().BeSameAs(computerPlayer);
        }

        [Fact]
        public void It_returns_null_when_its_tie()
        {
            // Arrange
            _sut = new Game(new HumanPlayer("HumanPlayer"), new ComputerPlayer());

            // Act
            var result = _sut.GetRoundWinner(GameResult.Tie);

            // Assert
            result.Should().BeNull();
        }

        [Theory]
        [InlineData(Choice.Rock, Choice.Scissors, GameResult.HumanPlayerWon)]
        [InlineData(Choice.Paper, Choice.Rock, GameResult.HumanPlayerWon)]
        [InlineData(Choice.Scissors, Choice.Paper, GameResult.HumanPlayerWon)]
        [InlineData(Choice.Scissors, Choice.Rock, GameResult.ComputerPlayerWon)]
        [InlineData(Choice.Rock, Choice.Paper, GameResult.ComputerPlayerWon)]
        [InlineData(Choice.Paper, Choice.Scissors, GameResult.ComputerPlayerWon)]
        [InlineData(Choice.Paper, Choice.Paper, GameResult.Tie)]
        public void It_correctly_selects_winner(Choice humanPlayerChoice, Choice computerPlayerChoice, GameResult expectedResult)
        {
            // Arrange
            _sut = new Game(new HumanPlayer("HumanPlayer"), new ComputerPlayer());

            // Act
            var result = _sut.SelectWinner(humanPlayerChoice, computerPlayerChoice);

            // Assert
            result.Should().Be(expectedResult);
        }
    }
}
