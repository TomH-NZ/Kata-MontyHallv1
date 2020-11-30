using System;

namespace MontyHallv1
{
    public class RandomPrizeDoorAssigner : IRandomPrizeDoorAssigner
    {
        public PrizeDoors PrizeDoor() //TODO: switch statement doesn't have a default option.  How to set this up?? 
        {
            var prizeDoor = new Random().Next(1, 4) switch
            {
                1 => PrizeDoors.one,
                2 => PrizeDoors.two,
                3 => PrizeDoors.three
            };
            return prizeDoor;
        }
    }
}