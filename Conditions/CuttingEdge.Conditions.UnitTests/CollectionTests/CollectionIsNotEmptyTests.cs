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
using System.Collections;
using System.Collections.ObjectModel;

using Xunit; using System.ComponentModel;
using FluentAssertions;

namespace CuttingEdge.Conditions.UnitTests.CollectionTests
{
    /// <summary>
    /// Tests the ValidatorExtensions.IsNotEmpty method.
    /// </summary>
    
    public class CollectionIsNotEmptyTests
    {
        [Fact]
        
        [Description("Calling IsNotEmpty on null reference should fail.")]
        public void IsNotEmptyTest1()
        {
            ICollection c = null;
            Action action = () => Condition.Requires(c).IsNotEmpty();
            action.Should().Throw<ArgumentNullException>();
        }

        [Fact]
        
        [Description("Calling IsNotEmpty on an empty ICollection should fail.")]
        public void IsNotEmptyTest2()
        {
            Collection<int> c = new Collection<int>();
            Action action = () => Condition.Requires(c).IsNotEmpty();
            action.Should().Throw<ArgumentException>();
        }

        [Fact]
        
        [Description("Calling IsNotEmpty on null reference should fail.")]
        public void IsNotEmptyTest3()
        {
            IEnumerable c = null;
            Action action = () => Condition.Requires(c).IsNotEmpty();
            action.Should().Throw<ArgumentNullException>();
        }

        [Fact]
        
        [Description("Calling IsNotEmpty on an not empty IEnumerable should fail.")]
        public void IsNotEmptyTest4()
        {
            EmptyTestEnumerable c = new EmptyTestEnumerable();
            Action action = () => Condition.Requires(c).IsNotEmpty();
            action.Should().Throw<ArgumentException>();
        }

        [Fact]
        [Description("Calling IsNotEmpty on an not empty ICollection should pass.")]
        public void IsNotEmptyTest5()
        {
            Collection<int> c = new Collection<int> { 1 };
            Condition.Requires(c).IsNotEmpty();
        }

        [Fact]
        [Description("Calling IsNotEmpty on an not empty IEnumerable should pass.")]
        public void IsNotEmptyTest6()
        {
            NonEmptyTestEnumerable c = new NonEmptyTestEnumerable();
            Condition.Requires(c).IsNotEmpty();
        }

        [Fact]
        [Description("Calling IsNotEmpty with conditional description parameter on an not empty ICollection should pass.")]
        public void IsNotEmptyTest7()
        {
            NonEmptyTestEnumerable c = new NonEmptyTestEnumerable();
            Condition.Requires(c).IsNotEmpty("conditionDescription");
        }

        [Fact]
        [Description("Calling a failing IsNotEmpty with a non generic collection should throw an Exception with an exception message that contains the given parameterized condition description argument.")]
        public void IsNotEmptyTest8()
        {
            EmptyTestEnumerable c = new EmptyTestEnumerable();
            try
            {
                Condition.Requires(c, "c").IsNotEmpty("{0} should have no elements what so ever");
            }
            catch (ArgumentException ex)
            {
                Assert.True(ex.Message.Contains("c should have no elements what so ever"));
            }
        }

        [Fact]
        [Description("Calling IsNotEmpty on null reference should succeed when exceptions are suppressed.")]
        public void IsNotEmptyTest9()
        {
            ICollection c = null;
            Condition.Requires(c).SuppressExceptionsForTest().IsNotEmpty();
        }
    }
}