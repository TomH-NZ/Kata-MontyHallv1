using System;
using System.Collections.Generic;

namespace MontyHallv1
{
    public class MontyHallGame
    {
        public List<string> Doors = new List<string>{"one", "two", "three"};

        public string PlayerSelection { get; }

        public MontyHallGame()
        {
        }

        public MontyHallGame(string playerSelection)
        {
            PlayerSelection = playerSelection;
        }


        public string ShowAnnouncerDoor()
        {
            return "joke";
        }
    }
}
// TODO: Generate three doors - done
// TODO: Allow player to select door - done??
// TODO: Show door with joke prize 
// TODO: Give player option to change door 
// TODO: Open door to reveal prize 