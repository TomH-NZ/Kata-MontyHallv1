using System.Runtime.InteropServices;
using MontyHallv1.Enums;
using MontyHallv1.Interfaces;
using Moq;
using Xunit;

namespace MontyHallUnitTests.AutomationTests
{
    public class AutomationTestsShould
    {
        [Fact]
        public void TestMoqCorrectly()
        {
            var moqTest = new Mock<IInputGenerator>();
            moqTest.Setup(inputGenerator => inputGenerator.PlayerSelection()).Returns(PrizeDoors.three);

            var wrappedTypeInstance = moqTest.Object;
            wrappedTypeInstance.PlayerSelection();
            wrappedTypeInstance.PlayerSelection();
            
            //Assert.Equal(PrizeDoors.three, wrappedTypeInstance.PlayerSelection());
            moqTest.Verify(calledProcess => calledProcess.PlayerSelection(), Times.Once);
        }
    }
}
//https://github.com/Moq/moq4/wiki/Quickstart