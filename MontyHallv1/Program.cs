using System;
using MontyHallv1.Automation;

namespace MontyHallv1
{
    class Program
    {
        public static void Main(string[] args)
        {
            var newGame = new AutomationSteps(new InputGenerator());
            newGame.AutomatedGame();
            
            //var newGame = new UserInterface();
            //newGame.Game();
        }
    }
}

//Autofac.