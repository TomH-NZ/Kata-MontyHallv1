using System;

namespace MontyHallv1
{
    public class Validation
    {
        public static bool UserEntry(string inputValue)
        {
            return Enum.IsDefined(typeof(Doors), inputValue);
        }
    }
}
