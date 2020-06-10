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

            bool isValid = ValidGuess(userGuess);

            if (isValid) Console.WriteLine("You guessed "+userGuess.Trim().ToUpper() );

            else Console.WriteLine($"Invalid guess!");

            Console.WriteLine("Game over!");
            
          



        }
        public static bool ValidGuess(string userGuess)
        {
            return (Regex.IsMatch(userGuess.ToUpper().Trim(), "^[A-ZÆØÅ]$"));
        }
    }
   
     
}
