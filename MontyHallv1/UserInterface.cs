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
                Console.WriteLine($"Please choose a door: {Doors.one.ToString()}, {Doors.two.ToString()}, {Doors.three.ToString()}");
                enteredDoor = Console.ReadLine();
                
                isValidEntry = Validation.UserEntry(enteredDoor);
            }
            var MontyGame = new MontyHallGame(enteredDoor, new RandomPrizeDoorAssigner());
            
            Console.WriteLine($"You selected {MontyGame.PlayerSelection}");
            Console.WriteLine($"Monty has opened door {MontyGame.AnnouncersDoor()} to show a {MontyGame.DoorPrizeStorage[MontyGame.AnnouncersDoor()]} prize!");
            Console.WriteLine("Do you wish to change doors? Y/N");
        }
    }
}