using System.Collections.Generic;
using System.Linq;

namespace DiscordBotGame.Instructions
{
    [InstructionHandler(Opcode.S)]
    public class SouthInstruction : Instruction
    {
        public override string Handel(Player p, List<Player> players, Command c)
        {
            if ((int) p.Position.Y == Program.WorldState.WorldSize)
            {
                return "ERROR south is out of bounds";
            }

            if (Program.WorldState.Players.Any(x =>
                    (int) x.Position.X == (int) p.Position.X && (int) x.Position.Y - 1 == (int) p.Position.Y) &&
                !p.Dead)
            {
                return
                    "ERROR Another Player is already occupying that space";
            }

            if (p.Tokens < 1)
            {
                return "ERROR You do not have enough tokens to move.";
            }

         
            for (int i = 0; i < (int) (c.Argument == 0 ? 1 : c.Argument); i++)
            {
                p.Position.Y += 1;
                p.Tokens -= 1;
            }

            return $"{p.Name} Has Move{(c.Argument == 0 ? "" : "d " +c.Argument + " times")} South";
        }
    }
}