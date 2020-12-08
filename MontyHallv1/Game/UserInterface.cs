using System;
using MontyHallv1.Enums;

namespace MontyHallv1.Game
{
    public class UserInterface
    {
        public void Game()
        {
            var isValidUserDoorSelection = false;
            var enteredUserSelection = "";
            var isValidChangeDoorInput = false;
            var changeDoor = "";
            
            Console.WriteLine("Welcome to Monty Hall \n");
            
            while (!isValidUserDoorSelection)
            {
                Console.WriteLine($"Please choose a door: {PrizeDoors.one}, {PrizeDoors.two}, {PrizeDoors.three}");
                enteredUserSelection = Console.ReadLine();
                
                isValidUserDoorSelection = Validation.Validation.UserEntryValidator(enteredUserSelection);
            }
            var montyGame = new MontyHallGame(Validation.Validation.UserInputConversion(enteredUserSelection), new RandomPrizeDoorAssigner());
            montyGame.UpdatePrizeStorage();
            var announcersChosenDoor = montyGame.AnnouncersDoor();
            
            Console.WriteLine($"You selected door {montyGame.PlayerSelection}");
            Console.WriteLine($"Monty has opened door {announcersChosenDoor} to show a {montyGame.DoorPrizeStorage[announcersChosenDoor]} prize! \n");
            
            while (!isValidChangeDoorInput)
            {
                Console.WriteLine("Do you wish to change doors? Yes/No");
                changeDoor = Console.ReadLine();

                isValidChangeDoorInput = Validation.Validation.ChangeDoorValidator(changeDoor);
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

            Console.WriteLine($"You have received a {montyGame.DoorPrizeStorage[montyGame.PlayerSelection]} prize!");
        }
    }
}
