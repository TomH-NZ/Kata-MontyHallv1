using System.Collections.Generic;

namespace MontyHallv1
{
    public class Door
    {
        public Door()
        {
        }

        public string AssignRandomPrizeToDoor(string selectedDoor, IRandomPrizeDoor prizeDoor)
        {
            var convertedDoor = prizeDoor.RandomPrizeDoor();

            return selectedDoor == convertedDoor ? "serious" : "joke";
        }
        
        
    }
}