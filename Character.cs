using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public enum CharacterType { Fighter, Mage, Cleric, Bard, Rouge, Paladin, Barbarian };

namespace RPG_game
{
    public class Character
    {
        public string name { get; set; }
        public int level { get; set; }
        public CharacterType character_type { get; set; }

        public Attributes attributes = new();

        public void show_stats()
        {
            Console.WriteLine(@$"
                        {name} the {character_type.ToString()}
                        - Attributes ------------
                        Strength:  {attributes.Strength}
                        Intelligence:  {attributes.Intelligence}
                        Wisdom:  {attributes.Wisdom}
                        Dexterity:  {attributes.Dexterity}
                        Constitution:  {attributes.Constitution}
                        Charisma:  {attributes.Charisma}
                        -------------------------

                    ");
        }
    }
}
