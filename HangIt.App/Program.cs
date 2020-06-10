using System;
using System.Text.RegularExpressions;


namespace HangIt.App
{
    class Program
    {
        static void Main(string[] args)
        {

            string secretWord = "GODFATHER";
            int guessesLeft = 3;
            while (true && (guessesLeft>0))
            {
                Console.WriteLine("Enter your guess");
                string userGuess = Console.ReadLine().ToUpper().Trim();
                

                bool isValid = ValidGuess(userGuess);

                if (isValid == true)
                {
                    bool correctGuess = secretWord.Contains(userGuess);
                    if (correctGuess)
                    {
                        Console.WriteLine("You guessed " + userGuess);
                        Console.WriteLine("Correct");
                        Console.WriteLine("Guesses left: {0}", guessesLeft);
                    }
                    else if (!correctGuess)
                    {
                        Console.WriteLine("You guessed " + userGuess);
                        Console.WriteLine("Wrong");
                        guessesLeft--;
                        Console.WriteLine("Guesses left: {0}", guessesLeft);
                    }


                }
                else Console.WriteLine($"Invalid guess!");

                


            }


            Console.WriteLine("Game over!");








        }
        public static bool ValidGuess(string userGuess)
        {
            return (Regex.IsMatch(userGuess.ToUpper().Trim(), "^[A-ZÆØÅ]$"));
        }
        
    }


}
