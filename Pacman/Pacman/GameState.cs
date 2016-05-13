using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Pacman
{
    //The different game states
    class GameState
    {
        private static bool menu, maze, powerup, enterName, highScore;

        public static void MenuTrue()
        {
            resetGameStates();
            menu = true;
        }

        public static void MazeTrue()
        {
            resetGameStates();
            maze = true;
        }

        public static void PowerupTrue()
        {
            resetGameStates();
            powerup = true;
        }

        public static void EnterNameTrue()
        {
            resetGameStates();
            enterName = true;
        }

        public static void HighScoreTrue()
        {
            resetGameStates();
            highScore = true;
        }

        public static bool Menu
        {
            get { return menu; }
        }

        public static bool Maze
        {
            get { return maze; }
        }

        public static bool Powerup
        {
            get { return powerup; }
        }

        public static bool EnterName
        {
            get { return enterName; }
        }

        public static bool HighScore
        {
            get { return highScore; }
        }

        private static void resetGameStates()
        {
            menu = false;
            maze = false;
            powerup = false;
            enterName = false;
            highScore = false;
        }
    }
}
