using NumberSet;

namespace NumberSetUnitTest.NumberSetUnitTest.Double
{
    [TestClass]
    public class TextNumberSetTest
    {
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
                if (NumberSet<double>.TryParse(elementList[i].Item2, null, out NumberSet<double> result))
                    Assert.IsTrue(NumberSet<double>.Create(new List<NumberSetElement<double>>() { elementList[i].Item1 }).Equals(result));
                else
                    Assert.Fail();
            }
        }

        [TestMethod]
        public void TestTryParseMoreElements()
        {
            var elementList = new List<Tuple<NumberSet<double>, string>>()
            {
                new Tuple<NumberSet<double>, string>(NumberSet<double>.Create(new List<NumberSetElement<double>>() { NumberSetElement<double>.Create(2, 3, true, true), NumberSetElement<double>.Create(4, 5, true, true) }), "[2, 3]; [4, 5]"),
                new Tuple<NumberSet<double>, string>(NumberSet<double>.Create(new List<NumberSetElement<double>>() { NumberSetElement<double>.Create(2, 3, true, true), NumberSetElement<double>.Create(4, 5, true, true) }), " [2, 3]; [4, 5]"),
                new Tuple<NumberSet<double>, string>(NumberSet<double>.Create(new List<NumberSetElement<double>>() { NumberSetElement<double>.Create(2, 3, true, true), NumberSetElement<double>.Create(4, 5, true, true) }), "[2, 3]; [4, 5] "),
                new Tuple<NumberSet<double>, string>(NumberSet<double>.Create(new List<NumberSetElement<double>>() { NumberSetElement<double>.Create(2, 3, true, true), NumberSetElement<double>.Create(4, 5, true, true) }), "[2, 3] ; [4, 5]"),
                new Tuple<NumberSet<double>, string>(NumberSet<double>.Create(new List<NumberSetElement<double>>() { NumberSetElement<double>.Create(2, 3, true, true), NumberSetElement<double>.Create(4, 5, true, true) }), "[2, 3];  [4, 5]"),
                new Tuple<NumberSet<double>, string>(NumberSet<double>.Create(new List<NumberSetElement<double>>() { NumberSetElement<double>.Create(2, 3, true, true), NumberSetElement<double>.Create(4, 5, true, true) }), "[2, 3];[4, 5]"),
                new Tuple<NumberSet<double>, string>(NumberSet<double>.Create(new List<NumberSetElement<double>>() { NumberSetElement<double>.Create(2, 3, true, true), NumberSetElement<double>.Create(4, 5, true, true), NumberSetElement<double>.Create(6, 7, false, true) }), "[2, 3]; [4, 5]; (6, 7]"),
                new Tuple<NumberSet<double>, string>(NumberSet<double>.Create(new List<NumberSetElement<double>>() { NumberSetElement<double>.Create(2, 3, true, false), NumberSetElement<double>.Create(3, 6, false, false), NumberSetElement<double>.Create(6, 7, false, true) }), "[2, 3); (3, 6); (6, 7]"),
                new Tuple<NumberSet<double>, string>(NumberSet<double>.Create(new List<NumberSetElement<double>>() { NumberSetElement<double>.Create(2, 3, true, true), NumberSetElement<double>.Create(4, 5, true, true) }), "[2, 3]; [4, 5]; (8, 8)"),
                new Tuple<NumberSet<double>, string>(NumberSet<double>.Create(new List<NumberSetElement<double>>() { NumberSetElement<double>.Create(2, 3, true, true), NumberSetElement<double>.Create(4, 5, true, true) }), "(1, 1); [2, 3]; [4, 5]"),
            };
            for (int i = 0; i < elementList.Count; i++)
            {
                if (NumberSet<double>.TryParse(elementList[i].Item2, null, out NumberSet<double> result))
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
                "[2, 3];; [4, 5]",
                "[2, 3]; ; [4, 5]",
                "[2, 3];3, 4; [4, 5]",
                "[2, 3]b; [4, 5]",
                "[2, 3];b [4, 5]",
            };
            for (int i = 0; i < elementList.Count; i++)
            {
                if (NumberSet<double>.TryParse(elementList[i], null, out NumberSet<double> result))
                    Assert.Fail();
            }
        }
    }
}
