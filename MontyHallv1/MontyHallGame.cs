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

        public string AssignPrizeToDoor(string selectedDoor)
        {
            return selectedDoor == "two" ? "serious" : "joke";
        }

        public string AssignPrizeToRandomDoor(string selectedDoor)
        {
            var rnd = new Random();
            //var randomDoor = rnd.Next(1, 4);

            var prizeDoor = rnd.Next(1, 4) switch
            {
                1 => "one",
                2 => "two",
                3 => "three",
                _ => "Not Implemented"
            };

            return selectedDoor == prizeDoor ? "serious" : "joke";
        }
    }
}

// TODO: For the AssignPrizeToDoor method, possible logic:  assign "joke" to all three doors, have a random number assign "serious" to one door.
// Possible issues include not being able to test for specific doors. 