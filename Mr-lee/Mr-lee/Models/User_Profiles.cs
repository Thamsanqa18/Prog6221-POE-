using System;

public class UserProfile
{
    public string Name { get; private set; } = "User";
    public string FavoriteTopic { get; set; } = "";

    public void GetUserName()
    {
        Console.Write("Enter your name: ");
        string input = Console.ReadLine();
        Name = string.IsNullOrWhiteSpace(input) ? "User" : input;
    }
}