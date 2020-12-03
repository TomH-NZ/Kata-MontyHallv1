using System;
using System.Collections.Generic;
using MontyHallv1.Game;

namespace MontyHallv1
{
    class Program
    {
        public static void Main(string[] args)
        {
            var newGame = new UserInterface();
            newGame.Game();
        }
    }
}
// TODO: Record player selection, prize success
// TODO: Loop through for 1000 cycles 