using System;

namespace MontyHallv1
{
    public class RandomPrizeDoorAssigner : IRandomPrizeDoorAssigner
    {
        public PrizeDoors PrizeDoor()  
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