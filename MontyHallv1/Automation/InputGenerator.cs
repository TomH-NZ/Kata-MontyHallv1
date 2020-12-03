using System;
using MontyHallv1.Enums;
using MontyHallv1.Interfaces;

namespace MontyHallv1.Automation
{
    public class InputGenerator : IInputGenerator
    {
        public string Yes = "yes";
        public string No = "no";

        public PrizeDoors PlayerSelection()
        {
            var selectedDoor = new Random().Next(1, 4) switch
            {
                1 => PrizeDoors.one,
                2 => PrizeDoors.two,
                3 => PrizeDoors.three
            };

            return selectedDoor;
        }
    }
}