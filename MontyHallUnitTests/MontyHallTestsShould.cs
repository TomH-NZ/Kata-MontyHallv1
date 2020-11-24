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
            var montyHallGame = new MontyHallGame(PrizeDoors.one, randomPrizeDoorAssigner );
            
            //Act
            var result = montyHallGame.PlayerSelection;
            var expected = PrizeDoors.one;

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
            var game = new MontyHallGame(PrizeDoors.two, new RandomDoorStubDoorTwo());

            //Act
            var result = game.AnnouncersDoor();

            //Assert
            Assert.Equal(PrizeDoors.one, result);
        }
        
        class AlternatingDoorTwoAndThreeStub : IRandomPrizeDoorAssigner
        {
            private int _counter;
            public string PrizeDoor()
            {
                var output = _counter % 2 == 0 ? "two" : "three";
                _counter++;
                return output;
            }
        }
        
        [Fact]
        public void AlwaysReturnAPrizeWhenADoorIsOpened()
        {
            //Arrange
            var game = new MontyHallGame(PrizeDoors.one, new AlternatingDoorTwoAndThreeStub());

            //Act
            var result = game.AnnouncersDoor();

            //Assert
            Assert.Equal(PrizeDoors.two, result);
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

        [Fact]
        public void ConvertUserStringToEnum()
        {
            //Arrange
            var stringValidation = Validation.InputConversion("one");
            
            //Act
            var result = PrizeDoors.one;

            //Assert
            Assert.Equal(result, stringValidation);
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
        
        class RandomPrizeDoorStubOne : IRandomPrizeDoorAssigner
        {
            public string PrizeDoor()
            {
                return "one";
            }
        }

        [Theory]
        [InlineData(PrizeDoors.one, "serious")]
        [InlineData(PrizeDoors.two, "joke")]
        //[InlineData(PrizeDoors.three, "joke")]
        public void ReturnCorrectPrizeFromDoorPrizeStorageTheory(PrizeDoors prizeDoor, string prizeResult)
        {
            //Arrange
            var game = new MontyHallGame(prizeDoor, new RandomPrizeDoorStubOne());
            
            //Act
            game.UpdateDictionary(prizeDoor);
            var actual = game.DoorPrizeStorage[prizeDoor];
            
            //Assert
            Assert.Equal(prizeResult, actual);
        }
        
        [Fact]
        public void ReturnCorrectPrizeFromDoorPrizeStorageFact()
        {
            //Arrange
            var game = new MontyHallGame(PrizeDoors.one, new RandomPrizeDoorStubOne());
            
            //Act
            game.UpdateDictionary(PrizeDoors.one);
            var actualDoorOnePrize = game.DoorPrizeStorage[PrizeDoors.one];
            var actualDoorTwoPrize = game.DoorPrizeStorage[PrizeDoors.two];
            
            //Assert
            Assert.Equal("serious", actualDoorOnePrize);
            Assert.Equal("joke", actualDoorTwoPrize);
        }
    }
}
