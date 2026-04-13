using System.Speech.Synthesis;

public static class AudioPlayer
{
    private static SpeechSynthesizer speak = new SpeechSynthesizer();

    public static void Speak(string message)
    {
        speak.Speak(message);
    }
}