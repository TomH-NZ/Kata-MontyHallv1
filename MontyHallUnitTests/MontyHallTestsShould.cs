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

        [Theory]
        [InlineData("one", "joke")]
        [InlineData("two", "serious")]
        [InlineData("three", "joke")]
        public void ShowAPrizeWhenDoorTwoIsSelected(string door, string prize)
        {
            //Arrange
            var montyHallGame = new MontyHallGame();
            
            //Act
            var result = montyHallGame.AssignFixedPrizeToDoor(door);

            //Assert
            Assert.Equal(prize, result);
        }

        class RandomDoorStubDoorOne : IRandomPrizeDoor
        {
            public string RandomPrizeDoor()
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
            IRandomPrizeDoor random = new RandomDoorStubDoorOne();
            
            //Act
            var result = montyHallGame.AssignRandomPrizeToDoor(door, random);

            //Assert
            Assert.Equal(prize, result);
        }
        
        class RandomDoorStubDoorThree : IRandomPrizeDoor
        {
            public string RandomPrizeDoor()
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
            IRandomPrizeDoor random = new RandomDoorStubDoorThree();
            
            //Act
            var result = montyHallGame.AssignRandomPrizeToDoor(door, random);

            //Assert
            Assert.Equal(prize, result);
        }
    }
}
