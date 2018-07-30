using System;
using System.Collections.Generic;

using Xunit; using System.ComponentModel;
using FluentAssertions;

namespace CuttingEdge.Conditions.UnitTests
{
    
    public class AlternativeExceptionConditionTests
    {
        [Fact]
        [Description("WithExceptionOnFailure called with a valid exception type does not return null.")]
        public void WithExceptionOnFailure_WithValidExceptionType_ReturnsAnInstance()
        {
            // Act
            var condition = Condition.WithExceptionOnFailure<InvalidOperationException>();

            // Assert
            Assert.NotNull(condition);
        }

        [Fact]
        [Description("WithExceptionOnFailure called with a valid exception throws that same type in case of a validation failure.")]
        public void WithExceptionOnFailure_WithValidExceptionType1_ThrowsSpecifiedExceptionOnValidationFailure()
        {
            // Arrange
            string value = null;

            // Act
            Action a = () => Condition.WithExceptionOnFailure<ObjectDisposedException>().Requires(value).IsNotNull();

            // Assert
            a.Should().Throw<ObjectDisposedException>();
        }

        [Fact]
        [Description("WithExceptionOnFailure called with a valid exception throws that same type in case of a validation failure.")]
        public void WithExceptionOnFailure_WithValidExceptionType2_ThrowsSpecifiedExceptionOnValidationFailure()
        {
            // Arrange
            string value = null;

            // First call WithExceptionOnFailure for another exception type.
            Condition.WithExceptionOnFailure<KeyNotFoundException>();

            // Act 
            Action a = () => Condition.WithExceptionOnFailure<ApplicationException>().Requires(value).IsNotNull();

            // Assert
            a.Should().Throw<ApplicationException>();
        }

        [Fact]
        [Description("WithExceptionOnFailure called with an invalid exception throws an exception with the expected message.")]
        public void WithExceptionOnFailure_WithInvalidExceptionType_ThrowsExceptionWithExpectedMessage()
        {
            // Arrange
            string expectedMessage = 
                "The type must be concrete and have a public constructor with a single string argument.";

            // Act
            Action a = () => Condition.WithExceptionOnFailure<NoValidConstructorException>();

            // Assert
            a.Should().Throw<ArgumentException>().Which.Message.Contains(expectedMessage);
        }

        [Fact]
        [Description("WithExceptionOnFailure called with an invalid exception throws an exception with the expected parameter name.")]
        public void WithExceptionOnFailure_WithInvalidExceptionType_ThrowsExceptionWithExpectedParamName()
        {
            // Arrange
            string expectedParamName = "TException";

            // Act
            Action a = () => Condition.WithExceptionOnFailure<NoValidConstructorException>();

            // Assert
            a.Should().Throw<ArgumentException>().Which.ParamName.Should().Be(expectedParamName, "Invalid ParamName.");
        }

        [Fact]
        [Description("WithExceptionOnFailure called with an abstract exception type throws an exception of type ArgumentException.")]
        public void WithExceptionOnFailure_WithAbstractExceptionType_ThrowsExpectedExceptionType()
        {
            // Act
            Action a = () => Condition.WithExceptionOnFailure<AbstractException>();

            // Assert
            a.Should().Throw<ArgumentException>();
        }

        [Fact]
        [Description("WithExceptionOnFailure called multiple times with the same exception type, always returns the same instance.")]
        public void WithExceptionOnFailure_CalledMultipleTimesWithTheSameExceptionType_ReturnsTheSameInstance()
        {
            // Act
            var condition1 = Condition.WithExceptionOnFailure<InvalidOperationException>();
            var condition2 = Condition.WithExceptionOnFailure<InvalidOperationException>();

            // Assert
            string assertMessage = "Two calls to WithExceptionOnFailure for the same exception type are " +
                "expected to return the same instance for performance reasons.";

            condition1.Should().Be(condition2, assertMessage);
        }

        [Fact]
        [Description("WithExceptionOnFailure called multiple times with the different exception type, always returns different instances.")]
        public void WithExceptionOnFailure_CalledWithDifferentExceptionType_ReturnsDifferentInstances()
        {
            // Act
            var condition1 = Condition.WithExceptionOnFailure<InvalidOperationException>();
            var condition2 = Condition.WithExceptionOnFailure<ObjectDisposedException>();

            // Assert
            string assertMessage = "Two calls to WithExceptionOnFailure for different exception type are " +
                "expected to return different instances, because each type will get its own condition type.";

            condition1.Should().NotBe(condition2, assertMessage);
        }

        protected class NoValidConstructorException : Exception
        {
            public NoValidConstructorException() 
            { 
            }
        }

        protected abstract class AbstractException : Exception
        {
            public AbstractException(string message)
            {
            }
        }
    }
}