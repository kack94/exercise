using RockPaperScissorsGame.Enums;

namespace RockPaperScissorsGame.Interfaces
{
    public interface IPlayerInputValidator
    {
        bool IsNameValid(string name);

        bool IsChoiceValid(string choice);
    }
}
