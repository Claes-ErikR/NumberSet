using System.Globalization;
using Utte.NumberSet;

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
                NumberSet<double> numberSet = stringRepresentation;
                Assert.AreEqual(expectedLowerBound, numberSet.LowerBound);
                Assert.AreEqual(expectedUpperBound, numberSet.UpperBound);
                Assert.AreEqual(expectedIncludeLowerBound, numberSet[0].IncludeLowerBound);
                Assert.AreEqual(expectedIncludeUpperBound, numberSet[0].IncludeUpperBound);
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
            NumberSet<double> numberSet = element;
            Assert.IsTrue(numberSet.IsEmpty);
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
                NumberSet<double> numberSet = stringRepresentation;
                Assert.IsTrue(numberSet.IsEmpty);
            }
            finally
            {
                CultureInfo.CurrentCulture = currentCulture;
            }
        }

        [TestMethod]
        public void TestCastStringTwoElements()
        {
            var currentCulture = CultureInfo.CurrentCulture;
            try
            {
                CultureInfo.CurrentCulture = CultureInfo.InvariantCulture; // Use '.' as decimal separator
                NumberSet<double> numberSet = "[1.2, 4.0]; (4.5, 7]";
                Assert.AreEqual(2, numberSet.Count);
                Assert.AreEqual(1.2, numberSet[0].LowerBound);
                Assert.AreEqual(4, numberSet[0].UpperBound);
                Assert.AreEqual(true, numberSet[0].IncludeLowerBound);
                Assert.AreEqual(true, numberSet[0].IncludeUpperBound);
                Assert.AreEqual(4.5, numberSet[1].LowerBound);
                Assert.AreEqual(7, numberSet[1].UpperBound);
                Assert.AreEqual(false, numberSet[1].IncludeLowerBound);
                Assert.AreEqual(true, numberSet[1].IncludeUpperBound);
            }
            finally
            {
                CultureInfo.CurrentCulture = currentCulture;
            }
        }

        [TestMethod]
        public void TestCastStringThreeElements()
        {
            var currentCulture = CultureInfo.CurrentCulture;
            try
            {
                CultureInfo.CurrentCulture = CultureInfo.InvariantCulture; // Use '.' as decimal separator
                NumberSet<double> numberSet = "[1.2, 4.0]; (4.5, 7]; (8, 9)";
                Assert.AreEqual(3, numberSet.Count);
                Assert.AreEqual(1.2, numberSet[0].LowerBound);
                Assert.AreEqual(4, numberSet[0].UpperBound);
                Assert.AreEqual(true, numberSet[0].IncludeLowerBound);
                Assert.AreEqual(true, numberSet[0].IncludeUpperBound);
                Assert.AreEqual(4.5, numberSet[1].LowerBound);
                Assert.AreEqual(7, numberSet[1].UpperBound);
                Assert.AreEqual(false, numberSet[1].IncludeLowerBound);
                Assert.AreEqual(true, numberSet[1].IncludeUpperBound);
                Assert.AreEqual(8, numberSet[2].LowerBound);
                Assert.AreEqual(9, numberSet[2].UpperBound);
                Assert.AreEqual(false, numberSet[2].IncludeLowerBound);
                Assert.AreEqual(false, numberSet[2].IncludeUpperBound);
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
            NumberSet<double> numberSet = number;
            Assert.AreEqual(1, numberSet.Count);
            Assert.AreEqual(number, numberSet.LowerBound);
            Assert.AreEqual(number, numberSet.UpperBound);
        }
    }
}
