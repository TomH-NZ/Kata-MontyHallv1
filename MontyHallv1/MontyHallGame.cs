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

        public string AssignPrize(string selectedDoor)
        {
            //return selectedDoor == "one" ? "joke" : selectedDoor == "two" ? "serious" : "joke";

            return selectedDoor switch
            {
                "one" => "joke",
                "two" => "serious",
                "three" => "joke",
                _ => "joke"
            };
        }
    }
}

// TODO: For the AssignPrize class, possible logic:  assign "joke" to all three doors, have a random number assign "serious" to one door.
// Possible issues include not being able to test for specific doors. 