using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace bbittlesBattleship
{
    /// <summary>
    /// Game class which holds game logic
    /// Author: Ben Bittles
    /// </summary>
    class Game
    {
        #region Create Objects and Global Variable
        //Create ships
        Ship destroyer1 = new Ship(2, 'd');
        Ship destroyer2 = new Ship(2, 'D');
        Ship submarine1 = new Ship(3, 's');
        Ship submarine2 = new Ship(3, 'S');
        Ship battleship = new Ship(4, 'B');
        Ship carrier = new Ship(5, 'C');

        //Create list to store ships
        List<Ship> ships = new List<Ship>();

        //Create gameboard
        Board board = new Board();

        //Random num seed I found on stack overflow that is used to avoid duplicate random nums
        Random r = new Random(Guid.NewGuid().GetHashCode());

        //Bool to determine whether the game is over or not for looping
        public bool gameover = false;
        #endregion

        /// <summary>
        /// Primary method that runs game logic
        /// </summary>
        public void RunGame()
        {
            //Display welcome message, make sure board is clear, ask user if they want to play with hacks,
            //clear the console window, place ships, then show the current board and ask for user 
            //coordinate input.
            WelcomeMessage();
            board.Reset();
            HacksMode();
            ConsoleClear();
            AddShipsToList();
            ShipLogic();

            //loop over to get user input until all ships are sunk or until game is over
            while (gameover == false)
            {
                board.Display();
                GetUserInput();
            }

            //Prompt for closing window
            Console.WriteLine("                                         Press any key to close this window.");
            Console.ReadLine();
        }

        /// <summary>
        /// Check if all ships have been sunk, and if they have ask to start a new game
        /// </summary>
        public void ShipCheck()
        {
            //for each element in gameboard
            for (int i = 0; i < board.gameBoard.GetLength(0); i++)
            {
                for (int j = 0; j < board.gameBoard.GetLength(1); j++)
                {
                    //check each element for any ships left
                    if (board.gameBoard[i, j] == 'X' || board.gameBoard[i, j] == 'O' || board.gameBoard[i, j] == ' ')
                    {
                        //once all elements have been checked, if no ships were found, prompt to start
                        //new game or end game
                        if (i == board.gameBoard.GetLength(0) - 1 && j == board.gameBoard.GetLength(1) - 1)
                        {
                            Console.WriteLine("                                      YOU SUNK ALL THE SHIPS, YOURE A PRO GAMER ");
                            Console.WriteLine();
                            Console.WriteLine("\n                      Would you like to play again? \"Y\" for yes, otherwise press any key to exit.");
                            Console.Write("                                                         ");
                            //if player chooses to play again, reset board and set ships to new spots
                            string playAgain = Console.ReadLine();
                            if (playAgain.ToLower() == "y")
                            {
                                board.Reset();
                                HacksMode();
                                ConsoleClear();
                                ShipLogic();
                            }//if player chooses not to play again, end game loop and close game
                            else { gameover = true; }
                        }
                    }
                    //if ship is found, exit for loop
                    else
                    {
                        return;
                    }
                }
            }
        }

        /// <summary>
        /// Get user coordinate input
        /// </summary>
        public void GetUserInput()
        {
            //prompt user for input
            Console.WriteLine();
            Console.Write("                      Enter a coordinate using the letters and numbers of the board(example: c5)\n");
            Console.Write("                                                        ");
            //get user coordinate input
            string userInput = "  ";
            userInput = Console.ReadLine();
            //if user coordinates does not contain 10 for the number
            if (userInput.Length == 2)
            {
                //check if first user provided coordinate is a letter or number and that letter is in bounds of gameboard
                if (Char.IsLetter(userInput[0]) && userInput[0].ToString().ToUpper().IndexOfAny("ABCDEFGHIJ".ToCharArray()) != -1)
                {
                    if (Char.IsDigit(userInput[1]))
                    {
                        //put user provided coordinates in terms of the game board
                        char colChar = userInput[0];
                        int col = char.ToUpper(colChar) - 65;
                        int row = userInput[1] - 49;
                        //check if gameboard has a ship at coordinates
                        HitOrMiss(row, col);
                    }//if input isnt valid print message prompting user to try a differet input 
                    else
                    {
                        Console.Clear();
                        Console.WriteLine("                                            Invalid input, please try again.");
                    }
                }
                else if (Char.IsDigit(userInput[0]))
                {
                    if (Char.IsLetter(userInput[1]) && userInput[1].ToString().ToUpper().IndexOfAny("ABCDEFGHIJ".ToCharArray()) != -1)
                    {
                        //put user provided coordinates in terms of the game board
                        char colChar = userInput[1];
                        int col = char.ToUpper(colChar) - 65;
                        int row = userInput[0] - 49;
                        //check if gameboard has a ship at coordinates
                        HitOrMiss(row, col);
                    }//if input isnt valid print message prompting user to try a differet input
                    else
                    {
                        Console.Clear();
                        Console.WriteLine("                                            Invalid input, please try again.");
                    }
                }
                else
                {
                    Console.Clear();
                    Console.WriteLine("                                            Invalid input, please try again.");
                }
            }
            //if user coordiantes contains 10 for the number
            else if (userInput.Length == 3)
            {
                //check if first user provided coordinate is a letter or number and that letter is in bounds of gameboard
                if (Char.IsLetter(userInput[0]) && userInput[0].ToString().ToUpper().IndexOfAny("ABCDEFGHIJ".ToCharArray()) != -1)
                {
                    if (Char.IsDigit(userInput[1]))
                    {
                        //put user provided coordinates in terms of the game board
                        char colChar = userInput[0];
                        int col = char.ToUpper(colChar) - 65;
                        int row = 9;
                        //check if gameboard has a ship at coordinates
                        HitOrMiss(row, col);
                    }//if input isnt valid print message prompting user to try a differet input 
                    else
                    {
                        Console.Clear();
                        Console.WriteLine("                                            Invalid input, please try again.");
                    }
                }
                else if (Char.IsDigit(userInput[0]))
                {
                    if (Char.IsLetter(userInput[2]) && userInput[2].ToString().ToUpper().IndexOfAny("ABCDEFGHIJ".ToCharArray()) != -1)
                    {
                        //put user provided coordinates in terms of the game board
                        char colChar = userInput[2];
                        int col = char.ToUpper(colChar) - 65;
                        int row = 9;
                        //check if gameboard has a ship at coordinates
                        HitOrMiss(row, col);
                    }//if input isnt valid print message prompting user to try a differet input 
                    else
                    {
                        Console.Clear();
                        Console.WriteLine("                                            Invalid input, please try again.");
                    }
                }
                else
                {
                    Console.Clear();
                    Console.WriteLine("                                            Invalid input, please try again.");
                }
            }
            //if input isnt valid print message prompting user to try a differet input 
            else
            {
                Console.Clear();
                Console.WriteLine("                                            Invalid input, please try again.");
            }
        }

        /// <summary>
        /// Check if user provided coordinate is a hit or a miss
        /// </summary>
        /// <param name="usrRow"></param>
        /// <param name="usrCol"></param>
        public void HitOrMiss(int usrRow, int usrCol)
        {
            //I guess they never miss huh

            //if gameboard element contains a part of a ship
            if (board.gameBoard[usrRow, usrCol] != ' ' && board.gameBoard[usrRow, usrCol] != 'O' && board.gameBoard[usrRow, usrCol] != 'X')
            {
                //console formatting and print message saying ship was hit
                Console.ForegroundColor = ConsoleColor.Green;
                Console.Clear();
                Console.WriteLine("\n                                               You got a hit! Keep it up!");
                //set ship hit position to x to mark hit
                char shipType = board.gameBoard[usrRow, usrCol];
                board.gameBoard[usrRow, usrCol] = 'X';
                //for each element in board
                for (int i = 0; i < board.gameBoard.GetLength(0); i++)
                {
                    for (int j = 0; j < board.gameBoard.GetLength(1); j++)
                    {
                        //check if ship still exists without being fully hit
                        if (board.gameBoard[i, j] != shipType)
                        {
                            //if all elements have been checked and ship is fully hit, display sunk message and check if all ships are sunk
                            if (i == board.gameBoard.GetLength(0) - 1 && j == board.gameBoard.GetLength(1) - 1)
                            {
                                Console.ForegroundColor = ConsoleColor.Magenta;
                                Console.WriteLine("                                                 YOU SUNK {0}", ShipType(shipType));
                                ShipCheck();
                            }
                        }
                        //if ship does still exist exit loop
                        else
                        {
                            return;
                        }
                    }
                }
            }
            //if user provided coordinates have already been guessed, ask them for different set of coordinates
            else if (board.gameBoard[usrRow, usrCol] == 'X' || board.gameBoard[usrRow, usrCol] == 'O')
            {
                Console.ForegroundColor = ConsoleColor.Gray;
                Console.WriteLine("                                 You've already tried that spot! Try another instead!");
            }
            //if user coordinates miss a ship, print miss message and assign element a miss symbol
            else
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.Clear();
                Console.WriteLine("\n                                                 You missed! Try again!");
                board.gameBoard[usrRow, usrCol] = 'O';
            }
        }

        /// <summary>
        /// Determines which ship to return for ship sunk messages
        /// </summary>
        /// <param name="shipID"></param>
        /// <returns></returns>
        public string ShipType(char shipID)
        {
            //get the ship type to display which ship has sunk
            return shipID switch
            {
                'D' => "A Destoyer",
                'd' => "A Destroyer",
                'S' => "A Submarine",
                's' => "A Submarine",
                'C' => "The Carrier",
                'B' => "The Battleship",
                _ => " "
            };
        }

        /// <summary>
        /// Simple method to clear the console screen after 3 seconds to keep things kinda tidy
        /// </summary>
        public void ConsoleClear()
        {
            //wait 3 seconds for "d r a m a t i c   e f f e c t" then clear console screen and move onto printing gameboard
            Console.Write("\n                                     Building gameboard, please wait momentarily.\n                                                      ");
            for (int i = 0; i < 6; i++)
            {
                System.Threading.Thread.Sleep(500);
                Console.Write(".");
            }
            System.Threading.Thread.Sleep(500);
            Console.Clear();
        }

        /// <summary>
        /// Welcome message to welcome user to game
        /// </summary>
        public void WelcomeMessage()
        {
            //set console title and display battleship ascii logo
            Console.Title = "THE BIGGEST AND BEST BATTLESHIP GAME TO EVER BATTLESHIP";
            Console.ForegroundColor = ConsoleColor.Blue;

            string titleString = @"
                              ______  ___ _____ _____ _      _____ _____ _   _ ___________ 
                              | ___ \/ _ \_   _|_   _| |    |  ___/  ___| | | |_   _| ___ \
                              | |_/ / /_\ \| |   | | | |    | |__ \ `--.| |_| | | | | |_/ /
                              | ___ \  _  || |   | | | |    |  __| `--. \  _  | | | |  __/ 
                              | |_/ / | | || |   | | | |____| |___/\__/ / | | |_| |_| |    
                              \____/\_| |_/\_/   \_/ \_____/\____/\____/\_| |_/\___/\_|

                                ";
            Console.WriteLine();
            Console.WriteLine(titleString);
            Console.WriteLine();
        }

        /// <summary>
        /// Asks user if they want to use hacks, which will display ship locations
        /// </summary>
        public void HacksMode()
        {
            //ask user if they want to play with hacks on
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("                                         Would you like to play with hacks on?\n            " +
                "Enter \"Y\" followed by the enter key if you do, otherwise hit any key followed by the enter key.");
            Console.WriteLine();
            Console.Write("                                                         ");
            //if player says yes, set board hacks to true
            string usrHacks = Console.ReadLine();
            if (usrHacks.ToLower() == "y")
            {
                board.hacks = true;
            }
        }

        /// <summary>
        /// Adds ship objects to a list that can be iterated through
        /// </summary>
        public void AddShipsToList()
        {
            //add ship objects to list to iterate through
            ships.Add(destroyer1);
            ships.Add(destroyer2);
            ships.Add(submarine1);
            ships.Add(submarine2);
            ships.Add(battleship);
            ships.Add(carrier);
        }

        /// <summary>
        /// Used for checking ship positions and debugging, not used in final program run
        /// </summary>
        /// <param name="rowCoord"></param>
        /// <param name="colCoord"></param>
        /// <param name="ship"></param>
        public void DebugMessage(int rowCoord, int colCoord, Ship ship)
        {
            //NOT USED IN FINAL EXECUTION
            //debug message that displays ships position and length
            Console.WriteLine("Debugging info\n--------------------");
            Console.WriteLine("{0} , {1}", rowCoord, colCoord);
            Console.WriteLine(ship.shipLength);
            Console.WriteLine("--------------------\n");
        }

        /// <summary>
        /// Places ships horizontally on the gameboard
        /// </summary>
        /// <param name="col"></param>
        /// <param name="row"></param>
        /// <param name="currentShip"></param>
        public void PlaceShipHorizontal(int col, int row, Ship currentShip)
        {
            // check if ship will go off edge horizontally
            bool shipNotOutBoard = false;
            while (shipNotOutBoard == false)
            {
                //if ship will not hang off board
                if ((col + currentShip.shipLength) - 1 < 10)
                {
                    //for all positions that you wanna place the ship
                    for (int i = col; i < col + currentShip.shipLength; i++)
                    {
                        //check if each spot is open
                        if (board.gameBoard[row, i] == ' ')
                        {
                            //if youve gone through each one and the if hasnt broken
                            if (i == (col + currentShip.shipLength) - 1)
                            {
                                shipNotOutBoard = true;
                                currentShip.bowy = row;
                                currentShip.bowx = col;
                                //go through the positions and place an char to indicate the ship type
                                for (int i1 = col; i1 < col + currentShip.shipLength; i1++)
                                {
                                    board.gameBoard[row, i1] = currentShip.shipType;
                                }
                            }
                        }
                        //if coordinate spot is not open, get new coordinate pair
                        else
                        {
                            row = r.Next(board.gameBoard.GetLength(0));
                            col = r.Next(board.gameBoard.GetLength(1));
                            break;
                        }
                    }
                }
                //if ship will hang off board, get new coordinate pair
                else
                {
                    row = r.Next(board.gameBoard.GetLength(0));
                    col = r.Next(board.gameBoard.GetLength(1));
                }
            }
        }

        /// <summary>
        /// Places ships vertically on the gameboard
        /// </summary>
        /// <param name="col"></param>
        /// <param name="row"></param>
        /// <param name="currentShip"></param>
        public void PlaceShipVertical(int col, int row, Ship currentShip)
        {
            // check if ship will go off edge vertically
            bool shipNotOutBoard = false;
            while (shipNotOutBoard == false)
            {
                //if ship will not hang off board
                if ((row + currentShip.shipLength) - 1 < 10)
                {
                    //for all positions that you wanna place the ship
                    for (int i = row; i < row + currentShip.shipLength; i++)
                    {
                        //check if each spot is open
                        if (board.gameBoard[i, col] == ' ')
                        {
                            //if youve gone through each one and the if hasnt broken
                            if (i == (row + currentShip.shipLength) - 1)
                            {
                                shipNotOutBoard = true;
                                currentShip.bowy = row;
                                currentShip.bowx = col;
                                //go through the positions and place an s to indicate the ship
                                for (int i1 = row; i1 < row + currentShip.shipLength; i1++)
                                {
                                    board.gameBoard[i1, col] = currentShip.shipType;
                                }
                            }
                        }
                        //if coordinate spot is not open, get new coordinate pair
                        else
                        {
                            row = r.Next(board.gameBoard.GetLength(0));
                            col = r.Next(board.gameBoard.GetLength(1));
                            break;
                        }
                    }
                }
                //if ship will hang off board, get new coordinate pair
                else
                {
                    row = r.Next(board.gameBoard.GetLength(0));
                    col = r.Next(board.gameBoard.GetLength(1));
                }
            }
        }

        /// <summary>
        /// Main ship placement method, calls PlaceShipHorizontal and PlaceShipVertical
        /// </summary>
        public void ShipLogic()
        {
            //for each ship
            foreach (var ship in ships)
            {
                //Set variables to random coordinates
                int rowCoord = r.Next(board.gameBoard.GetLength(0));
                int colCoord = r.Next(board.gameBoard.GetLength(1));

                bool shipPositionValid = false;
                while (shipPositionValid == false)
                {
                    //if initial coordinate is empty
                    if (board.gameBoard[rowCoord, colCoord] == ' ')
                    {
                        //pick direction randomly
                        int shipDirection = r.Next(0, 2);

                        //if ship direction is horizontal
                        if (shipDirection == 0)
                        {
                            //place ship horizontally
                            PlaceShipHorizontal(colCoord, rowCoord, ship);
                            shipPositionValid = true;
                        }
                        //if ship direction is vertical
                        else if (shipDirection == 1)
                        {
                            //place ship vertically
                            PlaceShipVertical(colCoord, rowCoord, ship);
                            shipPositionValid = true;
                        }
                    }
                    //if initial coordinate is filled, get new coordinate pair
                    else
                    {
                        rowCoord = r.Next(board.gameBoard.GetLength(0));
                        colCoord = r.Next(board.gameBoard.GetLength(1));
                    }
                }
            }
        }
    }
}