using System;
using System.Collections.Generic;

namespace MontyHallv1
{
    public class MontyHallGame
    {
        private readonly IRandomPrizeDoorAssigner _randomPrizeDoorAssigner;

        public string PlayerSelection { get; }
        //ToDo: look at changing playerselection from string to an enum

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
        public Dictionary<Doors, string> DoorPrizeStorage { get; set; }
        //ToDo: use enum as key instead of string.
        

        public Doors AnnouncersDoor()
        {
            Doors? outputOfAnnouncersDoor = null;
            
            Dictionary<Doors, string> prizeDictionary = new Dictionary<Doors, string>
            {
                {Doors.one, "joke"},
                {Doors.two, "joke"},
                {Doors.three, "serious"}
            };
            
            DoorPrizeStorage = prizeDictionary;
            
            foreach (Doors entry in Enum.GetValues(typeof(Doors)))
            {
                while (entry.ToString() != PlayerSelection && !outputOfAnnouncersDoor.HasValue )
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

 