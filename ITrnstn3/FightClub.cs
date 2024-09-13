using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ITrnstn3
{
    public class FightClub
    {
        public int UserMove { get; set; }

        public int CompMove { get; set; }

        public string[] Moves { get; set; }

        public FightClub(int userMove, int compMove, string[] args)
        {
            UserMove = userMove;
            CompMove = compMove;
            Moves = args;
        }

        public FightClub() { }

        public void Fight(SecretKey secretKey)
        {
            int half = Moves.Length / 2;
            int difference = UserMove - CompMove;

            string moveData = $"Computer move was {CompMove} ({Moves[CompMove - 1]})\nSecret key: {secretKey.GetKey()}\n";

            if (UserMove < CompMove)
            {
                if (difference >= -half)
                {
                    PrintResultMessage($"\nYou lose. Computer wins!\n{moveData}");
                    Restart();
                }
                else
                {
                    PrintResultMessage($"\nYou won! Computer is loser.\n{moveData}");
                    Restart();
                }
            }
            else if (UserMove > CompMove)
            {
                if (difference > half)
                {
                    PrintResultMessage($"\nYou lose. Computer wins!\n{moveData}");
                    Restart();
                }
                else
                {
                    PrintResultMessage($"\nYou won! Computer is loser.\n{moveData}");
                    Restart();
                }
            }
            else
            {
                PrintResultMessage($"\nNo winner\n{moveData}");
                Restart();
            }
        }

        public void PrintResultMessage(string message)
        {
            Console.WriteLine(message);
        }
        
        public void Restart()
        {
            Program.Play(Moves);
        }

        public string FightInfo()
        {
            int half = Moves.Length / 2;
            int difference = UserMove - CompMove;

            if (UserMove < CompMove)
            {
                if (difference >= -half)
                {
                    return "Win";
                }
                else
                {
                    return "Lose";
                }
            }
            else if (UserMove > CompMove)
            {
                if (difference > half)
                {
                    return "Win";
                }
                else
                {
                    return "Lose";
                }
            }
            else
            {
                return "Draw";
            }
        }
    }
}
