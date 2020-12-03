using System;
using System.Collections.Generic;
using MontyHallv1;
using MontyHallv1.Enums;
using MontyHallv1.Game;
using Xunit;

namespace MontyHallUnitTests 
{
    public class DoorTests
    {
        [Fact]
        public void ShowAJokePrizeWhenAnnouncerOpensADoor() 
        {
            //Arrange
            var game = new MontyHallGame(PrizeDoors.two);

            //Act
            game.AnnouncersDoor();
            var actual = game.DoorPrizeStorage[game.AnnouncersSelection.Value];

            //Assert
            Assert.Equal("joke", actual);
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

        [Fact]
        public void AllowPlayerToChangeToUnselectedDoor()
        {
            //Arrange
            var game = new MontyHallGame(PrizeDoors.one);
            game.AnnouncersSelection = PrizeDoors.two;

            //Act
            game.ChangePlayerDoor();
            var actual = game.PlayerSelection;

            //Assert
            Assert.Equal(PrizeDoors.three, actual);
        }

        [Fact (Skip = "unable to test")]
        public void AssignAnnouncersDoorToVariable() //delete test, not testable.
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