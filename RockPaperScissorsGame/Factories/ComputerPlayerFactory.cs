using RockPaperScissorsGame.Interfaces;

namespace RockPaperScissorsGame.Factories
{
    public class ComputerPlayerFactory : IComputerPlayerFactory
    {
        public ComputerPlayer Create() => new ComputerPlayer();
    }
}
