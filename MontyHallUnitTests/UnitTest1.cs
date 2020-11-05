using System;
using System.Collections.Generic;
using MontyHallv1;
using Xunit;

namespace MontyHallUnitTests
{
    public class UnitTest1
    {
        [Fact]
        public void TestGeneratingThreeDoors()
        {
            //Arrange
            var MontyHallGame = new MontyHallGame();
            
            //Act
            var actual = MontyHallGame.Doors.Count;

            //Assert
            Assert.Equal(3, actual);
        }

        [Fact]
        public void TestingDoorConstructor()
        {
            //Arrange
            var MontyHallGame = new MontyHallGame("one");
            
            //Act
            var result = MontyHallGame.PlayerSelection;
            var expected = "one";

            //Assert
            Assert.Equal(expected, result);

        }
    }
}