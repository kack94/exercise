using RockPaperScissorsGame.Enums;
using System;
using System.Collections.Generic;
using System.Linq;

namespace RockPaperScissorsGame
{
    public class Game
    { 
        private readonly HumanPlayer _humanPlayer;

        private readonly ComputerPlayer _computerPlayer;

        private readonly Dictionary<Type, int> _score;

        private static readonly IReadOnlyList<(Choice HumanPlayerChoice, Choice ComputerPlayerChoice, GameResult Result)> _combinations =
           new List<(Choice HumanPlayerChoice, Choice ComputerPlayerChoice, GameResult Result)>
           {
                (Choice.Rock, Choice.Scissors, GameResult.HumanPlayerWon),
                (Choice.Paper, Choice.Rock, GameResult.HumanPlayerWon),
                (Choice.Scissors, Choice.Paper, GameResult.HumanPlayerWon),
                (Choice.Scissors, Choice.Rock, GameResult.ComputerPlayerWon),
                (Choice.Rock, Choice.Paper, GameResult.ComputerPlayerWon),
                (Choice.Paper, Choice.Scissors, GameResult.ComputerPlayerWon),
                (Choice.Scissors, Choice.Scissors, GameResult.Tie),
                (Choice.Paper, Choice.Paper, GameResult.Tie),
                (Choice.Rock, Choice.Rock, GameResult.Tie)
           };

        public GameResult SelectWinner(Choice humanPlayerChoice, Choice computerPlayerChoice) => _combinations
          .FirstOrDefault(x => x.HumanPlayerChoice == humanPlayerChoice && x.ComputerPlayerChoice == computerPlayerChoice)
          .Result;

        public Game(HumanPlayer humanPlayer, ComputerPlayer computerPlayer)
        {
            _humanPlayer = humanPlayer;
            _computerPlayer = computerPlayer;
            _score = new Dictionary<Type, int>
            {
                { humanPlayer.GetType(), 0 },
                { computerPlayer.GetType(), 0}
            };
        }

        public Choice GetComputerPlayerChoice => _computerPlayer.Choice;

        public Choice GetHumanPlayerChoice => _humanPlayer.Choice;

        public Choice GenerateChoice() => _computerPlayer.GenerateChoice();

        public Player GetRoundWinner(GameResult result)
        {
            switch (result)
            {
                case GameResult.HumanPlayerWon:
                    return _humanPlayer;
                case GameResult.ComputerPlayerWon:
                    return _computerPlayer;
                case GameResult.Tie:
                    return null;
            }

            throw new ArgumentException($"Not supported GameResult {result}");
        }

        public Player GetGameWinner()
        {
            var winner = _score.OrderByDescending(x => x.Value).First().Key;

            if (winner == typeof(HumanPlayer))
            {
                return _humanPlayer;
            }
            
            return _computerPlayer;
        }


        public void SetHumanPlayerChoice(Choice choice)
        {
            _humanPlayer.SetChoice(choice);
        }

        public void SetComputerPlayerChoice(Choice computerChoice)
        {
            _computerPlayer.SetChoice(computerChoice);
        }

        public void AddPointToTheWinner(Player winner)
        {
            _score[winner.GetType()]++;
        }
    }
}
