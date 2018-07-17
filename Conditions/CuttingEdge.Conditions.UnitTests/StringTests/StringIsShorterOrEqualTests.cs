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
    /// Tests the ValidatorExtensions.IsShorterOrEqual method.
    /// </summary>
    
    public class StringIsShorterOrEqualTests
    {
        [Fact]
        [Description("Calling IsShorterOrEqual on string x with 'x.Length < upped bound' should pass.")]
        public void IsShorterOrEqual00()
        {
            string a = "test";
            Condition.Requires(a).IsShorterOrEqual(5);
        }

        [Fact]
        [Description("Calling IsShorterOrEqual on string x with 'x.Length = upped bound' should pass.")]
        public void IsShorterOrEqual01()
        {
            string a = "test";
            Condition.Requires(a).IsShorterOrEqual(4);
        }

        [Fact]
        [Description("Calling IsShorterOrEqual on string x with 'x.Length > upped bound' should fail.")]
        public void IsShorterOrEqual02()
        {
            string a = "test";
            Action action = () => Condition.Requires(a).IsShorterOrEqual(1);
            action.Should().Throw<ArgumentException>();
        }

        [Fact]
        [Description("Calling IsShorterOrEqual on string x with 'x.Length < upped bound' should pass.")]
        public void IsShorterOrEqual03()
        {
            string a = String.Empty;
            Condition.Requires(a).IsShorterOrEqual(1);
        }

        [Fact]
        [Description("Calling IsShorterOrEqual on string x with 'x.Length = upped bound' should pass.")]
        public void IsShorterOrEqual04()
        {
            string a = String.Empty;
            Condition.Requires(a).IsShorterOrEqual(0);
        }

        [Fact]
        [Description("Calling IsShorterOrEqual on string x with 'x.Length > upped bound' should fail.")]
        public void IsShorterOrEqual05()
        {
            string a = String.Empty;
            Action action = () => Condition.Requires(a).IsShorterOrEqual(-1);
            action.Should().Throw<ArgumentException>();
        }

        [Fact]
        [Description("Calling IsShorterOrEqual on string x with 'null = upped bound' should pass.")]
        public void IsShorterOrEqual06()
        {
            string a = null;
            Condition.Requires(a).IsShorterOrEqual(0);
        }

        [Fact]
        [Description("Calling IsShorterOrEqual on string x with 'null > upped bound' should fail.")]
        public void IsShorterOrEqual07()
        {
            string a = null;
            // A null value is considered to have a length of 0 characters.
            Action action = () => Condition.Requires(a).IsShorterOrEqual(-1);
            action.Should().Throw<ArgumentNullException>();
        }

        [Fact]
        [Description("Calling IsShorterOrEqual with conditionDescription parameter should pass.")]
        public void IsShorterOrEqual08()
        {
            string a = string.Empty;
            Condition.Requires(a).IsShorterOrEqual(0, string.Empty);
        }

        [Fact]
        [Description("Calling a failing IsShorterOrEqual should throw an Exception with an exception message that contains the given parameterized condition description argument.")]
        public void IsShorterOrEqual09()
        {
            string a = null;
            try
            {
                Condition.Requires(a, "a").IsShorterOrEqual(-1, "qwe {0} xyz");
                Assert.True(false);
            }
            catch (ArgumentException ex)
            {
                Assert.True(ex.Message.Contains("qwe a xyz"));
            }
        }

        [Fact]
        [Description("Calling IsShorterOrEqual on string x with 'x.Length > upped bound' should succeed when exceptions are suppressed.")]
        public void IsShorterOrEqual10()
        {
            string a = "test";
            Condition.Requires(a).SuppressExceptionsForTest().IsShorterOrEqual(1);
        }
    }
}