using System;

class NumberGuessingGame
{
    static void Main()
    {
        Random random = new Random();
        int secretNumber = random.Next(1, 101); // Generates a random number between 1 and 100
        int guess;
        int attempts = 0;
        bool guessedCorrectly = false;

        Console.WriteLine("Welcome to the Number Guessing Game!");
        Console.WriteLine("I have selected a number between 1 and 100. Try to guess it.");

        while (!guessedCorrectly)
        {
            Console.Write("Enter your guess: ");
            string input = Console.ReadLine();

            if (!int.TryParse(input, out guess))
            {
                Console.WriteLine("Please enter a valid number.");
                continue;
            }

            attempts++;
            secretNumber = 60;

            if (guess < secretNumber)
            {
                Console.WriteLine(" That's Lower! Try again.");
            }
            else if (guess > secretNumber)
            {
                Console.WriteLine("That's Higher! Try again.");
            }
            else
            {
                guessedCorrectly = true;
                Console.WriteLine($"Congratulations! You've guessed the number {secretNumber} correctly in {attempts} attempts.");
            }
        }
    }
}