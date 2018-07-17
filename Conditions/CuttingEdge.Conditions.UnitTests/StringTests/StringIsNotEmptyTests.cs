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

namespace CuttingEdge.Conditions.UnitTests.StringTests
{
    /// <summary>
    /// Tests the ValidatorExtensions.IsNotEmpty method.
    /// </summary>
    
    public class StringIsNotEmptyTests
    {
        [Fact]
        [Description("Calling IsNotEmpty on string x with 'x == String.Empty' should fail.")]
        public void IsStringNotEmptyTest1()
        {
            string s = String.Empty;
            Action action = () => Condition.Requires(s).IsNotEmpty();
            action.Should().Throw<ArgumentException>();
        }

        [Fact]
        [Description("Calling IsNotEmpty on string x with 'x != String.Empty' should pass.")]
        public void IsStringNotEmptyTest2()
        {
            string s = null;
            Condition.Requires(s).IsNotEmpty();
        }

        [Fact]
        [Description("Calling IsNotEmpty on string x with 'x != String.Empty' should pass.")]
        public void IsStringNotEmptyTest3()
        {
            string s = "test";
            Condition.Requires(s).IsNotEmpty();
        }

        [Fact]
        [Description("Calling IsNotEmpty with conditionDescription parameter should pass.")]
        public void IsStringNotEmptyTest4()
        {
            string a = "test";
            Condition.Requires(a).IsNotEmpty(string.Empty);
        }

        [Fact]
        [Description("Calling a failing IsNotEmpty should throw an Exception with an exception message that contains the given parameterized condition description argument.")]
        public void IsStringNotEmptyTest5()
        {
            string a = string.Empty;
            try
            {
                Condition.Requires(a, "a").IsNotEmpty("qwe {0} xyz");
                Assert.True(false);
            }
            catch (ArgumentException ex)
            {
                Assert.True(ex.Message.Contains("qwe a xyz"));
            }
        }

        [Fact]
        [Description("Calling IsNotEmpty on string x with 'x == String.Empty' should succeed when exceptions are suppressed.")]
        public void IsStringNotEmptyTest6()
        {
            string s = String.Empty;
            Condition.Requires(s).SuppressExceptionsForTest().IsNotEmpty();
        }
    }
}