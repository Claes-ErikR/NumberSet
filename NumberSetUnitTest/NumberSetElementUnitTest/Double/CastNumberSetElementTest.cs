using System.Globalization;
using Utte.NumberSet;

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
            NumberSetElement<double>? element = null;
            NumberSet<double> numberSet = element;
            Assert.IsTrue(numberSet.IsEmpty);
        }

        // ************** Cast string **************

        [TestMethod]
        [DataRow("[2, 3]", 2, 3, true, true)]
        [DataRow("[2, 3)", 2, 3, true, false)]
        [DataRow("(2, 3]", 2, 3, false, true)]
        [DataRow("(2, 3)", 2, 3, false, false)]
        [DataRow("[0.1, 1]", 0.1, 1, true, true)]
        [DataRow("[0, 1.1]", 0, 1.1, true, true)]
        [DataRow("[0.1, 1.1]", 0.1, 1.1, true, true)]
        [DataRow("[2.2, 2.2]", 2.2, 2.2, true, true)]
        public void TestCastString(string stringRepresentation, double expectedLowerBound, double expectedUpperBound, bool expectedIncludeLowerBound, bool expectedIncludeUpperBound)
        {
            var currentCulture = CultureInfo.CurrentCulture;
            try
            {
                CultureInfo.CurrentCulture = CultureInfo.InvariantCulture; // Use '.' as decimal separator
                NumberSetElement<double> numberSetElement = stringRepresentation;
                Assert.AreEqual(expectedLowerBound, numberSetElement.LowerBound);
                Assert.AreEqual(expectedUpperBound, numberSetElement.UpperBound);
                Assert.AreEqual(expectedIncludeLowerBound, numberSetElement.IncludeLowerBound);
                Assert.AreEqual(expectedIncludeUpperBound, numberSetElement.IncludeUpperBound);
            }
            finally
            {
                CultureInfo.CurrentCulture = currentCulture;
            }
        }

        [TestMethod]
        public void TestCastNullString()
        {
            string? element = null;
            NumberSetElement<double> numberSetElement = element;
            Assert.IsTrue(numberSetElement.IsEmpty);
        }

        [TestMethod]
        [DataRow("[2, 2)")]
        [DataRow("(2, 2]")]
        [DataRow("(2, 2)")]
        [DataRow("[2, 1]")]
        public void TestCastStringToEmpty(string stringRepresentation)
        {
            var currentCulture = CultureInfo.CurrentCulture;
            try
            {
                CultureInfo.CurrentCulture = CultureInfo.InvariantCulture; // Use '.' as decimal separator
                NumberSetElement<double> numberSetElement = stringRepresentation;
                Assert.IsTrue(numberSetElement.IsEmpty);
            }
            finally
            {
                CultureInfo.CurrentCulture = currentCulture;
            }
        }

        // ************** Cast double **************

        [TestMethod]
        [DataRow(2.45)]
        [DataRow(3)]
        public void TestCastDouble(double number)
        {
            NumberSetElement<double> numberSetElement = number;
            Assert.AreEqual(number, numberSetElement.LowerBound);
            Assert.AreEqual(number, numberSetElement.UpperBound);
            Assert.IsTrue(numberSetElement.IncludeLowerBound);
            Assert.IsTrue(numberSetElement.IncludeUpperBound);
        }
    }
}
