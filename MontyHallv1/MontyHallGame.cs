using System;
using System.Collections.Generic;

namespace MontyHallv1
{
    public class MontyHallGame
    {
        public List<string> Doors = new List<string>{"one", "two", "three"};

        public MontyHallGame()
        {
        }

        public MontyHallGame(string playerSelection)
        {
            PlayerSelection = playerSelection;
        }

        public string PlayerSelection { get; }

        public string AssignFixedPrizeToDoor(string selectedDoor)
        {
            return selectedDoor == "two" ? "serious" : "joke";
        }

        public string AssignRandomPrizeToDoor(string selectedDoor, IRandomPrizeDoor prizeDoor)
        {
            var convertedDoor = prizeDoor.RandomPrizeDoor();

            return selectedDoor == convertedDoor ? "serious" : "joke";
        }
    }
}

//var rnd = new Random();
//var randomDoor = rnd.Next(1, 4);

//var prizeDoor = rnd.Next(1, 4) switch