using MontyHallv1.Enums;
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
            //wrappedTypeInstance.PlayerSelection();
            //wrappedTypeInstance.PlayerSelection();
            
            Assert.Equal(PrizeDoors.three, wrappedTypeInstance.PlayerSelection());
            //moqTest.Verify(calledProcess => calledProcess.PlayerSelection(), Times.Once); //will fail as the method is called twice.
        }

        [Fact]
        public void TestAdditionCorrectly() // test not working correctly
        {
            //Arrange
            var moqTest = new Mock<IMoqTestPagev1>();
            moqTest.Setup(x => x.PlusOneAddition(It.IsAny<int>())).Returns(() => 4);
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
    }
}
//https://github.com/Moq/moq4/wiki/Quickstart