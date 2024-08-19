using System;

class RockPaperScissorsGame
{
    static void Main(string[] args)
    {
        Random random = new Random();
        bool playAgain = true;
        string userChoice;
        string computerChoice;
        string answer;

        while (playAgain)
        {
            userChoice = "";
            computerChoice = "";
            answer = "";

            while (userChoice != "ROCK" && userChoice != "PAPER" && userChoice != "SCISSORS")
            {
                Console.Write("Enter ROCK, PAPER, or SCISSORS: ");
                userChoice = Console.ReadLine().ToUpper();
            }

            switch (random.Next(1, 4))
            {
                case 1:
                    computerChoice = "ROCK";
                    break;
                case 2:
                    computerChoice = "PAPER";
                    break;
                case 3:
                    computerChoice = "SCISSORS";
                    break;
            }

            Console.WriteLine("Computer: " + computerChoice);

            switch (userChoice)
            {
                case "ROCK":
                    if (computerChoice == "ROCK")
                    {
                        Console.WriteLine("It's a draw!");
                    }
                    else if (computerChoice == "PAPER")
                    {
                        Console.WriteLine("You lose!");
                    }
                    else
                    {
                        Console.WriteLine("You win!");
                    }
                    break;
                case "PAPER":
                    if (computerChoice == "PAPER")
                    {
                        Console.WriteLine("It's a draw!");
                    }
                    else if (computerChoice == "SCISSORS")
                    {
                        Console.WriteLine("You lose!");
                    }
                    else
                    {
                        Console.WriteLine("You win!");
                    }
                    break;
                case "SCISSORS":
                    if (computerChoice == "SCISSORS")
                    {
                        Console.WriteLine("It's a draw!");
                    }
                    else if (computerChoice == "ROCK")
                    {
                        Console.WriteLine("You lose!");
                    }
                    else
                    {
                        Console.WriteLine("You win!");
                    }
                    break;
            }

            Console.Write("Would you like to play again (Y/N): ");
            answer = Console.ReadLine().ToUpper();

            if (answer == "Y")
            {
                playAgain = true;
            }
            else
            {
                playAgain = false;
            }
        }

        Console.WriteLine("Thanks for playing!");
    }
}
