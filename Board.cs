using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace bbittlesBattleship
{
    /// <summary>
    /// Class that is a container for a game board consisting of chars
    /// Author: Ben Bittles
    /// </summary>
    class Board
    {
        //bool to determine if hacks are on or not
        public bool hacks;

        //Gameboard array
        public char[,] gameBoard = new char[10, 10];

        /// <summary>
        /// Fills gameboard with a single char, used for resetting the board
        /// </summary>
        /// <param name="newChar"></param>
        public void FillBoard(char newChar)
        {
            //for each element in gameboard
            for (int row = 0; row < gameBoard.GetLength(0); row++)
            {
                for (int col = 0; col < gameBoard.GetLength(1); col++)
                {
                    //fill element with given char
                    gameBoard[row, col] = newChar;
                }
            }
        }

        /// <summary>
        /// Reset board to blank state
        /// </summary>
        public void Reset()
        {
            //fill board with spaces to clear board
            FillBoard(' ');
        }

        /// <summary>
        /// Prints the numbers along the side of the board to show coordinate position
        /// </summary>
        /// <param name="row"></param>
        public void PrintBoardNums(int row)
        {
            //print the numbers that go down the side of the game board
            //for numbers 1-9
            if (row + 1 < gameBoard.GetLength(0))
            {
                Console.ForegroundColor = ConsoleColor.DarkRed;
                Console.Write("                                   {0}", row + 1);
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.Write("   |");
            }
            //for number 10
            else if (row + 1 == gameBoard.GetLength(0))
            {
                Console.ForegroundColor = ConsoleColor.DarkRed;
                Console.Write("                                  {0}", row + 1);
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.Write("   |");
            }
        }

        /// <summary>
        /// Prints the letters along the top of the board to show coordinate position
        /// </summary>
        public void PrintBoardLetters()
        {
            //print letter that go along top of gameboard
            Console.ForegroundColor = ConsoleColor.DarkRed;
            Console.WriteLine("                                         A   B   C   D   E   F   G   H   I   J");
            Console.ForegroundColor = ConsoleColor.Yellow;
        }

        /// <summary>
        /// Draws a horizontal line
        /// </summary>
        private void DrawHorizontalLine()
        {
            //use dashes to make horizontal like for gameboard formatting
            Console.WriteLine();
            Console.Write("                                       -");
            for (int i = 0; i < gameBoard.GetLength(1); i++)
            {
                Console.Write("----");
            }
            Console.WriteLine();
        }

        /// <summary>
        /// Display board with ships shown
        /// </summary>
        public void HacksOn()
        {
            //display for if hacks are on
            Console.WriteLine("\n");
            PrintBoardLetters();
            DrawHorizontalLine();
            //for each element in gameboard
            for (int row = 0; row < gameBoard.GetLength(0); row++)
            {
                PrintBoardNums(row);

                for (int col = 0; col < gameBoard.GetLength(1); col++)
                {
                    //if gameboard element does no contain a ship, print whatever the element is
                    if (gameBoard[row, col] == ' ' || gameBoard[row, col] == 'X' || gameBoard[row, col] == 'O')
                    {
                        Console.ForegroundColor = ConsoleColor.DarkMagenta;
                        Console.Write($" {gameBoard[row, col]}");
                        Console.ForegroundColor = ConsoleColor.Yellow;
                        Console.Write(" |");
                    }
                    //if gameboard element does contain a ship, print an s
                    else if (gameBoard[row, col] != ' ' || gameBoard[row, col] != 'X' || gameBoard[row, col] != 'O')
                    {
                        Console.Write(" S |");
                    }
                }
                DrawHorizontalLine();
            }
        }

        /// <summary>
        /// Display board with ships hidden, but show hits and misses
        /// </summary>
        public void HacksOff()
        {
            //display for if hacks are off
            Console.WriteLine("\n");
            PrintBoardLetters();
            DrawHorizontalLine();
            //for each element in gameboard
            for (int row = 0; row < gameBoard.GetLength(0); row++)
            {
                PrintBoardNums(row);

                for (int col = 0; col < gameBoard.GetLength(1); col++)
                {
                    //if gameboard element does no contain a ship, print whatever the element is
                    if (gameBoard[row, col] == 'X' || gameBoard[row, col] == 'O' || gameBoard[row, col] == ' ')
                    {
                        Console.ForegroundColor = ConsoleColor.DarkMagenta;
                        Console.Write($" {gameBoard[row, col]}");
                        Console.ForegroundColor = ConsoleColor.Yellow;
                        Console.Write(" |");
                    }
                    //if gameboard element does contain a ship, print an blank space
                    else if (gameBoard[row, col] != 'X' || gameBoard[row, col] != 'O' || gameBoard[row, col] != ' ')
                    {
                        Console.Write("   |");
                    }
                }
                DrawHorizontalLine();
            }
        }

        /// <summary>
        /// Display gameboard to user
        /// </summary>
        public void Display()
        {
            //if hacks are on, display gameboard with hacks
            Console.ForegroundColor = ConsoleColor.Yellow;
            if (hacks == true)
            {
                HacksOn();
            }
            //if hacks are off, display gameboard without hacks
            else if (hacks == false)
            {
                HacksOff();
            }
        }
    }
}
