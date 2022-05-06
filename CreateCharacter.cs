 using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RPG_game
{
    public static class CreateCharacter
    {
        public static Character create_character()
        {
            Character character = new();
            Console.WriteLine("--Create character--");
            Console.WriteLine("Press any enter to roll dice and create character");
            Console.ReadKey();

            character.attributes = choose_attributes();
            character.character_type = choose_character_type();
            character.name = choose_name();

            Random rand = new Random();

            character.x = rand.Next(1, 40);
            character.y = rand.Next(1, 13);

            return confirm_character(character);
        }

        private static Attributes choose_attributes()
        {
            Attributes attributes = new Attributes();
            string input = "";
            do
            {
                attributes = get_random_attributes(attributes);
                Console.WriteLine("'n'=re-roll 'y'=continue");
                input = Console.ReadKey(true).KeyChar.ToString().ToLower();
            } while (input == "n");
            return attributes;
        }

        private static Attributes get_random_attributes(Attributes attributes)
        {
            string progress_bar = "|--------------------|";
            for (int i = 0; i < 20; i++)
            {
                progress_bar = progress_bar.Remove(i+1, 1).Insert(i+1, "#");
                Console.Clear();
                Console.WriteLine(progress_bar);
                if (i < 19)
                    dice_roll_effect();
                else
                {
                    attributes.Strength = Dice.throw_multiple_dices(3);
                    attributes.Intelligence = Dice.throw_multiple_dices(3);
                    attributes.Wisdom = Dice.throw_multiple_dices(3);
                    attributes.Dexterity = Dice.throw_multiple_dices(3);
                    attributes.Constitution = Dice.throw_multiple_dices(3);
                    attributes.Charisma = Dice.throw_multiple_dices(3);

                    Console.WriteLine("-- Attributes --");
                    Console.WriteLine("Strength: " + attributes.Strength);
                    Console.WriteLine("Intelligence: " + attributes.Intelligence);
                    Console.WriteLine("Wisdom: " + attributes.Wisdom);
                    Console.WriteLine("Dexterity: " + attributes.Dexterity);
                    Console.WriteLine("Constitution: " + attributes.Constitution);
                    Console.WriteLine("Charisma: " + attributes.Charisma);
                    Console.WriteLine("----------------");
                }
            }
            return attributes;
        }

        private static void dice_roll_effect()
        {
            Console.WriteLine("Strength: " + Dice.throw_multiple_dices(3));
            Console.WriteLine("Intelligence: " + Dice.throw_multiple_dices(3));
            Console.WriteLine("Wisdom: " + Dice.throw_multiple_dices(3));
            Console.WriteLine("Dexterity: " + Dice.throw_multiple_dices(3));
            Console.WriteLine("Constitution: " + Dice.throw_multiple_dices(3));
            Console.WriteLine("Charisma: " + Dice.throw_multiple_dices(3));
            Thread.Sleep(50);
        }

        private static CharacterType choose_character_type()
        {
            int input = 0;
            do
            {
                Console.Clear();
                Console.WriteLine("Choose class: ");

                // Displays the list of different classes
                for (int i = 0; i < Enum.GetNames(typeof(CharacterType)).Length; i++)
                {
                    Console.WriteLine($"{i}. {(CharacterType)i}");
                }
            } while (!int.TryParse(Console.ReadKey(true).KeyChar.ToString(), out input));
            return (CharacterType)input;
        }

        private static string choose_name()
        {
            Console.Clear();
            Console.WriteLine("Enter name of character: ");
            return Console.ReadLine();
        }

        private static Character confirm_character(Character character)
        {
            string input;
            do
            {
                Console.Clear();
                character.show_stats();
                Console.WriteLine(@"
            Are you happy with this? Type 'y' if you are, or press one of the corresponding numbers
            to change the details.
            ");
                Console.WriteLine(@"
            1. Change attributes
            2. Change type/class
            3. Change name
            ");
                input = Console.ReadKey(true).KeyChar.ToString();
                switch (input)
                {
                    case "1":
                        character.attributes = choose_attributes();
                        break;
                    case "2":
                        character.character_type = choose_character_type();
                        break;
                    case "3":
                        character.name = choose_name();
                        break;
                }
            } while (input != "y");
            Console.Clear();
            return character;
        }
    }
}
