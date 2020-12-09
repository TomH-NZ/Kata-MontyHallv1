using System;
using MontyHallv1.Game;
using MontyHallv1.Interfaces;

namespace MontyHallv1.Automation
{
    public class Automation // ToDo: Add in logic for x loops.
    {
        public Automation(IInputGenerator inputGenerator)
        {
            InputGenerator = inputGenerator;
        }

        private IInputGenerator InputGenerator { get; }
        public void AutomatedGame()
        {
            var automatedPlayerSelection = InputGenerator.PlayerSelection();
            var automatedMonty = new MontyHallGame(automatedPlayerSelection, new RandomPrizeDoorAssigner());
            automatedMonty.UpdatePrizeStorage();
            automatedMonty.AnnouncersDoor();
            automatedMonty.ChangePlayerDoor();
            ChangeDoor.AutomatedStorage.Add(automatedMonty.DoorPrizeStorage[automatedPlayerSelection] == "serious"
                ? 1 : 0);
        }
    }
}
// TODO: Create new Monty game with player selected door and random door - x

// TODO:Generate announcers door - x
        
// TODO:Change player door / do not change player door
        
// TODO:Show door prize
        
// TODO:Save results to list