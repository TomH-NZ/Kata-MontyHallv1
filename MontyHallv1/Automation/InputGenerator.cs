using System;

namespace MontyHallv1.Automation
{
    public class InputGenerator
    {
        public string yes = "yes";
        public string no = "no";
        
        public PrizeDoors PlayerDoor()
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