using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RPG_game
{
    public enum GameState { Creation, Running, Paused};
    public class Game
    {
        public GameState state { get; set; }
        public Party party;
        public void start()
        {
            party = new();
            if (state == GameState.Creation)
            {
                creation();
            } else if (state == GameState.Running)
            {
                running();
            } else if (state == GameState.Paused)
            {
                paused();
            }
        }

        private void creation()
        {
            CreationScreen screen = new CreationScreen { title = "Character overview", screenX = 5, screenY = 5, screenWidth = 45, screenHeight = 15 };
            screen.init();
            do
            {
                Console.Clear();
                screen.show();
                Console.SetCursorPosition(0, 25);
                Console.WriteLine(@"
                        --------- Party ---------");
                if (party.characters.Count > 0)
                {
                    for (int i = 0; i < party.characters.Count; i++)
                    {
                        party.characters[i].show_stats();
                    }
                }
                Console.WriteLine(@"
                        -------------------------");
                Console.WriteLine("\nPress 'y' to add a character to your party");
                string input = Console.ReadKey(true).KeyChar.ToString();
                if (input == "y")
                {
                    Console.Clear();
                    Character character = CreateCharacter.create_character();
                    party.characters.Add(character);
                    screen.setPixel(character.x, character.y-1, '0');
                    screen.setPixel(character.x+1, character.y, '-');
                    screen.setPixel(character.x + 2, character.y, '|');
                    screen.setPixel(character.x - 1, character.y, '-');
                    screen.setPixel(character.x, character.y + 1, '"');
                    screen.setPixel(character.x, character.y, Convert.ToChar(character.name.Substring(0, 1)));
                }
            } while (true);
        }
        private void running()
        {

        }
        private void paused()
        {

        }
    }
}
