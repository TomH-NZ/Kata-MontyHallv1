using System;
using System.Collections.Generic;
using MontyHallv1.Enums;
using MontyHallv1.Interfaces;

namespace MontyHallv1.Game
{
    public class MontyHallGame
    {
        public PrizeDoors PlayerSelection { get; private set; }
        public PrizeDoors? AnnouncersSelection { get; set; }
        public Dictionary<PrizeDoors, string> DoorPrizeStorage { get; }
        
        private IRandomPrizeDoorAssigner RandomPrizeDoorAssigner { get; } = new RandomPrizeDoorAssigner();

        public MontyHallGame(PrizeDoors playerSelection) 
        {
            PlayerSelection = playerSelection;
            DoorPrizeStorage = new Dictionary<PrizeDoors, string>
            {
                {PrizeDoors.one, "joke"},
                {PrizeDoors.two, "joke"},
                {PrizeDoors.three, "joke"}
            };
        }
        
        public PrizeDoors AnnouncersDoor() 
        {
            foreach (PrizeDoors entry in Enum.GetValues(typeof(PrizeDoors)))
            {
                if (entry != PlayerSelection && DoorPrizeStorage[entry] == "joke")
                {
                    AnnouncersSelection = entry;
                    break;
                }
            }

            return AnnouncersSelection.Value;
        }
        
        public void UpdatePrizeStorage()
        {
            DoorPrizeStorage[RandomPrizeDoorAssigner.PrizeDoor()] = "serious";
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


 