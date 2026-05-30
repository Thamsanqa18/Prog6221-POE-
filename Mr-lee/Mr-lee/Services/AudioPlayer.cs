using System;
using System.Speech.Synthesis;

public static class AudioPlayer
{
    public static void Speak(string text)
    {
        try
        {
            using (SpeechSynthesizer synth = new SpeechSynthesizer())
            {
                synth.Volume = 100;
                synth.Rate = 0; 
                synth.Speak(text);
            }
        }
        catch (Exception)
        {
            // Silently fall back if sound output devices are missing or unconfigured
        }
    }
}