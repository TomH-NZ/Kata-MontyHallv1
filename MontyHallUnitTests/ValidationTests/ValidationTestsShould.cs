using System;
using System.Collections.Generic;
using MontyHallv1;
using MontyHallv1.Validation;
using Xunit;

namespace MontyHallUnitTests
{
    public class ValidationTests
    {
        [Theory]
        [InlineData("yes", true)]
        [InlineData("no", true)]
        [InlineData("y", false)]
        [InlineData("n", false)]
        [InlineData("orange", false)]
        public void ReturnCorrectValueForChangeDoorInputValidator(string userEntry, bool outputValue)
        {
            //Arrange
            
            //Act
            var actual = Validation.ChangeDoorValidator(userEntry);

            //Assert
            Assert.Equal(outputValue, actual);
        }
        
        [Fact]
        public void ReturnTrueWhenValidatingUserInput()
        {
            //Arrange

            //Act
            var enumValue = Validation.UserEntryValidator("one");

            //Assert
            Assert.True(enumValue);
        }
        
        [Fact]
        public void ReturnFalseWhenValidatingUserInput()
        {
            //Arrange

            //Act
            var actual = Validation.UserEntryValidator("tree");

            //Assert
            Assert.False(actual);
        }
    }
}