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
            public PrizeDoors PrizeDoor()
            {
                return PrizeDoors.one;
            }
        }

        private class StubForDoorTwoReturnsSerious : IRandomPrizeDoorAssigner
        {
            public PrizeDoors PrizeDoor()
            {
                return PrizeDoors.two;
            }
        }

        private class StubForDoorThreeReturnsSerious : IRandomPrizeDoorAssigner
        {
            public PrizeDoors PrizeDoor()
            {
                return PrizeDoors.three;
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
                new object[]{PrizeDoors.one, "serious", stubOne },
                new object[]{PrizeDoors.two, "joke", stubOne},
                new object[]{PrizeDoors.three, "joke", stubOne},
                
                new object[]{PrizeDoors.one, "joke", stubTwo },
                new object[]{PrizeDoors.two, "serious", stubTwo},
                new object[]{PrizeDoors.three, "joke", stubTwo},
                
                new object[]{PrizeDoors.one, "joke", stubThree },
                new object[]{PrizeDoors.two, "joke", stubThree},
                new object[]{PrizeDoors.three, "serious", stubThree}
            };
        }
        
        [Theory]
        [MemberData(nameof(AssignRandomPrizeTestMember))]
        public void ShowAPrizeWhenAWinningDoorIsSelectedWithMemberData(PrizeDoors door, string prize, IRandomPrizeDoorAssigner randomPrizeDoorAssigner)
        {
            //Arrange

            //Act
            var result = Door.AssignRandomPrize(door, randomPrizeDoorAssigner);

            //Assert
            Assert.Equal(prize, result);
        }

        [Theory]
        [InlineData("one", PrizeDoors.one)]
        [InlineData("two", PrizeDoors.two)]
        [InlineData("three", PrizeDoors.three)]
        public void OutputTheUserInputToAsAnEnum(string userInput, PrizeDoors expected)
        {
            //Arrange
            
            //Act
            var actual = Validation.UserInputConversion(userInput);

            //Assert
            Assert.Equal(actual, expected );
        }
    }
}
