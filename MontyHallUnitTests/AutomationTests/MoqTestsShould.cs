using MontyHallv1.Enums;
using MontyHallv1.Game;
using MontyHallv1.Interfaces;
using MontyHallv1.MoqTestFolder;
using Moq;
using Xunit;

namespace MontyHallUnitTests.AutomationTests
{
    public class MoqTestsShould //https://github.com/Moq/moq4/wiki/Quickstart
    {
        [Fact]
        public void ReturnAValueCorrectly()
        {
            //Arrange
            var moqTest = new Mock<IInputGenerator>();
            moqTest.Setup(inputGenerator => inputGenerator.PlayerSelection()).Returns(PrizeDoors.three);

            //Act
            var wrappedTypeInstance = moqTest.Object;
            
            //Assert
            Assert.Equal(PrizeDoors.three, wrappedTypeInstance.PlayerSelection());
        }

        [Fact]
        public void CallAProcessAtLeastOnce()
        {
            //Arrange
            var moqTest = new Mock<IInputGenerator>();
            var wrappedTypeInstance = moqTest.Object;
            
            //Act
            wrappedTypeInstance.PlayerSelection();
            wrappedTypeInstance.PlayerSelection();
            
            //Assert
            moqTest.Verify(calledProcess => calledProcess.PlayerSelection(), Times.AtLeastOnce);
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

        // If a test does not have .Setup then the method will return default values, based on the return type.
        //(int = 0, string = null, bool = false, etc)
        // .Setup creates the implementation that the test uses. 
        [Fact]
        public void ReturnAFalseValueFromABoolAsDefault() // Test will return false due to the interface not  
        {  //having an implementation of the method.
            //Arrange
            var moqTest = new Mock<IMoqTestPagev1>();
            var moqObject = moqTest.Object;

            //Act
            var result = moqObject.Greater(6);

            //Assert
            Assert.False(result);
        }
        
        [Fact]
        public void ReturnANullValueFromAStringAsDefault()
        {
            //Arrange
            var moqTest = new Mock<IMoqTestPagev1>();
            var moqObject = moqTest.Object;

            //Act
            var result = moqObject.TestReturn();

            //Assert
            Assert.Null(result);
        }

        [Fact]
        public void SetThePropertyCorrectlyFromMoq()
        {
            //Arrange
            var moqTest = new Mock<IMoqTestPagev1>();
            moqTest.SetupProperty(foo => foo.playerDoor, PrizeDoors.two);
            var moqObject = moqTest.Object;

            //Act
            var result = moqObject.playerDoor;

            //Assert
            Assert.Equal(PrizeDoors.two, result);
        }

        [Fact]
        public void NotCallAProcess()
        {
            //Arrange
            var moqTest = new Mock<IInputGenerator>();
            var moqObject = moqTest.Object;

            //Act
            moqObject.PlayerSelection();

            //Assert
            moqTest.Verify(obj => obj.AnnouncerDoor(), Times.Never);
        }

        [Fact (Skip = "Unsure of exact layout of test")]
        public void CallTheMethodsInTheCorrectOrder()
        {
            //Arrange
            var moqTest = new Mock<MontyHallGame>(MockBehavior.Strict);
            var moqSequence = new MockSequence();
            
            //Act
            //_announcersDoor.InSequence(moqSequence).Setup(x => x.)
            
            //Assert
        }
        
        
    }
}
