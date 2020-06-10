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
            
           /* while (true) //guessLength > 1) 
            {


                if (Regex.IsMatch(userGuess.ToUpper().Trim(),"^[A-ZÆØÅ]$"))
                {
                    break;
                }
                else
                {
                    Console.WriteLine("Invalid guess");
                    Console.WriteLine("Guess again");
                    userGuess = Console.ReadLine();
                }

               

            }
            Console.WriteLine("You guessed: " + userGuess.ToUpper());
            Console.WriteLine("Game over!");*/



        }
        public static bool ValidGuess(string userGuess)
        {
            return (Regex.IsMatch(userGuess.ToUpper().Trim(), "^[A-ZÆØÅ]$"));
        }
    }
   
     
}
