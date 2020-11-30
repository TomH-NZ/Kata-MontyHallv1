using System;
using System.Collections.Generic;

namespace MontyHallv1
{
    public class MontyHallGame
    {
        public PrizeDoors PlayerSelection { get; private set; }
        public PrizeDoors? AnnouncersSelection { get; private set; }
        public Dictionary<PrizeDoors, string> DoorPrizeStorage { get; private set; }
        
        private Dictionary<PrizeDoors, string> _prizeStorage = new Dictionary<PrizeDoors, string>
        {
            {PrizeDoors.one, "joke"},
            {PrizeDoors.two, "joke"},
            {PrizeDoors.three, "joke"}
        };
        
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

            var randomDoorValue = _randomPrizeDoorAssigner.PrizeDoor();
            
            UpdatePrizeStorage(Validation.InputConversion(randomDoorValue));

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


// TODO: Give player option to change door 
// TODO: Open door to reveal prize 

 