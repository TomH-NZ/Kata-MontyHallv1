using System;

namespace MontyHallv1
{
    public class Validation
    {
        public static bool UserEntry(string inputValue)
        {
            /*var ifFound = false;

            foreach (var entry in Enum.GetValues(typeof(Enums.Doors)))
            {
                if (inputValue == entry.ToString())
                {
                    ifFound = true;
                    break;
                }
            }
            return ifFound;*/

            return Enum.IsDefined(typeof(Doors), inputValue);
            
        }
    }
}
