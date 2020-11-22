using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using MontyHallv1;
using Xunit;

namespace MontyHallUnitTests
{
    public class GameUnitTests
    {
        [Fact]
        public void ShowThreeDoorsWhenAGameIsCreated()
        {
            //Arrange
            var montyHallGame = new MontyHallGame();

            //Act
            var actual = Enum.GetNames(typeof(Doors)).Length;

            //Assert
            Assert.Equal(3, actual);
        }

        [Fact]
        public void DisplayAUserSelectionWhenAGameIsCreated()
        {
            //Arrange
            var randomPrizeDoorAssigner= new RandomPrizeDoorAssigner();
            var montyHallGame = new MontyHallGame("one", randomPrizeDoorAssigner );
            
            //Act
            var result = montyHallGame.PlayerSelection;
            var expected = "one";

            //Assert
            Assert.Equal(expected, result);
        }

        class RandomDoorStubDoorOneReturnsSerious : IRandomPrizeDoorAssigner
        {
            public string PrizeDoor()
            {
                return "one";
            }
        }

        [Theory]
        [InlineData("one", "serious")]
        [InlineData("two", "joke")]
        [InlineData("three", "joke")]
        public void ShowAPrizeWhenDoorOneIsSelectedWithStub(string door, string prize)
        {
            //Arrange
            var doors = new Door();
            IRandomPrizeDoorAssigner randomPrizeDoorAssigner = new RandomDoorStubDoorOneReturnsSerious();
            
            //Act
            var result = doors.AssignRandomPrize(door, randomPrizeDoorAssigner);

            //Assert
            Assert.Equal(prize, result);
        }

        class RandomDoorStubDoorTwo : IRandomPrizeDoorAssigner
        {
            public string PrizeDoor()
            {
                return "two";
            }
        }
        
        [Theory]
        [InlineData("one", "joke")]
        [InlineData("two", "serious")]
        [InlineData("three", "joke")]
        public void ShowAPrizeWhenDoorTwoIsSelectedWithStub(string door, string prize)
        {
            //Arrange
            var doors = new Door();
            IRandomPrizeDoorAssigner randomPrizeDoorAssigner = new RandomDoorStubDoorTwo();
            
            //Act
            var result = doors.AssignRandomPrize(door, randomPrizeDoorAssigner);

            //Assert
            Assert.Equal(prize, result);
        }
        
        class RandomDoorStubDoorThree : IRandomPrizeDoorAssigner
        {
            public string PrizeDoor()
            {
                return "three";
            }
        }
        
        [Theory]
        [InlineData("one", "joke")]
        [InlineData("two", "joke")]
        [InlineData("three", "serious")]
        public void ShowAPrizeWhenDoorThreeIsSelectedWithStub(string door, string prize)
        {
            //Arrange
            var doors = new Door();
            IRandomPrizeDoorAssigner randomPrizeDoorAssigner = new RandomDoorStubDoorThree();
            
            //Act
            var result = doors.AssignRandomPrize(door, randomPrizeDoorAssigner);

            //Assert
            Assert.Equal(prize, result);
        }
        
        public static IEnumerable<object[]> TestMember()
        {
            //Generates the stub object that is used by the data in the test.
            var stubOne = new RandomDoorStubDoorOneReturnsSerious();
            var stubTwo = new RandomDoorStubDoorTwo();
            var stubThree = new RandomDoorStubDoorThree();
            
            //This creates the data that is to be tested, similar to the [Theory] unit tests.
            return new List<object[]>
            {
                new object[]{"one", "serious", stubOne },
                new object[]{"two", "joke", stubOne},
                new object[]{"three", "joke", stubOne},
                
                new object[]{"one", "joke", stubTwo },
                new object[]{"two", "serious", stubTwo},
                new object[]{"three", "joke", stubTwo},
                
                new object[]{"one", "joke", stubThree },
                new object[]{"two", "joke", stubThree},
                new object[]{"three", "serious", stubThree}
            };
        }
        
        [Theory]
        [MemberData(nameof(TestMember))]
        public void ShowAPrizeWhenAWinningDoorIsSelectedWithMemberData(string door, string prize, IRandomPrizeDoorAssigner randomPrizeDoorAssigner)
        {
            //Arrange
            var doors = new Door();

            //Act
            var result = doors.AssignRandomPrize(door, randomPrizeDoorAssigner);

            //Assert
            Assert.Equal(prize, result);
        }

        [Fact]
        public void ShowIfTheDoorIsOpen()
        {
            //Arrange
            var doors = new Door();

            //Act
            var result = doors.OpenStatus("one");

            //Assert
            Assert.True(result);
        }

        [Fact]
        public void ShowAJokePrizeWhenAnnouncerOpensADoor()
        {
            //Arrange
            var game = new MontyHallGame("two", new RandomDoorStubDoorTwo());

            //Act
            var result = game.AnnouncersDoor();

            //Assert
            Assert.Equal(Doors.one, result);
        }
        
        class AlternatingDoorTwoAndThreeStub : IRandomPrizeDoorAssigner
        {
            private int counter = 0;
            public string PrizeDoor()
            {
                var output = counter % 2 == 0 ? "two" : "three";
                counter++;
                return output;
            }
        }
        
        [Fact]
        public void AlwaysReturnAPrizeWhenADoorIsOpened()
        {
            //Arrange
            var game = new MontyHallGame("one", new AlternatingDoorTwoAndThreeStub());

            //Act
            var result = game.AnnouncersDoor();

            //Assert
            Assert.Equal(Doors.two, result);
        }

        [Fact]
        public void ReturnTrueWhenValidatingUserInput()
        {
            //Arrange

            //Act
            var enumValue = Validation.UserEntry("one");

            //Assert
            Assert.True(enumValue);
        }
        
        [Fact]
        public void ReturnFalseWhenValidatingUserInput()
        {
            //Arrange

            //Act
            var actual = Validation.UserEntry("tree");

            //Assert
            Assert.False(actual);
        }

        [Fact]
        public void DoorAndPrizeStateTest()
        {
            //Arrange
            var game = new MontyHallGame();

            //Act
            var result = game.AnnouncersDoor();

            //Assert
            Assert.Equal("joke", game.DoorPrizeStorage[result]);

        }
    }
}
