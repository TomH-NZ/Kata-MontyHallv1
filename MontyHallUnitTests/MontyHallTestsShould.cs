using System;
using System.Collections.Generic;
using MontyHallv1;
using Xunit;

namespace MontyHallUnitTests //TODO: split tests out to new classes depending on behaviour being tested.
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
            var montyHallGame = new MontyHallGame(PrizeDoors.one, randomPrizeDoorAssigner );
            
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

        [Fact]
        public void ShowAJokePrizeWhenAnnouncerOpensADoor()
        {
            //Arrange
            var game = new MontyHallGame(PrizeDoors.two, new StubForDoorThreeReturnsSerious());

            //Act
            var result = game.AnnouncersDoor();

            //Assert
            Assert.Equal(PrizeDoors.one, result);
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

        public static IEnumerable<object[]> PrizeDoorStorageTestMember()
        {
            //Generates the stub object that is used by the data in the test.
            var stubOne = new StubForDoorOneReturnsSerious();
            var stubTwo = new StubForDoorTwoReturnsSerious();
            var stubThree = new StubForDoorThreeReturnsSerious();
            
            //This creates the data that is to be tested, similar to the [Theory] InlineData tests.
            return new List<object[]>
            {
                new object[] {PrizeDoors.one, PrizeDoors.one,  "serious", stubOne},
                new object[] {PrizeDoors.two, PrizeDoors.one, "joke", stubOne},
                new object[] {PrizeDoors.three, PrizeDoors.one, "joke", stubOne},

                new object[] {PrizeDoors.one, PrizeDoors.two, "joke", stubTwo},
                new object[] {PrizeDoors.two, PrizeDoors.two, "serious", stubTwo},
                new object[] {PrizeDoors.three, PrizeDoors.two, "joke", stubTwo},

                new object[] {PrizeDoors.one, PrizeDoors.three, "joke", stubThree},
                new object[] {PrizeDoors.two, PrizeDoors.three, "joke", stubThree},
                new object[] {PrizeDoors.three, PrizeDoors.three, "serious", stubThree}
            };
        }
        
        [Theory] 
        [MemberData(nameof(PrizeDoorStorageTestMember))]
        public void ReturnCorrectPrizeFromDoorPrizeStorageTheory(PrizeDoors testedDoor, PrizeDoors actualPrize, string prizeResult, IRandomPrizeDoorAssigner randomPrizeDoorAssigner)
        {
            //Arrange
            var game = new MontyHallGame(testedDoor, randomPrizeDoorAssigner);
            
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
            var game = new MontyHallGame();
            
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
            var game = new MontyHallGame(PrizeDoors.three, new StubForDoorOneReturnsSerious());
            
            //Act
            game.ChangePlayerDoor();
            var actual = game.PlayerSelection;

            //Assert
            Assert.Equal(PrizeDoors.two, actual);
        }
        
        [Fact]
        public void AllowPlayerToChangeDoorToDoorOne() // use ugly code to get this test passing.
        {
            //Arrange
            var game = new MontyHallGame(PrizeDoors.two, new StubForDoorOneReturnsSerious());
            
            //Act
            game.ChangePlayerDoor();
            var actual = game.PlayerSelection;

            //Assert
            Assert.Equal(PrizeDoors.one, actual);
        }
        
        

        [Fact]
        public void ReturnTrueForChangeDoorInputValidation()
        {
            //Arrange
            
            //Act
            var actual = Validation.ChangeDoorValidator("yes");

            //Assert
            Assert.True(actual);
        }

        [Fact]
        public void ReturnFalseForChangeDoorInputValidation()
        {
            //Arrange
            
            //Act
            var actual = Validation.ChangeDoorValidator("y");

            //Assert
            Assert.False(actual);

        }
    }
}
