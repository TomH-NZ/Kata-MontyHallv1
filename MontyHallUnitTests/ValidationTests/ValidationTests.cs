using System;
using System.Collections.Generic;
using MontyHallv1;
using Xunit;

namespace MontyHallUnitTests
{
    public class ValidationTests
    {
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
    }
}