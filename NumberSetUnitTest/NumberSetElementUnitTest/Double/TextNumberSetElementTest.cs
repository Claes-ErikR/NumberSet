using System.Globalization;
using Utte.NumberSet;

namespace NumberSetUnitTest.NumberSetElementUnitTest.Double
{
    [TestClass]
    public class TextNumberSetElementTest
    {
        [TestMethod]
        [DataRow(true, true, "[2, 3]")]
        [DataRow(true, false, "[2, 3)")]
        [DataRow(false, true, "(2, 3]")]
        [DataRow(false, false, "(2, 3)")]
        public void TestToString(bool includeLowerBound, bool includeUpperBound, string expectedResult)
        {
            var item = NumberSetElement<double>.Create(2, 3, includeLowerBound, includeUpperBound);
            Assert.AreEqual(item.ToString(), expectedResult);
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
                    if (NumberSetElement<double>.TryParse(elementList[i].Item2, null, out NumberSetElement<double> cultureNullResult))
                        Assert.IsTrue(elementList[i].Item1.Equals(cultureNullResult));
                    else
                        Assert.Fail();
                    if (NumberSetElement<double>.TryParse(elementList[i].Item2, out NumberSetElement<double> result))
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
            var elementList = new List<string>()
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
            };
            var currentCulture = CultureInfo.CurrentCulture;
            try
            {
                CultureInfo.CurrentCulture = CultureInfo.InvariantCulture; // Use '.' as decimal separator
                for (int i = 0; i < elementList.Count; i++)
                {
                    if (NumberSetElement<double>.TryParse(elementList[i], null, out NumberSetElement<double> cultureNullResult))
                        Assert.Fail();
                    if (NumberSetElement<double>.TryParse(elementList[i], out NumberSetElement<double> result))
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
