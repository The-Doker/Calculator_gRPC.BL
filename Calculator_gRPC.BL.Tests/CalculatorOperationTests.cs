using Calculator_gRPC.BL.Classes;
using Calculator_gRPC.Models;
using Moq;
using System;
using Xunit;

namespace Calculator_gRPC.BL.Tests
{
    public class CalculatorOperationTests
    {
        [Fact]
        public void InvalidOperationType()
        {
            // Arrange
            int typeOfOperation = 4;
            var firstFakeParameter = new Mock<Parameters>();
            var secondFakeParameter = new Mock<Parameters>();
            Parameters[] fakeParameters = new Parameters[2] {firstFakeParameter.Object, secondFakeParameter.Object}; 
            // Act & Assert
            var ex = Assert.Throws<Exception>(() => CalculatorOperation.Execute(typeOfOperation, fakeParameters));
            Assert.Equal("Invalid type of Operation", ex.Message);
        }
        [Fact]
        public void DivineFivePositiveValues()
        {
            // Arrange
            int typeOfOperation = 3;
            var firstParameter = new Parameters() { Name = "ObjectA", Value = 10_000M };
            var secondParameter = new Parameters() { Name = "ObjectB", Value = 10M };
            var thirdParameter = new Parameters() { Name = "ObjectC", Value = 10M };
            var fourthParameter = new Parameters() { Name = "ObjectD", Value = 10M };
            var fifthParameter = new Parameters() { Name = "ObjectE", Value = 10M };
            Parameters[] Parameters = new Parameters[5] { firstParameter, secondParameter, thirdParameter, fourthParameter, fifthParameter };
            // Act
            var result = CalculatorOperation.Execute(typeOfOperation, Parameters);
            // Assert
            Assert.Equal(1M, result.CalculateResut);
            Assert.Equal("ObjectA / ObjectB / ObjectC / ObjectD / ObjectE", result.Description);
        }
    }
}
