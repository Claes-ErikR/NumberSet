using NumberSet;

namespace NumberSetUnitTest.General.NaN
{
    [TestClass]
    public class NaNNumberSetElementTest
    {
        [TestMethod]
        [DataRow(2, double.NaN)]
        [DataRow(double.NaN, 3)]
        [DataRow(double.NaN, double.NaN)]
        public void TestCreatedoubleNaN(double lowerBound, double upperBound)
        {
            var element = NumberSetElement<double>.Create(lowerBound, upperBound, true, true);
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
        [DataRow(2, float.NaN)]
        [DataRow(float.NaN, 3)]
        [DataRow(float.NaN, float.NaN)]
        public void TestCreatefloatNaN(float lowerBound, float upperBound)
        {
            var element = NumberSetElement<float>.Create(lowerBound, upperBound, true, true);
            Assert.AreEqual(element.LowerBound, default(float));
            Assert.AreEqual(element.UpperBound, default(float));
            Assert.IsFalse(element.IncludeLowerBound);
            Assert.IsFalse(element.IncludeUpperBound);
            Assert.IsTrue(element.IsEmpty);
            Assert.IsFalse(element.IsClosed);
            Assert.IsTrue(element.IsOpen);
            Assert.AreEqual(element.Measure, 0);
        }

        [TestMethod]
        public void TestContainsdoubleNaN()
        {
            var element = NumberSetElement<double>.Create(2, 3, true, true);
            Assert.IsFalse(element.Contains(double.NaN));
        }

        [TestMethod]
        public void TestEmptyContainsdoubleNaN()
        {
            var element = NumberSetElement<double>.Empty;
            Assert.IsFalse(element.Contains(double.NaN));
        }


        [TestMethod]
        public void TestContainsfloatNaN()
        {
            var element = NumberSetElement<float>.Create(2, 3, true, true);
            Assert.IsFalse(element.Contains(float.NaN));
        }

        [TestMethod]
        public void TestEmptyContainsfloatNaN()
        {
            var element = NumberSetElement<float>.Empty;
            Assert.IsFalse(element.Contains(float.NaN));
        }

        [TestMethod]
        public void TestContainsdoubleNaNNumberSet()
        {
            var element = NumberSet<double>.Create(NumberSetElement<double>.Create(2, 3, true, true));
            Assert.IsFalse(element.Contains(double.NaN));
        }

        [TestMethod]
        public void TestEmptyContainsdoubleNaNNumberSet()
        {
            var element = NumberSet<double>.CreateEmpty();
            Assert.IsFalse(element.Contains(double.NaN));
        }

        [TestMethod]
        public void TestContainsfloatNaNNumberSet()
        {
            var element = NumberSet<float>.Create(NumberSetElement<float>.Create(2, 3, true, true));
            Assert.IsFalse(element.Contains(float.NaN));
        }

        [TestMethod]
        public void TestEmptyContainsfloatNaNNumberSet()
        {
            var element = NumberSet<float>.CreateEmpty();
            Assert.IsFalse(element.Contains(float.NaN));
        }
    }
}
