using RockPaperScissorsGame.Enums;
using System;

namespace RockPaperScissorsGame
{
    public class ComputerPlayer : Player
    {
        public override string Name => "Computer";

        public Choice GenerateChoice() => (Choice)new Random().Next(1, 3);
    }
}
