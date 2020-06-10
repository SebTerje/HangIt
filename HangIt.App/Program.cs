using System;
using System.Text.RegularExpressions;


namespace HangIt.App
{
    class Program
    {
        static void Main(string[] args)
        {



            Console.WriteLine("Enter your guess");
            string userGuess = Console.ReadLine();
            int guessLength = userGuess.Length;
            
            while (guessLength > 1) 
            {
                Console.WriteLine("you can only guess one letter");
                Console.WriteLine("Guess again");
                userGuess = Console.ReadLine();

                if (Regex.IsMatch(userGuess.ToUpper().Trim(),"^[A-ZÆØÅ]$"))
                {
                    break;
                }

               

            }
            Console.WriteLine("You guessed: " + userGuess.ToUpper());
            Console.WriteLine("Game over!");



        }
    }
     
}
