using System;
using System.IO;
using System.Threading;

public static class ConsoleUI
{
    public static void DisplayLogo()
    {
        Console.ForegroundColor = ConsoleColor.Green;

        if (File.Exists("ascii-art.txt"))
        {
            string logo = File.ReadAllText("ascii-art.txt");
            Console.WriteLine(logo);
        }
        else
        {
            Console.WriteLine("Logo file not found.");
        }

        Console.ResetColor();
    }

    public static void BotSay(string message)
    {
        Console.ForegroundColor = ConsoleColor.Green;
        Console.Write("Mr Lee Bot : ");

        foreach (char c in message)
        {
            Console.Write(c);
            Thread.Sleep(20);
        }

        Console.WriteLine();
        Console.ResetColor();
    }

    public static string GetUserInput(string name)
    {
        Console.ForegroundColor = ConsoleColor.Red;
        Console.Write(name + ": ");
        string input = Console.ReadLine();
        Console.ResetColor();

        return input;
    }
}