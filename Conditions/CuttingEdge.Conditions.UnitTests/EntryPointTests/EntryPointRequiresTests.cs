#region Copyright (c) 2009 S. van Deursen
/* The CuttingEdge.Conditions library enables developers to validate pre- and postconditions in a fluent 
 * manner.
 * 
 * To contact me, please visit my blog at http://www.cuttingedge.it/blogs/steven/ 
 *
 * Copyright (c) 2009 S. van Deursen
 * 
 * Permission is hereby granted, free of charge, to any person obtaining a copy of this software and
 * associated documentation files (the "Software"), to deal in the Software without restriction, including
 * without limitation the rights to use, copy, modify, merge, publish, distribute, sublicense, and/or sell
 * copies of the Software, and to permit persons to whom the Software is furnished to do so, subject to the
 * following conditions:
 * 
 * The above copyright notice and this permission notice shall be included in all copies or substantial
 * portions of the Software.
 * 
 * THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND, EXPRESS OR IMPLIED, INCLUDING BUT NOT
 * LIMITED TO THE WARRANTIES OF MERCHANTABILITY, FITNESS FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT. IN NO
 * EVENT SHALL THE AUTHORS OR COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER LIABILITY, WHETHER
 * IN AN ACTION OF CONTRACT, TORT OR OTHERWISE, ARISING FROM, OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE
 * USE OR OTHER DEALINGS IN THE SOFTWARE.
*/
#endregion

using System;

using Xunit; using System.ComponentModel;
using FluentAssertions;

namespace CuttingEdge.Conditions.UnitTests.EntryPointTests
{
    /// <summary>
    /// Tests the Condition.Requires method.
    /// </summary>
    
    public class EntryPointRequiresTests
    {
        [Fact]
        [Description("Checks whether the validator returned from Requires() will fail with an ArgumentException.")]
        public void RequiresTest01()
        {
            int a = 3;
            Action action = () => Condition.Requires(a).IsEqualTo(4);
            action.Should().Throw<ArgumentException>();
        }

        [Fact]
        [Description("Checks whether the parameterName on the Requires() will be used.")]
        public void RequiresTest02()
        {
            int a = 3;
            try
            {
                Condition.Requires(a, "foobar").IsEqualTo(4);
            }
            catch (Exception ex)
            {
                Assert.Equal(true, ex.Message.Contains("foobar"));
            }
        }

        [Fact]
        [Description("Checks whether supplying an invalid ConstraintViolationType results in the return of the default exception.")]
        public void RequiresTest03()
        {
            ConditionValidator<int> requiresValidator = Condition.Requires(3);

            const string ValidCondition = "valid condition";
            const string ValidAdditionalMessage = "valid additional message";
            const ConstraintViolationType InvalidConstraintViolationType = (ConstraintViolationType)666;

            const string AssertMessage = "RequiresValidator.ThrowException should throw an " +
                "ArgumentException when an invalid ConstraintViolationType is supplied.";

            Action action = () => requiresValidator.ThrowException(ValidCondition, ValidAdditionalMessage,
                InvalidConstraintViolationType);

            action.Should().Throw<ArgumentException>(AssertMessage).Which.Message.Should().Contain(ValidCondition, "The exception message does not contain the condition.");
        }
    }
}