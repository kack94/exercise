namespace RockPaperScissorsGame.Interfaces
{
    public interface IGameFactory
    {
        Game CreateGame(HumanPlayer firstPlayer, ComputerPlayer secondPlayer);
    }
}
