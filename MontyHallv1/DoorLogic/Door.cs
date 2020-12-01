using System;
using System.Collections.Generic;

namespace MontyHallv1
{
    public static class Door
    {
        public static string AssignRandomPrize(PrizeDoors selectedDoor, IRandomPrizeDoorAssigner prizeDoor)
        {
            return selectedDoor == prizeDoor.PrizeDoor() ? "serious" : "joke";
        }
    }
}