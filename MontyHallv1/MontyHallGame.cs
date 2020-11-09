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
            //var prizeDoor = MontyHallv1.RandomDoor.RandomDoor();
            var convertedDoor = prizeDoor.RandomPrizeDoor();

            return selectedDoor == convertedDoor ? "serious" : "joke";
        }
    }
}

// TODO: For the AssignFixedPrizeToDoor method, possible logic:  assign "joke" to all three doors, have a random number assign "serious" to one door.
// Possible issues include not being able to test for specific doors. 

//var rnd = new Random();
//var randomDoor = rnd.Next(1, 4);

//var prizeDoor = rnd.Next(1, 4) switch