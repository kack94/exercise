namespace RockPaperScissorsGame.Interfaces
{
    public class GameFactory : IGameFactory
    {
        public Game CreateGame(HumanPlayer firstPlayer, ComputerPlayer secondPlayer) => new Game(firstPlayer, secondPlayer);
    }
}
