using System;

namespace MontyHallv1
{
    public class UserInterface
    {
        public void Game()
        {
            Console.WriteLine("Welcome to Monty Hall \n");
            Console.WriteLine($"Please choose a door: {Enums.Doors.one.ToString()}, {Enums.Doors.two.ToString()}, {Enums.Doors.three.ToString()}");
            var MontyGame = new MontyHallGame(Console.ReadLine(), new RandomPrizeDoorAssigner());

            Console.WriteLine($"You selected {MontyGame.PlayerSelection}");
            Console.WriteLine($"Monty has opened door {MontyGame.AnnouncersDoor()} to show a joke prize!");
            Console.WriteLine("Do you wish to change doors? Y/N");
        }
    }
}