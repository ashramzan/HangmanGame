namespace HangmanGame
{

    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    class HangmanGame
    {
        static void Main()
        {
            Console.WriteLine("This is Hangman!");
            string[] secretWords = new string[5];

            secretWords[0] = "agitated";
            secretWords[1] = "sleep";
            secretWords[2] = "balloon";
            secretWords[3] = "anaconda";
            secretWords[4] = "mountain";

            Random randGen = new Random();
            var choosingWord = randGen.Next(0, 4);
            string chosenWord = secretWords[choosingWord];
            char[] guess = new char[chosenWord.Length];

            for (int i = 0; i < chosenWord.Length; i++)
            {
                guess[i] = '_';
            }

            int lives = 7;
            Console.WriteLine($"Lives: {lives}");
            Console.WriteLine("Word: " + new string(guess));

            while (lives > 0)
            {
                Console.WriteLine("Please enter a letter:");
                char playerGuess = char.Parse(Console.ReadLine());

                bool correctGuess = false;

                for (int j = 0; j < chosenWord.Length; j++)
                {
                    if (playerGuess == chosenWord[j])
                    {
                        guess[j] = playerGuess;
                        correctGuess = true;
                    }
                }

                if (!correctGuess)
                {
                    lives--;
                    Console.WriteLine("Incorrect guess! Lives remaining: " + lives);
                }

                Console.WriteLine("Word: " + new string(guess));

                if (new string(guess) == chosenWord)
                {
                    Console.WriteLine("Congratulations! You won!");
                    break;
                }
            }

            if (lives == 0)
            {
                Console.WriteLine("Sorry, you lost! The word was: " + chosenWord);
            }
        }
    }
}