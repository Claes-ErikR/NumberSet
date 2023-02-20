using NumberSet;

namespace NumberSetUnitTest.NumberSetElementUnitTest.Double
{
    [TestClass]
    public  class DeconstructNumberSetElementTest
    {
        [TestMethod]
        public void TestDeconstructClosedSet()
        {
            var element = NumberSetElement<double>.Create(2, 3, true, true);
            var (lowerbound, upperbound, includelowerbound, includeupperbound) = element;
            Assert.AreEqual(lowerbound, 2);
            Assert.AreEqual(upperbound, 3);
            Assert.IsTrue(includelowerbound);
            Assert.IsTrue(includeupperbound);
        }

        [TestMethod]
        public void TestDeconstructOpenSet()
        {
            var element = NumberSetElement<double>.Create(2, 3, false, false);
            var (lowerbound, upperbound, includelowerbound, includeupperbound) = element;
            Assert.AreEqual(lowerbound, 2);
            Assert.AreEqual(upperbound, 3);
            Assert.IsFalse(includelowerbound);
            Assert.IsFalse(includeupperbound);
        }

        [TestMethod]
        public void TestDeconstructLeftOpenRightClosedSet()
        {
            var element = NumberSetElement<double>.Create(2, 3, false, true);
            var (lowerbound, upperbound, includelowerbound, includeupperbound) = element;
            Assert.AreEqual(lowerbound, 2);
            Assert.AreEqual(upperbound, 3);
            Assert.IsFalse(includelowerbound);
            Assert.IsTrue(includeupperbound);
        }

        [TestMethod]
        public void TestDeconstructLeftClosedRightOpenSet()
        {
            var element = NumberSetElement<double>.Create(2, 3, true, false);
            var (lowerbound, upperbound, includelowerbound, includeupperbound) = element;
            Assert.AreEqual(lowerbound, 2);
            Assert.AreEqual(upperbound, 3);
            Assert.IsTrue(includelowerbound);
            Assert.IsFalse(includeupperbound);
        }

        [TestMethod]
        public void TestSmallDeconstructClosedSet()
        {
            var element = NumberSetElement<double>.Create(2, 3, true, true);
            var (lowerbound, upperbound) = element;
            Assert.AreEqual(lowerbound, 2);
            Assert.AreEqual(upperbound, 3);
        }

        [TestMethod]
        public void TestSmallDeconstructOpenSet()
        {
            var element = NumberSetElement<double>.Create(2, 3, false, false);
            var (lowerbound, upperbound) = element;
            Assert.AreEqual(lowerbound, 2);
            Assert.AreEqual(upperbound, 3);
        }

        [TestMethod]
        public void TestSmallDeconstructLeftOpenRightClosedSet()
        {
            var element = NumberSetElement<double>.Create(2, 3, false, true);
            var (lowerbound, upperbound) = element;
            Assert.AreEqual(lowerbound, 2);
            Assert.AreEqual(upperbound, 3);
        }

        [TestMethod]
        public void TestSmallDeconstructLeftClosedRightOpenSet()
        {
            var element = NumberSetElement<double>.Create(2, 3, true, false);
            var (lowerbound, upperbound) = element;
            Assert.AreEqual(lowerbound, 2);
            Assert.AreEqual(upperbound, 3);
        }

        [TestMethod]
        public void TestDeconstructEmptySet()
        {
            var element = NumberSetElement<double>.Empty;
            var (lowerbound, upperbound, includelowerbound, includeupperbound) = element;
            Assert.AreEqual(lowerbound, default(double));
            Assert.AreEqual(upperbound, default(double));
            Assert.IsFalse(includelowerbound);
            Assert.IsFalse(includeupperbound);
        }

        [TestMethod]
        public void TestSmallDeconstructEmptySet()
        {
            var element = NumberSetElement<double>.Empty;
            var (lowerbound, upperbound) = element;
            Assert.AreEqual(lowerbound, default(double));
            Assert.AreEqual(upperbound, default(double));
        }

        [TestMethod]
        public void TestDeconstructNullSet()
        {
            NumberSetElement<double> element = null;
            Assert.ThrowsException<NullReferenceException>(() => { var (lowerbound, upperbound, includelowerbound, includeupperbound) = element; });
        }

        [TestMethod]
        public void TestSmallDeconstructNullSet()
        {
            NumberSetElement<double> element = null;
            Assert.ThrowsException<NullReferenceException>(() => { var (lowerbound, upperbound) = element; });
        }
    }
}
