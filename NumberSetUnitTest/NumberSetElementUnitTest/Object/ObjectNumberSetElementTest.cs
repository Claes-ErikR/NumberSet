using NumberSet;
using System.Diagnostics.CodeAnalysis;
using System.Numerics;

namespace NumberSetUnitTest.NumberSetElementUnitTest.Object
{
    [TestClass]
    public class ObjectNumberSetElementTest
    {
        [TestMethod]
        public void TestClassTest()
        {
            var numberSetElement = NumberSetElement<TestClass>.Create(new TestClass(2), new TestClass(5), true, true);
            Assert.IsTrue(numberSetElement.Contains(new TestClass(2)));
            Assert.IsTrue(numberSetElement.Contains(new TestClass(3)));
            Assert.IsTrue(numberSetElement.Contains(new TestClass(5)));
        }

        [TestMethod]
        public void TestClassEmptyTest()
        {
            var numberSetElement = NumberSetElement<TestClass>.CreateEmpty();
            Assert.IsTrue(numberSetElement.IsEmpty);
        }

        [TestMethod]
        public void TestClassEmptyEqualityTest()
        {
            var numberSetElement1 = NumberSetElement<TestClass>.CreateEmpty();
            var numberSetElement2 = NumberSetElement<TestClass>.CreateEmpty();
            Assert.IsTrue(numberSetElement1 == numberSetElement2);
            Assert.IsFalse(numberSetElement1 != numberSetElement2);
        }

        [TestMethod]
        public void TestClassEmptyNotEmptyEqualityTest()
        {
            var numberSetElement1 = NumberSetElement<TestClass>.CreateEmpty();
            var numberSetElement2 = NumberSetElement<TestClass>.Create(new TestClass(2), new TestClass(3), true, true);
            Assert.IsFalse(numberSetElement1 == numberSetElement2);
            Assert.IsTrue(numberSetElement1 != numberSetElement2);
        }

        [TestMethod]
        public void TestClassEmptyEqualityNumberSetTest()
        {
            var numberSetElement1 = NumberSetElement<TestClass>.CreateEmpty();
            var numberSetElement2 = NumberSet<TestClass>.CreateEmpty();
            Assert.IsTrue(numberSetElement1 == numberSetElement2);
            Assert.IsFalse(numberSetElement1 != numberSetElement2);
        }

        [TestMethod]
        public void TestClassEmptyNotEmptyEqualityNumberSetTest()
        {
            var numberSetElement1 = NumberSetElement<TestClass>.CreateEmpty();
            var numberSetElement2 = NumberSet<TestClass>.Create(NumberSetElement<TestClass>.Create(new TestClass(2), new TestClass(3), true, true));
            Assert.IsFalse(numberSetElement1 == numberSetElement2);
            Assert.IsTrue(numberSetElement1 != numberSetElement2);
        }

        [TestMethod]
        public void TestClassNotEmptyEmptyEqualityNumberSetTest()
        {
            var numberSetElement1 = NumberSetElement<TestClass>.Create(new TestClass(2), new TestClass(3), true, true);
            var numberSetElement2 = NumberSet<TestClass>.CreateEmpty();
            Assert.IsTrue(numberSetElement1 != numberSetElement2);
            Assert.IsFalse(numberSetElement1 == numberSetElement2);
        }

        [TestMethod]
        public void TestClassCreateWithNullTest()
        {
            var numberSetElement = NumberSetElement<TestClass>.Create(null, null, true, true);
            Assert.IsTrue(numberSetElement.IsEmpty);
        }

        [TestMethod]
        public void TestClassCreateWithNullLowerBoundTest()
        {
            var numberSetElement = NumberSetElement<TestClass>.Create(null, new TestClass(3), true, true);
            Assert.IsTrue(numberSetElement.IsEmpty);
        }

        [TestMethod]
        public void TestClassCreateWithNullUpperBoundTest()
        {
            var numberSetElement = NumberSetElement<TestClass>.Create(new TestClass(2), null, true, true);
            Assert.IsTrue(numberSetElement.IsEmpty);
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
            if(double.TryParse(s, provider, out double res))
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
