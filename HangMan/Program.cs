using System;
using System.Collections.Generic;
using System.Diagnostics.Eventing.Reader;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HangMan
{
    internal class Program
    {
        static void Main(string[] args)
        {
            const int NumberOfLives = 5;
            // Ask player 1 for their word and then clear the screen
            Console.Write("Player 1 Enter a word: ");
            string Player1Word = Console.ReadLine().ToUpper();
            Console.Clear();
            PlayHangMan(Player1Word, NumberOfLives);
            Console.ReadLine();

        }

        // Subroutine to start the game (for player 2)
        static void PlayHangMan(string SecretWord, int Lives)
        {
            // Create string "*..." for equal to the length of the secret word.
            List<char> GuessedWord = new List<char>();
            for (int i = 0; i < SecretWord.Length; i++)
            {
                GuessedWord.Add('*');
            }

            // Runs code for x amount of lives (set in NumberOfLives)
            while (Lives > 0)
            {
                // Gets the user's guess
                char Guess = ' ';

                bool InputValid = false;
                do
                {
                    for (int j = 0; j < Lives; j++)
                    {
                        Console.Write("♥");
                    }
                    Console.WriteLine(" Lives remaining.");
                    for (int j = 0; j < GuessedWord.Count; j++)
                    {
                        Console.Write(GuessedWord[j]);
                    }
                    Console.Write(" Make a guess: ");
                    try
                    {
                        Guess = Convert.ToChar(Console.ReadLine().ToUpper());
                        InputValid = true;
                    }
                    catch
                    {
                        Console.WriteLine("Please enter a single letter.");
                    }
                    
                } while (!InputValid);

                // Reveals the word in GuessedWord if the letter is correct.
                bool CorrectGuess = SecretWord.Contains(Guess);
                if (CorrectGuess)
                {
                    for (int letter = 0; letter < SecretWord.Length; letter++)
                    {
                        if (SecretWord[letter] == Guess)
                        {
                            GuessedWord[letter] = SecretWord[letter];
                        }
                    }
                    Lives++;
                }
                bool WordsEqual = true;
                for (int i = 0; i < SecretWord.Length; i++)
                {
                    if (SecretWord[i] != GuessedWord[i])
                    {
                        WordsEqual = false;
                    }
                }
                if (WordsEqual)
                {
                    break;
                }
                Lives--;
            }
            if (Lives == 0)
            {
                Console.WriteLine("Player 1 wins!");
                Console.WriteLine($"The word was {SecretWord}");
            }
            else
            {
                Console.WriteLine("Player 2 wins!");
            }
        }
    }
}
