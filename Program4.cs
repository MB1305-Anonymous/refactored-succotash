using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

class Program
{
    static void Main(string[] args)
    {
        // Path to the text file
        string filePath = @"C:\Users\DELL\Documents\JANE ASSIGNMENT.docx";

        if (!File.Exists(filePath))
        {
            Console.WriteLine("The file does not exist.");
            return;
        }

        // Read the file content
        string text = File.ReadAllText(filePath);

        // Split the text into words
        var words = text.Split(new char[] { ' ', '\t', '\n', '\r', '.', ',', '!', '?', ';', ':', '(', ')' }, StringSplitOptions.RemoveEmptyEntries);

        // Dictionary to hold word counts
        Dictionary<string, int> wordCounts = new Dictionary<string, int>();

        // Count each word
        foreach (var word in words)
        {
            string lowerWord = word.ToLower(); // Convert to lowercase to ensure case-insensitive counting
            if (wordCounts.ContainsKey(lowerWord))
            {
                wordCounts[lowerWord]++;
            }
            else
            {
                wordCounts[lowerWord] = 1;
            }
        }

        // Get the top 10 most frequent words
        var topWords = wordCounts.OrderByDescending(pair => pair.Value).Take(10);

        // Display the top 10 words
        Console.WriteLine("Top 10 most frequent words:");
        foreach (var pair in topWords)
        {
            Console.WriteLine($"{pair.Key}: {pair.Value}");
        }
    }
}