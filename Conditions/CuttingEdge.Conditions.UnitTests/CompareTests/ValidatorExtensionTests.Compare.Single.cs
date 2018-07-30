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

// NOTE: This file a copy of ValidatorExtensionTests.Compare.Base.cs with all occurrences of 'xxx' replaced
// with 'Single'.
using System;

using Xunit; using System.ComponentModel;
using FluentAssertions;

namespace CuttingEdge.Conditions.UnitTests.CompareTests
{
    
    public class CompareSingleTests
    {
        private static readonly Single One = 1;
        private static readonly Single Two = 2;
        private static readonly Single Three = 3;
        private static readonly Single Four = 4;
        private static readonly Single Five = 5;

        #region IsSingleInRange

        [Fact]
        
        [Description("Calling IsInRange on Single x with 'lower bound > x < upper bound' should fail.")]
        public void IsSingleInRangeTest01()
        {
            Single a = One;
            Action action = () => Condition.Requires(a).IsInRange(Two, Four);
            action.Should().Throw<ArgumentOutOfRangeException>();
        }

        [Fact]
        [Description("Calling IsInRange on Single x with 'lower bound = x < upper bound' should pass.")]
        public void IsSingleInRangeTest02()
        {
            Single a = Two;
            Condition.Requires(a).IsInRange(Two, Four);
        }

        [Fact]
        [Description("Calling IsInRange on Single x with 'lower bound < x < upper bound' should pass.")]
        public void IsSingleInRangeTest03()
        {
            Single a = Three;
            Condition.Requires(a).IsInRange(Two, Four);
        }

        [Fact]
        [Description("Calling IsInRange on Single x with 'lower bound < x = upper bound' should pass.")]
        public void IsSingleInRangeTest04()
        {
            Single a = Four;
            Condition.Requires(a).IsInRange(Two, Four);
        }

        [Fact]
        
        [Description("Calling IsInRange on Single x with 'lower bound < x > upper bound' should fail.")]
        public void IsSingleInRangeTest05()
        {
            Single a = Five;
            Action action = () => Condition.Requires(a).IsInRange(Two, Four);
            action.Should().Throw<ArgumentOutOfRangeException>();
        }

        [Fact]
        [Description("Calling IsInRange on Single x with conditionDescription should pass.")]
        public void IsSingleInRangeTest06()
        {
            Single a = Four;
            Condition.Requires(a).IsInRange(Two, Four, string.Empty);
        }

        [Fact]
        [Description("Calling a failing IsInRange on Single should throw an Exception with an exception message that contains the given parameterized condition description argument.")]
        public void IsSingleInRangeTest07()
        {
            Single a = Five;
            try
            {
                Condition.Requires(a, "a").IsInRange(Two, Four, "abc {0} xyz");
                Assert.True(false);
            }
            catch (ArgumentException ex)
            {
                Assert.True(ex.Message.Contains("abc a xyz"));
            }
        }

        [Fact]
        [Description("Calling IsInRange on Single x with 'lower bound > x < upper bound' should succeed when exceptions are suppressed.")]
        public void IsSingleInRangeTest08()
        {
            Single a = One;
            Condition.Requires(a).SuppressExceptionsForTest().IsInRange(Two, Four);
        }

        #endregion // IsSingleInRange

        #region IsSingleNotInRange

        [Fact]
        [Description("Calling IsNotInRange on Single x with 'lower bound > x < upper bound' should pass.")]
        public void IsSingleNotInRangeTest01()
        {
            Single a = One;
            Condition.Requires(a).IsNotInRange(Two, Four);
        }

        [Fact]
        
        [Description("Calling IsNotInRange on Single x with 'lower bound = x < upper bound' should fail.")]
        public void IsSingleNotInRangeTest02()
        {
            Single a = Two;
            Action action = () => Condition.Requires(a).IsNotInRange(Two, Four);
            action.Should().Throw<ArgumentException>();
        }

        [Fact]
        
        [Description("Calling IsNotInRange on Single x with 'lower bound < x < upper bound' should fail.")]
        public void IsSingleNotInRangeTest03()
        {
            Single a = Three;
            Action action = () => Condition.Requires(a).IsNotInRange(Two, Four);
            action.Should().Throw<ArgumentException>();
        }

        [Fact]
        
        [Description("Calling IsNotInRange on Single x with 'lower bound < x = upper bound' should fail.")]
        public void IsSingleNotInRangeTest04()
        {
            Single a = Four;
            Action action = () => Condition.Requires(a).IsNotInRange(Two, Four);
            action.Should().Throw<ArgumentException>();
        }

        [Fact]
        [Description("Calling IsNotInRange on Single x with 'lower bound < x > upper bound' should pass.")]
        public void IsSingleNotInRangeTest05()
        {
            Single a = Five;
            Condition.Requires(a).IsNotInRange(Two, Four);
        }

        [Fact]
        [Description("Calling IsNotInRange on Single x with conditionDescription should pass.")]
        public void IsSingleNotInRangeTest06()
        {
            Single a = Five;
            Condition.Requires(a).IsNotInRange(Two, Four, string.Empty);
        }

        [Fact]
        [Description("Calling a failing IsNotInRange on Single should throw an Exception with an exception message that contains the given parameterized condition description argument.")]
        public void IsSingleNotInRangeTest07()
        {
            Single a = Four;
            try
            {
                Condition.Requires(a, "a").IsNotInRange(Two, Four, "abc {0} xyz");
                Assert.True(false);
            }
            catch (ArgumentException ex)
            {
                Assert.True(ex.Message.Contains("abc a xyz"));
            }
        }

        [Fact]
        [Description("Calling IsNotInRange on Single x with 'lower bound = x < upper bound' should succeed when exceptions are suppressed.")]
        public void IsSingleNotInRangeTest08()
        {
            Single a = Two;
            Condition.Requires(a).SuppressExceptionsForTest().IsNotInRange(Two, Four);
        }

        #endregion // IsSingleNotInRange

        #region IsSingleGreaterThan

        [Fact]
        
        [Description("Calling IsGreaterThan on Single x with 'lower bound < x' should fail.")]
        public void IsSingleGreaterThanTest01()
        {
            Single a = One;
            Action action = () => Condition.Requires(a).IsGreaterThan(Two);
            action.Should().Throw<ArgumentOutOfRangeException>();
        }

        [Fact]
        
        [Description("Calling IsGreaterThan on Single x with 'lower bound = x' should fail.")]
        public void IsSingleGreaterThanTest02()
        {
            Single a = Two;
            Action action = () => Condition.Requires(a).IsGreaterThan(Two);
            action.Should().Throw<ArgumentOutOfRangeException>();
        }

        [Fact]
        [Description("Calling IsGreaterThan on Single x with 'lower bound < x' should pass.")]
        public void IsSingleGreaterThanTest03()
        {
            Single a = Three;
            Condition.Requires(a).IsGreaterThan(Two);
        }

        [Fact]
        [Description("Calling IsGreaterThan on Single x with conditionDescription should pass.")]
        public void IsSingleGreaterThanTest04()
        {
            Single a = Three;
            Condition.Requires(a).IsGreaterThan(Two, string.Empty);
        }

        [Fact]
        [Description("Calling a failing IsGreaterThan on Single should throw an Exception with an exception message that contains the given parameterized condition description argument.")]
        public void IsSingleGreaterThanTest05()
        {
            Single a = Three;
            try
            {
                Condition.Requires(a, "a").IsGreaterThan(Three, "abc {0} xyz");
                Assert.True(false);
            }
            catch (ArgumentException ex)
            {
                Assert.True(ex.Message.Contains("abc a xyz"));
            }
        }

        [Fact]
        [Description("Calling IsGreaterThan on Single x with 'lower bound < x' should succeed when exceptions are suppressed.")]
        public void IsSingleGreaterThanTest06()
        {
            Single a = One;
            Condition.Requires(a).SuppressExceptionsForTest().IsGreaterThan(Two);
        }

        #endregion // IsSingleGreaterThan

        #region IsSingleNotGreaterThan

        [Fact]
        [Description("Calling IsNotGreaterThan on Single x with 'x < upper bound' should pass.")]
        public void IsSingleNotGreaterThanTest01()
        {
            Single a = One;
            Condition.Requires(a).IsNotGreaterThan(Two);
        }

        [Fact]
        [Description("Calling IsNotGreaterThan on Single x with 'x = upper bound' should pass.")]
        public void IsSingleNotGreaterThanTest02()
        {
            Single a = Two;
            Condition.Requires(a).IsNotGreaterThan(Two);
        }

        [Fact]
        
        [Description("Calling IsNotGreaterThan on Single x with 'x > upper bound' should fail.")]
        public void IsSingleNotGreaterThanTest03()
        {
            Single a = Three;
            Action action = () => Condition.Requires(a).IsNotGreaterThan(Two);
            action.Should().Throw<ArgumentOutOfRangeException>();
        }

        [Fact]
        [Description("Calling IsNotGreaterThan on Single x with conditionDescription should pass.")]
        public void IsSingleNotGreaterThanTest04()
        {
            Single a = Two;
            Condition.Requires(a).IsNotGreaterThan(Two, string.Empty);
        }

        [Fact]
        [Description("Calling a failing IsNotGreaterThan on Single should throw an Exception with an exception message that contains the given parameterized condition description argument.")]
        public void IsSingleNotGreaterThanTest05()
        {
            Single a = Three;
            try
            {
                Condition.Requires(a, "a").IsNotGreaterThan(Two, "abc {0} xyz");
                Assert.True(false);
            }
            catch (ArgumentException ex)
            {
                Assert.True(ex.Message.Contains("abc a xyz"));
            }
        }

        [Fact]
        [Description("Calling IsNotGreaterThan on Single x with 'x > upper bound' should succeed when exceptions are suppressed.")]
        public void IsSingleNotGreaterThanTest06()
        {
            Single a = Three;
            Condition.Requires(a).SuppressExceptionsForTest().IsNotGreaterThan(Two);
        }

        #endregion // IsSingleNotGreaterThan

        #region IsSingleGreaterOrEqual

        [Fact]
        
        [Description("Calling IsGreaterOrEqual on Single x with 'lower bound > x' should fail.")]
        public void IsSingleGreaterOrEqualTest01()
        {
            Single a = One;
            Action action = () => Condition.Requires(a).IsGreaterOrEqual(Two);
            action.Should().Throw<ArgumentOutOfRangeException>();
        }

        [Fact]
        [Description("Calling IsGreaterOrEqual on Single x with 'lower bound = x' should pass.")]
        public void IsSingleGreaterOrEqualTest02()
        {
            Single a = Two;
            Condition.Requires(a).IsGreaterOrEqual(Two);
        }

        [Fact]
        [Description("Calling IsGreaterOrEqual on Single x with 'lower bound < x' should pass.")]
        public void IsSingleGreaterOrEqualTest03()
        {
            Single a = Three;
            Condition.Requires(a).IsGreaterOrEqual(Two);
        }

        [Fact]
        [Description("Calling IsGreaterOrEqual on Single x with conditionDescription should pass.")]
        public void IsSingleGreaterOrEqualTest04()
        {
            Single a = Three;
            Condition.Requires(a).IsGreaterOrEqual(Two, string.Empty);
        }

        [Fact]
        [Description("Calling a failing IsGreaterOrEqual on Single should throw an Exception with an exception message that contains the given parameterized condition description argument.")]
        public void IsSingleGreaterOrEqualTest05()
        {
            Single a = One;
            try
            {
                Condition.Requires(a, "a").IsGreaterOrEqual(Two, "abc {0} xyz");
                Assert.True(false);
            }
            catch (ArgumentException ex)
            {
                Assert.True(ex.Message.Contains("abc a xyz"));
            }
        }

        [Fact]
        [Description("Calling IsGreaterOrEqual on Single x with 'lower bound > x' should succeed when exceptions are suppressed.")]
        public void IsSingleGreaterOrEqualTest06()
        {
            Single a = One;
            Condition.Requires(a).SuppressExceptionsForTest().IsGreaterOrEqual(Two);
        }

        #endregion // IsSingleGreaterOrEqual

        #region IsSingleNotGreaterOrEqual

        [Fact]
        [Description("Calling IsNotGreaterOrEqual on Single x with 'x < upper bound' should pass.")]
        public void IsSingleNotGreaterOrEqualTest01()
        {
            Single a = One;
            Condition.Requires(a).IsNotGreaterOrEqual(Two);
        }

        [Fact]
        
        [Description("Calling IsNotGreaterOrEqual on Single x with 'x = upper bound' should fail.")]
        public void IsSingleNotGreaterOrEqualTest02()
        {
            Single a = Two;
            Action action = () => Condition.Requires(a).IsNotGreaterOrEqual(Two);
            action.Should().Throw<ArgumentOutOfRangeException>();
        }

        [Fact]
        
        [Description("Calling IsNotGreaterOrEqual on Single x with 'x > upper bound' should fail.")]
        public void IsSingleNotGreaterOrEqualTest03()
        {
            Single a = Three;
            Action action = () => Condition.Requires(a).IsNotGreaterOrEqual(Two);
            action.Should().Throw<ArgumentOutOfRangeException>();
        }

        [Fact]
        [Description("Calling IsNotGreaterOrEqual on Single x with conditionDescription should pass.")]
        public void IsSingleNotGreaterOrEqualTest04()
        {
            Single a = One;
            Condition.Requires(a).IsNotGreaterOrEqual(Two, string.Empty);
        }

        [Fact]
        [Description("Calling a failing IsNotGreaterOrEqual on Single should throw an Exception with an exception message that contains the given parameterized condition description argument.")]
        public void IsSingleNotGreaterOrEqualTest05()
        {
            Single a = Three;
            try
            {
                Condition.Requires(a, "a").IsNotGreaterOrEqual(Two, "abc {0} xyz");
                Assert.True(false);
            }
            catch (ArgumentException ex)
            {
                Assert.True(ex.Message.Contains("abc a xyz"));
            }
        }

        [Fact]
        [Description("Calling IsNotGreaterOrEqual on Single x with 'x = upper bound' should succeed when exceptions are suppressed.")]
        public void IsSingleNotGreaterOrEqualTest06()
        {
            Single a = Two;
            Condition.Requires(a).SuppressExceptionsForTest().IsNotGreaterOrEqual(Two);
        }

        #endregion // IsSingleNotGreaterOrEqual

        #region IsSingleLessThan

        [Fact]
        [Description("Calling IsLessThan on Single x with 'x < upper bound' should pass.")]
        public void IsSingleLessThanTest01()
        {
            Single a = One;
            Condition.Requires(a).IsLessThan(Two);
        }

        [Fact]
        
        [Description("Calling IsLessThan on Single x with 'x = upper bound' should fail.")]
        public void IsSingleLessThanTest02()
        {
            Single a = Two;
            Action action = () => Condition.Requires(a).IsLessThan(Two);
            action.Should().Throw<ArgumentOutOfRangeException>();
        }

        [Fact]
        
        [Description("Calling IsLessThan on Single x with 'x > upper bound' should fail.")]
        public void IsSingleLessThanTest03()
        {
            Single a = Three;
            Action action = () => Condition.Requires(a).IsLessThan(Two);
            action.Should().Throw<ArgumentOutOfRangeException>();
        }

        [Fact]
        [Description("Calling IsLessThan on Single x with conditionDescription should pass.")]
        public void IsSingleLessThanTest04()
        {
            Single a = Two;
            Condition.Requires(a).IsLessThan(Three, string.Empty);
        }

        [Fact]
        [Description("Calling a failing IsLessThan on Single should throw an Exception with an exception message that contains the given parameterized condition description argument.")]
        public void IsSingleLessThanTest05()
        {
            Single a = Three;
            try
            {
                Condition.Requires(a, "a").IsLessThan(Two, "abc {0} xyz");
                Assert.True(false);
            }
            catch (ArgumentException ex)
            {
                Assert.True(ex.Message.Contains("abc a xyz"));
            }
        }

        [Fact]
        [Description("Calling IsLessThan on Single x with 'x = upper bound' should succeed when exceptions are suppressed.")]
        public void IsSingleLessThanTest06()
        {
            Single a = Two;
            Condition.Requires(a).SuppressExceptionsForTest().IsLessThan(Two);
        }

        #endregion // IsSingleLessThan

        #region IsSingleNotLessThan

        [Fact]
        
        [Description("Calling IsNotLessThan on Single x with 'lower bound > x' should fail.")]
        public void IsSingleNotLessThanTest01()
        {
            Single a = One;
            Action action = () => Condition.Requires(a).IsNotLessThan(Two);
            action.Should().Throw<ArgumentOutOfRangeException>();
        }

        [Fact]
        [Description("Calling IsNotLessThan on Single x with 'lower bound = x' should pass.")]
        public void IsSingleNotLessThanTest02()
        {
            Single a = Two;
            Condition.Requires(a).IsNotLessThan(Two);
        }

        [Fact]
        [Description("Calling IsNotLessThan on Single x with 'lower bound < x' should pass.")]
        public void IsSingleNotLessThanTest03()
        {
            Single a = Three;
            Condition.Requires(a).IsNotLessThan(Two);
        }

        [Fact]
        [Description("Calling IsNotLessThan on Single x with conditionDescription should pass.")]
        public void IsSingleNotLessThanTest04()
        {
            Single a = Two;
            Condition.Requires(a).IsNotLessThan(Two, string.Empty);
        }

        [Fact]
        [Description("Calling a failing IsNotLessThan on Single should throw an Exception with an exception message that contains the given parameterized condition description argument.")]
        public void IsSingleNotLessThanTest05()
        {
            Single a = Two;
            try
            {
                Condition.Requires(a, "a").IsNotLessThan(Three, "abc {0} xyz");
                Assert.True(false);
            }
            catch (ArgumentException ex)
            {
                Assert.True(ex.Message.Contains("abc a xyz"));
            }
        }

        [Fact]
        [Description("Calling IsNotLessThan on Single x with 'lower bound > x' should succeed when exceptions are suppressed.")]
        public void IsSingleNotLessThanTest06()
        {
            Single a = One;
            Condition.Requires(a).SuppressExceptionsForTest().IsNotLessThan(Two);
        }

        #endregion // IsSingleNotLessThan

        #region IsSingleLessOrEqual

        [Fact]
        [Description("Calling IsLessOrEqual on Single x with 'x < upper bound' should pass.")]
        public void IsSingleLessOrEqualTest01()
        {
            Single a = One;
            Condition.Requires(a).IsLessOrEqual(Two);
        }

        [Fact]
        [Description("Calling IsLessOrEqual on Single x with 'x = upper bound' should pass.")]
        public void IsSingleLessOrEqualTest02()
        {
            Single a = Two;
            Condition.Requires(a).IsLessOrEqual(Two);
        }

        [Fact]
        
        [Description("Calling IsLessOrEqual on Single x with 'x > upper bound' should fail.")]
        public void IsSingleLessOrEqualTest03()
        {
            Single a = Three;
            Action action = () => Condition.Requires(a).IsLessOrEqual(Two);
            action.Should().Throw<ArgumentOutOfRangeException>();
        }

        [Fact]
        [Description("Calling IsLessOrEqual on Single x with conditionDescription should pass.")]
        public void IsSingleLessOrEqualTest04()
        {
            Single a = Two;
            Condition.Requires(a).IsLessOrEqual(Two, string.Empty);
        }

        [Fact]
        [Description("Calling a failing IsLessOrEqual on Single should throw an Exception with an exception message that contains the given parameterized condition description argument.")]
        public void IsSingleLessOrEqualTest05()
        {
            Single a = Three;
            try
            {
                Condition.Requires(a, "a").IsLessOrEqual(Two, "abc {0} xyz");
                Assert.True(false);
            }
            catch (ArgumentException ex)
            {
                Assert.True(ex.Message.Contains("abc a xyz"));
            }
        }

        [Fact]
        [Description("Calling IsLessOrEqual on Single x with 'x > upper bound' should succeed when exceptions are suppressed.")]
        public void IsSingleLessOrEqualTest06()
        {
            Single a = Three;
            Condition.Requires(a).SuppressExceptionsForTest().IsLessOrEqual(Two);
        }

        #endregion // IsSingleLessOrEqual

        #region IsSingleNotLessOrEqual

        [Fact]
        
        [Description("Calling IsNotLessOrEqual on Single x with 'lower bound > x' should fail.")]
        public void IsSingleNotLessOrEqualTest01()
        {
            Single a = One;
            Action action = () => Condition.Requires(a).IsNotLessOrEqual(Two);
            action.Should().Throw<ArgumentOutOfRangeException>();
        }

        [Fact]
        
        [Description("Calling IsNotLessOrEqual on Single x with 'lower bound = x' should fail.")]
        public void IsSingleNotLessOrEqualTest02()
        {
            Single a = Two;
            Action action = () => Condition.Requires(a).IsNotLessOrEqual(Two);
            action.Should().Throw<ArgumentOutOfRangeException>();
        }

        [Fact]
        [Description("Calling IsNotLessOrEqual on Single x with 'lower bound < x' should pass.")]
        public void IsSingleNotLessOrEqualTest03()
        {
            Single a = Three;
            Condition.Requires(a).IsNotLessOrEqual(Two);
        }

        [Fact]
        [Description("Calling IsNotLessOrEqual on Single x with conditionDescription should pass.")]
        public void IsSingleNotLessOrEqualTest04()
        {
            Single a = Three;
            Condition.Requires(a).IsNotLessOrEqual(Two, string.Empty);
        }

        [Fact]
        [Description("Calling a failing IsNotLessOrEqual on Single should throw an Exception with an exception message that contains the given parameterized condition description argument.")]
        public void IsSingleNotLessOrEqualTest05()
        {
            Single a = Two;
            try
            {
                Condition.Requires(a, "a").IsNotLessOrEqual(Two, "abc {0} xyz");
                Assert.True(false);
            }
            catch (ArgumentException ex)
            {
                Assert.True(ex.Message.Contains("abc a xyz"));
            }
        }

        [Fact]
        [Description("Calling IsNotLessOrEqual on Single x with 'lower bound > x' should succeed when exceptions are suppressed.")]
        public void IsSingleNotLessOrEqualTest06()
        {
            Single a = One;
            Condition.Requires(a).SuppressExceptionsForTest().IsNotLessOrEqual(Two);
        }

        #endregion // IsNotLessOrEqual

        #region IsSingleEqualTo

        [Fact]
        
        [Description("Calling IsEqualTo on Single x with 'x < other' should fail.")]
        public void IsSingleEqualToTest01()
        {
            Single a = One;
            Action action = () => Condition.Requires(a).IsEqualTo(Two);
            action.Should().Throw<ArgumentException>();
        }

        [Fact]
        [Description("Calling IsEqualTo on Single x with 'x = other' should pass.")]
        public void IsSingleEqualToTest02()
        {
            Single a = Two;
            Condition.Requires(a).IsEqualTo(Two);
        }

        [Fact]
        
        [Description("Calling IsEqualTo on Single x with 'x > other' should fail.")]
        public void IsSingleEqualToTest03()
        {
            Single a = Three;
            Action action = () => Condition.Requires(a).IsEqualTo(Two);
            action.Should().Throw<ArgumentException>();
        }

        [Fact]
        [Description("Calling IsEqualTo on Single x with conditionDescription should pass.")]
        public void IsSingleEqualToTest04()
        {
            Single a = Two;
            Condition.Requires(a).IsEqualTo(Two, string.Empty);
        }

        [Fact]
        [Description("Calling a failing IsEqualTo on Single should throw an Exception with an exception message that contains the given parameterized condition description argument.")]
        public void IsSingleEqualToTest05()
        {
            Single a = Three;
            try
            {
                Condition.Requires(a, "a").IsEqualTo(Two, "abc {0} xyz");
                Assert.True(false);
            }
            catch (ArgumentException ex)
            {
                Assert.True(ex.Message.Contains("abc a xyz"));
            }
        }

        [Fact]
        [Description("Calling IsEqualTo on Single x with 'x < other' should succeed when exceptions are suppressed.")]
        public void IsSingleEqualToTest06()
        {
            Single a = One;
            Condition.Requires(a).SuppressExceptionsForTest().IsEqualTo(Two);
        }

        #endregion // IsSingleEqualTo

        #region IsSingleNotEqualTo

        [Fact]
        [Description("Calling IsNotEqualTo on Single x with 'x < other' should pass.")]
        public void IsSingleNotEqualToTest01()
        {
            Single a = One;
            Condition.Requires(a).IsNotEqualTo(Two);
        }

        [Fact]
        
        [Description("Calling IsNotEqualTo on Single x with 'x = other' should fail.")]
        public void IsSingleNotEqualToTest02()
        {
            Single a = Two;
            Action action = () => Condition.Requires(a).IsNotEqualTo(Two);
            action.Should().Throw<ArgumentException>();
        }

        [Fact]
        [Description("Calling IsNotEqualTo on Single x with 'x > other' should pass.")]
        public void IsSingleNotEqualToTest03()
        {
            Single a = Three;
            Condition.Requires(a).IsNotEqualTo(Two);
        }

        [Fact]
        [Description("Calling IsNotEqualTo on Single x with conditionDescription should pass.")]
        public void IsSingleNotEqualToTest04()
        {
            Single a = Three;
            Condition.Requires(a).IsNotEqualTo(Two, string.Empty);
        }

        [Fact]
        [Description("Calling a failing IsNotEqualTo on Single should throw an Exception with an exception message that contains the given parameterized condition description argument.")]
        public void IsSingleNotEqualToTest05()
        {
            Single a = Two;
            try
            {
                Condition.Requires(a, "a").IsNotEqualTo(Two, "abc {0} xyz");
                Assert.True(false);
            }
            catch (ArgumentException ex)
            {
                Assert.True(ex.Message.Contains("abc a xyz"));
            }
        }

        [Fact]
        [Description("Calling IsNotEqualTo on Single x with 'x = other' should succeed when exceptions are suppressed.")]
        public void IsSingleNotEqualToTest06()
        {
            Single a = Two;
            Condition.Requires(a).SuppressExceptionsForTest().IsNotEqualTo(Two);
        }

        #endregion // IsSingleNotEqualTo
    }
}