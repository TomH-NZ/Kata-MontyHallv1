using System;
using System.Collections.Generic;
using MontyHallv1;
using Xunit;

namespace MontyHallUnitTests 
{
    public class DoorTests
    {
        [Fact]
        public void ShowAJokePrizeWhenAnnouncerOpensADoor() //TODO: unsure how to test this without saying 1 = 1
        {
            //Arrange
            var game = new MontyHallGame(PrizeDoors.two);

            //Act
            var result = game.AnnouncersDoor();

            //Assert
            Assert.Equal(PrizeDoors.one, result);
        }
        
        public static IEnumerable<object[]> PrizeDoorStorageTestMember()
        {
            //This creates the data that is to be tested, similar to the [Theory] InlineData tests.
            return new List<object[]>
            {
                new object[] {PrizeDoors.one, PrizeDoors.one,  "serious"},
                new object[] {PrizeDoors.two, PrizeDoors.one, "joke"},
                new object[] {PrizeDoors.three, PrizeDoors.one, "joke"},

                new object[] {PrizeDoors.one, PrizeDoors.two, "joke"},
                new object[] {PrizeDoors.two, PrizeDoors.two, "serious"},
                new object[] {PrizeDoors.three, PrizeDoors.two, "joke"},

                new object[] {PrizeDoors.one, PrizeDoors.three, "joke"},
                new object[] {PrizeDoors.two, PrizeDoors.three, "joke"},
                new object[] {PrizeDoors.three, PrizeDoors.three, "serious"}
            };
        }
        
        [Theory] 
        [MemberData(nameof(PrizeDoorStorageTestMember))]
        public void ReturnCorrectPrizeFromDoorPrizeStorageTheory(PrizeDoors testedDoor, PrizeDoors actualPrize, string prizeResult)
        {
            //Arrange
            var game = new MontyHallGame(testedDoor);
            
            //Act
            game.UpdatePrizeStorage(actualPrize);
            var actual = game.DoorPrizeStorage[testedDoor];
            
            //Assert
            Assert.Equal(prizeResult, actual);
        }

        [Theory]
        [InlineData(PrizeDoors.two, PrizeDoors.three, PrizeDoors.one)]
        [InlineData(PrizeDoors.three, PrizeDoors.one, PrizeDoors.two)]
        [InlineData(PrizeDoors.one, PrizeDoors.two, PrizeDoors.three)]
        public void AllowPlayerToChangeToUnselectedDoor(PrizeDoors playerSelection, PrizeDoors announcersSelection, PrizeDoors unselectedDoor)
        {
            //Arrange
            var game = new MontyHallGame(playerSelection);
            game.AnnouncersSelection = announcersSelection;
            
            //Act
            game.ChangePlayerDoor();
            var actual = game.PlayerSelection;
            
            //Assert
            Assert.Equal(unselectedDoor, actual);
        }

        [Fact]
        public void AssignAnnouncersDoorToVariable() //TODO: Unsure how to test this correctly as it called the random assigner
        {
            //Arrange
            var game = new MontyHallGame(PrizeDoors.two);

            //Act
            game.AnnouncersDoor();

            //Assert
            Assert.Equal(PrizeDoors.one, game.AnnouncersSelection);
        }
    }
}