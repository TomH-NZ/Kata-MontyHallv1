using System;
using System.Collections.Generic;

namespace MontyHallv1
{
    public class MontyHallGame
    {
        public PrizeDoors PlayerSelection { get; private set; }
        public PrizeDoors? AnnouncersSelection { get; set; }
        public Dictionary<PrizeDoors, string> DoorPrizeStorage { get; private set; }
        
        private Dictionary<PrizeDoors, string> _prizeStorage = new Dictionary<PrizeDoors, string>
        {
            {PrizeDoors.one, "joke"},
            {PrizeDoors.two, "joke"},
            {PrizeDoors.three, "joke"}
        };

        private IRandomPrizeDoorAssigner RandomPrizeDoorAssigner { get; } = new RandomPrizeDoorAssigner();

        public MontyHallGame(PrizeDoors playerSelection) 
        {
            PlayerSelection = playerSelection;
        }
        
        public PrizeDoors AnnouncersDoor()
        {
            PrizeDoors? outputOfAnnouncersDoor = null;

            var seriousPrizeDoor = RandomPrizeDoorAssigner.PrizeDoor();
            
            UpdatePrizeStorage(seriousPrizeDoor);

            foreach (PrizeDoors entry in Enum.GetValues(typeof(PrizeDoors)))
            {
                if (entry != PlayerSelection && DoorPrizeStorage[entry] == "joke")
                {
                    outputOfAnnouncersDoor = entry;
                    break;
                }
            }

            AnnouncersSelection = outputOfAnnouncersDoor.Value;
            return outputOfAnnouncersDoor.Value;
        }
        
        public void UpdatePrizeStorage(PrizeDoors prizeDoor)
        {
            DoorPrizeStorage = _prizeStorage;
            
            DoorPrizeStorage[prizeDoor] = "serious";
        }

        public PrizeDoors ChangePlayerDoor()
        {
            foreach (PrizeDoors entry in Enum.GetValues(typeof(PrizeDoors)))
            {
                if (entry == PlayerSelection || entry == AnnouncersSelection)
                {
                    continue;
                }

                PlayerSelection = entry;
                break;
            }

            return PlayerSelection;
        }
    }
}


 