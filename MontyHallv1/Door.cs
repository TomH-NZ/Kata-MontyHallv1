using System;
using System.Collections.Generic;

namespace MontyHallv1
{
    public class Door
    {
        public Door()
        {
        }

        public string AssignRandomPrize(string selectedDoor, IRandomPrizeDoorAssigner prizeDoor)
        {
            return selectedDoor == prizeDoor.PrizeDoor() ? "serious" : "joke";
        }
        
        Dictionary<string, bool> _doorDictionary = new Dictionary<string, bool>()
        {
            {"one", true},
            {"two", false},
            {"three", false}
        };
        
        public bool OpenStatus(string playerSelectedDoor)
        {
            return _doorDictionary[playerSelectedDoor];
        }

        public void DoorPrizeStorage(string doorSelection, string prizeSelection)
        {
            
        }
    }
}
// TODO: Assign prizes to doors - done