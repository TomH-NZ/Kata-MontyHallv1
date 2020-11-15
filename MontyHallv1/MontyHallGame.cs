using System;
using System.Collections.Generic;

namespace MontyHallv1
{
    public class MontyHallGame
    {
        public List<string> Doors = new List<string>{"one", "two", "three"};

        public string PlayerSelection { get; }

        public MontyHallGame()
        {
        }

        public MontyHallGame(string playerSelection)
        {
            PlayerSelection = playerSelection;
        }
    }
}