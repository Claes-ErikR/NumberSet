using NumberSet;

namespace NumberSetUnitTest.NumberSetElementUnitTest.Double
{
    [TestClass]
    public class TextNumberSetElementTest
    {
        [TestMethod]
        public void TestToString()
        {
            var elementList = new List<Tuple<NumberSetElement<double>, string>>()
            {
                new Tuple<NumberSetElement<double>, string>(NumberSetElement<double>.Create(2, 3, true, true), "[2, 3]"),
                new Tuple<NumberSetElement<double>, string>(NumberSetElement<double>.Create(2, 3, true, false), "[2, 3)"),
                new Tuple<NumberSetElement<double>, string>(NumberSetElement<double>.Create(2, 3, false, true), "(2, 3]"),
                new Tuple<NumberSetElement<double>, string>(NumberSetElement<double>.Create(2, 3, false, false), "(2, 3)"),
                new Tuple<NumberSetElement<double>, string>(NumberSetElement<double>.CreateEmpty(), "Empty"),
            };
            for (int i = 0; i < elementList.Count; i++)
            {
                Assert.AreEqual(elementList[i].Item1.ToString(), elementList[i].Item2);
            }
        }

        [TestMethod]
        public void TestTryParse()
        {
            var elementList = new List<Tuple<NumberSetElement<double>, string>>()
            {
                new Tuple<NumberSetElement<double>, string>(NumberSetElement<double>.Create(2, 3, true, true), "[2, 3]"),
                new Tuple<NumberSetElement<double>, string>(NumberSetElement<double>.Create(2, 3, true, false), "[2, 3)"),
                new Tuple<NumberSetElement<double>, string>(NumberSetElement<double>.Create(2, 3, false, true), "(2, 3]"),
                new Tuple<NumberSetElement<double>, string>(NumberSetElement<double>.Create(2, 3, false, false), "(2, 3)"),
                new Tuple<NumberSetElement<double>, string>(NumberSetElement<double>.Create(2, 3, true, true), "[2,3]"),
                new Tuple<NumberSetElement<double>, string>(NumberSetElement<double>.Create(2, 3, true, false), "[2,3)"),
                new Tuple<NumberSetElement<double>, string>(NumberSetElement<double>.Create(2, 3, false, true), "(2,3]"),
                new Tuple<NumberSetElement<double>, string>(NumberSetElement<double>.Create(2, 3, false, false), "(2,3)"),
                new Tuple<NumberSetElement<double>, string>(NumberSetElement<double>.CreateEmpty(), "Empty"),
                new Tuple<NumberSetElement<double>, string>(NumberSetElement<double>.CreateEmpty(), "(2, 2)"),
                new Tuple<NumberSetElement<double>, string>(NumberSetElement<double>.Create(2, 3, true, true), " [2, 3]"),
                new Tuple<NumberSetElement<double>, string>(NumberSetElement<double>.Create(2, 3, true, true), "[2, 3] "),
                new Tuple<NumberSetElement<double>, string>(NumberSetElement<double>.Create(2, 3, true, true), "[2 , 3]"),
                new Tuple<NumberSetElement<double>, string>(NumberSetElement<double>.Create(2, 3, true, true), "[ 2, 3]"),
                new Tuple<NumberSetElement<double>, string>(NumberSetElement<double>.Create(2, 3, true, true), "[2, 3 ]"),
                new Tuple<NumberSetElement<double>, string>(NumberSetElement<double>.Create(2, 2, true, true), "[2, 2]"),
                new Tuple<NumberSetElement<double>, string>(NumberSetElement<double>.Create(2.13, 3.14, true, true), "[2.13, 3.14]"),
                new Tuple<NumberSetElement<double>, string>(NumberSetElement<double>.CreateEmpty(), "(2, 2]"),
                new Tuple<NumberSetElement<double>, string>(NumberSetElement<double>.CreateEmpty(), "[2, 2)"),
                new Tuple<NumberSetElement<double>, string>(NumberSetElement<double>.CreateEmpty(), "(2, 2)"),
                new Tuple<NumberSetElement<double>, string>(NumberSetElement<double>.CreateEmpty(), "[2, 1]"),
                new Tuple<NumberSetElement<double>, string>(NumberSetElement<double>.CreateEmpty(), "(2, 2]"),
                new Tuple<NumberSetElement<double>, string>(NumberSetElement<double>.CreateEmpty(), "(2, 2]"),
                new Tuple<NumberSetElement<double>, string>(NumberSetElement<double>.CreateEmpty(), "(2, 2]"),
                new Tuple<NumberSetElement<double>, string>(NumberSetElement<double>.CreateEmpty(), "(2, 2]"),

            };
            for (int i = 0; i < elementList.Count; i++)
            {
                if (NumberSetElement<double>.TryParse(elementList[i].Item2, null, out NumberSetElement<double> result))
                    Assert.IsTrue(elementList[i].Item1.Equals(result));
                else
                    Assert.Fail();
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
            for (int i = 0; i < elementList.Count; i++)
            {
                if (NumberSetElement<double>.TryParse(elementList[i], null, out NumberSetElement<double> result))
                    Assert.Fail();
            }
        }
    }
}
