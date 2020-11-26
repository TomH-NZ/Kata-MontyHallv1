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
            var changeDoor = "";
            while (!isValidEntry)
            {
                Console.WriteLine($"Please choose a door: {PrizeDoors.one}, {PrizeDoors.two}, {PrizeDoors.three}");
                enteredDoor = Console.ReadLine();
                
                isValidEntry = Validation.UserEntry(enteredDoor);
            }
            var montyGame = new MontyHallGame(Validation.InputConversion(enteredDoor), new RandomPrizeDoorAssigner());
            var AnnouncersChosenDoor = montyGame.AnnouncersDoor();
            
            Console.WriteLine($"You selected door {montyGame.PlayerSelection}");
            Console.WriteLine($"Monty has opened door {AnnouncersChosenDoor} to show a {montyGame.DoorPrizeStorage[AnnouncersChosenDoor]} prize!");
            Console.WriteLine("Do you wish to change doors? Yes/No");
            
            changeDoor = Console.ReadLine();
            
            if (changeDoor.ToLower() == "yes")
            {
                montyGame.ChangePlayerDoor();
            }
        }
    }
}