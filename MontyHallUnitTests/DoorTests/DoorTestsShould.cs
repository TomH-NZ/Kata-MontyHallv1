using System.Collections.Generic;
using MontyHallv1;
using MontyHallv1.Enums;
using MontyHallv1.Game;
using MontyHallv1.Interfaces;
using Xunit;

namespace MontyHallUnitTests.DoorTests 
{
    public class DoorTests
    {
        
        private class StubForDoorOne : IRandomPrizeDoorAssigner
        {
            public PrizeDoors PrizeDoor()
            {
                return PrizeDoors.one;
            }
        }

        private class StubForDoorTwo : IRandomPrizeDoorAssigner
        {
            public PrizeDoors PrizeDoor()
            {
                return PrizeDoors.two;
            }
        }

        private class StubForDoorThree : IRandomPrizeDoorAssigner
        {
            public PrizeDoors PrizeDoor()
            {
                return PrizeDoors.three;
            }
        }
        [Fact]
        public void ShowAJokePrizeWhenAnnouncerOpensADoor() 
        {
            //Arrange
            var game = new MontyHallGame(PrizeDoors.two, new StubForDoorOne()); //use moq to pass in correct door or use a stub

            //Act
            game.AnnouncersDoor();
            var actual = game.DoorPrizeStorage[game.AnnouncersSelection.Value];

            //Assert
            Assert.Equal("joke", actual);
        }
        
        public static IEnumerable<object[]> PrizeDoorStorageTestMemberDoorOneSerious()
        {
            //This creates the data that is to be tested, similar to the [Theory] InlineData tests.
            return new List<object[]>
            {
                new object[] {PrizeDoors.one, "serious"},
                new object[] {PrizeDoors.two, "joke"},
                new object[] {PrizeDoors.three, "joke"},
            };
        }
        
        [Theory] 
        [MemberData(nameof(PrizeDoorStorageTestMemberDoorOneSerious))]
        public void ReturnSeriousPrizeFromPrizeStorageDoorOneTheory(PrizeDoors testedDoor, string prizeResult)
        {
            //Arrange
            var game = new MontyHallGame(testedDoor, new StubForDoorOne());
            
            //Act
            game.UpdatePrizeStorage();
            var actual = game.DoorPrizeStorage[testedDoor];
            
            //Assert
            Assert.Equal(prizeResult, actual);
        }
        
        public static IEnumerable<object[]> PrizeDoorStorageTestMemberDoorTwoSerious()
        {
            //This creates the data that is to be tested, similar to the [Theory] InlineData tests.
            return new List<object[]>
            {
                new object[] {PrizeDoors.one, "joke"},
                new object[] {PrizeDoors.two, "serious"},
                new object[] {PrizeDoors.three, "joke"},
            };
        }
        
        [Theory] 
        [MemberData(nameof(PrizeDoorStorageTestMemberDoorTwoSerious))]
        public void ReturnSeriousPrizeFromPrizeStorageDoorTwoTheory(PrizeDoors testedDoor, string prizeResult)
        {
            //Arrange
            var game = new MontyHallGame(testedDoor, new StubForDoorTwo());
            
            //Act
            game.UpdatePrizeStorage();
            var actual = game.DoorPrizeStorage[testedDoor];
            
            //Assert
            Assert.Equal(prizeResult, actual);
        }
        
        public static IEnumerable<object[]> PrizeDoorStorageTestMemberDoorThreeSerious()
        {
            //This creates the data that is to be tested, similar to the [Theory] InlineData tests.
            return new List<object[]>
            {
                new object[] {PrizeDoors.one, "joke"},
                new object[] {PrizeDoors.two, "joke"},
                new object[] {PrizeDoors.three, "serious"}
            };
        }
        
        [Theory] 
        [MemberData(nameof(PrizeDoorStorageTestMemberDoorThreeSerious))]
        public void ReturnSeriousPrizeFromPrizeStorageDoorThreeTheory(PrizeDoors testedDoor, string prizeResult)
        {
            //Arrange
            var game = new MontyHallGame(testedDoor, new StubForDoorThree());
            
            //Act
            game.UpdatePrizeStorage();
            var actual = game.DoorPrizeStorage[testedDoor];
            
            //Assert
            Assert.Equal(prizeResult, actual);
        }

        [Fact]
        public void AllowPlayerToChangeToUnselectedDoor()
        {
            //Arrange
            var game = new MontyHallGame(PrizeDoors.one, new RandomPrizeDoorAssigner());
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
            var game = new MontyHallGame(PrizeDoors.two, new RandomPrizeDoorAssigner());

            //Act
            game.AnnouncersDoor();

            //Assert
            Assert.Equal(PrizeDoors.one, game.AnnouncersSelection);
        }
    }
}