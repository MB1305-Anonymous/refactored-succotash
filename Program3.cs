using System;

class PalindromeChecker
{
    static void Main()
    {
        Console.WriteLine("Palindrome Checker");
        Console.WriteLine("Enter a word or phrase to check (or type 'exit' to quit):");

        while (true)
        {
            string input = Console.ReadLine();

            if (input.ToLower() == "exit")
            {
                break;
            }

            if (IsPalindrome(input))
            {
                Console.WriteLine($"\"{input}\" is a palindrome.");
            }
            else
            {
                Console.WriteLine($"\"{input}\" is not a palindrome.");
            }
        }
    }

    static bool IsPalindrome(string input)
    {
        // Remove non-alphanumeric characters and convert to lowercase
        string cleanedInput = System.Text.RegularExpressions.Regex.Replace(input, "[^A-Za-z0-9]", "").ToLower();

        int left = 0;
        int right = cleanedInput.Length - 1;

        while (left < right)
        {
            if (cleanedInput[left] != cleanedInput[right])
            {
                return false;
            }
            left++;
            right--;
        }

        return true;
    }
}