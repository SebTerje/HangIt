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

            string secretWord = "HUND";
            int guessesLeft = 10;

            HashSet<char> guessedLetters = new HashSet<char>();
            while (true && (guessesLeft>0))
            {
                if (Win(secretWord, guessedLetters) == true)
                {
                    SuccessLine("YAAAAAAAAAY!" + "\nYou did it!!!!");
                    break;
                }
                
               else 
                
                Console.WriteLine("Enter your guess");
                string userGuess = Console.ReadLine().ToUpper().Trim();
               
                bool isValid = ValidGuess(userGuess);

                if (isValid == true)
                {
                    bool correctGuess = secretWord.Contains(userGuess);

                    
                    if (guessedLetters.Contains(char.Parse(userGuess)))
                    {
                        Console.Clear();
                        Console.WriteLine("The guessed letters are: ");
                        foreach (var character in guessedLetters)
                        {
                            Console.Write(character + " ");

                        }
                        Console.WriteLine();
                        Console.WriteLine("You already guessed '{0}'", userGuess);
                        Console.ReadKey(true);
                        continue;

                    }

                    else if (correctGuess)
                    {
                        Console.Clear();
                        Console.WriteLine("The guessed letters are: ");
                        foreach (var character in guessedLetters)
                        {
                            Console.Write(character + " ");

                        }
                        Console.WriteLine();
                        Console.WriteLine("You guessed " + userGuess);
                        guessedLetters.Add(char.Parse(userGuess));
                        SuccessLine("Correct");
                        Console.WriteLine("Guesses left: {0}", guessesLeft);
                        Console.WriteLine(MaskedSecretWord(secretWord, guessedLetters));
                        Console.ReadKey(true);

                    }
                    else if (!correctGuess)
                    {
                        Console.Clear();
                        Console.WriteLine("The guessed letters are: ");
                        foreach (var character in guessedLetters)
                        {
                            Console.Write(character + " ");

                        }
                        Console.WriteLine();
                        Console.WriteLine("You guessed " + userGuess);
                        ErrorLine("Wrong");
                        guessesLeft--;
                        Console.WriteLine("Guesses left: {0}", guessesLeft);
                        guessedLetters.Add(char.Parse(userGuess));
                        Console.WriteLine(MaskedSecretWord(secretWord, guessedLetters));
                        Console.ReadKey(true);

                    }


                }


                

                else ErrorLine($"Invalid guess!");
            }

            if (guessesLeft == 0)
            {
                Console.WriteLine("Game over!");
            }

            
                
            







        }

        private static void ErrorLine(string message)
        {
            
            Console.ForegroundColor = ConsoleColor.Red;
            Console.BackgroundColor = ConsoleColor.Magenta;
            Console.WriteLine(message);
            Console.ResetColor();
        }
        private static void SuccessLine(string message)
        {
            
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine(message);
            Console.ResetColor();
        }

        private static string MaskedSecretWord(string secretWord, HashSet<char> guessedLetters)
       {
            string result = "";
            
            foreach (char i in secretWord)
            {
                if (guessedLetters.Contains(i))
                    result += i;
                else
                    result += '-';
            }
           

            return result;
       }
        private static bool Win (string secretWord, HashSet<char> guessedLetters)
        {
            if (MaskedSecretWord(secretWord, guessedLetters) == secretWord)
                return true;
            
            else
                return false;
        }

        public static bool ValidGuess(string userGuess)
        {
            return (Regex.IsMatch(userGuess.ToUpper().Trim(), "^[A-ZÆØÅ]$"));
        }
        
        
      

    }


}
