using Microsoft.Extensions.DependencyInjection;
using RockPaperScissorsGame.Factories;
using RockPaperScissorsGame.Interfaces;
using RockPaperScissorsGame.Services;

namespace RockPaperScissorsGame
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var serviceProvider = ConfigureServices();

            var gameExecutor = serviceProvider.GetService<IGameService>();

            gameExecutor.StartGame();
        }

        public static ServiceProvider ConfigureServices()
        {
            var serviceProvider = new ServiceCollection()
                .AddTransient<IComputerPlayerFactory, ComputerPlayerFactory>()
                .AddTransient<IHumanPlayerFactory, HumanPlayerFactory>()
                .AddTransient<IGameFactory, GameFactory>()
                .AddTransient<IGameService, GameService>()
                .AddTransient<IPlayerInputValidator, PlayerInputValidator>()
                .BuildServiceProvider();

            return serviceProvider;
        }
    }
}
