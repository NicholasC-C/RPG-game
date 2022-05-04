using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RPG_game
{
    public class Party
    {
        public List<Character> characters { get; set; }

        public Party()
        {
            characters = new List<Character>();
        }
    }
}
