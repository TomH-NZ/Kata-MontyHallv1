using System;
using System.Collections.Generic;
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
            var MontyHallGame = new MontyHallGame();
            
            //Act
            var actual = MontyHallGame.Doors.Count;

            //Assert
            Assert.Equal(3, actual);
        }

        [Fact]
        public void DisplayAUserSelectionWhenAGameIsCreated()
        {
            //Arrange
            var MontyHallGame = new MontyHallGame("one");
            
            //Act
            var result = MontyHallGame.PlayerSelection;
            var expected = "one";

            //Assert
            Assert.Equal(expected, result);
        }

        [Theory]
        [InlineData("one", "joke")]
        [InlineData("two", "serious")]
        [InlineData("three", "joke")]
        public void ShowAPrizeWhenADoorIsSelected(string door, string prize)
        {
            //Arrange
            var MontyHallGame = new MontyHallGame();
            
            //Act
            var result = MontyHallGame.AssignPrize(door);
            //var expected = prize;

            //Assert
            Assert.Equal(prize, result);
        }
    }
}