using System;

namespace MontyHallv1
{
    public class UserInterface
    {
        public void Game()
        {
            Console.WriteLine("Welcome to Monty Hall \n");
            var isValidUserDoorSelectionInput = false;
            var enteredDoor = "";
            var isValidUserChangeDoorInput = false;
            var changeDoor = "";
            while (!isValidUserDoorSelectionInput)
            {
                Console.WriteLine($"Please choose a door: {PrizeDoors.one}, {PrizeDoors.two}, {PrizeDoors.three}");
                enteredDoor = Console.ReadLine();
                
                isValidUserDoorSelectionInput = Validation.UserEntry(enteredDoor);
            }
            var montyGame = new MontyHallGame(Validation.InputConversion(enteredDoor), new RandomPrizeDoorAssigner());
            var announcersChosenDoor = montyGame.AnnouncersDoor();
            
            Console.WriteLine($"You selected door {montyGame.PlayerSelection}");
            Console.WriteLine($"Monty has opened door {announcersChosenDoor} to show a {montyGame.DoorPrizeStorage[announcersChosenDoor]} prize!");
            while (!isValidUserChangeDoorInput)
            {
                Console.WriteLine("Do you wish to change doors? Yes/No");
                changeDoor = Console.ReadLine();

                isValidUserChangeDoorInput = Validation.ChangeDoorValidator(changeDoor);
            }
            
            if (changeDoor.ToLower() == "yes")
            {
                montyGame.ChangePlayerDoor();
                Console.WriteLine($"You have changed to door {montyGame.PlayerSelection} \n");
            }
            else
            {
                Console.WriteLine($"You have stuck with door {montyGame.PlayerSelection} \n");
            }
        }
    }
}