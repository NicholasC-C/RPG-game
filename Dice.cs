using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RPG_game
{
    public static class Dice
    {
        public static int roll_d6()
        {
            Random rand = new Random();
            return rand.Next(1, 7);
        }

        public static int throw_multiple_dices(int amount)
        {
            int buffer = 0;
            for (int i = 0; i < amount; i++)
            {
                buffer = buffer + roll_d6();
            }
            return buffer;
        }
    }
}
