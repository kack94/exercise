using RockPaperScissorsGame.Enums;
using RockPaperScissorsGame.Interfaces;
using System;

namespace RockPaperScissorsGame.Services
{
    public class GameService : IGameService
    {
        private const int NumberOfRounds = 3;

        private readonly IComputerPlayerFactory _computerPlayerFactory;

        private readonly IHumanPlayerFactory _humanPlayerFactory;

        private readonly IPlayerInputValidator _playerInputValidator;

        private readonly IGameFactory _gameFactory;

        public GameService(
            IComputerPlayerFactory computerPlayerFactory,
            IHumanPlayerFactory humanPlayerFactory,
            IPlayerInputValidator playerInputValidator,
            IGameFactory gameFactory)
        {
            _computerPlayerFactory = computerPlayerFactory;
            _humanPlayerFactory = humanPlayerFactory;
            _playerInputValidator = playerInputValidator;
            _gameFactory = gameFactory;
        }

        public void StartGame()
        {
            Console.WriteLine("Rock, Paper, Scissors game");

            Console.WriteLine("Please specify your name:");
            string playerName = Console.ReadLine();
            
            
            if (!_playerInputValidator.IsNameValid(playerName))
            {
                Console.WriteLine("Invalid name");
                return;
            }

            var game = _gameFactory.CreateGame(
                _humanPlayerFactory.Create(playerName),
                _computerPlayerFactory.Create());

            int roundsCounter = 1;

            while (roundsCounter <= NumberOfRounds)
            {
                Console.WriteLine($"Specify your choice: { Environment.NewLine }" +
                    $"1.{ Choice.Paper } { Environment.NewLine }" +
                    $"2.{ Choice.Rock } { Environment.NewLine }" +
                    $"3.{ Choice.Scissors } { Environment.NewLine }");

                string input = Console.ReadLine();

                if (_playerInputValidator.IsChoiceValid(input))
                {
                    var humanPlayerChoice = (Choice)Convert.ToInt32(input);
                    game.SetHumanPlayerChoice(humanPlayerChoice);
                }
                else
                {
                    Console.WriteLine($"Invalid choice, try again { Environment.NewLine }");
                    continue;
                }

                var computerChoice = game.GenerateChoice();
                game.SetComputerPlayerChoice(computerChoice);

                Console.WriteLine($"Computer choice: { game.GetComputerPlayerChoice }");
                Console.WriteLine($"{ playerName } choice: { game.GetHumanPlayerChoice }");

                var roundResult = game.SelectWinner(game.GetHumanPlayerChoice, game.GetComputerPlayerChoice);
                var roundWinner = game.GetRoundWinner(roundResult);

                if (roundWinner == null)
                {
                    Console.WriteLine("No winner, tie");
                }
                else
                {
                    game.AddPointToTheWinner(roundWinner);

                    Console.WriteLine($"{ roundWinner.Name } wins round { roundsCounter } { Environment.NewLine }");

                    roundsCounter++;
                }
            }

            var winner = game.GetGameWinner();

            Console.WriteLine($"The winner is { winner.Name }");
        }
    }
}
