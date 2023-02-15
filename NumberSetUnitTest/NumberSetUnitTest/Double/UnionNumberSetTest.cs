using NumberSet;


namespace NumberSetUnitTest.NumberSetUnitTest.Double
{
    [TestClass]
    public class UnionNumberSetTest
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
        [DataRow(1, 2, true, false, 2, 4, false, true)]
        [DataRow(3, 4, false, false, 1, 2, true, true)]
        [DataRow(2, 4, false, true, 1, 2, true, false)]
        [DataRow(2, 2, true, true, 3, 3, true, true)]
        [DataRow(0, 2, true, true, 3, 3, true, true)]
        [DataRow(2, 2, true, true, 3, 5, true, true)]
        public void TestDisjunktUnion(double lowerBound1, double upperBound1, bool includeLowerBound1, bool includeUpperBound1, double lowerBound2, double upperBound2, bool includeLowerBound2, bool includeUpperBound2)
        {
            var element1 = NumberSet<double>.Create(NumberSetElement<double>.Create(lowerBound1, upperBound1, includeLowerBound1, includeUpperBound1));
            var element2 = NumberSetElement<double>.Create(lowerBound2, upperBound2, includeLowerBound2, includeUpperBound2);
            var result = element1.Union(element2);
            Assert.AreEqual(result.Count, 2);
            if (lowerBound1 < lowerBound2)
            {
                Assert.AreEqual(result[0].LowerBound, lowerBound1);
                Assert.AreEqual(result[0].UpperBound, upperBound1);
                Assert.AreEqual(result[0].IncludeLowerBound, includeLowerBound1);
                Assert.AreEqual(result[0].IncludeUpperBound, includeUpperBound1);
                Assert.AreEqual(result[1].LowerBound, lowerBound2);
                Assert.AreEqual(result[1].UpperBound, upperBound2);
                Assert.AreEqual(result[1].IncludeLowerBound, includeLowerBound2);
                Assert.AreEqual(result[1].IncludeUpperBound, includeUpperBound2);
            }
            else
            {
                Assert.AreEqual(result[0].LowerBound, lowerBound2);
                Assert.AreEqual(result[0].UpperBound, upperBound2);
                Assert.AreEqual(result[0].IncludeLowerBound, includeLowerBound2);
                Assert.AreEqual(result[0].IncludeUpperBound, includeUpperBound2);
                Assert.AreEqual(result[1].LowerBound, lowerBound1);
                Assert.AreEqual(result[1].UpperBound, upperBound1);
                Assert.AreEqual(result[1].IncludeLowerBound, includeLowerBound1);
                Assert.AreEqual(result[1].IncludeUpperBound, includeUpperBound1);
            }
        }

        [TestMethod]
        [DataRow(2, 3, true, true, 3, 4, true, true)]
        [DataRow(3, 4, true, true, 2, 3, true, true)]
        [DataRow(1, 4, true, false, 3, 5, false, true)]
        [DataRow(1, 6, false, true, 3, 4, true, true)]
        [DataRow(1, 2, false, false, 0, 4, true, true)]
        [DataRow(4, 7, true, true, 3, 5, true, true)]
        [DataRow(4, 4, true, true, 3, 5, false, true)]
        [DataRow(1, 4, true, false, 3, 3, true, true)]
        [DataRow(4, 4, true, true, 4, 4, true, true)]
        public void TestOverlapOrTouchUnion(double lowerBound1, double upperBound1, bool includeLowerBound1, bool includeUpperBound1, double lowerBound2, double upperBound2, bool includeLowerBound2, bool includeUpperBound2)
        {
            var element1 = NumberSet<double>.Create(NumberSetElement<double>.Create(lowerBound1, upperBound1, includeLowerBound1, includeUpperBound1));
            var element2 = NumberSetElement<double>.Create(lowerBound2, upperBound2, includeLowerBound2, includeUpperBound2);
            var result = element1.Union(element2);
            Assert.AreEqual(result.Count, 1);
            Assert.AreEqual(result[0].LowerBound, lowerBound1 < lowerBound2 ? lowerBound1 : lowerBound2);
            Assert.AreEqual(result[0].UpperBound, upperBound1 > upperBound2 ? upperBound1 : upperBound2);
            Assert.AreEqual(result[0].IncludeLowerBound, lowerBound1 < lowerBound2 ? includeLowerBound1 : includeLowerBound2);
            Assert.AreEqual(result[0].IncludeUpperBound, upperBound1 > upperBound2 ? includeUpperBound1 : includeUpperBound2);
        }

        [TestMethod]
        [DataRow(2, 3, true, true)]
        [DataRow(2, 3, false, true)]
        [DataRow(2, 3, true, false)]
        [DataRow(2, 3, false, false)]
        [DataRow(2, 2, true, true)]
        public void TestWithEmptyUnion(double lowerBound, double upperBound, bool includeLowerBound, bool includeUpperBound)
        {
            var element = NumberSetElement<double>.Create(lowerBound, upperBound, includeLowerBound, includeUpperBound);
            var result1 = NumberSet<double>.Create(element).Union(NumberSetElement<double>.CreateEmpty());
            Assert.AreEqual(result1.Count, 1);
            Assert.AreEqual(result1[0].LowerBound, lowerBound);
            Assert.AreEqual(result1[0].UpperBound, upperBound);
            Assert.AreEqual(result1[0].IncludeLowerBound, includeLowerBound);
            Assert.AreEqual(result1[0].IncludeUpperBound, includeUpperBound);
            var result2 = NumberSet<double>.CreateEmpty().Union(element);
            Assert.AreEqual(result2.Count, 1);
            Assert.AreEqual(result2[0].LowerBound, lowerBound);
            Assert.AreEqual(result2[0].UpperBound, upperBound);
            Assert.AreEqual(result2[0].IncludeLowerBound, includeLowerBound);
            Assert.AreEqual(result2[0].IncludeUpperBound, includeUpperBound);
        }

        [TestMethod]
        public void TestEmptyWithEmptyUnion()
        {
            var result = NumberSet<double>.CreateEmpty().Union(NumberSetElement<double>.CreateEmpty());
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
        public void TestUnionNumberSet2Elements(double lowerBound, double upperBound, bool includeLowerBound, bool includeUpperBound)
        {
            var element = NumberSetElement<double>.Create(lowerBound, upperBound, includeLowerBound, includeUpperBound);
            var numberSet = NumberSet<double>.Create(NumberSetElement<double>.Create(1, 4, false, false), NumberSetElement<double>.Create(7, 9, false, false));
            var result = numberSet.Union(element);
            Assert.AreEqual(result.Count, 3);
            bool equal1 = element.Equals(result[0]) || element.Equals(result[1]) || element.Equals(result[2]);
            bool equal2 = numberSet[0].Equals(result[0]) || numberSet[0].Equals(result[1]) || numberSet[0].Equals(result[2]);
            bool equal3 = numberSet[1].Equals(result[0]) || numberSet[1].Equals(result[1]) || numberSet[1].Equals(result[2]);

            Assert.IsTrue(equal1);
            Assert.IsTrue(equal2);
            Assert.IsTrue(equal3);
        }

        [TestMethod]
        [DataRow(3, 7, true, true)]
        [DataRow(3, 7, false, true)]
        [DataRow(3, 7, true, false)]
        [DataRow(3, 7, false, false)]
        [DataRow(4, 6, true, true)]
        [DataRow(4, 6, false, true)]
        [DataRow(4, 6, true, false)]
        [DataRow(4, 6, false, false)]
        public void TestUnionJoinNumberSet(double lowerBound, double upperBound, bool includeLowerBound, bool includeUpperBound)
        {
            var element = NumberSetElement<double>.Create(lowerBound, upperBound, includeLowerBound, includeUpperBound);
            var numberSet = NumberSet<double>.Create(NumberSetElement<double>.Create(1, 4, true, true), NumberSetElement<double>.Create(6, 9, true, true));
            var result = numberSet.Union(element);
            Assert.AreEqual(result.Count, 1);
            Assert.AreEqual(result[0].LowerBound, 1);
            Assert.AreEqual(result[0].UpperBound, 9);
            Assert.AreEqual(result[0].IncludeLowerBound, true);
            Assert.AreEqual(result[0].IncludeUpperBound, true);
        }

        [TestMethod]
        [DataRow(3, 5, true, true)]
        [DataRow(0, 3, false, true)]
        [DataRow(0, 5, true, false)]
        [DataRow(2, 3, false, false)]
        public void TestUnionJoinNumberSetLower(double lowerBound, double upperBound, bool includeLowerBound, bool includeUpperBound)
        {
            var element = NumberSetElement<double>.Create(lowerBound, upperBound, includeLowerBound, includeUpperBound);
            var numberSet = NumberSet<double>.Create(NumberSetElement<double>.Create(1, 4, true, true), NumberSetElement<double>.Create(6, 9, true, true));
            var result = numberSet.Union(element);
            Assert.AreEqual(result.Count, 2);

            Assert.AreEqual(result[0].LowerBound, lowerBound < numberSet[0].LowerBound ? lowerBound : numberSet[0].LowerBound);
            Assert.AreEqual(result[0].UpperBound, upperBound > numberSet[0].UpperBound ? upperBound : numberSet[0].UpperBound);
            Assert.AreEqual(result[0].IncludeLowerBound, lowerBound < numberSet[0].LowerBound ? includeLowerBound : numberSet[0].IncludeLowerBound);
            Assert.AreEqual(result[0].IncludeUpperBound, upperBound > numberSet[0].UpperBound ? includeUpperBound : numberSet[0].IncludeUpperBound);

            Assert.IsTrue(result[1].Equals(numberSet[1]));
        }

        [TestMethod]
        [DataRow(8, 10, true, true)]
        [DataRow(5, 8, false, true)]
        [DataRow(5, 10, true, false)]
        [DataRow(7, 8, false, false)]
        public void TestUnionJoinNumberSetUpper(double lowerBound, double upperBound, bool includeLowerBound, bool includeUpperBound)
        {
            var element = NumberSetElement<double>.Create(lowerBound, upperBound, includeLowerBound, includeUpperBound);
            var numberSet = NumberSet<double>.Create(NumberSetElement<double>.Create(1, 4, true, true), NumberSetElement<double>.Create(6, 9, true, true));
            var result = numberSet.Union(element);
            Assert.AreEqual(result.Count, 2);

            Assert.AreEqual(result[1].LowerBound, lowerBound < numberSet[1].LowerBound ? lowerBound : numberSet[1].LowerBound);
            Assert.AreEqual(result[1].UpperBound, upperBound > numberSet[1].UpperBound ? upperBound : numberSet[1].UpperBound);
            Assert.AreEqual(result[1].IncludeLowerBound, lowerBound < numberSet[1].LowerBound ? includeLowerBound : numberSet[1].IncludeLowerBound);
            Assert.AreEqual(result[1].IncludeUpperBound, upperBound > numberSet[1].UpperBound ? includeUpperBound : numberSet[1].IncludeUpperBound);

            Assert.IsTrue(result[0].Equals(numberSet[0]));
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
        [DataRow(1, 2, true, false, 2, 4, false, true)]
        [DataRow(3, 4, false, false, 1, 2, true, true)]
        [DataRow(2, 4, false, true, 1, 2, true, false)]
        [DataRow(2, 2, true, true, 3, 3, true, true)]
        [DataRow(0, 2, true, true, 3, 3, true, true)]
        [DataRow(2, 2, true, true, 3, 5, true, true)]
        public void TestDisjunktUnionNumberSet(double lowerBound1, double upperBound1, bool includeLowerBound1, bool includeUpperBound1, double lowerBound2, double upperBound2, bool includeLowerBound2, bool includeUpperBound2)
        {
            var element1 = NumberSet<double>.Create(NumberSetElement<double>.Create(lowerBound1, upperBound1, includeLowerBound1, includeUpperBound1));
            var element2 = NumberSet<double>.Create(NumberSetElement<double>.Create(lowerBound2, upperBound2, includeLowerBound2, includeUpperBound2));
            var result = element1.Union(element2);
            Assert.AreEqual(result.Count, 2);
            if (lowerBound1 < lowerBound2)
            {
                Assert.AreEqual(result[0].LowerBound, lowerBound1);
                Assert.AreEqual(result[0].UpperBound, upperBound1);
                Assert.AreEqual(result[0].IncludeLowerBound, includeLowerBound1);
                Assert.AreEqual(result[0].IncludeUpperBound, includeUpperBound1);
                Assert.AreEqual(result[1].LowerBound, lowerBound2);
                Assert.AreEqual(result[1].UpperBound, upperBound2);
                Assert.AreEqual(result[1].IncludeLowerBound, includeLowerBound2);
                Assert.AreEqual(result[1].IncludeUpperBound, includeUpperBound2);
            }
            else
            {
                Assert.AreEqual(result[0].LowerBound, lowerBound2);
                Assert.AreEqual(result[0].UpperBound, upperBound2);
                Assert.AreEqual(result[0].IncludeLowerBound, includeLowerBound2);
                Assert.AreEqual(result[0].IncludeUpperBound, includeUpperBound2);
                Assert.AreEqual(result[1].LowerBound, lowerBound1);
                Assert.AreEqual(result[1].UpperBound, upperBound1);
                Assert.AreEqual(result[1].IncludeLowerBound, includeLowerBound1);
                Assert.AreEqual(result[1].IncludeUpperBound, includeUpperBound1);
            }
        }

        [TestMethod]
        [DataRow(2, 3, true, true, 3, 4, true, true)]
        [DataRow(3, 4, true, true, 2, 3, true, true)]
        [DataRow(1, 4, true, false, 3, 5, false, true)]
        [DataRow(1, 6, false, true, 3, 4, true, true)]
        [DataRow(1, 2, false, false, 0, 4, true, true)]
        [DataRow(4, 7, true, true, 3, 5, true, true)]
        [DataRow(4, 4, true, true, 3, 5, false, true)]
        [DataRow(1, 4, true, false, 3, 3, true, true)]
        [DataRow(4, 4, true, true, 4, 4, true, true)]
        public void TestOverlapOrTouchUnionNumberSet(double lowerBound1, double upperBound1, bool includeLowerBound1, bool includeUpperBound1, double lowerBound2, double upperBound2, bool includeLowerBound2, bool includeUpperBound2)
        {
            var element1 = NumberSet<double>.Create(NumberSetElement<double>.Create(lowerBound1, upperBound1, includeLowerBound1, includeUpperBound1));
            var element2 = NumberSet<double>.Create(NumberSetElement<double>.Create(lowerBound2, upperBound2, includeLowerBound2, includeUpperBound2));
            var result = element1.Union(element2);
            Assert.AreEqual(result.Count, 1);
            Assert.AreEqual(result[0].LowerBound, lowerBound1 < lowerBound2 ? lowerBound1 : lowerBound2);
            Assert.AreEqual(result[0].UpperBound, upperBound1 > upperBound2 ? upperBound1 : upperBound2);
            Assert.AreEqual(result[0].IncludeLowerBound, lowerBound1 < lowerBound2 ? includeLowerBound1 : includeLowerBound2);
            Assert.AreEqual(result[0].IncludeUpperBound, upperBound1 > upperBound2 ? includeUpperBound1 : includeUpperBound2);
        }

        [TestMethod]
        [DataRow(2, 3, true, true)]
        [DataRow(2, 3, false, true)]
        [DataRow(2, 3, true, false)]
        [DataRow(2, 3, false, false)]
        [DataRow(2, 2, true, true)]
        public void TestWithEmptyUnionNumberSet(double lowerBound, double upperBound, bool includeLowerBound, bool includeUpperBound)
        {
            var element = NumberSetElement<double>.Create(lowerBound, upperBound, includeLowerBound, includeUpperBound);
            var result1 = NumberSet<double>.Create(element).Union(NumberSet<double>.CreateEmpty());
            Assert.AreEqual(result1.Count, 1);
            Assert.AreEqual(result1[0].LowerBound, lowerBound);
            Assert.AreEqual(result1[0].UpperBound, upperBound);
            Assert.AreEqual(result1[0].IncludeLowerBound, includeLowerBound);
            Assert.AreEqual(result1[0].IncludeUpperBound, includeUpperBound);
            var result2 = NumberSet<double>.CreateEmpty().Union(NumberSet<double>.Create(element));
            Assert.AreEqual(result2.Count, 1);
            Assert.AreEqual(result2[0].LowerBound, lowerBound);
            Assert.AreEqual(result2[0].UpperBound, upperBound);
            Assert.AreEqual(result2[0].IncludeLowerBound, includeLowerBound);
            Assert.AreEqual(result2[0].IncludeUpperBound, includeUpperBound);
        }

        [TestMethod]
        public void TestEmptyWithEmptyUnionNumberSet()
        {
            var result = NumberSet<double>.CreateEmpty().Union(NumberSet<double>.CreateEmpty());
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
        public void TestNumberSetUnionNumberSet2Elements(double lowerBound, double upperBound, bool includeLowerBound, bool includeUpperBound)
        {
            var element = NumberSet<double>.Create(NumberSetElement<double>.Create(lowerBound, upperBound, includeLowerBound, includeUpperBound));
            var numberSet = NumberSet<double>.Create(NumberSetElement<double>.Create(1, 4, false, false), NumberSetElement<double>.Create(7, 9, false, false));
            var result = element.Union(numberSet);
            Assert.AreEqual(result.Count, 3);
            bool equal1 = element[0].Equals(result[0]) || element[0].Equals(result[1]) || element[0].Equals(result[2]);
            bool equal2 = numberSet[0].Equals(result[0]) || numberSet[0].Equals(result[1]) || numberSet[0].Equals(result[2]);
            bool equal3 = numberSet[1].Equals(result[0]) || numberSet[1].Equals(result[1]) || numberSet[1].Equals(result[2]);

            Assert.IsTrue(equal1);
            Assert.IsTrue(equal2);
            Assert.IsTrue(equal3);

            var result2 = numberSet.Union(element);
            Assert.IsTrue(result.Equals(result2));
        }

        [TestMethod]
        [DataRow(3, 7, true, true)]
        [DataRow(3, 7, false, true)]
        [DataRow(3, 7, true, false)]
        [DataRow(3, 7, false, false)]
        [DataRow(4, 6, true, true)]
        [DataRow(4, 6, false, true)]
        [DataRow(4, 6, true, false)]
        [DataRow(4, 6, false, false)]
        public void TestNumberSetUnionJoinNumberSet(double lowerBound, double upperBound, bool includeLowerBound, bool includeUpperBound)
        {
            var element = NumberSet<double>.Create(NumberSetElement<double>.Create(lowerBound, upperBound, includeLowerBound, includeUpperBound));
            var numberSet = NumberSet<double>.Create(NumberSetElement<double>.Create(1, 4, true, true), NumberSetElement<double>.Create(6, 9, true, true));
            var result = element.Union(numberSet);
            Assert.AreEqual(result.Count, 1);
            Assert.AreEqual(result[0].LowerBound, 1);
            Assert.AreEqual(result[0].UpperBound, 9);
            Assert.AreEqual(result[0].IncludeLowerBound, true);
            Assert.AreEqual(result[0].IncludeUpperBound, true);

            var result2 = numberSet.Union(element);
            Assert.IsTrue(result.Equals(result2));
        }

        [TestMethod]
        [DataRow(3, 5, true, true)]
        [DataRow(0, 3, false, true)]
        [DataRow(0, 5, true, false)]
        [DataRow(2, 3, false, false)]
        public void TestNumberSetUnionJoinNumberSetLower(double lowerBound, double upperBound, bool includeLowerBound, bool includeUpperBound)
        {
            var element = NumberSet<double>.Create(NumberSetElement<double>.Create(lowerBound, upperBound, includeLowerBound, includeUpperBound));
            var numberSet = NumberSet<double>.Create(NumberSetElement<double>.Create(1, 4, true, true), NumberSetElement<double>.Create(6, 9, true, true));
            var result = element.Union(numberSet);
            Assert.AreEqual(result.Count, 2);

            Assert.AreEqual(result[0].LowerBound, lowerBound < numberSet[0].LowerBound ? lowerBound : numberSet[0].LowerBound);
            Assert.AreEqual(result[0].UpperBound, upperBound > numberSet[0].UpperBound ? upperBound : numberSet[0].UpperBound);
            Assert.AreEqual(result[0].IncludeLowerBound, lowerBound < numberSet[0].LowerBound ? includeLowerBound : numberSet[0].IncludeLowerBound);
            Assert.AreEqual(result[0].IncludeUpperBound, upperBound > numberSet[0].UpperBound ? includeUpperBound : numberSet[0].IncludeUpperBound);

            Assert.IsTrue(result[1].Equals(numberSet[1]));

            var result2 = numberSet.Union(element);
            Assert.IsTrue(result.Equals(result2));
        }

        [TestMethod]
        [DataRow(8, 10, true, true)]
        [DataRow(5, 8, false, true)]
        [DataRow(5, 10, true, false)]
        [DataRow(7, 8, false, false)]
        public void TestNumberSetUnionJoinNumberSetUpper(double lowerBound, double upperBound, bool includeLowerBound, bool includeUpperBound)
        {
            var element = NumberSet<double>.Create(NumberSetElement<double>.Create(lowerBound, upperBound, includeLowerBound, includeUpperBound));
            var numberSet = NumberSet<double>.Create(NumberSetElement<double>.Create(1, 4, true, true), NumberSetElement<double>.Create(6, 9, true, true));
            var result = element.Union(numberSet);
            Assert.AreEqual(result.Count, 2);

            Assert.AreEqual(result[1].LowerBound, lowerBound < numberSet[1].LowerBound ? lowerBound : numberSet[1].LowerBound);
            Assert.AreEqual(result[1].UpperBound, upperBound > numberSet[1].UpperBound ? upperBound : numberSet[1].UpperBound);
            Assert.AreEqual(result[1].IncludeLowerBound, lowerBound < numberSet[1].LowerBound ? includeLowerBound : numberSet[1].IncludeLowerBound);
            Assert.AreEqual(result[1].IncludeUpperBound, upperBound > numberSet[1].UpperBound ? includeUpperBound : numberSet[1].IncludeUpperBound);

            Assert.IsTrue(result[0].Equals(numberSet[0]));

            var result2 = numberSet.Union(element);
            Assert.IsTrue(result.Equals(result2));
        }

        [TestMethod]
        public void TestNumberSetUnionNumberSet224()
        {
            var numberSet1 = NumberSet<double>.Create(NumberSetElement<double>.Create(1, 4, true, true), NumberSetElement<double>.Create(7, 9, true, true));
            var numberSet2 = NumberSet<double>.Create(NumberSetElement<double>.Create(5, 6, true, true), NumberSetElement<double>.Create(11, 12, true, true));
            var result = numberSet1.Union(numberSet2);
            Assert.AreEqual(result.Count, 4);
            Assert.IsTrue(result[0].Equals(numberSet1[0]));
            Assert.IsTrue(result[1].Equals(numberSet2[0]));
            Assert.IsTrue(result[2].Equals(numberSet1[1]));
            Assert.IsTrue(result[3].Equals(numberSet2[1]));

            var result2 = numberSet2.Union(numberSet1);
            Assert.IsTrue(result.Equals(result2));
        }

        [TestMethod]
        public void TestNumberSetUnionNumberSet223()
        {
            var numberSet1 = NumberSet<double>.Create(NumberSetElement<double>.Create(1, 4, true, true), NumberSetElement<double>.Create(7, 9, true, true));
            var numberSet2 = NumberSet<double>.Create(NumberSetElement<double>.Create(3, 6, true, true), NumberSetElement<double>.Create(11, 12, true, true));
            var result = numberSet1.Union(numberSet2);
            Assert.AreEqual(result.Count, 3);
            Assert.IsTrue(result[0].Equals(NumberSetElement<double>.Create(1, 6, true, true)));
            Assert.IsTrue(result[1].Equals(numberSet1[1]));
            Assert.IsTrue(result[2].Equals(numberSet2[1]));
            
            var result2 = numberSet2.Union(numberSet1);
            Assert.IsTrue(result.Equals(result2));
        }

        [TestMethod]
        public void TestNumberSetUnionNumberSet222()
        {
            var numberSet1 = NumberSet<double>.Create(NumberSetElement<double>.Create(1, 4, true, true), NumberSetElement<double>.Create(6, 9, true, true));
            var numberSet2 = NumberSet<double>.Create(NumberSetElement<double>.Create(3, 6, true, true), NumberSetElement<double>.Create(11, 12, true, true));
            var result = numberSet1.Union(numberSet2);
            Assert.AreEqual(result.Count, 2);
            Assert.IsTrue(result[0].Equals(NumberSetElement<double>.Create(1, 9, true, true)));
            Assert.IsTrue(result[1].Equals(numberSet2[1]));

            var result2 = numberSet2.Union(numberSet1);
            Assert.IsTrue(result.Equals(result2));
        }

        [TestMethod]
        public void TestNumberSetUnionNumberSet221()
        {
            var numberSet1 = NumberSet<double>.Create(NumberSetElement<double>.Create(1, 4, true, true), NumberSetElement<double>.Create(6, 9, true, true));
            var numberSet2 = NumberSet<double>.Create(NumberSetElement<double>.Create(3, 6, true, true), NumberSetElement<double>.Create(9, 12, false, true));
            var result = numberSet1.Union(numberSet2);
            Assert.AreEqual(result.Count, 1);
            Assert.IsTrue(result[0].Equals(NumberSetElement<double>.Create(1, 12, true, true)));
            
            var result2 = numberSet2.Union(numberSet1);
            Assert.IsTrue(result.Equals(result2));
        }

        [TestMethod]
        public void TestNumberSetUnionNumberSet234()
        {
            var numberSet1 = NumberSet<double>.Create(NumberSetElement<double>.Create(1, 2, true, true), NumberSetElement<double>.Create(6, 11, false, true));
            var numberSet2 = NumberSet<double>.Create(NumberSetElement<double>.Create(3, 4, true, true), NumberSetElement<double>.Create(5, 6, true, false), NumberSetElement<double>.Create(11, 12, true, true));
            var result = numberSet1.Union(numberSet2);
            Assert.AreEqual(result.Count, 4);
            Assert.IsTrue(result[0].Equals(numberSet1[0]));
            Assert.IsTrue(result[1].Equals(numberSet2[0]));
            Assert.IsTrue(result[2].Equals(numberSet2[1]));
            Assert.IsTrue(result[3].Equals(NumberSetElement<double>.Create(6, 12, false, true)));

            var result2 = numberSet2.Union(numberSet1);
            Assert.IsTrue(result.Equals(result2));
        }
    }
}
