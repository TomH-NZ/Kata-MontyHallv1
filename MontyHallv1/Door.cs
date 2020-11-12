using System.Collections.Generic;

namespace MontyHallv1
{
    public class Door
    {
        public Door()
        {
        }

        public string AssignRandomPrize(string selectedDoor, IRandomPrizeDoor prizeDoor)
        {
            var convertedDoor = prizeDoor.RandomPrizeDoor();

            return selectedDoor == convertedDoor ? "serious" : "joke";
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
    }
}