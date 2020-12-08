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
            //UpdatePrizeStorage(RandomPrizeDoorAssigner.PrizeDoor()); //breaks command query separation
            //TODO: how to move the above process outside this method? Moving it to the UserInterface class creates errors
            //TODO: related to static method.

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
        
        //public void UpdatePrizeStorage(PrizeDoors prizeDoor)
        public void UpdatePrizeStorage()
        {
            //var prizeDoor = RandomPrizeDoorAssigner.PrizeDoor();
            //DoorPrizeStorage[prizeDoor] = "serious";
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


 