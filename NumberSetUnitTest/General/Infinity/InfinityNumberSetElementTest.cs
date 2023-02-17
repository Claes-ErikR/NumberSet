using NumberSet;
using System.Data;

namespace NumberSetUnitTest.General.Infinity
{
    [TestClass]
    public class InfinityNumberSetElementTest
    {
        [TestMethod]
        public void TestCreatePositiveInfinity()
        {
            var element = NumberSetElement<double>.Create(2, double.PositiveInfinity, true, true);
            Assert.AreEqual(element.LowerBound, 2);
            Assert.AreEqual(element.UpperBound, double.PositiveInfinity);
            Assert.IsTrue(element.IncludeLowerBound);
            Assert.IsTrue(element.IncludeUpperBound);
            Assert.IsFalse(element.IsEmpty);
            Assert.IsTrue(element.IsClosed);
            Assert.IsFalse(element.IsOpen);
            Assert.AreEqual(element.Measure, double.PositiveInfinity);
        }

        [TestMethod]
        public void TestCreateNegativeInfinity()
        {
            var element = NumberSetElement<double>.Create(double.NegativeInfinity, 3, true, true);
            Assert.AreEqual(element.LowerBound, double.NegativeInfinity);
            Assert.AreEqual(element.UpperBound, 3);
            Assert.IsTrue(element.IncludeLowerBound);
            Assert.IsTrue(element.IncludeUpperBound);
            Assert.IsFalse(element.IsEmpty);
            Assert.IsTrue(element.IsClosed);
            Assert.IsFalse(element.IsOpen);
            Assert.AreEqual(element.Measure, double.PositiveInfinity);
        }

        [TestMethod]
        public void TestCreateInfinity()
        {
            var element = NumberSetElement<double>.Create(double.NegativeInfinity, double.PositiveInfinity, true, true);
            Assert.AreEqual(element.LowerBound, double.NegativeInfinity);
            Assert.AreEqual(element.UpperBound, double.PositiveInfinity);
            Assert.IsTrue(element.IncludeLowerBound);
            Assert.IsTrue(element.IncludeUpperBound);
            Assert.IsFalse(element.IsEmpty);
            Assert.IsTrue(element.IsClosed);
            Assert.IsFalse(element.IsOpen);
            Assert.AreEqual(element.Measure, double.PositiveInfinity);
        }

        [TestMethod]
        [DataRow(false, false)]
        [DataRow(true, false)]
        [DataRow(false, true)]
        [DataRow(true, true)]
        public void TestIntersectsZeroMaxValuePositiveInfinity(bool includeUpperBoundElement1, bool includeLowerBoundElement2)
        {
            var element1 = NumberSetElement<double>.Create(0, double.MaxValue, true, includeUpperBoundElement1);
            var element2 = NumberSetElement<double>.Create(double.MaxValue, double.PositiveInfinity, includeLowerBoundElement2, true);
            if (includeUpperBoundElement1 && includeLowerBoundElement2)
                Assert.IsTrue(element1.Intersects(element2));
            else
                Assert.IsFalse(element1.Intersects(element2));
        }

        [TestMethod]
        [DataRow(false)]
        [DataRow(true)]
        public void TestIntersectsZeroPositiveInfinityPoint(bool includeUpperBoundElement1)
        {
            var element1 = NumberSetElement<double>.Create(0, double.PositiveInfinity, true, includeUpperBoundElement1);
            var element2 = NumberSetElement<double>.Create(double.PositiveInfinity, double.PositiveInfinity, true, true);
            if (includeUpperBoundElement1)
                Assert.IsTrue(element1.Intersects(element2));
            else
                Assert.IsFalse(element1.Intersects(element2));
        }
    }
}
