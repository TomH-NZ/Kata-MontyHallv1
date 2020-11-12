using System;
using System.Collections.Generic;

namespace MontyHallv1
{
    public class MontyHallGame
    {
        public List<string> Doors = new List<string>{"one", "two", "three"};

        public string PlayerSelection { get; }

        public Door Door
        {
            get { return _door; }
        }

        public MontyHallGame()
        {
            _door = new Door();
        }

        public MontyHallGame(string playerSelection)
        {
            _door = new Door();
            PlayerSelection = playerSelection;
        }
        
        private readonly Door _door;
    }
}