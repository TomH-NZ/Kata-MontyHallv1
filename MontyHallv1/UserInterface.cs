using System;

namespace MontyHallv1
{
    public class UserInterface
    {
        public void Game()
        {
            Console.WriteLine("Welcome to Monty Hall \n");
            var isValidEntry = false;
            var enteredDoor = "";
            while (!isValidEntry)
            {
                Console.WriteLine($"Please choose a door: {PrizeDoors.one.ToString()}, {PrizeDoors.two.ToString()}, {PrizeDoors.three.ToString()}");
                enteredDoor = Console.ReadLine();
                
                isValidEntry = Validation.UserEntry(enteredDoor);
            }
            var montyGame = new MontyHallGame(Validation.InputConversion(enteredDoor), new RandomPrizeDoorAssigner());
            
            Console.WriteLine($"You selected {montyGame.PlayerSelection}");
            Console.WriteLine($"Monty has opened door {montyGame.AnnouncersDoor()} to show a {montyGame.DoorPrizeStorage[montyGame.AnnouncersDoor()]} prize!");
            Console.WriteLine("Do you wish to change doors? Y/N");
        }
    }
}