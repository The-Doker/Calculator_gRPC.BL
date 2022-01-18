using Calculator_gRPC.BL.Classes;
using System;
using Xunit;

namespace Calculator_gRPC.BL.Tests
{
    public class BasicOperationsTests
    {
        [Fact]
        public void SumOfTwoPositiveValues()
        {
            // Arrange
            decimal firstValue = 34.5M;
            decimal secondValue = 25.5M;
            int typeOfAddingOperation = 0; 
            // Act
            var resultOfAddingOperation = BasicOperations.CalculateValues(typeOfAddingOperation, firstValue, secondValue);
            // Assert
            Assert.Equal(60M, resultOfAddingOperation);
        }
        [Fact]
        public void SubtractionOfTwoPositiveValues()
        {
            // Arrange
            decimal firstValue = 30.5M;
            decimal secondValue = 40.5M;
            int typeOfSubtractionOperation = 1;
            // Act
            var resultOfSubtractionOperation = BasicOperations.CalculateValues(typeOfSubtractionOperation, firstValue, secondValue);
            // Assert
            Assert.Equal(-10M, resultOfSubtractionOperation);
        }
        [Fact]
        public void SumOfTwoNegativeValues()
        {
            // Arrange
            decimal firstValue = -34.5M;
            decimal secondValue = -25.5M;
            int typeOfAddingOperation = 0;
            // Act
            var resultOfAddingOperation = BasicOperations.CalculateValues(typeOfAddingOperation, firstValue, secondValue);
            // Assert
            Assert.Equal(-60M, resultOfAddingOperation);
        }
        [Fact]
        public void SubtractionOfTwoNegativeValues()
        {
            // Arrange
            decimal firstValue = -30.5M;
            decimal secondValue = -40.5M;
            int typeOfSubtractionOperation = 1;
            // Act
            var resultOfSubtractionOperation = BasicOperations.CalculateValues(typeOfSubtractionOperation, firstValue, secondValue);
            // Assert
            Assert.Equal(10M, resultOfSubtractionOperation);
        }
        [Fact]
        public void MultiplicationOfTwoPositiveValues()
        {
            // Arrange
            decimal firstValue = 10.0M;
            decimal secondValue = 1.5M;
            int typeOfMultiplicationOperation = 2;
            // Act
            var resultOfMultiplicationOperation = BasicOperations.CalculateValues(typeOfMultiplicationOperation, firstValue, secondValue);
            // Assert
            Assert.Equal(15.0M, resultOfMultiplicationOperation);
        }
        [Fact]
        public void MultiplicationOfNegativeValueAndZero()
        {
            // Arrange
            decimal firstValue = -10.0M;
            decimal secondValue = 0M;
            int typeOfMultiplicationOperation = 2;
            // Act
            var resultOfMultiplicationOperation = BasicOperations.CalculateValues(typeOfMultiplicationOperation, firstValue, secondValue);
            // Assert
            Assert.Equal(0M, resultOfMultiplicationOperation);
        }
        [Fact]
        public void DivisionOfTwoNegativeValues()
        {
            // Arrange
            decimal firstValue = -10.0M;
            decimal secondValue = -2.5M;
            int typeOfDivisionOperation = 3;
            // Act
            var resultOfDivisionOperation = BasicOperations.CalculateValues(typeOfDivisionOperation, firstValue, secondValue);
            // Assert
            Assert.Equal(4M, resultOfDivisionOperation);
        }
        [Fact]
        public void DivisionOfNegativeValueByZero()
        {
            // Arrange
            decimal firstValue = -10.0M;
            decimal secondValue = 0M;
            int typeOfDivisionOperation = 3;
            // Act & Assert
            var ex = Assert.Throws<Exception>(() => BasicOperations.CalculateValues(typeOfDivisionOperation, firstValue, secondValue));
            Assert.Equal("Divine by zero", ex.Message);
        }
        [Fact]
        public void ConcatStringsForAllTypesOfOperations()
        {
            // Arrange
            string firstValueName = "OperandA";
            string secondValueName = "OperandB";
            // Act
            var resultOfConcatOperationForType0 = BasicOperations.ConcatStringsForValues(0, firstValueName, secondValueName);
            var resultOfConcatOperationForType1 = BasicOperations.ConcatStringsForValues(1, firstValueName, secondValueName);
            var resultOfConcatOperationForType2 = BasicOperations.ConcatStringsForValues(2, firstValueName, secondValueName);
            var resultOfConcatOperationForType3 = BasicOperations.ConcatStringsForValues(3, firstValueName, secondValueName);
            // Assert
            Assert.Equal("OperandA + OperandB", resultOfConcatOperationForType0);
            Assert.Equal("OperandA - OperandB", resultOfConcatOperationForType1);
            Assert.Equal("OperandA * OperandB", resultOfConcatOperationForType2);
            Assert.Equal("OperandA / OperandB", resultOfConcatOperationForType3);
        }
    }
}
