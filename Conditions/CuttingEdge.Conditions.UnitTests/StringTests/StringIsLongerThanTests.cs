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
    /// Tests the ValidatorExtensions.IsLongerThan method.
    /// </summary>
    
    public class StringIsLongerThanTests
    {
        [Fact]
        [Description("Calling IsLongerThan on string x with 'lower bound < x.Length' should pass.")]
        public void IsLongerThan01()
        {
            string a = "test";
            Condition.Requires(a).IsLongerThan(3);
        }

        [Fact]
        [Description("Calling IsLongerThan on string x with 'lower bound = x.Length' should fail.")]
        public void IsLongerThan2()
        {
            string a = "test";
            Action action = () => Condition.Requires(a).IsLongerThan(4);
            action.Should().Throw<ArgumentException>();
        }

        [Fact]
        [Description("Calling IsLongerThan on string x with '-1 < x.Length' should pass.")]
        public void IsLongerThan003()
        {
            string a = String.Empty;
            Condition.Requires(a).IsLongerThan(-1);
        }

        [Fact]
        [Description("Calling IsLongerThan on string x with 'lower bound = x.Length' should fail.")]
        public void IsLongerThan04()
        {
            string a = String.Empty;
            Action action = () => Condition.Requires(a).IsLongerThan(0);
            action.Should().Throw<ArgumentException>();
        }

        [Fact]
        [Description("Calling IsLongerThan on string x with '-1 < null' should pass.")]
        public void IsLongerThan05()
        {
            string a = null;
            Condition.Requires(a).IsLongerThan(-1);
        }

        [Fact]
        [Description("Calling IsLongerThan on string x with 'lower bound = null' should fail.")]
        public void IsLongerThan06()
        {
            string a = null;
            Action action = () => Condition.Requires(a).IsLongerThan(0);
            action.Should().Throw<ArgumentNullException>();
        }

        [Fact]
        [Description("Calling IsLongerThan with conditionDescription parameter should pass.")]
        public void IsLongerThan07()
        {
            string a = string.Empty;
            Condition.Requires(a).IsLongerThan(-1, string.Empty);
        }

        [Fact]
        [Description("Calling a failing IsLongerThan should throw an Exception with an exception message that contains the given parameterized condition description argument.")]
        public void IsLongerThan08()
        {
            string a = null;
            try
            {
                Condition.Requires(a, "a").IsLongerThan(0, "qwe {0} xyz");
                Assert.True(false);
            }
            catch (ArgumentException ex)
            {
                Assert.True(ex.Message.Contains("qwe a xyz"));
            }
        }

        [Fact]
        [Description("Calling IsLongerThan on string x with 'lower bound = 1' should fail.")]
        public void IsLongerThan09()
        {
            // Testing a string with length of one and minLength = 1 to achieve 100% code coverage.
            string a = "1";
            Action action = () => Condition.Requires(a).IsLongerThan(1);
            action.Should().Throw<ArgumentException>();
        }

        [Fact]
        [Description("Calling IsLongerThan on string x with 'lower bound = x.Length' should succeed when exceptions are suppressed.")]
        public void IsLongerThan10()
        {
            string a = "test";
            Condition.Requires(a).SuppressExceptionsForTest().IsLongerThan(4);
        }
    }
}