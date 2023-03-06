using NumberSet;
using System.Diagnostics.CodeAnalysis;
using System.Numerics;

namespace NumberSetUnitTest.NumberSetUnitTest.Object
{
    [TestClass]
    public class ObjectNumberSetTest
    {
        [TestMethod]
        public void TestClassTest()
        {
            var numberSetElement = NumberSet<TestClass>.Create(NumberSetElement<TestClass>.Create(new TestClass(2), new TestClass(5), true, true));
            Assert.IsTrue(numberSetElement.Contains(new TestClass(2)));
            Assert.IsTrue(numberSetElement.Contains(new TestClass(3)));
            Assert.IsTrue(numberSetElement.Contains(new TestClass(5)));
        }

        [TestMethod]
        public void TestClassEmptyTest()
        {
            var numberSet = NumberSet<TestClass>.Empty;
            Assert.IsTrue(numberSet.IsEmpty);
        }

        [TestMethod]
        public void TestClassEmptyEqualityTest()
        {
            var numberSetElement1 = (NumberSet<TestClass>)NumberSet<TestClass>.Empty;
            var numberSetElement2 = (NumberSetElement<TestClass>)NumberSetElement<TestClass>.Empty;
            Assert.IsTrue(numberSetElement1 == numberSetElement2);
            Assert.IsFalse(numberSetElement1 != numberSetElement2);
        }



        [TestMethod]
        public void TestClassEmptyNotEmptyEqualityTest()
        {
            var numberSetElement1 = NumberSet<TestClass>.Empty;
            var numberSetElement2 = NumberSetElement<TestClass>.Create(new TestClass(2), new TestClass(3), true, true);
            Assert.IsFalse(numberSetElement1 == numberSetElement2);
            Assert.IsTrue(numberSetElement1 != numberSetElement2);
        }

        [TestMethod]
        public void TestClassEmptyEqualityNumberSetTest()
        {
            var numberSetElement1 = NumberSet<TestClass>.Empty;
            var numberSetElement2 = NumberSet<TestClass>.Empty;
            Assert.IsTrue(numberSetElement1 == numberSetElement2);
            Assert.IsFalse(numberSetElement1 != numberSetElement2);
        }

        [TestMethod]
        public void TestClassEmptyNotEmptyEqualityNumberSetTest()
        {
            var numberSetElement1 = NumberSet<TestClass>.Empty;
            var numberSetElement2 = NumberSet<TestClass>.Create(NumberSetElement<TestClass>.Create(new TestClass(2), new TestClass(3), true, true));
            Assert.IsFalse(numberSetElement1 == numberSetElement2);
            Assert.IsTrue(numberSetElement1 != numberSetElement2);
        }

        [TestMethod]
        public void TestClassNotEmptyEmptyEqualityNumberSetTest()
        {
            var numberSetElement1 = NumberSet<TestClass>.Create(NumberSetElement<TestClass>.Create(new TestClass(2), new TestClass(3), true, true));
            var numberSetElement2 = NumberSet<TestClass>.Empty;
            Assert.IsTrue(numberSetElement1 != numberSetElement2);
            Assert.IsFalse(numberSetElement1 == numberSetElement2);
        }
    }

    public class TestClass : IAdditionOperators<TestClass, TestClass, TestClass>, ISubtractionOperators<TestClass, TestClass, TestClass>, IComparisonOperators<TestClass, TestClass, bool>, IParsable<TestClass>
    {

        private double _value;

        public TestClass(double value)
        {
            _value = value;
        }

        public static TestClass Parse(string s, IFormatProvider? provider)
        {
            return new TestClass(double.Parse(s, provider));
        }

        public static bool TryParse([NotNullWhen(true)] string? s, IFormatProvider? provider, [MaybeNullWhen(false)] out TestClass result)
        {
            if (double.TryParse(s, provider, out double res))
            {
                result = new TestClass(res);
                return true;
            }
            else
            {
                result = null;
                return false;
            }
        }

        public static TestClass operator +(TestClass left, TestClass right)
        {
            return new TestClass(left._value + right._value);
        }

        public static TestClass operator -(TestClass left, TestClass right)
        {
            return new TestClass(left._value - right._value);
        }

        public static bool operator ==(TestClass? left, TestClass? right)
        {
            return left._value == right._value;
        }

        public static bool operator !=(TestClass? left, TestClass? right)
        {
            return left._value != right._value;
        }

        public static bool operator <(TestClass left, TestClass right)
        {
            return left._value < right._value;
        }

        public static bool operator >(TestClass left, TestClass right)
        {
            return left._value > right._value;
        }

        public static bool operator <=(TestClass left, TestClass right)
        {
            return left._value <= right._value;
        }

        public static bool operator >=(TestClass left, TestClass right)
        {
            return left._value >= right._value;
        }
    }

}
