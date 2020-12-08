using MontyHallv1.Enums;
using MontyHallv1.Game;
using MontyHallv1.Interfaces;
using MontyHallv1.MoqTestFolder;
using Moq;
using Xunit;

namespace MontyHallUnitTests.AutomationTests
{
    public class MoqTestsShould
    {
        [Fact]
        public void TestMoqCorrectly()
        {
            var moqTest = new Mock<IInputGenerator>();
            moqTest.Setup(inputGenerator => inputGenerator.PlayerSelection()).Returns(PrizeDoors.three);

            var wrappedTypeInstance = moqTest.Object;
            
            Assert.Equal(PrizeDoors.three, wrappedTypeInstance.PlayerSelection());
        }

        [Fact]
        public void TestAdditionCorrectly() 
        {
            //Arrange
            var moqTest = new Mock<IMoqTestPagev1>();
            moqTest.Setup(x => x.PlusOneAddition(It.IsAny<int>())).Returns(4);
            var moqObject = moqTest.Object;
            
            //Act
            var result = moqObject.PlusOneAddition(0);
            
            //Assert
            Assert.Equal(4, result);
        }

        [Fact]
        public void ReturnACorrectGreaterThanResult()
        {
            //Arrange
            var moqTest = new Mock<IMoqTestPagev1>();
            //moqTest.Setup(x => x.Greater(It.Is<int>(y => y > 1))).Returns(true);
            moqTest.Setup(x => x.Greater(It.IsAny<int>())).Returns(true);
            var moqObject = moqTest.Object;

            //Act
            var result = moqObject.Greater(3);

            //Assert
            Assert.True(result);
        }

        [Fact]
        public void UpdateThePrizeDoorDictionaryWithMoq()
        {
            //Arrange
            var moqRandomDoor = new Mock<IRandomPrizeDoorAssigner>();
            moqRandomDoor.Setup(randomDoor => randomDoor.PrizeDoor()).Returns(PrizeDoors.three);
            var gameUnderTest = new MontyHallGame(PrizeDoors.one, moqRandomDoor.Object);
            
            //Act
            gameUnderTest.UpdatePrizeStorage();

            //Assert
            Assert.Equal("serious", gameUnderTest.DoorPrizeStorage[PrizeDoors.three]);
        }
    }
}
//https://github.com/Moq/moq4/wiki/Quickstart