using System;
using System.Collections.Generic;

public class ResponsesService
{
    private readonly Dictionary<string, List<string>> _topicResponses;
    private readonly Random _random = new Random();

    public ResponsesService()
    {
        // Using optimized Dictionary setup to house multi-response arrays per topic keyword
        _topicResponses = new Dictionary<string, List<string>>(StringComparer.OrdinalIgnoreCase)
        {
            {
                "password", new List<string>
                {
                    "Make sure to use strong, unique passwords for each account. Avoid using personal details!",
                    "Consider using a password manager to keep your credentials safe and complex.",
                    "Always enable Two-Factor Authentication (2FA) alongside a strong password."
                }
            },
            {
                "scam", new List<string>
                {
                    "If an offer looks too good to be true, it probably is. Never transfer money to unknown sources.",
                    "Scammers often create a false sense of urgency. Take your time to verify their claims.",
                    "Be skeptical of unsolicited calls, texts, or social media messages requesting financial help."
                }
            },
            {
                "phishing", new List<string>
                {
                    "Be cautious of emails asking for personal information. Scammers often disguise themselves as trusted organisations.",
                    "Always check the sender's actual email address before clicking any links or downloading attachments.",
                    "Look out for generic greetings like 'Dear Customer' and urgent calls to action in suspicious emails."
                }
            },
            {
                "privacy", new List<string>
                {
                    "Regularly review the privacy settings on your social media accounts to control who sees your data.",
                    "Avoid sharing sensitive information like your location or phone number publicly online.",
                    "Be mindful of app permissions; don't give apps access to your contacts or camera unless necessary."
                }
            }
        };
    }

    public void RunChat(UserProfile user)
    {
        bool keepRunning = true;

        while (keepRunning)
        {
            Console.Write($"\n[{user.Name}] > ");
            string userInput = Console.ReadLine()?.Trim();

            if (string.IsNullOrEmpty(userInput)) continue;

            // Check for explicit session termination commands
            if (userInput.Equals("exit", StringComparison.OrdinalIgnoreCase) || 
                userInput.Equals("bye", StringComparison.OrdinalIgnoreCase))
            {
                ConsoleUI.BotSay("Stay safe out there! Goodbye.");
                AudioPlayer.Speak("Goodbye.");
                keepRunning = false;
                continue;
            }

            // 1. Evaluate User Sentiment Triggers
            string sentimentResponse = DetectAndRespondToSentiment(userInput);
            if (!string.IsNullOrEmpty(sentimentResponse))
            {
                ConsoleUI.BotSay(sentimentResponse);
                AudioPlayer.Speak(sentimentResponse);
            }

            // 2. Process Topic Keywords Mapping
            bool keywordFound = false;
            foreach (var topic in _topicResponses.Keys)
            {
                if (userInput.Contains(topic, StringComparison.OrdinalIgnoreCase))
                {
                    // Memory Context Storage
                    if (string.IsNullOrEmpty(user.FavoriteTopic))
                    {
                        user.FavoriteTopic = topic;
                        string memoryAck = $"Great! I'll remember that you're interested in {topic}. It's a crucial part of staying safe online.";
                        ConsoleUI.BotSay(memoryAck);
                        AudioPlayer.Speak(memoryAck);
                    }

                    // Select and fetch a randomized response item from the target array collection
                    string tip = GetRandomResponse(topic);
                    ConsoleUI.BotSay(tip);
                    AudioPlayer.Speak(tip);
                    keywordFound = true;
                    break;
                }
            }

            // 3. Conditional Memory Context Recall
            if (keywordFound && !string.IsNullOrEmpty(user.FavoriteTopic) && _random.Next(0, 2) == 1)
            {
                string recallMessage = $"As someone interested in {user.FavoriteTopic}, you might also want to stay updated on related safety definitions.";
                ConsoleUI.BotSay(recallMessage);
                AudioPlayer.Speak(recallMessage);
            }

            // 4. Default Fallback Processing Edge Case
            if (!keywordFound && string.IsNullOrEmpty(sentimentResponse))
            {
                string fallback = "I'm not sure I understand. Can you try rephrasing? Ask me about passwords, scams, phishing, or privacy.";
                ConsoleUI.BotSay(fallback);
                AudioPlayer.Speak(fallback);
            }
        }
    }

    private string GetRandomResponse(string topic)
    {
        List<string> responses = _topicResponses[topic];
        int index = _random.Next(responses.Count);
        return responses[index];
    }

    private string DetectAndRespondToSentiment(string input)
    {
        if (input.Contains("worried", StringComparison.OrdinalIgnoreCase) || 
            input.Contains("scared", StringComparison.OrdinalIgnoreCase) || 
            input.Contains("afraid", StringComparison.OrdinalIgnoreCase))
        {
            return "It's completely understandable to feel that way. Scams can be very convincing. Let me share some tips to help you stay safe.";
        }
        if (input.Contains("curious", StringComparison.OrdinalIgnoreCase) || 
            input.Contains("learn", StringComparison.OrdinalIgnoreCase))
        {
            return "It's fantastic that you are curious about tech safety! Knowledge is your best defence.";
        }
        if (input.Contains("frustrated", StringComparison.OrdinalIgnoreCase) || 
            input.Contains("annoyed", StringComparison.OrdinalIgnoreCase))
        {
            return "Cybersecurity rules can feel overwhelming and frustrating, but taking minor steps protects your entire identity.";
        }
        return null;
    }
}