using RockPaperScissorsGame.Enums;

namespace RockPaperScissorsGame
{
    public class Player
    {
        public virtual string Name { get; protected set; }

        public Choice Choice { get; private set; }

        public void SetChoice(Choice choice)
        {
            Choice = choice;
        }
    }
}
