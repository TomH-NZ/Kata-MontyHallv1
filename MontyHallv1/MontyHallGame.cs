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
        
        public string AssignRandomPrizeToDoor(string selectedDoor, IRandomPrizeDoor prizeDoor)
        {
            var convertedDoor = prizeDoor.RandomPrizeDoor();

            return selectedDoor == convertedDoor ? "serious" : "joke";
        }
    }
}