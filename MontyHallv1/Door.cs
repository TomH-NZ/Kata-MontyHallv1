using System.Collections.Generic;

namespace MontyHallv1
{
    public class Door
    {
        public Door()
        {
        }

        public string AssignRandomPrize(string selectedDoor, IRandom prizeDoor)
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
    }
}
// TODO: Assign prizes to doors - done