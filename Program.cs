using RPG_game;
Party party = new();

do {
    Console.Clear();
    CreationScreen screen = new CreationScreen { screenX=5, screenY=5, screenWidth=45, screenHeight=15};
    screen.init();
    screen.setPixel(4, 45);
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
        party.characters.Add(CreateCharacter.create_character());
    }
} while (true);