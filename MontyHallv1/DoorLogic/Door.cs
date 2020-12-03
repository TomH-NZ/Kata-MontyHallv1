using System;
using System.Collections.Generic;
using MontyHallv1.Enums;
using MontyHallv1.Interfaces;

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