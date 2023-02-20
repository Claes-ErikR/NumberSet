using NumberSet;

namespace NumberSetUnitTest.NumberSetElementUnitTest.Double
{
    [TestClass]
    public class DifferenceNumberSetElementTest
    {
        [TestMethod]
        [DataRow(1, 2, true, true, 3, 4, true, true)]
        [DataRow(1, 2, true, false, 3, 4, true, true)]
        [DataRow(1, 2, false, true, 3, 4, true, true)]
        [DataRow(1, 2, false, false, 3, 4, true, true)]
        [DataRow(1, 2, true, true, 3, 4, true, true)]
        [DataRow(1, 2, true, true, 3, 4, false, true)]
        [DataRow(1, 2, true, true, 3, 4, true, false)]
        [DataRow(1, 2, true, true, 3, 4, false, false)]
        [DataRow(1, 2, true, false, 2, 4, true, true)]
        [DataRow(3, 4, false, false, 1, 2, true, true)]
        [DataRow(2, 4, false, true, 1, 2, true, false)]
        [DataRow(2, 2, true, true, 3, 3, true, true)]
        [DataRow(0, 2, true, true, 3, 3, true, true)]
        [DataRow(2, 2, true, true, 3, 5, true, true)]
        public void TestDisjunktDifference(double lowerBound1, double upperBound1, bool includeLowerBound1, bool includeUpperBound1, double lowerBound2, double upperBound2, bool includeLowerBound2, bool includeUpperBound2)
        {
            var element1 = NumberSetElement<double>.Create(lowerBound1, upperBound1, includeLowerBound1, includeUpperBound1);
            var element2 = NumberSetElement<double>.Create(lowerBound2, upperBound2, includeLowerBound2, includeUpperBound2);
            var result = element1.Difference(element2);
            Assert.AreEqual(result.Count, 1);
            Assert.IsTrue(result[0].Equals(element1));
        }

        [TestMethod]
        [DataRow(3, 4, true, true, 2, 3, true, true)]
        [DataRow(4, 6, true, true, 3, 5, true, true)]
        public void TestOverlapOrTouchFromLeftSideDifference(double lowerBound1, double upperBound1, bool includeLowerBound1, bool includeUpperBound1, double lowerBound2, double upperBound2, bool includeLowerBound2, bool includeUpperBound2)
        {
            var element1 = NumberSetElement<double>.Create(lowerBound1, upperBound1, includeLowerBound1, includeUpperBound1);
            var element2 = NumberSetElement<double>.Create(lowerBound2, upperBound2, includeLowerBound2, includeUpperBound2);
            var result = element1.Difference(element2);
            Assert.AreEqual(result.Count, 1);
            Assert.AreEqual(result[0].LowerBound, upperBound2);
            Assert.AreEqual(result[0].UpperBound, upperBound1);
            Assert.AreEqual(result[0].IncludeLowerBound, !includeUpperBound2);
            Assert.AreEqual(result[0].IncludeUpperBound, includeUpperBound1);
        }

        [TestMethod]
        [DataRow(2, 3, true, true, 3, 4, true, true)]
        [DataRow(1, 4, true, false, 3, 5, false, true)]
        public void TestOverlapOrTouchFromRightSideDifference(double lowerBound1, double upperBound1, bool includeLowerBound1, bool includeUpperBound1, double lowerBound2, double upperBound2, bool includeLowerBound2, bool includeUpperBound2)
        {
            var element1 = NumberSetElement<double>.Create(lowerBound1, upperBound1, includeLowerBound1, includeUpperBound1);
            var element2 = NumberSetElement<double>.Create(lowerBound2, upperBound2, includeLowerBound2, includeUpperBound2);
            var result = element1.Difference(element2);
            Assert.AreEqual(result.Count, 1);
            Assert.AreEqual(result[0].LowerBound, lowerBound1);
            Assert.AreEqual(result[0].UpperBound, lowerBound2);
            Assert.AreEqual(result[0].IncludeLowerBound, includeLowerBound1);
            Assert.AreEqual(result[0].IncludeUpperBound, !includeLowerBound2);
        }

        [TestMethod]
        [DataRow(1, 6, true, true, 3, 4, true, true)]
        [DataRow(1, 6, true, true, 3, 4, false, true)]
        [DataRow(1, 6, true, true, 3, 4, true, false)]
        [DataRow(1, 6, true, true, 3, 4, false, false)]
        [DataRow(1, 6, true, true, 4, 4, true, true)]
        public void TestOverlapInMiddleDifference(double lowerBound1, double upperBound1, bool includeLowerBound1, bool includeUpperBound1, double lowerBound2, double upperBound2, bool includeLowerBound2, bool includeUpperBound2)
        {
            var element1 = NumberSetElement<double>.Create(lowerBound1, upperBound1, includeLowerBound1, includeUpperBound1);
            var element2 = NumberSetElement<double>.Create(lowerBound2, upperBound2, includeLowerBound2, includeUpperBound2);
            var result = element1.Difference(element2);
            Assert.AreEqual(result.Count, 2);
            Assert.AreEqual(result[0].LowerBound, lowerBound1);
            Assert.AreEqual(result[0].UpperBound, lowerBound2);
            Assert.AreEqual(result[0].IncludeLowerBound, includeLowerBound1);
            Assert.AreEqual(result[0].IncludeUpperBound, !includeLowerBound2);
            Assert.AreEqual(result[1].LowerBound, upperBound2);
            Assert.AreEqual(result[1].UpperBound, upperBound1);
            Assert.AreEqual(result[1].IncludeLowerBound, !includeUpperBound2);
            Assert.AreEqual(result[1].IncludeUpperBound, includeUpperBound1);
        }

        [TestMethod]
        [DataRow(1, 2, false, false, 0, 4, true, true)]
        [DataRow(4, 4, true, true, 3, 5, false, true)]
        [DataRow(4, 4, true, true, 4, 4, true, true)]
        public void TestOverlapWholeDifference(double lowerBound1, double upperBound1, bool includeLowerBound1, bool includeUpperBound1, double lowerBound2, double upperBound2, bool includeLowerBound2, bool includeUpperBound2)
        {
            var element1 = NumberSetElement<double>.Create(lowerBound1, upperBound1, includeLowerBound1, includeUpperBound1);
            var element2 = NumberSetElement<double>.Create(lowerBound2, upperBound2, includeLowerBound2, includeUpperBound2);
            var result = element1.Difference(element2);
            Assert.AreEqual(result.Count, 1);
            Assert.IsTrue(result.IsEmpty);
        }

        [TestMethod]
        [DataRow(2, 3, true, true)]
        [DataRow(2, 3, false, true)]
        [DataRow(2, 3, true, false)]
        [DataRow(2, 3, false, false)]
        [DataRow(2, 2, true, true)]
        public void TestWithEmptyDifference(double lowerBound, double upperBound, bool includeLowerBound, bool includeUpperBound)
        {
            var element = NumberSetElement<double>.Create(lowerBound, upperBound, includeLowerBound, includeUpperBound);
            var result1 = element.Difference(NumberSetElement<double>.Empty);
            Assert.AreEqual(result1.Count, 1);
            Assert.AreEqual(result1[0].LowerBound, lowerBound);
            Assert.AreEqual(result1[0].UpperBound, upperBound);
            Assert.AreEqual(result1[0].IncludeLowerBound, includeLowerBound);
            Assert.AreEqual(result1[0].IncludeUpperBound, includeUpperBound);
            var result2 = NumberSetElement<double>.Empty.Difference(element);
            Assert.AreEqual(result2.Count, 1);
            Assert.IsTrue(result2.IsEmpty);
        }

        [TestMethod]
        public void TestEmptyWithEmptyDifference()
        {
            var result = NumberSetElement<double>.Empty.Difference(NumberSetElement<double>.Empty);
            Assert.AreEqual(result.Count, 1);
            Assert.IsTrue(result.IsEmpty);
        }

        [TestMethod]
        [DataRow(1, 2, true, true, 3, 4, true, true)]
        [DataRow(1, 2, true, false, 3, 4, true, true)]
        [DataRow(1, 2, false, true, 3, 4, true, true)]
        [DataRow(1, 2, false, false, 3, 4, true, true)]
        [DataRow(1, 2, true, true, 3, 4, true, true)]
        [DataRow(1, 2, true, true, 3, 4, false, true)]
        [DataRow(1, 2, true, true, 3, 4, true, false)]
        [DataRow(1, 2, true, true, 3, 4, false, false)]
        [DataRow(1, 2, true, false, 2, 4, true, true)]
        [DataRow(3, 4, false, false, 1, 2, true, true)]
        [DataRow(2, 4, false, true, 1, 2, true, false)]
        [DataRow(2, 2, true, true, 3, 3, true, true)]
        [DataRow(0, 2, true, true, 3, 3, true, true)]
        [DataRow(2, 2, true, true, 3, 5, true, true)]
        public void TestDisjunktDifferenceNumberSet(double lowerBound1, double upperBound1, bool includeLowerBound1, bool includeUpperBound1, double lowerBound2, double upperBound2, bool includeLowerBound2, bool includeUpperBound2)
        {
            var element1 = NumberSetElement<double>.Create(lowerBound1, upperBound1, includeLowerBound1, includeUpperBound1);
            var element2 = NumberSet<double>.Create(NumberSetElement<double>.Create(lowerBound2, upperBound2, includeLowerBound2, includeUpperBound2));
            var result = element1.Difference(element2);
            Assert.AreEqual(result.Count, 1);
            Assert.IsTrue(result[0].Equals(element1));
        }

        [TestMethod]
        [DataRow(3, 4, true, true, 2, 3, true, true)]
        [DataRow(4, 6, true, true, 3, 5, true, true)]
        public void TestOverlapOrTouchFromLeftSideDifferenceNumberSet(double lowerBound1, double upperBound1, bool includeLowerBound1, bool includeUpperBound1, double lowerBound2, double upperBound2, bool includeLowerBound2, bool includeUpperBound2)
        {
            var element1 = NumberSetElement<double>.Create(lowerBound1, upperBound1, includeLowerBound1, includeUpperBound1);
            var element2 = NumberSet<double>.Create(NumberSetElement<double>.Create(lowerBound2, upperBound2, includeLowerBound2, includeUpperBound2));
            var result = element1.Difference(element2);
            Assert.AreEqual(result.Count, 1);
            Assert.AreEqual(result[0].LowerBound, upperBound2);
            Assert.AreEqual(result[0].UpperBound, upperBound1);
            Assert.AreEqual(result[0].IncludeLowerBound, !includeUpperBound2);
            Assert.AreEqual(result[0].IncludeUpperBound, includeUpperBound1);
        }

        [TestMethod]
        [DataRow(2, 3, true, true, 3, 4, true, true)]
        [DataRow(1, 4, true, false, 3, 5, false, true)]
        public void TestOverlapOrTouchFromRightSideDifferenceNumberSet(double lowerBound1, double upperBound1, bool includeLowerBound1, bool includeUpperBound1, double lowerBound2, double upperBound2, bool includeLowerBound2, bool includeUpperBound2)
        {
            var element1 = NumberSetElement<double>.Create(lowerBound1, upperBound1, includeLowerBound1, includeUpperBound1);
            var element2 = NumberSet<double>.Create(NumberSetElement<double>.Create(lowerBound2, upperBound2, includeLowerBound2, includeUpperBound2));
            var result = element1.Difference(element2);
            Assert.AreEqual(result.Count, 1);
            Assert.AreEqual(result[0].LowerBound, lowerBound1);
            Assert.AreEqual(result[0].UpperBound, lowerBound2);
            Assert.AreEqual(result[0].IncludeLowerBound, includeLowerBound1);
            Assert.AreEqual(result[0].IncludeUpperBound, !includeLowerBound2);
        }

        [TestMethod]
        [DataRow(1, 6, true, true, 3, 4, true, true)]
        [DataRow(1, 6, true, true, 3, 4, false, true)]
        [DataRow(1, 6, true, true, 3, 4, true, false)]
        [DataRow(1, 6, true, true, 3, 4, false, false)]
        [DataRow(1, 6, true, true, 4, 4, true, true)]
        public void TestOverlapInMiddleDifferenceNumberSet(double lowerBound1, double upperBound1, bool includeLowerBound1, bool includeUpperBound1, double lowerBound2, double upperBound2, bool includeLowerBound2, bool includeUpperBound2)
        {
            var element1 = NumberSetElement<double>.Create(lowerBound1, upperBound1, includeLowerBound1, includeUpperBound1);
            var element2 = NumberSet<double>.Create(NumberSetElement<double>.Create(lowerBound2, upperBound2, includeLowerBound2, includeUpperBound2));
            var result = element1.Difference(element2);
            Assert.AreEqual(result.Count, 2);
            Assert.AreEqual(result[0].LowerBound, lowerBound1);
            Assert.AreEqual(result[0].UpperBound, lowerBound2);
            Assert.AreEqual(result[0].IncludeLowerBound, includeLowerBound1);
            Assert.AreEqual(result[0].IncludeUpperBound, !includeLowerBound2);
            Assert.AreEqual(result[1].LowerBound, upperBound2);
            Assert.AreEqual(result[1].UpperBound, upperBound1);
            Assert.AreEqual(result[1].IncludeLowerBound, !includeUpperBound2);
            Assert.AreEqual(result[1].IncludeUpperBound, includeUpperBound1);
        }

        [TestMethod]
        [DataRow(1, 2, false, false, 0, 4, true, true)]
        [DataRow(4, 4, true, true, 3, 5, false, true)]
        [DataRow(4, 4, true, true, 4, 4, true, true)]
        public void TestOverlapWholeDifferenceNumberSet(double lowerBound1, double upperBound1, bool includeLowerBound1, bool includeUpperBound1, double lowerBound2, double upperBound2, bool includeLowerBound2, bool includeUpperBound2)
        {
            var element1 = NumberSetElement<double>.Create(lowerBound1, upperBound1, includeLowerBound1, includeUpperBound1);
            var element2 = NumberSet<double>.Create(NumberSetElement<double>.Create(lowerBound2, upperBound2, includeLowerBound2, includeUpperBound2));
            var result = element1.Difference(element2);
            Assert.AreEqual(result.Count, 1);
            Assert.IsTrue(result.IsEmpty);
        }

        [TestMethod]
        [DataRow(2, 3, true, true)]
        [DataRow(2, 3, false, true)]
        [DataRow(2, 3, true, false)]
        [DataRow(2, 3, false, false)]
        [DataRow(2, 2, true, true)]
        public void TestWithEmptyDifferenceNumberSet(double lowerBound, double upperBound, bool includeLowerBound, bool includeUpperBound)
        {
            var element = NumberSetElement<double>.Create(lowerBound, upperBound, includeLowerBound, includeUpperBound);
            var result1 = element.Difference(NumberSet<double>.Empty);
            Assert.AreEqual(result1.Count, 1);
            Assert.AreEqual(result1[0].LowerBound, lowerBound);
            Assert.AreEqual(result1[0].UpperBound, upperBound);
            Assert.AreEqual(result1[0].IncludeLowerBound, includeLowerBound);
            Assert.AreEqual(result1[0].IncludeUpperBound, includeUpperBound);
            var result2 = NumberSetElement<double>.Empty.Difference(NumberSet<double>.Create(element));
            Assert.AreEqual(result2.Count, 1);
            Assert.IsTrue(result2.IsEmpty);
        }

        [TestMethod]
        public void TestEmptyWithEmptyDifferenceNumberSet()
        {
            var result = NumberSetElement<double>.Empty.Difference(NumberSet<double>.Empty);
            Assert.AreEqual(result.Count, 1);
            Assert.IsTrue(result.IsEmpty);
        }

        [TestMethod]
        [DataRow(-1, 0, true, true)]
        [DataRow(5, 6, true, true)]
        [DataRow(10, 11, true, true)]
        [DataRow(0, 1, false, false)]
        [DataRow(4, 5, false, false)]
        [DataRow(6, 7, false, false)]
        [DataRow(9, 10, false, false)]
        [DataRow(4, 7, false, false)]
        public void TestDifferenceNumberSet2Elements(double lowerBound, double upperBound, bool includeLowerBound, bool includeUpperBound)
        {
            var element = NumberSetElement<double>.Create(lowerBound, upperBound, includeLowerBound, includeUpperBound);
            var numberSet = NumberSet<double>.Create(NumberSetElement<double>.Create(1, 4, false, false), NumberSetElement<double>.Create(7, 9, false, false));
            var result = element.Difference(numberSet);
            Assert.AreEqual(result.Count, 1);

            Assert.IsTrue(element.Equals(result[0]));
        }

        [TestMethod]
        [DataRow(3, 7, true, true)]
        [DataRow(3, 7, false, true)]
        [DataRow(3, 7, true, false)]
        [DataRow(3, 7, false, false)]
        [DataRow(4, 6, true, true)]
        public void TestDifferenceNumberSet(double lowerBound, double upperBound, bool includeLowerBound, bool includeUpperBound)
        {
            var element = NumberSetElement<double>.Create(lowerBound, upperBound, includeLowerBound, includeUpperBound);
            var numberSet = NumberSet<double>.Create(NumberSetElement<double>.Create(1, 4, true, true), NumberSetElement<double>.Create(6, 9, true, true));
            var result = element.Difference(numberSet);
            Assert.AreEqual(result.Count, 1);
            Assert.AreEqual(result[0].LowerBound, numberSet[0].UpperBound);
            Assert.AreEqual(result[0].UpperBound, numberSet[1].LowerBound);
            Assert.AreEqual(result[0].IncludeLowerBound, !numberSet[0].IncludeUpperBound);
            Assert.AreEqual(result[0].IncludeUpperBound, !numberSet[1].IncludeLowerBound);
        }

        [TestMethod]
        public void TestDifferenceNumberSet2Elements()
        {
            var element = NumberSetElement<double>.Create(1, 6, true, true);
            var numberSet = NumberSet<double>.Create(NumberSetElement<double>.Create(2, 3, true, true), NumberSetElement<double>.Create(4, 5, true, true));
            var result = element.Difference(numberSet);
            Assert.AreEqual(result.Count, 3);

            Assert.AreEqual(result[0].LowerBound, 1);
            Assert.AreEqual(result[0].UpperBound, 2);
            Assert.AreEqual(result[0].IncludeLowerBound, true);
            Assert.AreEqual(result[0].IncludeUpperBound, false);

            Assert.AreEqual(result[1].LowerBound, 3);
            Assert.AreEqual(result[1].UpperBound, 4);
            Assert.AreEqual(result[1].IncludeLowerBound, false);
            Assert.AreEqual(result[1].IncludeUpperBound, false);

            Assert.AreEqual(result[1].LowerBound, 5);
            Assert.AreEqual(result[1].UpperBound, 6);
            Assert.AreEqual(result[1].IncludeLowerBound, false);
            Assert.AreEqual(result[1].IncludeUpperBound, true);
        }
    }
}
