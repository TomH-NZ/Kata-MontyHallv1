using System;
using System.Collections.Generic;

namespace MontyHallv1
{
    class Program
    {
        public static void Main(string[] args)
        {
            
        }
        
    }
    
    public class MontyHallGame
    {
        public List<string> Doors = new List<string>{"one", "two", "three"};

        public MontyHallGame()
        {
            
        }
        public MontyHallGame(string door)
        {
            PlayerSelection = door;
        }

        public string PlayerSelection { get; set; }
    }
}