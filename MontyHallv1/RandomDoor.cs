using System;

namespace MontyHallv1
{
    public class RandomDoor : IRandomPrizeDoor
    {
        public string RandomPrizeDoor()
        {
            var prizeDoor = new Random().Next(1, 4) switch
            {
                1 => "one",
                2 => "two",
                3 => "three",
                _ => "Not Implemented"
            };
            return prizeDoor;
        }
    }
}