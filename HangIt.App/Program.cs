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
            /*List<char> bars = new List<char>();
            foreach (char letter in bars)
            {
                Console.Write("- ");
            }
            Console.WriteLine();
            for (int i = 0; i < secretWord.Length; i++)
            {
                bars.Add('-');
            }*/
            
            
            
            int guessesLeft = 3;

            HashSet<char> guessedLetters = new HashSet<char>();
            while (true && (guessesLeft>0))
            {
                
                Console.WriteLine("Enter your guess");
                string userGuess = Console.ReadLine().ToUpper().Trim();
               /* int test = Array.IndexOf(bars, userGuess[0]);
               // bars[Array.IndexOf(bars, userGuess[0])] = char.Parse(userGuess);
                for (int i = 0; i < secretWord.Length; i++)
                {
                    if (char.Parse(userGuess) == bars[i])
                        bars[i] = char.Parse(userGuess);
                }
                Console.WriteLine(string.Join("", bars));*/

                

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
                    if (guessedLetters.Contains(char.Parse(userGuess)))
                    {
                        Console.WriteLine("You already guessed '{0}'", userGuess);
                        continue;
                    }

                    else if (correctGuess)
                    {
                        Console.WriteLine("You guessed " + userGuess);
                        guessedLetters.Add(char.Parse(userGuess));
                        
                        Console.ForegroundColor = ConsoleColor.Green;
                        Console.WriteLine("Correct");
                        Console.ResetColor();
                        Console.WriteLine("Guesses left: {0}", guessesLeft);
                        Console.WriteLine(MaskedSecretWord(secretWord,guessedLetters));
                       
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
                        Console.WriteLine(MaskedSecretWord(secretWord,guessedLetters));


                    }


                }
                else Console.WriteLine($"Invalid guess!");

                


            }


            Console.WriteLine("Game over!");








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

        public static bool ValidGuess(string userGuess)
        {
            return (Regex.IsMatch(userGuess.ToUpper().Trim(), "^[A-ZÆØÅ]$"));
        }
      

    }


}
