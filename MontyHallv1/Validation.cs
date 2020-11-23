using System;

namespace MontyHallv1
{
    public class Validation
    {
        public static bool UserEntry(string inputValue)
        {
            return Enum.IsDefined(typeof(PrizeDoors), inputValue);
        }

        public static PrizeDoors InputConversion(string userEntry)
        {
            Enum.TryParse(userEntry, out PrizeDoors door);
            return door;
        }
    }
}
