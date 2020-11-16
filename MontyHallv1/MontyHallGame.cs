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

        private Door Door { get; } = new Door();

        // This method returns the door that the announcer opens to show the joke prize.
        public string AnnouncersDoor(string playerSelection)
        {
            var randomAssigner = new RandomPrizeDoorAssigner();
            var randomPrizeDoor = randomAssigner.PrizeDoor();

            foreach (var entry in Doors)
            {
                if (entry != playerSelection && Door.AssignRandomPrize(entry, randomAssigner) == "joke")
                {
                    return entry;
                }
            }
            return "one";
        }
    }
}
// TODO: Generate three doors - done
// TODO: Allow player to select door - done??
// TODO: Show door with joke prize 
// TODO: Give player option to change door 
// TODO: Open door to reveal prize 

 