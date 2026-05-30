using System;
using System.IO;

public static class ConsoleUI
{
    public static void DisplayLogo()
    {
        Console.ForegroundColor = ConsoleColor.Cyan;
        
        // Assembles the path to the text file managed within your folder directory structure
        string asciiArtPath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Assets", "ascii-art.txt");

        try
        {
            if (File.Exists(asciiArtPath))
            {
                string logo = File.ReadAllText(asciiArtPath);
                Console.WriteLine(logo);
            }
            else
            {
                // Fallback banner if file replication isn't fully synchronized on runtime initialization
                Console.WriteLine(@"==================================================");
                Console.WriteLine(@"               MR LEE SECURITY BOT                ");
                Console.WriteLine(@"==================================================");
            }
        }
        catch (Exception)
        {
            Console.WriteLine("[Mr Lee Bot - Cybersecurity Awareness]");
        }
        
        Console.ResetColor();
    }

    public static void BotSay(string text)
    {
        Console.ForegroundColor = ConsoleColor.Green;
        Console.WriteLine($"\n[Mr Lee Bot]: {text}");
        Console.ResetColor();
    }
}