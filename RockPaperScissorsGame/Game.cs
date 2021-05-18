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

        public void SetComputerPlayerChoice()
        {
            var computerChoice = _computerPlayer.GenerateChoice();
            _computerPlayer.SetChoice(computerChoice);
        }

        public void AddPointToTheWinner(Player winner)
        {
            _score[winner.GetType()]++;
        }

        public GameResult SelectWinner(Choice humanPlayerChoice, Choice computerPlayerChoice)
        {
            if (humanPlayerChoice == Choice.Rock && computerPlayerChoice == Choice.Scissors)
                return GameResult.HumanPlayerWon;
            else if (humanPlayerChoice == Choice.Paper && computerPlayerChoice == Choice.Rock)
                return GameResult.HumanPlayerWon;
            else if (humanPlayerChoice == Choice.Scissors && computerPlayerChoice == Choice.Paper)
                return GameResult.HumanPlayerWon;
            else if (humanPlayerChoice == Choice.Scissors && computerPlayerChoice == Choice.Rock)
                return GameResult.ComputerPlayerWon;
            else if (humanPlayerChoice == Choice.Rock && computerPlayerChoice == Choice.Paper)
                return GameResult.ComputerPlayerWon;
            else if (humanPlayerChoice == Choice.Paper && computerPlayerChoice == Choice.Scissors)
                return GameResult.ComputerPlayerWon;
            else
                return GameResult.Tie;
        }
    }
}
