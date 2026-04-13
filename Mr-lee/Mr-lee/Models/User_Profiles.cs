using System;

public class UserProfile
{
    public string Name { get; private set; }

    public void GetUserName()
    {
        Console.ForegroundColor = ConsoleColor.Green;
        Console.WriteLine("Please enter your name:");
        Console.ResetColor();

        while (true)
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Name = Console.ReadLine();
            Console.ResetColor();

            if (!string.IsNullOrWhiteSpace(Name))
                break;

            ConsoleUI.BotSay("Name cannot be empty. Please enter your name:");
        }
    }
}