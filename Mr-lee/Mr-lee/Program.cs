using System;

class Program
{
    static void Main(string[] args)

    {


        Console.Title = "Mr Lee Bot - Cybersecurity Awareness";

        ConsoleUI.DisplayLogo();

        UserProfile user = new UserProfile();
        user.GetUserName();

        ConsoleUI.BotSay(
            $"Hello {user.Name}! Welcome to the Cybersecurity Awareness Bot\n" +
            "I am \"Mr Lee Bot, here to help you stay safe online.\n" +
            "Ask me about passwords, phishing, or safe browsing.\n" +
            "Type 'exit' or 'bye' to quit."
        );

        AudioPlayer.Speak("Welcome to the Cybersecurity Awareness Bot");

        ResponsesService bot = new ResponsesService();
        bot.RunChat(user.Name);
    }
}