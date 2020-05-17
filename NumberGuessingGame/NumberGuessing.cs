using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Security.Policy;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace NumberGuessingGame
{
    public class NumberGuessing
    {
        int playerGamesWon = 0;
        int computerGamesWon = 0;
        public void TitleScreen()
        {   
            string titleScreen = System.IO.File.ReadAllText(@"TitleScreen.txt");
            Console.ForegroundColor = ConsoleColor.DarkCyan;
            Console.WriteLine(titleScreen);
            Console.ReadKey();
            Console.Clear();
            Console.ForegroundColor = ConsoleColor.Gray;
        }
        public void DifficultySelect()
        {
            bool keepRunning = true;
            while (keepRunning)
            {
                Console.WriteLine("Select your difficulty:\n 1. Easy \n 2. Medium \n 3. Hard");
                string gameSelect = Console.ReadLine();
                switch (gameSelect)
                {
                    case "1":
                    case "Easy":
                    case "easy":
                        Console.Clear();
                        EasyGame();
                        keepRunning = false;
                        break;
                    case "2":
                    case "Medium":
                    case "medium":
                        Console.Clear();
                        Game();
                        keepRunning = false;
                        break;
                    case "3":
                    case "Hard":
                    case "hard":
                        Console.Clear();
                        HardGame();
                        keepRunning = false;
                        break;
                    default:
                        Console.WriteLine("Please select a valid option");
                        Console.ReadLine();
                        break;
                }
            }

        }
        public void EasyGame()
        {       
            string win = System.IO.File.ReadAllText(@"Win.txt");
            Console.WriteLine("\nPlayer games won: " + playerGamesWon);
            Console.WriteLine("Computer games won: " + computerGamesWon + "\n");
            Console.WriteLine("Welcome! You have 5 chances to guess the designated number. \nThe number is between 5 - 80.");
            Random random = new Random();
            int number = random.Next(5, 80);
            //Console.WriteLine("This is the generated number: " + number);
            int availableGuesses = 5;
            bool IsEqual = false;
            while (!IsEqual)
            {
                if (availableGuesses > 0)
                {
                    int numberGuess;
                    try
                    {
                        numberGuess = Convert.ToInt32(Console.ReadLine());
                    }
                    catch //(Exception e)
                    {
                        //Console.WriteLine(e.Message);
                        Console.ForegroundColor = ConsoleColor.DarkRed;
                        Console.WriteLine("That was dumb and its going to cost one of your guesses. \nI told you to input a number...");
                        availableGuesses--;
                        Console.ForegroundColor = ConsoleColor.Gray;
                        Console.WriteLine("Available guesses left: " + availableGuesses);
                        continue;
                    }
                    if (numberGuess == 1150)
                    {
                        Console.ForegroundColor = ConsoleColor.DarkGreen;
                        Console.WriteLine(win);
                        Console.ForegroundColor = ConsoleColor.Cyan;
                        Console.WriteLine("\nThank you for playing!");
                        playerGamesWon += 1150;
                        DoOver();
                        IsEqual = true;
                    }
                    else if (numberGuess <= 80 && numberGuess >= 5)
                    {
                        if (numberGuess > number)
                        {
                            Console.ForegroundColor = ConsoleColor.DarkBlue;
                            Console.WriteLine("Too High");
                            availableGuesses--;
                            if (numberGuess >= number + 15)
                            {
                                Console.ForegroundColor = ConsoleColor.DarkGray;
                                Console.WriteLine("Way too high..");
                            }
                            else if (numberGuess <= number + 5 && numberGuess >= number + 2)
                            {
                                Console.ForegroundColor = ConsoleColor.Blue;
                                Console.WriteLine("Getting close..");
                            }
                            else if (numberGuess < number + 4)
                            {
                                Console.ForegroundColor = ConsoleColor.Red;
                                Console.WriteLine("You're so close!");
                            }
                            Console.ForegroundColor = ConsoleColor.White;
                            Console.WriteLine("Available guesses left: " + availableGuesses);
                        }
                        else if (numberGuess < number)
                        {
                            Console.ForegroundColor = ConsoleColor.DarkYellow;
                            Console.WriteLine("Too Low");
                            availableGuesses--;
                            if (numberGuess <= number - 15)
                            {
                                Console.ForegroundColor = ConsoleColor.DarkGray;
                                Console.WriteLine("Way too low..");

                            }
                            else if (numberGuess >= number - 5 && numberGuess <= number - 2)
                            {
                                Console.ForegroundColor = ConsoleColor.Yellow;
                                Console.WriteLine("Getting close..");
                            }
                            else if (numberGuess > number - 4)
                            {
                                Console.ForegroundColor = ConsoleColor.Red;
                                Console.WriteLine("You're so close!");
                            }
                            Console.ForegroundColor = ConsoleColor.White;
                            Console.WriteLine("Available guesses left: " + availableGuesses);
                        }
                        else
                        {
                            Console.ForegroundColor = ConsoleColor.DarkGreen;
                            Console.WriteLine("\nYou guessed correctly!!");
                            Console.ForegroundColor = ConsoleColor.Cyan;
                            Console.WriteLine("\nThank you for playing!");
                            playerGamesWon++;
                            DoOver();
                            IsEqual = true;
                        }
                    }
                    else
                    {
                        Console.ForegroundColor = ConsoleColor.DarkMagenta;
                        Console.WriteLine("You're REALLY bad at this. Read the instructions!!!");
                        availableGuesses--;
                        Console.ForegroundColor = ConsoleColor.White;
                        Console.WriteLine("Available guesses left: " + availableGuesses);
                    }
                }
                else
                {
                    Console.WriteLine("\nYou are out of guesses! ");
                    Console.ForegroundColor = ConsoleColor.DarkRed;
                    Console.WriteLine("GAME OVER!!");
                    Console.ForegroundColor = ConsoleColor.White;
                    computerGamesWon++;
                    DoOver();
                    IsEqual = true;
                }
            }
        }
        public void HardGame()
        {       
            string win = System.IO.File.ReadAllText(@"Win.txt");
            Console.WriteLine("\nPlayer games won: " + playerGamesWon);
            Console.WriteLine("Computer games won: " + computerGamesWon + "\n");
            Console.WriteLine("Welcome! You have 5 chances to guess the designated number. \nThe number is between 5 - 200.");
            Random random = new Random();
            int number = random.Next(5, 200);
            //Console.WriteLine("This is the generated number: " + number);
            int availableGuesses = 5;
            bool IsEqual = false;
            while (!IsEqual)
            {
                if (availableGuesses > 0)
                {
                    int numberGuess;
                    try
                    {
                        numberGuess = Convert.ToInt32(Console.ReadLine());
                    }
                    catch //(Exception e)
                    {
                        //Console.WriteLine(e.Message);
                        Console.ForegroundColor = ConsoleColor.DarkRed;
                        Console.WriteLine("That was dumb and its going to cost one of your guesses. \nI told you to input a number...");
                        availableGuesses--;
                        Console.ForegroundColor = ConsoleColor.Gray;
                        Console.WriteLine("Available guesses left: " + availableGuesses);
                        continue;
                    }
                    if (numberGuess == 1150)
                    {
                        Console.ForegroundColor = ConsoleColor.DarkGreen;
                        Console.WriteLine(win);
                        Console.ForegroundColor = ConsoleColor.Cyan;
                        Console.WriteLine("\nThank you for playing!");
                        playerGamesWon += 1150;
                        DoOver();
                        IsEqual = true;
                    }
                    else if (numberGuess <= 200 && numberGuess >= 5)
                    {
                        if (numberGuess > number)
                        {
                            Console.ForegroundColor = ConsoleColor.DarkBlue;
                            Console.WriteLine("Too High");
                            availableGuesses--;
                            if (numberGuess < number + 4)
                            {
                                Console.ForegroundColor = ConsoleColor.Red;
                                Console.WriteLine("You're so close!");
                            }
                            Console.ForegroundColor = ConsoleColor.White;
                            Console.WriteLine("Available guesses left: " + availableGuesses);
                        }
                        else if (numberGuess < number)
                        {
                            Console.ForegroundColor = ConsoleColor.DarkYellow;
                            Console.WriteLine("Too Low");
                            availableGuesses--;
                            if (numberGuess > number - 4)
                            {
                                Console.ForegroundColor = ConsoleColor.Red;
                                Console.WriteLine("You're so close!");
                            }
                            Console.ForegroundColor = ConsoleColor.White;
                            Console.WriteLine("Available guesses left: " + availableGuesses);
                        }
                        else
                        {
                            Console.ForegroundColor = ConsoleColor.DarkGreen;
                            Console.WriteLine("\nYou guessed correctly!!");
                            Console.ForegroundColor = ConsoleColor.Cyan;
                            Console.WriteLine("\nThank you for playing!");
                            playerGamesWon++;
                            DoOver();
                            IsEqual = true;
                        }
                    }
                    else
                    {
                        Console.ForegroundColor = ConsoleColor.DarkMagenta;
                        Console.WriteLine("You're REALLY bad at this. Read the instructions!!!");
                        availableGuesses--;
                        Console.ForegroundColor = ConsoleColor.White;
                        Console.WriteLine("Available guesses left: " + availableGuesses);
                    }
                }
                else
                {
                    Console.WriteLine("\nYou are out of guesses! ");
                    Console.ForegroundColor = ConsoleColor.DarkRed;
                    Console.WriteLine("GAME OVER!!");
                    Console.ForegroundColor = ConsoleColor.White;
                    computerGamesWon++;
                    DoOver();
                    IsEqual = true;
                }
            }
        }
        public void Game()
        {       
            string win = System.IO.File.ReadAllText(@"Win.txt");
            Console.WriteLine("\nPlayer games won: " + playerGamesWon);
            Console.WriteLine("Computer games won: " + computerGamesWon + "\n");
            Console.WriteLine("Welcome! You have 5 chances to guess the designated number. \nThe number is between 5 - 100.");
            Random random = new Random();
            int number = random.Next(5, 100);
            //Console.WriteLine("This is the generated number: " + number);
            int availableGuesses = 5;
            bool IsEqual = false;
            while (!IsEqual)
            {
                if (availableGuesses > 0)
                {
                    int numberGuess;
                    try
                    {
                        numberGuess = Convert.ToInt32(Console.ReadLine());
                    }
                    catch //(Exception e)
                    {
                        //Console.WriteLine(e.Message);
                        Console.ForegroundColor = ConsoleColor.DarkRed;
                        Console.WriteLine("That was dumb and its going to cost one of your guesses. \nI told you to input a number...");
                        availableGuesses--;
                        Console.ForegroundColor = ConsoleColor.Gray;
                        Console.WriteLine("Available guesses left: " + availableGuesses);
                        continue;
                    }
                    if (numberGuess == 1150)
                    {
                        Console.ForegroundColor = ConsoleColor.DarkGreen;
                        Console.WriteLine(win);
                        Console.ForegroundColor = ConsoleColor.Cyan;
                        Console.WriteLine("\nThank you for playing!");
                        playerGamesWon += 1150;
                        DoOver();
                        IsEqual = true;
                    }
                    else if (numberGuess <= 100 && numberGuess >= 5)
                    {
                        if (numberGuess > number)
                        {
                            Console.ForegroundColor = ConsoleColor.DarkBlue;
                            Console.WriteLine("Too High");
                            availableGuesses--;
                            if (numberGuess >= number + 15)
                            {
                                Console.ForegroundColor = ConsoleColor.DarkGray;
                                Console.WriteLine("Way too high..");
                            }
                            else if (numberGuess < number + 4)
                            {
                                Console.ForegroundColor = ConsoleColor.Red;
                                Console.WriteLine("You're so close!");
                            }
                            Console.ForegroundColor = ConsoleColor.White;
                            Console.WriteLine("Available guesses left: " + availableGuesses);
                        }
                        else if (numberGuess < number)
                        {
                            Console.ForegroundColor = ConsoleColor.DarkYellow;
                            Console.WriteLine("Too Low");
                            availableGuesses--;
                            if (numberGuess <= number - 15)
                            {
                                Console.ForegroundColor = ConsoleColor.DarkGray;
                                Console.WriteLine("Way too low..");

                            }
                            else if (numberGuess > number - 4)
                            {
                                Console.ForegroundColor = ConsoleColor.Red;
                                Console.WriteLine("You're so close!");
                            }
                            Console.ForegroundColor = ConsoleColor.White;
                            Console.WriteLine("Available guesses left: " + availableGuesses);
                        }
                        else
                        {
                            Console.ForegroundColor = ConsoleColor.DarkGreen;
                            Console.WriteLine("\nYou guessed correctly!!");
                            Console.ForegroundColor = ConsoleColor.Cyan;
                            Console.WriteLine("\nThank you for playing!");
                            playerGamesWon++;
                            DoOver();
                            IsEqual = true;
                        }
                    }
                    else
                    {
                        Console.ForegroundColor = ConsoleColor.DarkMagenta;
                        Console.WriteLine("You're REALLY bad at this. Read the instructions!!!");
                        availableGuesses--;
                        Console.ForegroundColor = ConsoleColor.White;
                        Console.WriteLine("Available guesses left: " + availableGuesses);
                    }
                }
                else
                {
                    Console.WriteLine("\nYou are out of guesses! ");
                    Console.ForegroundColor = ConsoleColor.DarkRed;
                    Console.WriteLine("GAME OVER!!");
                    Console.ForegroundColor = ConsoleColor.White;
                    computerGamesWon++;
                    DoOver();
                    IsEqual = true;
                }
            }
        }
        public void DoOver()
        {
            bool continueToRun = true;
            while (continueToRun)
            {
                Console.ForegroundColor = ConsoleColor.White;
                Console.WriteLine("Would you like to play again? \n 1. Y \n 2. N");
                string playAgain = Console.ReadLine();
                switch (playAgain)
                {
                    case "1":
                    case "Y":
                    case "y":
                    case "yes":
                    case "Yes":
                        Console.Clear();
                        DifficultySelect();
                        continueToRun = false;
                        break;
                    case "2":
                    case "N":
                    case "n":
                    case "no":
                    case "No":
                        Console.WriteLine("Goodbye!");
                        Thread.Sleep(2500);
                        continueToRun = false;
                        break;
                    default:
                        Console.WriteLine("Please enter a valid option.");
                        Console.ReadLine();
                        break;
                }
            }
        }
    }
}








