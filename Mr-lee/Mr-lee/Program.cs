using System;

class Program
{
    static void Main(string[] args)
    {
        Console.Title = "Mr Lee Bot - Cybersecurity Awareness";

        // Loads and displays the ASCII art banner from the Assets folder
        ConsoleUI.DisplayLogo();

        UserProfile user = new UserProfile();
        user.GetUserName();

        ConsoleUI.BotSay(
            $"Hello {user.Name}! Welcome to the Cybersecurity Awareness Bot\n" +
            "I am Mr Lee Bot, here to help you stay safe online.\n" +
            "Ask me about passwords, scams, phishing, or privacy.\n" +
            "Type 'exit' or 'bye' to quit."
        );

        AudioPlayer.Speak("Welcome to the Cybersecurity Awareness Bot");

        ResponsesService bot = new ResponsesService();
        // Passes the stateful user tracking profile directly into the chat loop
        bot.RunChat(user);
    }
}