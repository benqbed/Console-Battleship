using System;

namespace bbittlesBattleship 
{
    /// <summary>
    /// Program for our first of coding in CS3020
    /// Author: Ben Bittles
    /// </summary>
    class Program
    {
        //
        //Ok, so this method is pretty complicated. Basically it creates a
        //game object, then runs the rungame method which holds the game logic.
        /// <summary>
        /// Main method that runs the game. It makes a game object and runs it's rungame method which holds the game logic.
        /// </summary>
        /// <param name="args"></param>
        static void Main(string[] args)
        {
            //create game object
            Game game = new Game();
            //run game
            game.RunGame();
        }
    }
}
