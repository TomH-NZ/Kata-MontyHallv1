using System;
using MontyHallv1.Game;
using MontyHallv1.Interfaces;

namespace MontyHallv1.Automation
{
    public class Automation
    {
        public Automation(IInputGenerator inputGenerator)
        {
            InputGenerator = inputGenerator;
        }

        private IInputGenerator InputGenerator { get; }
        public void AutomatedGame()
        {
            Console.WriteLine("Please enter a number of cycles to run through:");
            int.TryParse(Console.ReadLine(), out var programCycles);

            var index = 0;
            while (index < programCycles)
            {
                var automatedPlayerSelection = InputGenerator.PlayerSelection();
                var automatedMonty = new MontyHallGame(automatedPlayerSelection, new RandomPrizeDoorAssigner());
                automatedMonty.UpdatePrizeStorage();
                automatedMonty.AnnouncersDoor();
                //automatedMonty.ChangePlayerDoor();

                if (automatedMonty.DoorPrizeStorage[automatedPlayerSelection] == "serious")
                {
                    ChangeDoor.AutomatedStorage.Add(1);
                }

                index++;
            }

            Console.WriteLine($"Not changing doors gave {ChangeDoor.AutomatedStorage.Count} out of {programCycles} serious prizes.");

            
        }
    }
}
