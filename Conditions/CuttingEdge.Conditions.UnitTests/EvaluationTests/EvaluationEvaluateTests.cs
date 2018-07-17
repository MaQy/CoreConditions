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
using System.Linq.Expressions;

using Xunit; using System.ComponentModel;
using FluentAssertions;

namespace CuttingEdge.Conditions.UnitTests.EvaluationTests
{
    
    public class EvaluationEvaluateTests
    {
        [Fact]
        [Description("Calling Evaluate on integer x with boolean 'true' should pass.")]
        public void EvaluateTest01()
        {
            int a = 3;
            Condition.Requires(a).Evaluate(true);
        }

        [Fact]
        [Description("Calling the Evaluate overload with the description on integer x with boolean 'true' should pass.")]
        public void EvaluateTest02()
        {
            int a = 3;
            Condition.Requires(a).Evaluate(true, String.Empty);
        }

        [Fact]
        
        [Description("Calling Evaluate on integer x with boolean 'false' should fail.")]
        public void EvaluateTest03()
        {
            int a = 3;
            Action action = () => Condition.Requires(a).Evaluate(false);
            action.Should().Throw<ArgumentException>();
        }

        [Fact]
        
        [Description("Calling the Evaluate overload with the description on integer x with boolean 'false' should fail.")]
        public void EvaluateTest04()
        {
            int a = 3;
            Action action = () => Condition.Requires(a).Evaluate(false, String.Empty);
            action.Should().Throw<ArgumentException>();
        }

        [Fact]
        [Description("Calling Evaluate on integer x (3) with expression '(x) => (x == 3)' should pass.")]
        public void EvaluateTest05()
        {
            int a = 3;
            Expression<Func<int, bool>> expression = x => (x == 3);
            Condition.Requires(a).Evaluate(expression);
        }

        [Fact]
        
        [Description("Calling Evaluate on integer x (3) with expression '(x) => (x == 4)' should fail.")]
        public void EvaluateTest06()
        {
            int a = 3;
            Action action = () => Condition.Requires(a).Evaluate(x => x == 4);
            action.Should().Throw<ArgumentException>();
        }

        [Fact]
        [Description("Calling Evaluate on string x (hoi) with expression '(x) => (x == hoi)' should pass.")]
        public void EvaluateTest07()
        {
            string a = "hoi";
            Condition.Requires(a).Evaluate(x => x == "hoi");
        }

        [Fact]
        [Description("Calling Evaluate on object x with expression 'x => true' should pass.")]
        public void EvaluateTest08()
        {
            object a = new object();
            Condition.Requires(a).Evaluate(x => true);
        }

        [Fact]
        [Description("Calling Evaluate on null object x with expression '(x) => (x != null)' should fail with ArgumentNullException.")]
        public void EvaluateTest09()
        {
            object a = null;
            Action action = () => Condition.Requires(a).Evaluate(x => x != null);
            action.Should().Throw<ArgumentNullException>();
        }

        [Fact]
        [Description("Calling Evaluate on null object x with expression '(x) => (x == 3)' should fail with ArgumentNullException.")]
        public void EvaluateTest10()
        {
            int? a = null;
            Action action = () => Condition.Requires(a).Evaluate(x => x == 3);
            action.Should().Throw<ArgumentNullException>();
        }

        [Fact]
        [Description("Calling Evaluate on null object x with boolean 'false' should fail with ArgumentNullException.")]
        public void EvaluateTest11()
        {
            object a = null;
            Action action = () => Condition.Requires(a).Evaluate(false);
            action.Should().Throw<ArgumentNullException>();
        }

        [Fact]
        [Description("Calling Evaluate on enum x with boolean 'false' should fail with InvalidEnumArgumentException.")]
        public void EvaluateTest12()
        {
            DayOfWeek day = DayOfWeek.Thursday;
            Action action = () => Condition.Requires(day).Evaluate(false);
            action.Should().Throw<InvalidEnumArgumentException>();
        }

        [Fact]
        [Description("Calling Evaluate on enum x with expression 'x => false' should fail with InvalidEnumArgumentException.")]
        public void EvaluateTest13()
        {
            DayOfWeek day = DayOfWeek.Thursday;
            Action action = () => Condition.Requires(day).Evaluate(x => false);
            action.Should().Throw<InvalidEnumArgumentException>();
        }

        [Fact]
        [Description("Calling the Evaluate overload containing the description message, should result in a exception message containing that description.")]
        public void EvaluateTest14()
        {
            string expectedMessage = "value should not be null. The actual value is null." +
                Environment.NewLine + TestHelper.CultureSensitiveArgumentExceptionParameterText + ": value";

            object a = null;
            try
            {
                Condition.Requires(a).Evaluate(a != null, "{0} should not be null");
            }
            catch (Exception ex)
            {
                Assert.Equal(expectedMessage, ex.Message);
            }
        }

        [Fact]
        [Description("Calling the Evaluate overload containing a invalid description message, should pass and result in a exception message containing that description.")]
        public void EvaluateTest15()
        {
            string expectedMessage = "{1} should not be null. The actual value is null." +
                Environment.NewLine + TestHelper.CultureSensitiveArgumentExceptionParameterText + ": value";

            object a = null;
            try
            {
                Condition.Requires(a).Evaluate(a != null, "{1} should not be null");
            }
            catch (Exception ex)
            {
                Assert.Equal(expectedMessage, ex.Message);
            }
        }

        [Fact]
        
        [Description("Calling Evaluate with lambda 'null' should fail with an ArgumentException.")]
        public void EvaluateTest16()
        {
            Action action = () => Condition.Requires(3).Evaluate(null);
            action.Should().Throw<ArgumentException>();
        }

        [Fact]
        [Description("Calling Evaluate with lambda 'null' should fail with an PostconditionException.")]
        public void EvaluateTest17()
        {
            Action action = () => Condition.Ensures(3).Evaluate(null);
            action.Should().Throw<PostconditionException>();
        }

        [Fact]
        [Description("Calling Evaluate with boolen 'false' should succeed when exceptions are suppressed.")]
        public void EvaluateTest18()
        {
            Condition.Requires(3).SuppressExceptionsForTest().Evaluate(false);
        }

        [Fact]
        [Description("Calling Evaluate with lambda 'null' should succeed when exceptions are suppressed.")]
        public void EvaluateTest19()
        {
            Condition.Requires(3).SuppressExceptionsForTest().Evaluate(null);
        }
    }
}
