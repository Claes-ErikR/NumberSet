using NumberSetUnitTest.Helpers;
using System.Globalization;
using Utte.NumberSet;

namespace NumberSetUnitTest.NumberSetUnitTest.Double
{
    [TestClass]
    public class TextNumberSetTest
    {
        [TestMethod]
        [DataRow(true, true, "[2, 3]")]
        [DataRow(true, false, "[2, 3)")]
        [DataRow(false, true, "(2, 3]")]
        [DataRow(false, false, "(2, 3)")]
        public void TestToString(bool includeLowerBound, bool includeUpperBound, string expectedResult)
        {
            var currentCulture = CultureInfo.CurrentCulture;
            try
            {
                CultureInfo.CurrentCulture = CultureInfo.InvariantCulture; // Use '.' as decimal separator

                var item = (NumberSet<double>)NumberSet<double>.Create(NumberSetElement<double>.Create(2, 3, includeLowerBound, includeUpperBound));
                Assert.AreEqual(item.ToString(), expectedResult);
                Assert.AreEqual(item.ToString(null, CultureInfo.InvariantCulture), expectedResult);
            }
            finally
            {
                CultureInfo.CurrentCulture = currentCulture;
            }
        }

        [TestMethod]
        public void TestEmptyToString()
        {
            var currentCulture = CultureInfo.CurrentCulture;
            try
            {
                CultureInfo.CurrentCulture = CultureInfo.InvariantCulture; // Use '.' as decimal separator

                var item = (NumberSet<double>)NumberSet<double>.Empty;
                Assert.AreEqual(item.ToString(), "Empty");
                Assert.AreEqual(item.ToString(null, CultureInfo.InvariantCulture), "Empty");
            }
            finally
            {
                CultureInfo.CurrentCulture = currentCulture;
            }
        }

        [TestMethod]
        public void Test2ElementToString()
        {
            var currentCulture = CultureInfo.CurrentCulture;
            try
            {
                CultureInfo.CurrentCulture = CultureInfo.InvariantCulture; // Use '.' as decimal separator
                var item = (NumberSet<double>)NumberSet<double>.Create(NumberSetElement<double>.Create(2, 3, false, true), NumberSetElement<double>.Create(4, 5, true, false));
                Assert.AreEqual(item.ToString(), "(2, 3]; [4, 5)");
                Assert.AreEqual(item.ToString(null, CultureInfo.InvariantCulture), "(2, 3]; [4, 5)");
            }
            finally
            {
                CultureInfo.CurrentCulture = currentCulture;
            }
        }

        [TestMethod]
        public void Test3ElementToString()
        {
            var currentCulture = CultureInfo.CurrentCulture;
            try
            {
                CultureInfo.CurrentCulture = CultureInfo.InvariantCulture; // Use '.' as decimal separator

                var item = (NumberSet<double>)NumberSet<double>.Create(NumberSetElement<double>.Create(2, 3, false, true), NumberSetElement<double>.Create(4, 5, true, false), NumberSetElement<double>.Create(5, 6, false, false));
                Assert.AreEqual(item.ToString(), "(2, 3]; [4, 5); (5, 6)");
                Assert.AreEqual(item.ToString(null, CultureInfo.InvariantCulture), "(2, 3]; [4, 5); (5, 6)");
            }
            finally
            {
                CultureInfo.CurrentCulture = currentCulture;
            }
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
                    if (NumberSet<double>.TryParse(elementList[i].Item2, out NumberSet<double>? cultureNullResult))
                        Assert.IsTrue(NumberSet<double>.Create(new List<INumberSetElement<double>>() { elementList[i].Item1 }).Equals(cultureNullResult));
                    else
                        Assert.Fail();
                    if (NumberSet<double>.TryParse(elementList[i].Item2, null, out NumberSet<double>? result))
                        Assert.IsTrue(NumberSet<double>.Create(new List<INumberSetElement<double>>() { elementList[i].Item1 }).Equals(result));
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
        public void TestTryParseMoreElements()
        {
            var elementList = new List<Tuple<INumberSet<double>, string>>()
            {
                new Tuple<INumberSet<double>, string>(NumberSet<double>.Create(new List<INumberSetElement<double>>() { NumberSetElement<double>.Create(2, 3, true, true), NumberSetElement<double>.Create(4, 5, true, true) }), "[2, 3]; [4, 5]"),
                new Tuple<INumberSet<double>, string>(NumberSet<double>.Create(new List<INumberSetElement<double>>() { NumberSetElement<double>.Create(2, 3, true, true), NumberSetElement<double>.Create(4, 5, true, true) }), " [2, 3]; [4, 5]"),
                new Tuple<INumberSet<double>, string>(NumberSet<double>.Create(new List<INumberSetElement<double>>() { NumberSetElement<double>.Create(2, 3, true, true), NumberSetElement<double>.Create(4, 5, true, true) }), "[2, 3]; [4, 5] "),
                new Tuple<INumberSet<double>, string>(NumberSet<double>.Create(new List<INumberSetElement<double>>() { NumberSetElement<double>.Create(2, 3, true, true), NumberSetElement<double>.Create(4, 5, true, true) }), "[2, 3] ; [4, 5]"),
                new Tuple<INumberSet<double>, string>(NumberSet<double>.Create(new List<INumberSetElement<double>>() { NumberSetElement<double>.Create(2, 3, true, true), NumberSetElement<double>.Create(4, 5, true, true) }), "[2, 3];  [4, 5]"),
                new Tuple<INumberSet<double>, string>(NumberSet<double>.Create(new List<INumberSetElement<double>>() { NumberSetElement<double>.Create(2, 3, true, true), NumberSetElement<double>.Create(4, 5, true, true) }), "[2, 3];[4, 5]"),
                new Tuple<INumberSet<double>, string>(NumberSet<double>.Create(new List<INumberSetElement<double>>() { NumberSetElement<double>.Create(2, 3, true, true), NumberSetElement<double>.Create(4, 5, true, true), NumberSetElement<double>.Create(6, 7, false, true) }), "[2, 3]; [4, 5]; (6, 7]"),
                new Tuple<INumberSet<double>, string>(NumberSet<double>.Create(new List<INumberSetElement<double>>() { NumberSetElement<double>.Create(2, 3, true, false), NumberSetElement<double>.Create(3, 6, false, false), NumberSetElement<double>.Create(6, 7, false, true) }), "[2, 3); (3, 6); (6, 7]"),
                new Tuple<INumberSet<double>, string>(NumberSet<double>.Create(new List<INumberSetElement<double>>() { NumberSetElement<double>.Create(2, 3, true, true), NumberSetElement<double>.Create(4, 5, true, true) }), "[2, 3]; [4, 5]; (8, 8)"),
                new Tuple<INumberSet<double>, string>(NumberSet<double>.Create(new List<INumberSetElement<double>>() { NumberSetElement<double>.Create(2, 3, true, true), NumberSetElement<double>.Create(4, 5, true, true) }), "(1, 1); [2, 3]; [4, 5]"),
                new Tuple<INumberSet<double>, string>(NumberSet<double>.Create(new List<INumberSetElement<double>>() { NumberSetElement<double>.Create(2.1, 3, true, true), NumberSetElement<double>.Create(4, 5, true, true) }), "[2.1, 3]; [4, 5]"),
            };
            var currentCulture = CultureInfo.CurrentCulture;
            try
            {
                CultureInfo.CurrentCulture = CultureInfo.InvariantCulture; // Use '.' as decimal separator
                for (int i = 0; i < elementList.Count; i++)
                {
                    if (NumberSet<double>.TryParse(elementList[i].Item2, out NumberSet<double>? cultureNullResult))
                        Assert.IsTrue(elementList[i].Item1.Equals(cultureNullResult));
                    else
                        Assert.Fail();
                    if (NumberSet<double>.TryParse(elementList[i].Item2, null, out NumberSet<double>? result))
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
                "[2, 3];; [4, 5]",
                "[2, 3]; ; [4, 5]",
                "[2, 3];3, 4; [4, 5]",
                "[2, 3]b; [4, 5]",
                "[2, 3];b [4, 5]",
                "[2,1; 3]; [4; 5]",
                null,
            };
            var currentCulture = CultureInfo.CurrentCulture;
            try
            {
                CultureInfo.CurrentCulture = CultureInfo.InvariantCulture; // Use '.' as decimal separator
                for (int i = 0; i < elementList.Count; i++)
                {
                    if (NumberSet<double>.TryParse(elementList[i], out NumberSet<double>? cultureNullResult))
                        Assert.Fail();
                    if (NumberSet<double>.TryParse(elementList[i], null, out NumberSet<double>? result))
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
                    if (NumberSet<double>.TryParse(elementList[i].Item2, out NumberSet<double>? cultureNullResult))
                        Assert.IsTrue(NumberSet<double>.Create(new List<INumberSetElement<double>>() { elementList[i].Item1 }).Equals(cultureNullResult));
                    else
                        Assert.Fail();
                    if (NumberSet<double>.TryParse(elementList[i].Item2, culture, out NumberSet<double>? result))
                        Assert.IsTrue(NumberSet<double>.Create(new List<INumberSetElement<double>>() { elementList[i].Item1 }).Equals(result));
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
        public void TestTryParseMoreElementsNumberDecimalSeparatorComma()
        {
            var elementList = new List<Tuple<INumberSet<double>, string>>()
            {
                new Tuple<INumberSet<double>, string>(NumberSet<double>.Create(new List<INumberSetElement<double>>() { NumberSetElement<double>.Create(2, 3, true, true), NumberSetElement<double>.Create(4, 5, true, true) }), "[2; 3]; [4; 5]"),
                new Tuple<INumberSet<double>, string>(NumberSet<double>.Create(new List<INumberSetElement<double>>() { NumberSetElement<double>.Create(2, 3, true, true), NumberSetElement<double>.Create(4, 5, true, true) }), " [2; 3]; [4; 5]"),
                new Tuple<INumberSet<double>, string>(NumberSet<double>.Create(new List<INumberSetElement<double>>() { NumberSetElement<double>.Create(2, 3, true, true), NumberSetElement<double>.Create(4, 5, true, true) }), "[2; 3]; [4; 5] "),
                new Tuple<INumberSet<double>, string>(NumberSet<double>.Create(new List<INumberSetElement<double>>() { NumberSetElement<double>.Create(2, 3, true, true), NumberSetElement<double>.Create(4, 5, true, true) }), "[2; 3] ; [4; 5]"),
                new Tuple<INumberSet<double>, string>(NumberSet<double>.Create(new List<INumberSetElement<double>>() { NumberSetElement<double>.Create(2, 3, true, true), NumberSetElement<double>.Create(4, 5, true, true) }), "[2; 3];  [4; 5]"),
                new Tuple<INumberSet<double>, string>(NumberSet<double>.Create(new List<INumberSetElement<double>>() { NumberSetElement<double>.Create(2, 3, true, true), NumberSetElement<double>.Create(4, 5, true, true) }), "[2; 3];[4; 5]"),
                new Tuple<INumberSet<double>, string>(NumberSet<double>.Create(new List<INumberSetElement<double>>() { NumberSetElement<double>.Create(2, 3, true, true), NumberSetElement<double>.Create(4, 5, true, true), NumberSetElement<double>.Create(6, 7, false, true) }), "[2; 3]; [4; 5]; (6; 7]"),
                new Tuple<INumberSet<double>, string>(NumberSet<double>.Create(new List<INumberSetElement<double>>() { NumberSetElement<double>.Create(2, 3, true, false), NumberSetElement<double>.Create(3, 6, false, false), NumberSetElement<double>.Create(6, 7, false, true) }), "[2; 3); (3; 6); (6; 7]"),
                new Tuple<INumberSet<double>, string>(NumberSet<double>.Create(new List<INumberSetElement<double>>() { NumberSetElement<double>.Create(2, 3, true, true), NumberSetElement<double>.Create(4, 5, true, true) }), "[2; 3]; [4; 5]; (8; 8)"),
                new Tuple<INumberSet<double>, string>(NumberSet<double>.Create(new List<INumberSetElement<double>>() { NumberSetElement<double>.Create(2, 3, true, true), NumberSetElement<double>.Create(4, 5, true, true) }), "(1; 1); [2; 3]; [4; 5]"),
                new Tuple<INumberSet<double>, string>(NumberSet<double>.Create(new List<INumberSetElement<double>>() { NumberSetElement<double>.Create(2.1, 3, true, true), NumberSetElement<double>.Create(4, 5, true, true) }), "[2,1; 3]; [4; 5]"),
            };
            var currentCulture = CultureInfo.CurrentCulture;
            try
            {
                var culture = CultureInfoTestHelper.GetNumberCommaSeparatedCulture(); // Use ',' as decimal separator
                CultureInfo.CurrentCulture = culture;
                for (int i = 0; i < elementList.Count; i++)
                {
                    if (NumberSet<double>.TryParse(elementList[i].Item2, out NumberSet<double>? cultureNullResult))
                        Assert.IsTrue(elementList[i].Item1.Equals(cultureNullResult));
                    else
                        Assert.Fail();
                    if (NumberSet<double>.TryParse(elementList[i].Item2, culture, out NumberSet<double>? result))
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
                "[2; 3];; [4; 5]",
                "[2; 3]; ; [4; 5]",
                "[2; 3];3, 4; [4; 5]",
                "[2; 3]b; [4; 5]",
                "[2; 3];b [4; 5]",
                "[2.1; 3]; [4; 5]",
                null,
            };
            var currentCulture = CultureInfo.CurrentCulture;
            try
            {
                var culture = CultureInfoTestHelper.GetNumberCommaSeparatedCulture(); // Use ',' as decimal separator
                CultureInfo.CurrentCulture = culture;
                for (int i = 0; i < elementList.Count; i++)
                {
                    if (NumberSet<double>.TryParse(elementList[i], out NumberSet<double>? cultureNullResult))
                        Assert.Fail();
                    if (NumberSet<double>.TryParse(elementList[i], culture, out NumberSet<double>? result))
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
