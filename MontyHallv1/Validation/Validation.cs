using System;

namespace MontyHallv1
{
    public static class Validation
    {
        public static bool UserEntryValidator(string inputValue)
        {
            return Enum.IsDefined(typeof(PrizeDoors), inputValue);
        }

        public static PrizeDoors UserInputConversion(string userEntry)
        {
            Enum.TryParse(userEntry, out PrizeDoors door);
            return door;
        }

        public static bool ChangeDoorValidator(string userEntry)
        {
             return !(userEntry.ToLower() != "yes" && userEntry.ToLower() != "no");
        }
    }
}
