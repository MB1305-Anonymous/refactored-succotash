using System;
using System.Collections.Generic;

class MorseCodeTranslator
{
    private static readonly Dictionary<char, string> textToMorse = new Dictionary<char, string>
    {
        {'A', ".-"}, {'B', "-..."}, {'C', "-.-."}, {'D', "-.."}, {'E', "."}, {'F', "..-."},
        {'G', "--."}, {'H', "...."}, {'I', ".."}, {'J', ".---"}, {'K', "-.-"}, {'L', ".-.."},
        {'M', "--"}, {'N', "-."}, {'O', "---"}, {'P', ".--."}, {'Q', "--.-"}, {'R', ".-."},
        {'S', "..."}, {'T', "-"}, {'U', "..-"}, {'V', "...-"}, {'W', ".--"}, {'X', "-..-"},
        {'Y', "-.--"}, {'Z', "--.."}, {'0', "-----"}, {'1', ".----"}, {'2', "..---"},
        {'3', "...--"}, {'4', "....-"}, {'5', "....."}, {'6', "-...."}, {'7', "--..."},
        {'8', "---.."}, {'9', "----."}, {' ', "/"}
    };

    private static readonly Dictionary<string, char> morseToText = new Dictionary<string, char>();

    static MorseCodeTranslator()
    {
        foreach (var kvp in textToMorse)
        {
            morseToText[kvp.Value] = kvp.Key;
        }
    }

    static void Main(string[] args)
    {
        while (true)
        {
            Console.WriteLine("Choose an option:");
            Console.WriteLine("1. Text to Morse Code");
            Console.WriteLine("2. Morse Code to Text");
            Console.WriteLine("3. Exit");
            string choice = Console.ReadLine();

            switch (choice)
            {
                case "1":
                    Console.WriteLine("Enter text to convert to Morse code:");
                    string text = Console.ReadLine().ToUpper();
                    string morse = TextToMorse(text);
                    Console.WriteLine($"Morse Code: {morse}");
                    break;
                case "2":
                    Console.WriteLine("Enter Morse code to convert to text (use spaces between Morse code characters):");
                    string morseCode = Console.ReadLine();
                    string textResult = MorseToText(morseCode);
                    Console.WriteLine($"Text: {textResult}");
                    break;
                case "3":
                    return;
                default:
                    Console.WriteLine("Invalid choice. Please try again.");
                    break;
            }
        }
    }

    static string TextToMorse(string text)
    {
        List<string> morse = new List<string>();
        foreach (char c in text)
        {
            if (textToMorse.TryGetValue(c, out string code))
            {
                morse.Add(code);
            }
        }
        return string.Join(" ", morse);
    }

    static string MorseToText(string morse)
    {
        List<char> text = new List<char>();
        string[] morseCodes = morse.Split(' ');
        foreach (string code in morseCodes)
        {
            if (morseToText.TryGetValue(code, out char c))
            {
                text.Add(c);
            }
        }
        return new string(text.ToArray());
    }
}
