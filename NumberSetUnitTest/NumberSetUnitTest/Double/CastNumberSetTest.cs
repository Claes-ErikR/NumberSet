using NumberSet;

namespace NumberSetUnitTest.NumberSetUnitTest.Double
{
    [TestClass]
    public class CastNumberSetTest
    {
        [TestMethod]
        public void TestCastClosedSet()
        {
            var numberSet = (NumberSet<double>)NumberSet<double>.Create(NumberSetElement<double>.Create(2, 3, true, true));
            var element = (NumberSetElement<double>)numberSet;
            Assert.AreEqual(element.LowerBound, 2);
            Assert.AreEqual(element.UpperBound, 3);
            Assert.IsTrue(element.IncludeLowerBound);
            Assert.IsTrue(element.IncludeUpperBound);
            Assert.IsFalse(element.IsEmpty);
            Assert.IsTrue(element.IsClosed);
            Assert.IsFalse(element.IsOpen);
            Assert.AreEqual(element.Measure, 1);
        }

        [TestMethod]
        public void TestCastOpenSet()
        {
            var numberSet = (NumberSet<double>)NumberSet<double>.Create(NumberSetElement<double>.Create(2, 3, false, false));
            var element = (NumberSetElement<double>)numberSet;
            Assert.AreEqual(element.LowerBound, 2);
            Assert.AreEqual(element.UpperBound, 3);
            Assert.IsFalse(element.IncludeLowerBound);
            Assert.IsFalse(element.IncludeUpperBound);
            Assert.IsFalse(element.IsEmpty);
            Assert.IsFalse(element.IsClosed);
            Assert.IsTrue(element.IsOpen);
            Assert.AreEqual(element.Measure, 1);
        }

        [TestMethod]
        public void TestCastLeftOpenRightClosedSet()
        {
            var numberSet = (NumberSet<double>)NumberSet<double>.Create(NumberSetElement<double>.Create(2, 3, false, true));
            var element = (NumberSetElement<double>)numberSet;
            Assert.AreEqual(element.LowerBound, 2);
            Assert.AreEqual(element.UpperBound, 3);
            Assert.IsFalse(element.IncludeLowerBound);
            Assert.IsTrue(element.IncludeUpperBound);
            Assert.IsFalse(element.IsEmpty);
            Assert.IsFalse(element.IsClosed);
            Assert.IsFalse(element.IsOpen);
            Assert.AreEqual(element.Measure, 1);
        }

        [TestMethod]
        public void TestCastLeftClosedRightOpenSet()
        {
            var numberSet = (NumberSet<double>)NumberSet<double>.Create(NumberSetElement<double>.Create(2, 3, true, false));
            var element = (NumberSetElement<double>)numberSet;
            Assert.AreEqual(element.LowerBound, 2);
            Assert.AreEqual(element.UpperBound, 3);
            Assert.IsTrue(element.IncludeLowerBound);
            Assert.IsFalse(element.IncludeUpperBound);
            Assert.IsFalse(element.IsEmpty);
            Assert.IsFalse(element.IsClosed);
            Assert.IsFalse(element.IsOpen);
            Assert.AreEqual(element.Measure, 1);
        }

        [TestMethod]
        public void TestCastEmptySet()
        {
            var numberSet = (NumberSet<double>)NumberSet<double>.Empty;
            var element = (NumberSetElement<double>)numberSet;
            Assert.AreEqual(element.LowerBound, default(double));
            Assert.AreEqual(element.UpperBound, default(double));
            Assert.IsFalse(element.IncludeLowerBound);
            Assert.IsFalse(element.IncludeUpperBound);
            Assert.IsTrue(element.IsEmpty);
            Assert.IsFalse(element.IsClosed);
            Assert.IsTrue(element.IsOpen);
            Assert.AreEqual(element.Measure, 0);
        }

        [TestMethod]
        public void TestCastNullSet()
        {
            NumberSet<double> numberSet = null;
            var element = (NumberSetElement<double>)numberSet;
            
            Assert.IsNull(element);
        }

        [TestMethod]
        public void TestCastLoseInformation()
        {
            var numberSet = (NumberSet<double>)NumberSet<double>.Create(NumberSetElement<double>.Create(2, 3, true, true), NumberSetElement<double>.Create(4, 5, true, true));
            var element = (NumberSetElement<double>)numberSet;
            Assert.AreEqual(element.LowerBound, 2);
            Assert.AreEqual(element.UpperBound, 3);
            Assert.IsTrue(element.IncludeLowerBound);
            Assert.IsTrue(element.IncludeUpperBound);
            Assert.IsFalse(element.IsEmpty);
            Assert.IsTrue(element.IsClosed);
            Assert.IsFalse(element.IsOpen);
            Assert.AreEqual(element.Measure, 1);
        }
    }
}
