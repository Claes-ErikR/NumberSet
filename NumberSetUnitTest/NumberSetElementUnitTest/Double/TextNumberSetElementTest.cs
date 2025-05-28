using NumberSetUnitTest.Helpers;
using System.Globalization;
using Utte.NumberSet;

namespace NumberSetUnitTest.NumberSetElementUnitTest.Double
{
    [TestClass]
    public class TextNumberSetElementTest
    {
        [TestMethod]
        [DataRow(2, 3, true, true, "[2, 3]")]
        [DataRow(2, 3, true, false, "[2, 3)")]
        [DataRow(2, 3, false, true, "(2, 3]")]
        [DataRow(2, 3, false, false, "(2, 3)")]
        [DataRow(0.1, 1, true, true, "[0.1, 1]")]
        [DataRow(0, 1.1, true, true, "[0, 1.1]")]
        [DataRow(0.1, 1.1, true, true, "[0.1, 1.1]")]
        public void TestToString(double lowerBound, double upperBound, bool includeLowerBound, bool includeUpperBound, string expectedResult)
        {
            var currentCulture = CultureInfo.CurrentCulture;
            try
            {
                CultureInfo.CurrentCulture = CultureInfo.InvariantCulture; // Use '.' as decimal separator
                var item = (NumberSetElement<double>)NumberSetElement<double>.Create(lowerBound, upperBound, includeLowerBound, includeUpperBound);
                Assert.AreEqual(item.ToString(), expectedResult);
                Assert.AreEqual(item.ToString(null, CultureInfo.InvariantCulture), expectedResult);
            }
            finally
            {
                CultureInfo.CurrentCulture = currentCulture;
            }
        }

        [TestMethod]
        [DataRow(2, 3, true, true, "[2; 3]")]
        [DataRow(2, 3, true, false, "[2; 3)")]
        [DataRow(2, 3, false, true, "(2; 3]")]
        [DataRow(2, 3, false, false, "(2; 3)")]
        [DataRow(0.1, 1, true, true, "[0,1; 1]")]
        [DataRow(0, 1.1, true, true, "[0; 1,1]")]
        [DataRow(0.1, 1.1, true, true, "[0,1; 1,1]")]
        public void TestToStringDecimalSeparatorComma(double lowerBound, double upperBound, bool includeLowerBound, bool includeUpperBound, string expectedResult)
        {
            var currentCulture = CultureInfo.CurrentCulture;
            try
            {
                var culture = CultureInfoTestHelper.GetNumberCommaSeparatedCulture(); // Use ',' as decimal separator
                CultureInfo.CurrentCulture = culture;
                var item = (NumberSetElement<double>)NumberSetElement<double>.Create(lowerBound, upperBound, includeLowerBound, includeUpperBound);
                Assert.AreEqual(item.ToString(), expectedResult);
                Assert.AreEqual(item.ToString(null, culture), expectedResult);
            }
            finally
            {
                CultureInfo.CurrentCulture = currentCulture;
            }
        }

        [TestMethod]
        public void TestEmptyToString()
        {
            var item = NumberSetElement<double>.Empty;
            Assert.AreEqual(item.ToString(), "Empty");
        }

        [TestMethod]
        public void TestTryParse()
        {
            var elementList = new List<Tuple<INumberSetElement<double>, string>>()
            {
                new Tuple<INumberSetElement<double>, string>(NumberSetElement<double>.Create(2, 3, true, true), "[2, 3]"),
                new Tuple<INumberSetElement<double>, string>(NumberSetElement<double>.Create(2, 3, true, false), "[2, 3)"),
                new Tuple<INumberSetElement<double>, string>(NumberSetElement<double>.Create(2, 3, false, true), "(2, 3]"),
                new Tuple<INumberSetElement<double>, string>(NumberSetElement<double>.Create(2, 3, false, false), "(2, 3)"),
                new Tuple<INumberSetElement<double>, string>(NumberSetElement<double>.Create(2, 3, true, true), "[2,3]"),
                new Tuple<INumberSetElement<double>, string>(NumberSetElement<double>.Create(2, 3, true, false), "[2,3)"),
                new Tuple<INumberSetElement<double>, string>(NumberSetElement<double>.Create(2, 3, false, true), "(2,3]"),
                new Tuple<INumberSetElement<double>, string>(NumberSetElement<double>.Create(2, 3, false, false), "(2,3)"),
                new Tuple<INumberSetElement<double>, string>(NumberSetElement<double>.Empty, "Empty"),
                new Tuple<INumberSetElement<double>, string>(NumberSetElement<double>.Empty, "(2, 2)"),
                new Tuple<INumberSetElement<double>, string>(NumberSetElement<double>.Create(2, 3, true, true), " [2, 3]"),
                new Tuple<INumberSetElement<double>, string>(NumberSetElement<double>.Create(2, 3, true, true), "[2, 3] "),
                new Tuple<INumberSetElement<double>, string>(NumberSetElement<double>.Create(2, 3, true, true), "[2 , 3]"),
                new Tuple<INumberSetElement<double>, string>(NumberSetElement<double>.Create(2, 3, true, true), "[ 2, 3]"),
                new Tuple<INumberSetElement<double>, string>(NumberSetElement<double>.Create(2, 3, true, true), "[2, 3 ]"),
                new Tuple<INumberSetElement<double>, string>(NumberSetElement<double>.Create(2, 2, true, true), "[2, 2]"),
                new Tuple<INumberSetElement<double>, string>(NumberSetElement<double>.Create(2.13, 3.14, true, true), "[2.13, 3.14]"),
                new Tuple<INumberSetElement<double>, string>(NumberSetElement<double>.Empty, "(2, 2]"),
                new Tuple<INumberSetElement<double>, string>(NumberSetElement<double>.Empty, "[2, 2)"),
                new Tuple<INumberSetElement<double>, string>(NumberSetElement<double>.Empty, "(2, 2)"),
                new Tuple<INumberSetElement<double>, string>(NumberSetElement<double>.Empty, "[2, 1]"),
                new Tuple<INumberSetElement<double>, string>(NumberSetElement<double>.Empty, "(2, 2]"),
                new Tuple<INumberSetElement<double>, string>(NumberSetElement<double>.Empty, "(2, 2]"),
                new Tuple<INumberSetElement<double>, string>(NumberSetElement<double>.Empty, "(2, 2]"),
                new Tuple<INumberSetElement<double>, string>(NumberSetElement<double>.Empty, "(2, 2]"),

            };

            var currentCulture = CultureInfo.CurrentCulture;
            try
            {
                CultureInfo.CurrentCulture = CultureInfo.InvariantCulture; // Use '.' as decimal separator
                for (int i = 0; i < elementList.Count; i++)
                {
                    if (NumberSetElement<double>.TryParse(elementList[i].Item2, null, out NumberSetElement<double>? cultureNullResult))
                        Assert.IsTrue(elementList[i].Item1.Equals(cultureNullResult));
                    else
                        Assert.Fail();
                    if (NumberSetElement<double>.TryParse(elementList[i].Item2, out NumberSetElement<double>? result))
                        Assert.IsTrue(elementList[i].Item1.Equals(result));
                    else
                        Assert.Fail();
                }
            }
            finally
            {
                CultureInfo.CurrentCulture = currentCulture;
            }
        }

        [TestMethod]
        public void TestFailTryParse()
        {
            var elementList = new List<string?>()
            {
                "2, 2",
                "2, 2]",
                "2, 2]",
                "[, 2]",
                "[2, ]",
                "[2 2]",
                "[2, 2] banan",
                "banan [2, 2]",
                "banan [2, 2] banan",
                "[2, 2]banan",
                "banan[2, 2]",
                "banan[2, 2]banan",
                "[2,, 2]",
                "[[2, 2]",
                "[2, 2]]",
                "((2, 2]",
                "[2, 2))",
                null,
            };
            var currentCulture = CultureInfo.CurrentCulture;
            try
            {
                CultureInfo.CurrentCulture = CultureInfo.InvariantCulture; // Use '.' as decimal separator
                for (int i = 0; i < elementList.Count; i++)
                {
                    if (NumberSetElement<double>.TryParse(elementList[i], null, out NumberSetElement<double>? cultureNullResult))
                        Assert.Fail();
                    if (NumberSetElement<double>.TryParse(elementList[i], out NumberSetElement<double>? result))
                        Assert.Fail();
                }
            }
            finally
            {
                CultureInfo.CurrentCulture = currentCulture;
            }
        }

        [TestMethod]
        public void TestTryParseNumberDecimalSeparatorComma()
        {
            var elementList = new List<Tuple<INumberSetElement<double>, string>>()
            {
                new Tuple<INumberSetElement<double>, string>(NumberSetElement<double>.Create(2, 3, true, true), "[2; 3]"),
                new Tuple<INumberSetElement<double>, string>(NumberSetElement<double>.Create(2, 3, true, false), "[2; 3)"),
                new Tuple<INumberSetElement<double>, string>(NumberSetElement<double>.Create(2, 3, false, true), "(2; 3]"),
                new Tuple<INumberSetElement<double>, string>(NumberSetElement<double>.Create(2, 3, false, false), "(2; 3)"),
                new Tuple<INumberSetElement<double>, string>(NumberSetElement<double>.Create(2, 3, true, true), "[2;3]"),
                new Tuple<INumberSetElement<double>, string>(NumberSetElement<double>.Create(2, 3, true, false), "[2;3)"),
                new Tuple<INumberSetElement<double>, string>(NumberSetElement<double>.Create(2, 3, false, true), "(2;3]"),
                new Tuple<INumberSetElement<double>, string>(NumberSetElement<double>.Create(2, 3, false, false), "(2;3)"),
                new Tuple<INumberSetElement<double>, string>(NumberSetElement<double>.Empty, "Empty"),
                new Tuple<INumberSetElement<double>, string>(NumberSetElement<double>.Empty, "(2; 2)"),
                new Tuple<INumberSetElement<double>, string>(NumberSetElement<double>.Create(2, 3, true, true), " [2; 3]"),
                new Tuple<INumberSetElement<double>, string>(NumberSetElement<double>.Create(2, 3, true, true), "[2; 3] "),
                new Tuple<INumberSetElement<double>, string>(NumberSetElement<double>.Create(2, 3, true, true), "[2 ; 3]"),
                new Tuple<INumberSetElement<double>, string>(NumberSetElement<double>.Create(2, 3, true, true), "[ 2; 3]"),
                new Tuple<INumberSetElement<double>, string>(NumberSetElement<double>.Create(2, 3, true, true), "[2; 3 ]"),
                new Tuple<INumberSetElement<double>, string>(NumberSetElement<double>.Create(2, 2, true, true), "[2; 2]"),
                new Tuple<INumberSetElement<double>, string>(NumberSetElement<double>.Create(2.13, 3.14, true, true), "[2,13; 3,14]"),
                new Tuple<INumberSetElement<double>, string>(NumberSetElement<double>.Create(2, 3.14, true, true), "[2; 3,14]"),
                new Tuple<INumberSetElement<double>, string>(NumberSetElement<double>.Create(2.13, 3, true, true), "[2,13; 3]"),
                new Tuple<INumberSetElement<double>, string>(NumberSetElement<double>.Empty, "(2; 2]"),
                new Tuple<INumberSetElement<double>, string>(NumberSetElement<double>.Empty, "[2; 2)"),
                new Tuple<INumberSetElement<double>, string>(NumberSetElement<double>.Empty, "(2; 2)"),
                new Tuple<INumberSetElement<double>, string>(NumberSetElement<double>.Empty, "[2; 1]"),
                new Tuple<INumberSetElement<double>, string>(NumberSetElement<double>.Empty, "(2; 2]"),
                new Tuple<INumberSetElement<double>, string>(NumberSetElement<double>.Empty, "(2; 2]"),
                new Tuple<INumberSetElement<double>, string>(NumberSetElement<double>.Empty, "(2; 2]"),
                new Tuple<INumberSetElement<double>, string>(NumberSetElement<double>.Empty, "(2; 2]"),
            };

            var currentCulture = CultureInfo.CurrentCulture;
            try
            {
                var culture = CultureInfoTestHelper.GetNumberCommaSeparatedCulture(); // Use ',' as decimal separator
                CultureInfo.CurrentCulture = culture;

                for (int i = 0; i < elementList.Count; i++)
                {
                    if (NumberSetElement<double>.TryParse(elementList[i].Item2, culture, out NumberSetElement<double>? cultureNullResult))
                        Assert.IsTrue(elementList[i].Item1.Equals(cultureNullResult));
                    else
                        Assert.Fail();
                    if (NumberSetElement<double>.TryParse(elementList[i].Item2, out NumberSetElement<double>? result))
                        Assert.IsTrue(elementList[i].Item1.Equals(result));
                    else
                        Assert.Fail();
                }
            }
            finally
            {
                CultureInfo.CurrentCulture = currentCulture;
            }
        }

        [TestMethod]
        public void TestFailTryParseNumberDecimalSeparatorComma()
        {
            var elementList = new List<string?>()
            {
                "2; 2",
                "2; 2]",
                "2; 2]",
                "[; 2]",
                "[2; ]",
                "[2 2]",
                "[2; 2] banan",
                "banan [2; 2]",
                "banan [2; 2] banan",
                "[2; 2]banan",
                "banan[2; 2]",
                "banan[2; 2]banan",
                "[2;; 2]",
                "[[2; 2]",
                "[2; 2]]",
                "((2; 2]",
                "[2; 2))",
                null,
            };
            var currentCulture = CultureInfo.CurrentCulture;
            try
            {
                var culture = CultureInfoTestHelper.GetNumberCommaSeparatedCulture(); // Use ',' as decimal separator
                CultureInfo.CurrentCulture = culture;

                for (int i = 0; i < elementList.Count; i++)
                {
                    if (NumberSetElement<double>.TryParse(elementList[i], culture, out NumberSetElement<double>? cultureNullResult))
                        Assert.Fail();
                    if (NumberSetElement<double>.TryParse(elementList[i], out NumberSetElement<double>? result))
                        Assert.Fail();
                }
            }
            finally
            {
                CultureInfo.CurrentCulture = currentCulture;
            }
        }
    }
}
