using NumberSet;

namespace NumberSetUnitTest.NumberSetElementUnitTest.Double
{
    [TestClass]
    public class CastNumberSetElementTest
    {
        [TestMethod]
        public void TestCastClosedSet()
        {
            var element = (NumberSetElement<double>)NumberSetElement<double>.Create(2, 3, true, true);
            NumberSet<double> numberSet = element;
            Assert.AreEqual(numberSet.LowerBound, 2);
            Assert.AreEqual(numberSet.UpperBound, 3);
            Assert.IsTrue(numberSet[0].IncludeLowerBound);
            Assert.IsTrue(numberSet[0].IncludeUpperBound);
            Assert.IsFalse(numberSet.IsEmpty);
            Assert.IsTrue(numberSet.IsClosed);
            Assert.IsFalse(numberSet.IsOpen);
            Assert.AreEqual(numberSet.Measure, 1);
        }

        [TestMethod]
        public void TestCastOpenSet()
        {
            var element = (NumberSetElement<double>)NumberSetElement<double>.Create(2, 3, false, false);
            NumberSet<double> numberSet = element;
            Assert.AreEqual(numberSet.LowerBound, 2);
            Assert.AreEqual(numberSet.UpperBound, 3);
            Assert.IsFalse(numberSet[0].IncludeLowerBound);
            Assert.IsFalse(numberSet[0].IncludeUpperBound);
            Assert.IsFalse(numberSet.IsEmpty);
            Assert.IsFalse(numberSet.IsClosed);
            Assert.IsTrue(numberSet.IsOpen);
            Assert.AreEqual(numberSet.Measure, 1);
        }

        [TestMethod]
        public void TestCastLeftOpenRightClosedSet()
        {
            var element = (NumberSetElement<double>)NumberSetElement<double>.Create(2, 3, false, true);
            NumberSet<double> numberSet = element;
            Assert.AreEqual(numberSet.LowerBound, 2);
            Assert.AreEqual(numberSet.UpperBound, 3);
            Assert.IsFalse(numberSet[0].IncludeLowerBound);
            Assert.IsTrue(numberSet[0].IncludeUpperBound);
            Assert.IsFalse(numberSet.IsEmpty);
            Assert.IsFalse(numberSet.IsClosed);
            Assert.IsFalse(numberSet.IsOpen);
            Assert.AreEqual(numberSet.Measure, 1);
        }

        [TestMethod]
        public void TestCastLeftClosedRightOpenSet()
        {
            var element = (NumberSetElement<double>)NumberSetElement<double>.Create(2, 3, true, false);
            NumberSet<double> numberSet = element;
            Assert.AreEqual(numberSet.LowerBound, 2);
            Assert.AreEqual(numberSet.UpperBound, 3);
            Assert.IsTrue(numberSet[0].IncludeLowerBound);
            Assert.IsFalse(numberSet[0].IncludeUpperBound);
            Assert.IsFalse(numberSet.IsEmpty);
            Assert.IsFalse(numberSet.IsClosed);
            Assert.IsFalse(numberSet.IsOpen);
            Assert.AreEqual(numberSet.Measure, 1);
        }

        [TestMethod]
        public void TestCastEmptySet()
        {
            var element = (NumberSetElement<double>)NumberSetElement<double>.Empty;
            NumberSet<double> numberSet = element;
            Assert.AreEqual(numberSet.LowerBound, default(double));
            Assert.AreEqual(numberSet.UpperBound, default(double));
            Assert.IsFalse(numberSet[0].IncludeLowerBound);
            Assert.IsFalse(numberSet[0].IncludeUpperBound);
            Assert.IsTrue(numberSet.IsEmpty);
            Assert.IsFalse(numberSet.IsClosed);
            Assert.IsTrue(numberSet.IsOpen);
            Assert.AreEqual(numberSet.Measure, 0);
        }

        [TestMethod]
        public void TestCastNullSet()
        {
            NumberSetElement<double> element = null;
            NumberSet<double> numberSet = element;
            Assert.IsNull(numberSet);
        }
    }
}
