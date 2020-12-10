using System;
using MontyHallv1.Automation;
using MontyHallv1.Game;

namespace MontyHallv1
{
    class Program
    {
        public static void Main(string[] args)
        {
            var newGame = new Automation.Automation(new InputGenerator());
            newGame.AutomatedGame();
            
            //var newGame = new UserInterface();
            //newGame.Game();
        }
    }
}

//Autofac.