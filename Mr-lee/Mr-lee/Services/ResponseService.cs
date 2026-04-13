using System;

public class ResponsesService
{
    private Random rand = new Random();

    private string[] greetings = {
        "Hello! I'm running perfectly and ready to help you stay secure online.",
        "All systems operational! How can I help you stay safe online?",
        "I'm doing great! Ready to assist with cybersecurity tips."
    };

    private string[] unknownResponses = {
        "Sorry, I didn't quite understand that. Could you rephrase?",
        "I'm not sure I follow. Try asking in a different way.",
        "Hmm, I didn't get that. Can you clarify?"
    };

    private string[] emptyResponses = {
        "You entered nothing. Please type a question.",
        "Oops! That was empty. Try asking something.",
        "Please type something so I can help you."
    };

    private string[] passwordAdvice = {
        "Use strong passwords with at least 12 characters and enable 2FA.",
        "Avoid personal info and always use unique passwords.",
        "Use a mix of letters, numbers, and symbols."
    };

    public void RunChat(string name)
    {
        string input = "";

        while (input != "exit" && input != "bye")
        {
            input = ConsoleUI.GetUserInput(name)?.ToLower();

            if (string.IsNullOrWhiteSpace(input))
            {
                Respond(GetRandom(emptyResponses));
                continue;
            }

            if (input.Contains("how are you"))
            {
                Respond(GetRandom(greetings));
            }
            else if (input.Contains("password"))
            {
                Respond(GetRandom(passwordAdvice));
            }
            else if (input == "exit" || input == "bye")
            {
                Respond($"Goodbye {name}! Stay safe online.");
                break;
            }
            else
            {
                Respond(GetRandom(unknownResponses));
            }
        }
    }

    private void Respond(string message)
    {
        ConsoleUI.BotSay(message);
        AudioPlayer.Speak(message);
    }

    private string GetRandom(string[] arr)
    {
        return arr[rand.Next(arr.Length)];
    }
}
