using System;
using System.Collections.Generic;

namespace MontyHallv1
{
    public class MontyHallGame
    {
        public PrizeDoors PlayerSelection { get; }
        public Dictionary<PrizeDoors, string> DoorPrizeStorage { get; set; }
        
        private readonly IRandomPrizeDoorAssigner _randomPrizeDoorAssigner;
        private Door Door { get; } = new Door();
        
        public MontyHallGame()
        {
            _randomPrizeDoorAssigner = new RandomPrizeDoorAssigner();
        }

        public MontyHallGame(PrizeDoors playerSelection, IRandomPrizeDoorAssigner prizeDoorAssigner)
        {
            PlayerSelection = playerSelection;
            _randomPrizeDoorAssigner = prizeDoorAssigner;
        }
        
        public PrizeDoors AnnouncersDoor()
        {
            PrizeDoors? outputOfAnnouncersDoor = null;
            
            Dictionary<PrizeDoors, string> prizeDictionary = new Dictionary<PrizeDoors, string>
            {
                {PrizeDoors.one, "joke"},
                {PrizeDoors.two, "joke"},
                {PrizeDoors.three, "serious"}
            };
            
            DoorPrizeStorage = prizeDictionary;
            
            foreach (PrizeDoors entry in Enum.GetValues(typeof(PrizeDoors)))
            {
                while (entry != PlayerSelection && !outputOfAnnouncersDoor.HasValue )
                {
                    if (Door.AssignRandomPrize(entry.ToString(), _randomPrizeDoorAssigner) == "joke")
                    {
                        outputOfAnnouncersDoor = entry;
                        break;
                    }
                }

                if (outputOfAnnouncersDoor.HasValue)
                {
                    break;
                }
            }
            return outputOfAnnouncersDoor.Value;
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

 