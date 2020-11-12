using System.Collections;
using System.Collections.Generic;
using System.Linq;
using MontyHallv1;
using Xunit;

namespace MontyHallUnitTests
{
    public class UnitTest1
    {
        [Fact]
        public void ShowThreeDoorsWhenAGameIsCreated()
        {
            //Arrange
            var montyHallGame = new MontyHallGame();
            
            //Act
            var actual = montyHallGame.Doors.Count;

            //Assert
            Assert.Equal(3, actual);
        }

        [Fact]
        public void DisplayAUserSelectionWhenAGameIsCreated()
        {
            //Arrange
            var montyHallGame = new MontyHallGame("one");
            
            //Act
            var result = montyHallGame.PlayerSelection;
            var expected = "one";

            //Assert
            Assert.Equal(expected, result);
        }

        class RandomDoorStubDoorOne : IRandom
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
            var montyHallGame = new MontyHallGame();
            IRandom random = new RandomDoorStubDoorOne();
            
            //Act
            var result = montyHallGame.Door.AssignRandomPrize(door, random);

            //Assert
            Assert.Equal(prize, result);
        }

        class RandomDoorStubDoorTwo : IRandom
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
            var montyHallGame = new MontyHallGame();
            IRandom random = new RandomDoorStubDoorTwo();
            
            //Act
            var result = montyHallGame.Door.AssignRandomPrize(door, random);

            //Assert
            Assert.Equal(prize, result);
        }
        
        class RandomDoorStubDoorThree : IRandom
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
            var montyHallGame = new MontyHallGame();
            IRandom random = new RandomDoorStubDoorThree();
            
            //Act
            var result = montyHallGame.Door.AssignRandomPrize(door, random);

            //Assert
            Assert.Equal(prize, result);
        }
        
        public static IEnumerable<object[]> TestMember()
        {
            var stubOne = new RandomDoorStubDoorOne();
            var stubTwo = new RandomDoorStubDoorTwo();
            var stubThree = new RandomDoorStubDoorThree();
            
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
        public void ShowAPrizeWhenAWinningDoorIsSelectedWithMemberData(string door, string prize, IRandom random)
        {
            //Arrange
            var montyHallGame = new MontyHallGame();

            //Act
            var result = montyHallGame.Door.AssignRandomPrize(door, random);

            //Assert
            Assert.Equal(prize, result);
        }

        [Fact]
        public void ShowIfTheDoorIsOpen()
        {
            //Arrange
            var montyHallGame = new MontyHallGame();

            //Act
            var result = montyHallGame.Door.OpenStatus("one");

            //Assert
            Assert.True(result);
        }
    }
}
