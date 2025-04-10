using System;

namespace number_guesser_game
{
    class Program
    {
        static void Main(string[] args)
        {
            // Display header
            GetAppInfo();
            // Greet the user
            GreetUser();

            while (true)
            {
                // Generate a random number between 1 and 10
                Random randomNumber = new Random();
                int correctNumber = randomNumber.Next(1, 11);
                int guess = 0;

                Console.WriteLine("Guess a number between 1 and 10:");

                // Loop until the user guesses correctly
                while (guess != correctNumber)
                {
                    string input = Console.ReadLine();

                    // Check if the input is a valid number
                    if (!int.TryParse(input, out guess))
                    {
                        TextColorChanger(ConsoleColor.Red, "That's not a number, try again.");
                        continue;
                    }

                    // Check if number is out of range
                    if (guess < 1 || guess > 10)
                    {
                        TextColorChanger(ConsoleColor.Red, "Please enter a number between 1 and 10.");
                        continue;
                    }

                    // Check if guess is incorrect and give hint
                    if (guess != correctNumber)
                    {
                        if (guess > correctNumber)
                        {
                            TextColorChanger(ConsoleColor.Yellow, "Too high, try again.");
                        }
                        else if (guess < correctNumber)
                        {
                            TextColorChanger(ConsoleColor.Yellow, "Too low, try again.");
                        }
                    }
                }

                // User guessed correctly
                TextColorChanger(ConsoleColor.Green, "Correct! Congratulations!!!");

                // Ask to play again
                Console.WriteLine("Play again? [Y or N]");
                string answer = Console.ReadLine().ToUpper();

                if (answer != "Y")
                {
                    break;
                }
            }
        }

        // Show application info
        static void GetAppInfo()
        {
            string appName = "Number Guesser Game";
            string appVersion = "1.0.0";
            string appAuthor = "Sam";

            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine("{0} Version: {1} by {2}", appName, appVersion, appAuthor);
            Console.ResetColor();
        }

        // Display message in color
        static void TextColorChanger(ConsoleColor color, string message)
        {
            Console.ForegroundColor = color;
            Console.WriteLine(message);
            Console.ResetColor();
        }

        // Greet user
        static void GreetUser()
        {
            Console.WriteLine("Hi user! What is your name?");
            string input = Console.ReadLine();
            Console.WriteLine("Welcome {0}! Let's play the Number Guesser game!", input);
        }
    }
}
