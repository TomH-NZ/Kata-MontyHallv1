using System;
using System.Collections.Generic;
using MontyHallv1;
using Xunit;

namespace MontyHallUnitTests // update tests to pass in stub value for random prize assigner.
{
    public class DoorTests
    {
        private class StubForDoorOneReturnsSerious : IRandomPrizeDoorAssigner
        {
            public string PrizeDoor()
            {
                return "one";
            }
        }

        private class StubForDoorTwoReturnsSerious : IRandomPrizeDoorAssigner
        {
            public string PrizeDoor()
            {
                return "two";
            }
        }

        private class StubForDoorThreeReturnsSerious : IRandomPrizeDoorAssigner
        {
            public string PrizeDoor()
            {
                return "three";
            }
        }
        
        [Fact]
        public void ShowAJokePrizeWhenAnnouncerOpensADoor()
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
            //Generates the stub object that is used by the data in the test.
            var stubOne = new StubForDoorOneReturnsSerious();
            var stubTwo = new StubForDoorTwoReturnsSerious();
            var stubThree = new StubForDoorThreeReturnsSerious();
            
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
        public void AllowPlayerToChangeDoorToDoorThree()
        {
            //Arrange
            var game = new MontyHallGame(PrizeDoors.one);
            game.AnnouncersDoor();
            
            //Act
            game.ChangePlayerDoor();
            var actual = game.PlayerSelection;

            //Assert
            Assert.Equal(PrizeDoors.three, actual);
        }
        
        [Fact]
        public void AllowPlayerToChangeDoorToDoorTwo()
        {
            //Arrange
            var game = new MontyHallGame(PrizeDoors.three);
            game.AnnouncersDoor();
            
            //Act
            game.ChangePlayerDoor();
            var actual = game.PlayerSelection;

            //Assert
            Assert.Equal(PrizeDoors.two, actual);
        }
        
        [Fact]
        public void AllowPlayerToChangeDoorToDoorOne()
        {
            //Arrange
            var game = new MontyHallGame(PrizeDoors.two);
            game.AnnouncersDoor();
            
            //Act
            game.ChangePlayerDoor();
            var actual = game.PlayerSelection;

            //Assert
            Assert.Equal(PrizeDoors.one, actual);
        }

        [Fact]
        public void AssignAnnouncersDoorToVariable()
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