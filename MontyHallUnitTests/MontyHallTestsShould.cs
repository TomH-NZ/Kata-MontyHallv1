using System;
using System.Collections.Generic;
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

            //Act
            var actual = Enum.GetNames(typeof(PrizeDoors)).Length;

            //Assert
            Assert.Equal(3, actual);
        }

        [Fact]
        public void DisplayAUserSelectionWhenAGameIsCreated()
        {
            //Arrange
            var randomPrizeDoorAssigner= new RandomPrizeDoorAssigner();
            var montyHallGame = new MontyHallGame(PrizeDoors.one );
            
            //Act
            var result = montyHallGame.PlayerSelection;
            var expected = PrizeDoors.one;

            //Assert
            Assert.Equal(expected, result);
        }

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

        public static IEnumerable<object[]> AssignRandomPrizeTestMember()
        {
            //Generates the stub object that is used by the data in the test.
            var stubOne = new StubForDoorOneReturnsSerious();
            var stubTwo = new StubForDoorTwoReturnsSerious();
            var stubThree = new StubForDoorThreeReturnsSerious();
            
            //This creates the data that is to be tested, similar to the [Theory] InlineData tests.
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
        [MemberData(nameof(AssignRandomPrizeTestMember))]
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

        [Theory]
        [InlineData("one", PrizeDoors.one)]
        [InlineData("two", PrizeDoors.two)]
        [InlineData("three", PrizeDoors.three)]
        public void OutputTheUserInputToAsAnEnum(string userInput, PrizeDoors expected)
        {
            //Arrange
            
            //Act
            var actual = Validation.InputConversion(userInput);

            //Assert
            Assert.Equal(actual, expected );
        }
    }
}
