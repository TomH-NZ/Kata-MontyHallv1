using System;
using System.Collections.Generic;

namespace MontyHallv1
{
    public class MontyHallGame
    {
        private readonly IRandomPrizeDoorAssigner _randomPrizeDoorAssigner;

        public string PlayerSelection { get; }

        public MontyHallGame()
        {
            _randomPrizeDoorAssigner = new RandomPrizeDoorAssigner();
        }

        public MontyHallGame(string playerSelection, IRandomPrizeDoorAssigner prizeDoorAssigner)
        {
            PlayerSelection = playerSelection;
            _randomPrizeDoorAssigner = prizeDoorAssigner;
        }

        private Door Door { get; } = new Door();

        public string AnnouncersDoor()
        {
            var output = "";
            
            foreach (var entry in Enum.GetValues(typeof(Enums.Doors)))
            {
                while (entry.ToString() != PlayerSelection && output == "")
                {
                    if (Door.AssignRandomPrize(entry.ToString(), _randomPrizeDoorAssigner) == "joke")
                    {
                        output = entry.ToString();
                        break;
                    }
                }

                if (output != "")
                {
                    break;
                }
            }
            return output;
        }
    }
}
// TODO: Generate three doors - done
// TODO: Allow player to select door - done??
// TODO: Show door with joke prize - done
// TODO: create mapping of door to prize for each instance
// TODO: Add validation for player selection to match enum list.
// TODO: Give player option to change door 
// TODO: Open door to reveal prize 

 