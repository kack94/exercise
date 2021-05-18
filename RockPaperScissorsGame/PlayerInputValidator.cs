using RockPaperScissorsGame.Enums;
using RockPaperScissorsGame.Interfaces;
using System;

namespace RockPaperScissorsGame
{
    public class PlayerInputValidator : IPlayerInputValidator
    {
        public bool IsChoiceValid(string choice) => int.TryParse(choice, out int result) 
            && Enum.IsDefined(typeof(Choice), result);

        public bool IsNameValid(string name) => !string.IsNullOrEmpty(name);
    }
}
