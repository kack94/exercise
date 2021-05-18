using RockPaperScissorsGame.Interfaces;

namespace RockPaperScissorsGame.Factories
{
    public class HumanPlayerFactory : IHumanPlayerFactory
    {
        public HumanPlayer Create(string playerName) => new HumanPlayer(playerName);
    }
}
