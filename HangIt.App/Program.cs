using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;


namespace HangIt.App
{
    class Program
    {
        static void Main(string[] args)
        {

            string secretWord = "GODFATHER";
            int secretWordLength = secretWord.Length;
            //Console.WriteLine(Underscores(secretWordLength));
            int guessesLeft = 3;

            HashSet<char> guessedLetters = new HashSet<char>();
            while (true && (guessesLeft>0))
            {
                
                Console.WriteLine("Enter your guess");
                string userGuess = Console.ReadLine().ToUpper().Trim();
                Console.WriteLine("The guessed letters are: ");
                foreach (var character in guessedLetters)
                {
                    Console.Write(character + " ");
                    
                }
                Console.WriteLine();


                bool isValid = ValidGuess(userGuess);

                if (isValid == true)
                {
                    bool correctGuess = secretWord.Contains(userGuess);
                    if (correctGuess)
                    {
                        Console.WriteLine("You guessed " + userGuess);
                        guessedLetters.Add(char.Parse(userGuess));
                        
                        Console.ForegroundColor = ConsoleColor.Green;
                        Console.WriteLine("Correct");
                        Console.ResetColor();
                        Console.WriteLine("Guesses left: {0}", guessesLeft);
                        Console.Clear();
                    }
                    else if (!correctGuess)
                    {
                        Console.WriteLine("You guessed " + userGuess);
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine("Wrong");
                        Console.ResetColor();
                        guessesLeft--;
                        Console.WriteLine("Guesses left: {0}", guessesLeft);
                        guessedLetters.Add(char.Parse(userGuess));
                        Console.Clear();


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
        static string Underscores(int n)
        {
            return new String('_', n);
        }

    }


}
