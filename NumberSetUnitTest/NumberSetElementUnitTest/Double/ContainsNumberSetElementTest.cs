using Utte.NumberSet;

namespace NumberSetUnitTest.NumberSetElementUnitTest.Double
{
    [TestClass]
    public class ContainsNumberSetElementTest
    {
        [TestMethod]
        public void TestContainsPoint()
        {
            var elementList = new List<Tuple<INumberSetElement<double>, double, bool>>()
            {
                new Tuple<INumberSetElement<double>, double, bool>(NumberSetElement<double>.Create(2, 3, true, true), 1.9, false),
                new Tuple<INumberSetElement<double>, double, bool>(NumberSetElement<double>.Create(2, 3, true, true), 2, true),
                new Tuple<INumberSetElement<double>, double, bool>(NumberSetElement<double>.Create(2, 3, true, true), 2.5, true),
                new Tuple<INumberSetElement<double>, double, bool>(NumberSetElement<double>.Create(2, 3, true, true), 3, true),
                new Tuple<INumberSetElement<double>, double, bool>(NumberSetElement<double>.Create(2, 3, true, true), 3.1, false),

                new Tuple<INumberSetElement<double>, double, bool>(NumberSetElement<double>.Create(2, 3, false, true), 1.9, false),
                new Tuple<INumberSetElement<double>, double, bool>(NumberSetElement<double>.Create(2, 3, false, true), 2, false),
                new Tuple<INumberSetElement<double>, double, bool>(NumberSetElement<double>.Create(2, 3, false, true), 2.5, true),
                new Tuple<INumberSetElement<double>, double, bool>(NumberSetElement<double>.Create(2, 3, false, true), 3, true),
                new Tuple<INumberSetElement<double>, double, bool>(NumberSetElement<double>.Create(2, 3, false, true), 3.1, false),

                new Tuple<INumberSetElement<double>, double, bool>(NumberSetElement<double>.Create(2, 3, true, false), 1.9, false),
                new Tuple<INumberSetElement<double>, double, bool>(NumberSetElement<double>.Create(2, 3, true, false), 2, true),
                new Tuple<INumberSetElement<double>, double, bool>(NumberSetElement<double>.Create(2, 3, true, false), 2.5, true),
                new Tuple<INumberSetElement<double>, double, bool>(NumberSetElement<double>.Create(2, 3, true, false), 3, false),
                new Tuple<INumberSetElement<double>, double, bool>(NumberSetElement<double>.Create(2, 3, true, false), 3.1, false),

                new Tuple<INumberSetElement<double>, double, bool>(NumberSetElement<double>.Create(2, 2, true, true), 1.9, false),
                new Tuple<INumberSetElement<double>, double, bool>(NumberSetElement<double>.Create(2, 2, true, true), 2, true),
                new Tuple<INumberSetElement<double>, double, bool>(NumberSetElement<double>.Create(2, 2, true, true), 2.1, false),

                new Tuple<INumberSetElement<double>, double, bool>(NumberSetElement<double>.Empty, 2, false),
            };
            for (int i = 0; i < elementList.Count; i++)
                Assert.IsTrue(elementList[i].Item1.Contains(elementList[i].Item2) == elementList[i].Item3);
        }

        [TestMethod]
        public void TestContainsNumberSetElement()
        {
            var elementList = new List<Tuple<INumberSetElement<double>, INumberSetElement<double>, bool>>()
            {
                new Tuple<INumberSetElement<double>, INumberSetElement<double>, bool>(NumberSetElement<double>.Create(2, 3, true, true), NumberSetElement<double>.Create(2, 3, false, false), true),
                new Tuple<INumberSetElement<double>, INumberSetElement<double>, bool>(NumberSetElement<double>.Create(2, 3, true, true), NumberSetElement<double>.Create(2, 3, false, true), true),
                new Tuple<INumberSetElement<double>, INumberSetElement<double>, bool>(NumberSetElement<double>.Create(2, 3, true, true), NumberSetElement<double>.Create(2, 3, true, false), true),
                new Tuple<INumberSetElement<double>, INumberSetElement<double>, bool>(NumberSetElement<double>.Create(2, 3, true, true), NumberSetElement<double>.Create(2, 3, true, true), true),

                new Tuple<INumberSetElement<double>, INumberSetElement<double>, bool>(NumberSetElement<double>.Create(2, 3, true, false), NumberSetElement<double>.Create(2, 3, false, false), true),
                new Tuple<INumberSetElement<double>, INumberSetElement<double>, bool>(NumberSetElement<double>.Create(2, 3, true, false), NumberSetElement<double>.Create(2, 3, false, true), false),
                new Tuple<INumberSetElement<double>, INumberSetElement<double>, bool>(NumberSetElement<double>.Create(2, 3, true, false), NumberSetElement<double>.Create(2, 3, true, false), true),
                new Tuple<INumberSetElement<double>, INumberSetElement<double>, bool>(NumberSetElement<double>.Create(2, 3, true, false), NumberSetElement<double>.Create(2, 3, true, true), false),

                new Tuple<INumberSetElement<double>, INumberSetElement<double>, bool>(NumberSetElement<double>.Create(2, 3, false, true), NumberSetElement<double>.Create(2, 3, false, false), true),
                new Tuple<INumberSetElement<double>, INumberSetElement<double>, bool>(NumberSetElement<double>.Create(2, 3, false, true), NumberSetElement<double>.Create(2, 3, false, true), true),
                new Tuple<INumberSetElement<double>, INumberSetElement<double>, bool>(NumberSetElement<double>.Create(2, 3, false, true), NumberSetElement<double>.Create(2, 3, true, false), false),
                new Tuple<INumberSetElement<double>, INumberSetElement<double>, bool>(NumberSetElement<double>.Create(2, 3, false, true), NumberSetElement<double>.Create(2, 3, true, true), false),

                new Tuple<INumberSetElement<double>, INumberSetElement<double>, bool>(NumberSetElement<double>.Create(2, 3, false, false), NumberSetElement<double>.Create(2, 3, false, false), true),
                new Tuple<INumberSetElement<double>, INumberSetElement<double>, bool>(NumberSetElement<double>.Create(2, 3, false, false), NumberSetElement<double>.Create(2, 3, false, true), false),
                new Tuple<INumberSetElement<double>, INumberSetElement<double>, bool>(NumberSetElement<double>.Create(2, 3, false, false), NumberSetElement<double>.Create(2, 3, true, false), false),
                new Tuple<INumberSetElement<double>, INumberSetElement<double>, bool>(NumberSetElement<double>.Create(2, 3, false, false), NumberSetElement<double>.Create(2, 3, true, true), false),

                new Tuple<INumberSetElement<double>, INumberSetElement<double>, bool>(NumberSetElement<double>.Create(2, 3, true, true), NumberSetElement<double>.Create(2.2, 2.8, true, true), true),
                new Tuple<INumberSetElement<double>, INumberSetElement<double>, bool>(NumberSetElement<double>.Create(2, 3, true, true), NumberSetElement<double>.Create(2.2, 3, true, true), true),
                new Tuple<INumberSetElement<double>, INumberSetElement<double>, bool>(NumberSetElement<double>.Create(2, 3, true, true), NumberSetElement<double>.Create(2, 2.8, true, true), true),
                new Tuple<INumberSetElement<double>, INumberSetElement<double>, bool>(NumberSetElement<double>.Create(2, 3, true, true), NumberSetElement<double>.Empty, true),

                new Tuple<INumberSetElement<double>, INumberSetElement<double>, bool>(NumberSetElement<double>.Create(2, 2, true, true), NumberSetElement<double>.Create(2, 2, true, true), true),
                new Tuple<INumberSetElement<double>, INumberSetElement<double>, bool>(NumberSetElement<double>.Create(2, 2, true, true), NumberSetElement<double>.Empty, true),

                new Tuple<INumberSetElement<double>, INumberSetElement<double>, bool>(NumberSetElement<double>.Create(2, 3, true, true), NumberSetElement<double>.Create(2.2, 4, true, true), false),
                new Tuple<INumberSetElement<double>, INumberSetElement<double>, bool>(NumberSetElement<double>.Create(2, 3, true, true), NumberSetElement<double>.Create(1, 2.5, true, true), false),
                new Tuple<INumberSetElement<double>, INumberSetElement<double>, bool>(NumberSetElement<double>.Create(2, 3, true, true), NumberSetElement<double>.Create(2, 4, true, true), false),
                new Tuple<INumberSetElement<double>, INumberSetElement<double>, bool>(NumberSetElement<double>.Create(2, 3, true, true), NumberSetElement<double>.Create(1, 3, true, true), false),
                new Tuple<INumberSetElement<double>, INumberSetElement<double>, bool>(NumberSetElement<double>.Create(2, 3, true, true), NumberSetElement<double>.Create(1, 4, true, true), false),

                new Tuple<INumberSetElement<double>, INumberSetElement<double>, bool>(NumberSetElement<double>.Create(2, 2, true, true), NumberSetElement<double>.Create(2, 3, true, true), false),
                new Tuple<INumberSetElement<double>, INumberSetElement<double>, bool>(NumberSetElement<double>.Create(2, 2, true, true), NumberSetElement<double>.Create(1, 2, true, true), false),
                new Tuple<INumberSetElement<double>, INumberSetElement<double>, bool>(NumberSetElement<double>.Create(2, 2, true, true), NumberSetElement<double>.Create(1, 3, true, true), false),

                new Tuple<INumberSetElement<double>, INumberSetElement<double>, bool>(NumberSetElement<double>.Empty, NumberSetElement<double>.Create(2, 2, true, true), false),
                new Tuple<INumberSetElement<double>, INumberSetElement<double>, bool>(NumberSetElement<double>.Empty, NumberSetElement<double>.Create(1, 2, true, true), false),
                new Tuple<INumberSetElement<double>, INumberSetElement<double>, bool>(NumberSetElement<double>.Empty, NumberSetElement<double>.Empty, true),
            };
            for (int i = 0; i < elementList.Count; i++)
                Assert.IsTrue(elementList[i].Item1.Contains(elementList[i].Item2) == elementList[i].Item3);
        }

        [TestMethod]
        public void TestContainsNumberSet()
        {
            var elementList = new List<Tuple<INumberSetElement<double>, INumberSet<double>, bool>>()
            {
                new Tuple<INumberSetElement<double>, INumberSet<double>, bool>(NumberSetElement<double>.Create(2, 3, true, true), NumberSet<double>.Create(NumberSetElement<double>.Create(2, 3, false, false)), true),
                new Tuple<INumberSetElement<double>, INumberSet<double>, bool>(NumberSetElement<double>.Create(2, 3, true, true), NumberSet<double>.Create(NumberSetElement<double>.Create(2, 3, false, true)), true),
                new Tuple<INumberSetElement<double>, INumberSet<double>, bool>(NumberSetElement<double>.Create(2, 3, true, true), NumberSet<double>.Create(NumberSetElement<double>.Create(2, 3, true, false)), true),
                new Tuple<INumberSetElement<double>, INumberSet<double>, bool>(NumberSetElement<double>.Create(2, 3, true, true), NumberSet<double>.Create(NumberSetElement<double>.Create(2, 3, true, true)), true),

                new Tuple<INumberSetElement<double>, INumberSet<double>, bool>(NumberSetElement<double>.Create(2, 3, true, false), NumberSet<double>.Create(NumberSetElement<double>.Create(2, 3, false, false)), true),
                new Tuple<INumberSetElement<double>, INumberSet<double>, bool>(NumberSetElement<double>.Create(2, 3, true, false), NumberSet<double>.Create(NumberSetElement<double>.Create(2, 3, false, true)), false),
                new Tuple<INumberSetElement<double>, INumberSet<double>, bool>(NumberSetElement<double>.Create(2, 3, true, false), NumberSet<double>.Create(NumberSetElement<double>.Create(2, 3, true, false)), true),
                new Tuple<INumberSetElement<double>, INumberSet<double>, bool>(NumberSetElement<double>.Create(2, 3, true, false), NumberSet<double>.Create(NumberSetElement<double>.Create(2, 3, true, true)), false),

                new Tuple<INumberSetElement<double>, INumberSet<double>, bool>(NumberSetElement<double>.Create(2, 3, false, true), NumberSet<double>.Create(NumberSetElement<double>.Create(2, 3, false, false)), true),
                new Tuple<INumberSetElement<double>, INumberSet<double>, bool>(NumberSetElement<double>.Create(2, 3, false, true), NumberSet<double>.Create(NumberSetElement<double>.Create(2, 3, false, true)), true),
                new Tuple<INumberSetElement<double>, INumberSet<double>, bool>(NumberSetElement<double>.Create(2, 3, false, true), NumberSet<double>.Create(NumberSetElement<double>.Create(2, 3, true, false)), false),
                new Tuple<INumberSetElement<double>, INumberSet<double>, bool>(NumberSetElement<double>.Create(2, 3, false, true), NumberSet<double>.Create(NumberSetElement<double>.Create(2, 3, true, true)), false),

                new Tuple<INumberSetElement<double>, INumberSet<double>, bool>(NumberSetElement<double>.Create(2, 3, false, false), NumberSet<double>.Create(NumberSetElement<double>.Create(2, 3, false, false)), true),
                new Tuple<INumberSetElement<double>, INumberSet<double>, bool>(NumberSetElement<double>.Create(2, 3, false, false), NumberSet<double>.Create(NumberSetElement<double>.Create(2, 3, false, true)), false),
                new Tuple<INumberSetElement<double>, INumberSet<double>, bool>(NumberSetElement<double>.Create(2, 3, false, false), NumberSet<double>.Create(NumberSetElement<double>.Create(2, 3, true, false)), false),
                new Tuple<INumberSetElement<double>, INumberSet<double>, bool>(NumberSetElement<double>.Create(2, 3, false, false), NumberSet<double>.Create(NumberSetElement<double>.Create(2, 3, true, true)), false),

                new Tuple<INumberSetElement<double>, INumberSet<double>, bool>(NumberSetElement<double>.Create(2, 3, true, true), NumberSet<double>.Create(NumberSetElement<double>.Create(2.2, 2.8, true, true)), true),
                new Tuple<INumberSetElement<double>, INumberSet<double>, bool>(NumberSetElement<double>.Create(2, 3, true, true), NumberSet<double>.Create(NumberSetElement<double>.Create(2.2, 3, true, true)), true),
                new Tuple<INumberSetElement<double>, INumberSet<double>, bool>(NumberSetElement<double>.Create(2, 3, true, true), NumberSet<double>.Create(NumberSetElement<double>.Create(2, 2.8, true, true)), true),
                new Tuple<INumberSetElement<double>, INumberSet<double>, bool>(NumberSetElement<double>.Create(2, 3, true, true), NumberSet<double>.Create(NumberSetElement<double>.Empty), true),

                new Tuple<INumberSetElement<double>, INumberSet<double>, bool>(NumberSetElement<double>.Create(2, 2, true, true), NumberSet<double>.Create(NumberSetElement<double>.Create(2, 2, true, true)), true),
                new Tuple<INumberSetElement<double>, INumberSet<double>, bool>(NumberSetElement<double>.Create(2, 2, true, true), NumberSet<double>.Create(NumberSetElement<double>.Empty), true),

                new Tuple<INumberSetElement<double>, INumberSet<double>, bool>(NumberSetElement<double>.Create(2, 3, true, true), NumberSet<double>.Create(NumberSetElement<double>.Create(2.2, 4, true, true)), false),
                new Tuple<INumberSetElement<double>, INumberSet<double>, bool>(NumberSetElement<double>.Create(2, 3, true, true), NumberSet<double>.Create(NumberSetElement<double>.Create(1, 2.5, true, true)), false),
                new Tuple<INumberSetElement<double>, INumberSet<double>, bool>(NumberSetElement<double>.Create(2, 3, true, true), NumberSet<double>.Create(NumberSetElement<double>.Create(2, 4, true, true)), false),
                new Tuple<INumberSetElement<double>, INumberSet<double>, bool>(NumberSetElement<double>.Create(2, 3, true, true), NumberSet<double>.Create(NumberSetElement<double>.Create(1, 3, true, true)), false),
                new Tuple<INumberSetElement<double>, INumberSet<double>, bool>(NumberSetElement<double>.Create(2, 3, true, true), NumberSet<double>.Create(NumberSetElement<double>.Create(1, 4, true, true)), false),

                new Tuple<INumberSetElement<double>, INumberSet<double>, bool>(NumberSetElement<double>.Create(2, 2, true, true), NumberSet<double>.Create(NumberSetElement<double>.Create(2, 3, true, true)), false),
                new Tuple<INumberSetElement<double>, INumberSet<double>, bool>(NumberSetElement<double>.Create(2, 2, true, true), NumberSet<double>.Create(NumberSetElement<double>.Create(1, 2, true, true)), false),
                new Tuple<INumberSetElement<double>, INumberSet<double>, bool>(NumberSetElement<double>.Create(2, 2, true, true), NumberSet<double>.Create(NumberSetElement<double>.Create(1, 3, true, true)), false),

                new Tuple<INumberSetElement<double>, INumberSet<double>, bool>(NumberSetElement<double>.Empty, NumberSet<double>.Create(NumberSetElement<double>.Create(2, 2, true, true)), false),
                new Tuple<INumberSetElement<double>, INumberSet<double>, bool>(NumberSetElement<double>.Empty, NumberSet<double>.Create(NumberSetElement<double>.Create(1, 2, true, true)), false),
                new Tuple<INumberSetElement<double>, INumberSet<double>, bool>(NumberSetElement<double>.Empty, NumberSet<double>.Create(NumberSetElement<double>.Empty), true),

                new Tuple<INumberSetElement<double>, INumberSet<double>, bool>(NumberSetElement<double>.Create(2, 5, true, true), NumberSet<double>.Create(NumberSetElement<double>.Create(2, 3, false, false), NumberSetElement<double>.Create(4, 5, false, false)), true),
                new Tuple<INumberSetElement<double>, INumberSet<double>, bool>(NumberSetElement<double>.Create(2, 5, true, true), NumberSet<double>.Create(NumberSetElement<double>.Create(2, 3, false, true), NumberSetElement<double>.Create(4, 5, false, true)), true),
                new Tuple<INumberSetElement<double>, INumberSet<double>, bool>(NumberSetElement<double>.Create(2, 5, true, true), NumberSet<double>.Create(NumberSetElement<double>.Create(2, 3, true, false), NumberSetElement<double>.Create(4, 5, true, false)), true),
                new Tuple<INumberSetElement<double>, INumberSet<double>, bool>(NumberSetElement<double>.Create(2, 5, true, true), NumberSet<double>.Create(NumberSetElement<double>.Create(2, 3, true, true), NumberSetElement<double>.Create(4, 5, true, true)), true),

                new Tuple<INumberSetElement<double>, INumberSet<double>, bool>(NumberSetElement<double>.Create(2, 5, true, false), NumberSet<double>.Create(NumberSetElement<double>.Create(2, 3, false, false), NumberSetElement<double>.Create(4, 5, false, false)), true),
                new Tuple<INumberSetElement<double>, INumberSet<double>, bool>(NumberSetElement<double>.Create(2, 5, true, false), NumberSet<double>.Create(NumberSetElement<double>.Create(2, 3, false, true), NumberSetElement<double>.Create(4, 5, false, true)), false),
                new Tuple<INumberSetElement<double>, INumberSet<double>, bool>(NumberSetElement<double>.Create(2, 5, true, false), NumberSet<double>.Create(NumberSetElement<double>.Create(2, 3, true, false), NumberSetElement<double>.Create(4, 5, true, false)), true),
                new Tuple<INumberSetElement<double>, INumberSet<double>, bool>(NumberSetElement<double>.Create(2, 5, true, false), NumberSet<double>.Create(NumberSetElement<double>.Create(2, 3, true, true), NumberSetElement<double>.Create(4, 5, true, true)), false),

                new Tuple<INumberSetElement<double>, INumberSet<double>, bool>(NumberSetElement<double>.Create(2, 5, false, true), NumberSet<double>.Create(NumberSetElement<double>.Create(2, 3, false, false), NumberSetElement<double>.Create(4, 5, false, false)), true),
                new Tuple<INumberSetElement<double>, INumberSet<double>, bool>(NumberSetElement<double>.Create(2, 5, false, true), NumberSet<double>.Create(NumberSetElement<double>.Create(2, 3, false, true), NumberSetElement<double>.Create(4, 5, false, true)), true),
                new Tuple<INumberSetElement<double>, INumberSet<double>, bool>(NumberSetElement<double>.Create(2, 5, false, true), NumberSet<double>.Create(NumberSetElement<double>.Create(2, 3, true, false), NumberSetElement<double>.Create(4, 5, true, false)), false),
                new Tuple<INumberSetElement<double>, INumberSet<double>, bool>(NumberSetElement<double>.Create(2, 5, false, true), NumberSet<double>.Create(NumberSetElement<double>.Create(2, 3, true, true), NumberSetElement<double>.Create(4, 5, true, true)), false),

                new Tuple<INumberSetElement<double>, INumberSet<double>, bool>(NumberSetElement<double>.Create(2, 5, false, false), NumberSet<double>.Create(NumberSetElement<double>.Create(2, 3, false, false), NumberSetElement<double>.Create(4, 5, false, false)), true),
                new Tuple<INumberSetElement<double>, INumberSet<double>, bool>(NumberSetElement<double>.Create(2, 5, false, false), NumberSet<double>.Create(NumberSetElement<double>.Create(2, 3, false, true), NumberSetElement<double>.Create(4, 5, false, true)), false),
                new Tuple<INumberSetElement<double>, INumberSet<double>, bool>(NumberSetElement<double>.Create(2, 5, false, false), NumberSet<double>.Create(NumberSetElement<double>.Create(2, 3, true, false), NumberSetElement<double>.Create(4, 5, true, false)), false),
                new Tuple<INumberSetElement<double>, INumberSet<double>, bool>(NumberSetElement<double>.Create(2, 5, false, false), NumberSet<double>.Create(NumberSetElement<double>.Create(2, 3, true, true), NumberSetElement<double>.Create(4, 5, true, true)), false),

                new Tuple<INumberSetElement<double>, INumberSet<double>, bool>(NumberSetElement<double>.Create(2, 5, true, true), NumberSet<double>.Create(NumberSetElement<double>.Create(2.2, 2.8, true, true), NumberSetElement<double>.Create(4.2, 4.8, true, true)), true),
                new Tuple<INumberSetElement<double>, INumberSet<double>, bool>(NumberSetElement<double>.Create(2, 5, true, true), NumberSet<double>.Create(NumberSetElement<double>.Create(2.2, 3, true, true), NumberSetElement<double>.Create(4.2, 5, true, true)), true),
                new Tuple<INumberSetElement<double>, INumberSet<double>, bool>(NumberSetElement<double>.Create(2, 5, true, true), NumberSet<double>.Create(NumberSetElement<double>.Create(2, 2.8, true, true), NumberSetElement<double>.Create(4, 4.8, true, true)), true),

                new Tuple<INumberSetElement<double>, INumberSet<double>, bool>(NumberSetElement<double>.Create(2, 5, true, true), NumberSet<double>.Create(NumberSetElement<double>.Create(2.2, 4, true, true), NumberSetElement<double>.Create(4.2, 6, true, true)), false),
                new Tuple<INumberSetElement<double>, INumberSet<double>, bool>(NumberSetElement<double>.Create(2, 5, true, true), NumberSet<double>.Create(NumberSetElement<double>.Create(1, 2.5, true, true), NumberSetElement<double>.Create(3, 4.5, true, true)), false),
                new Tuple<INumberSetElement<double>, INumberSet<double>, bool>(NumberSetElement<double>.Create(2, 5, true, true), NumberSet<double>.Create(NumberSetElement<double>.Create(2, 4, true, true), NumberSetElement<double>.Create(4, 6, true, true)), false),
                new Tuple<INumberSetElement<double>, INumberSet<double>, bool>(NumberSetElement<double>.Create(2, 5, true, true), NumberSet<double>.Create(NumberSetElement<double>.Create(1, 3, true, true), NumberSetElement<double>.Create(3, 5, true, true)), false),
                new Tuple<INumberSetElement<double>, INumberSet<double>, bool>(NumberSetElement<double>.Create(2, 5, true, true), NumberSet<double>.Create(NumberSetElement<double>.Create(1, 4, true, true), NumberSetElement<double>.Create(3, 6, true, true)), false),

                new Tuple<INumberSetElement<double>, INumberSet<double>, bool>(NumberSetElement<double>.Create(2, 5, true, true), NumberSet<double>.Create(NumberSetElement<double>.Create(0, 1, false, false), NumberSetElement<double>.Create(2, 3, false, false), NumberSetElement<double>.Create(4, 5, false, false)), false),
                new Tuple<INumberSetElement<double>, INumberSet<double>, bool>(NumberSetElement<double>.Create(2, 5, true, true), NumberSet<double>.Create(NumberSetElement<double>.Create(0, 1, false, false), NumberSetElement<double>.Create(2, 3, false, true), NumberSetElement<double>.Create(4, 5, false, true)), false),
                new Tuple<INumberSetElement<double>, INumberSet<double>, bool>(NumberSetElement<double>.Create(2, 5, true, true), NumberSet<double>.Create(NumberSetElement<double>.Create(0, 1, false, false), NumberSetElement<double>.Create(2, 3, true, false), NumberSetElement<double>.Create(4, 5, true, false)), false),
                new Tuple<INumberSetElement<double>, INumberSet<double>, bool>(NumberSetElement<double>.Create(2, 5, true, true), NumberSet<double>.Create(NumberSetElement<double>.Create(0, 1, false, false), NumberSetElement<double>.Create(2, 3, true, true), NumberSetElement<double>.Create(4, 5, true, true)), false),
                new Tuple<INumberSetElement<double>, INumberSet<double>, bool>(NumberSetElement<double>.Create(2, 5, true, true), NumberSet<double>.Create(NumberSetElement<double>.Create(1, 1, true, true), NumberSetElement<double>.Create(2, 3, false, false), NumberSetElement<double>.Create(4, 5, false, false)), false),

                new Tuple<INumberSetElement<double>, INumberSet<double>, bool>(NumberSetElement<double>.Create(2, 5, true, false), NumberSet<double>.Create(NumberSetElement<double>.Create(0, 1, false, false), NumberSetElement<double>.Create(2, 3, false, false), NumberSetElement<double>.Create(4, 5, false, false)), false),
                new Tuple<INumberSetElement<double>, INumberSet<double>, bool>(NumberSetElement<double>.Create(2, 5, true, false), NumberSet<double>.Create(NumberSetElement<double>.Create(0, 1, false, false), NumberSetElement<double>.Create(2, 3, false, true), NumberSetElement<double>.Create(4, 5, false, true)), false),
                new Tuple<INumberSetElement<double>, INumberSet<double>, bool>(NumberSetElement<double>.Create(2, 5, true, false), NumberSet<double>.Create(NumberSetElement<double>.Create(0, 1, false, false), NumberSetElement<double>.Create(2, 3, true, false), NumberSetElement<double>.Create(4, 5, true, false)), false),
                new Tuple<INumberSetElement<double>, INumberSet<double>, bool>(NumberSetElement<double>.Create(2, 5, true, false), NumberSet<double>.Create(NumberSetElement<double>.Create(0, 1, false, false), NumberSetElement<double>.Create(2, 3, true, true), NumberSetElement<double>.Create(4, 5, true, true)), false),

                new Tuple<INumberSetElement<double>, INumberSet<double>, bool>(NumberSetElement<double>.Create(2, 5, false, true), NumberSet<double>.Create(NumberSetElement<double>.Create(0, 1, false, false), NumberSetElement<double>.Create(2, 3, false, false), NumberSetElement<double>.Create(4, 5, false, false)), false),
                new Tuple<INumberSetElement<double>, INumberSet<double>, bool>(NumberSetElement<double>.Create(2, 5, false, true), NumberSet<double>.Create(NumberSetElement<double>.Create(0, 1, false, false), NumberSetElement<double>.Create(2, 3, false, true), NumberSetElement<double>.Create(4, 5, false, true)), false),
                new Tuple<INumberSetElement<double>, INumberSet<double>, bool>(NumberSetElement<double>.Create(2, 5, false, true), NumberSet<double>.Create(NumberSetElement<double>.Create(0, 1, false, false), NumberSetElement<double>.Create(2, 3, true, false), NumberSetElement<double>.Create(4, 5, true, false)), false),
                new Tuple<INumberSetElement<double>, INumberSet<double>, bool>(NumberSetElement<double>.Create(2, 5, false, true), NumberSet<double>.Create(NumberSetElement<double>.Create(0, 1, false, false), NumberSetElement<double>.Create(2, 3, true, true), NumberSetElement<double>.Create(4, 5, true, true)), false),

                new Tuple<INumberSetElement<double>, INumberSet<double>, bool>(NumberSetElement<double>.Create(2, 5, false, false), NumberSet<double>.Create(NumberSetElement<double>.Create(0, 1, false, false), NumberSetElement<double>.Create(2, 3, false, false), NumberSetElement<double>.Create(4, 5, false, false)), false),
                new Tuple<INumberSetElement<double>, INumberSet<double>, bool>(NumberSetElement<double>.Create(2, 5, false, false), NumberSet<double>.Create(NumberSetElement<double>.Create(0, 1, false, false), NumberSetElement<double>.Create(2, 3, false, true), NumberSetElement<double>.Create(4, 5, false, true)), false),
                new Tuple<INumberSetElement<double>, INumberSet<double>, bool>(NumberSetElement<double>.Create(2, 5, false, false), NumberSet<double>.Create(NumberSetElement<double>.Create(0, 1, false, false), NumberSetElement<double>.Create(2, 3, true, false), NumberSetElement<double>.Create(4, 5, true, false)), false),
                new Tuple<INumberSetElement<double>, INumberSet<double>, bool>(NumberSetElement<double>.Create(2, 5, false, false), NumberSet<double>.Create(NumberSetElement<double>.Create(0, 1, false, false), NumberSetElement<double>.Create(2, 3, true, true), NumberSetElement<double>.Create(4, 5, true, true)), false),

                new Tuple<INumberSetElement<double>, INumberSet<double>, bool>(NumberSetElement<double>.Create(2, 5, true, true), NumberSet<double>.Create(NumberSetElement<double>.Create(0, 1, false, false), NumberSetElement<double>.Create(2.2, 2.8, true, true), NumberSetElement<double>.Create(4.2, 4.8, true, true)), false),
                new Tuple<INumberSetElement<double>, INumberSet<double>, bool>(NumberSetElement<double>.Create(2, 5, true, true), NumberSet<double>.Create(NumberSetElement<double>.Create(0, 1, false, false), NumberSetElement<double>.Create(2.2, 3, true, true), NumberSetElement<double>.Create(4.2, 5, true, true)), false),
                new Tuple<INumberSetElement<double>, INumberSet<double>, bool>(NumberSetElement<double>.Create(2, 5, true, true), NumberSet<double>.Create(NumberSetElement<double>.Create(0, 1, false, false), NumberSetElement<double>.Create(2, 2.8, true, true), NumberSetElement<double>.Create(4, 4.8, true, true)), false),

                new Tuple<INumberSetElement<double>, INumberSet<double>, bool>(NumberSetElement<double>.Create(2, 5, true, true), NumberSet<double>.Create(NumberSetElement<double>.Create(0, 1, false, false), NumberSetElement<double>.Create(2.2, 4, true, true), NumberSetElement<double>.Create(4.2, 6, true, true)), false),
                new Tuple<INumberSetElement<double>, INumberSet<double>, bool>(NumberSetElement<double>.Create(2, 5, true, true), NumberSet<double>.Create(NumberSetElement<double>.Create(0, 1, false, false), NumberSetElement<double>.Create(1, 2.5, true, true), NumberSetElement<double>.Create(3, 4.5, true, true)), false),
                new Tuple<INumberSetElement<double>, INumberSet<double>, bool>(NumberSetElement<double>.Create(2, 5, true, true), NumberSet<double>.Create(NumberSetElement<double>.Create(0, 1, false, false), NumberSetElement<double>.Create(2, 4, true, true), NumberSetElement<double>.Create(4, 6, true, true)), false),
                new Tuple<INumberSetElement<double>, INumberSet<double>, bool>(NumberSetElement<double>.Create(2, 5, true, true), NumberSet<double>.Create(NumberSetElement<double>.Create(0, 1, false, false), NumberSetElement<double>.Create(1, 3, true, true), NumberSetElement<double>.Create(3, 5, true, true)), false),
                new Tuple<INumberSetElement<double>, INumberSet<double>, bool>(NumberSetElement<double>.Create(2, 5, true, true), NumberSet<double>.Create(NumberSetElement<double>.Create(0, 1, false, false), NumberSetElement<double>.Create(1, 4, true, true), NumberSetElement<double>.Create(3, 6, true, true)), false),

                new Tuple<INumberSetElement<double>, INumberSet<double>, bool>(NumberSetElement<double>.Create(2, 5, true, true), NumberSet<double>.Create(NumberSetElement<double>.Create(2, 3, false, false), NumberSetElement<double>.Create(4, 5, false, false), NumberSetElement<double>.Create(7, 8, false, false)), false),
                new Tuple<INumberSetElement<double>, INumberSet<double>, bool>(NumberSetElement<double>.Create(2, 5, true, true), NumberSet<double>.Create(NumberSetElement<double>.Create(2, 3, false, true), NumberSetElement<double>.Create(4, 5, false, true), NumberSetElement<double>.Create(7, 8, false, false)), false),
                new Tuple<INumberSetElement<double>, INumberSet<double>, bool>(NumberSetElement<double>.Create(2, 5, true, true), NumberSet<double>.Create(NumberSetElement<double>.Create(2, 3, true, false), NumberSetElement<double>.Create(4, 5, true, false), NumberSetElement<double>.Create(7, 8, false, false)), false),
                new Tuple<INumberSetElement<double>, INumberSet<double>, bool>(NumberSetElement<double>.Create(2, 5, true, true), NumberSet<double>.Create(NumberSetElement<double>.Create(2, 3, true, true), NumberSetElement<double>.Create(4, 5, true, true), NumberSetElement<double>.Create(7, 8, false, false)), false),
                new Tuple<INumberSetElement<double>, INumberSet<double>, bool>(NumberSetElement<double>.Create(2, 5, true, true), NumberSet<double>.Create(NumberSetElement<double>.Create(2, 3, false, false), NumberSetElement<double>.Create(4, 5, false, false), NumberSetElement<double>.Create(8, 8, true, true)), false),

                new Tuple<INumberSetElement<double>, INumberSet<double>, bool>(NumberSetElement<double>.Create(2, 5, true, false), NumberSet<double>.Create(NumberSetElement<double>.Create(2, 3, false, false), NumberSetElement<double>.Create(4, 5, false, false), NumberSetElement<double>.Create(7, 8, false, false)), false),
                new Tuple<INumberSetElement<double>, INumberSet<double>, bool>(NumberSetElement<double>.Create(2, 5, true, false), NumberSet<double>.Create(NumberSetElement<double>.Create(2, 3, false, true), NumberSetElement<double>.Create(4, 5, false, true), NumberSetElement<double>.Create(7, 8, false, false)), false),
                new Tuple<INumberSetElement<double>, INumberSet<double>, bool>(NumberSetElement<double>.Create(2, 5, true, false), NumberSet<double>.Create(NumberSetElement<double>.Create(2, 3, true, false), NumberSetElement<double>.Create(4, 5, true, false), NumberSetElement<double>.Create(7, 8, false, false)), false),
                new Tuple<INumberSetElement<double>, INumberSet<double>, bool>(NumberSetElement<double>.Create(2, 5, true, false), NumberSet<double>.Create(NumberSetElement<double>.Create(2, 3, true, true), NumberSetElement<double>.Create(4, 5, true, true), NumberSetElement<double>.Create(7, 8, false, false)), false),

                new Tuple<INumberSetElement<double>, INumberSet<double>, bool>(NumberSetElement<double>.Create(2, 5, false, true), NumberSet<double>.Create(NumberSetElement<double>.Create(2, 3, false, false), NumberSetElement<double>.Create(4, 5, false, false), NumberSetElement<double>.Create(7, 8, false, false)), false),
                new Tuple<INumberSetElement<double>, INumberSet<double>, bool>(NumberSetElement<double>.Create(2, 5, false, true), NumberSet<double>.Create(NumberSetElement<double>.Create(2, 3, false, true), NumberSetElement<double>.Create(4, 5, false, true), NumberSetElement<double>.Create(7, 8, false, false)), false),
                new Tuple<INumberSetElement<double>, INumberSet<double>, bool>(NumberSetElement<double>.Create(2, 5, false, true), NumberSet<double>.Create(NumberSetElement<double>.Create(2, 3, true, false), NumberSetElement<double>.Create(4, 5, true, false), NumberSetElement<double>.Create(7, 8, false, false)), false),
                new Tuple<INumberSetElement<double>, INumberSet<double>, bool>(NumberSetElement<double>.Create(2, 5, false, true), NumberSet<double>.Create(NumberSetElement<double>.Create(2, 3, true, true), NumberSetElement<double>.Create(4, 5, true, true), NumberSetElement<double>.Create(7, 8, false, false)), false),

                new Tuple<INumberSetElement<double>, INumberSet<double>, bool>(NumberSetElement<double>.Create(2, 5, false, false), NumberSet<double>.Create(NumberSetElement<double>.Create(2, 3, false, false), NumberSetElement<double>.Create(4, 5, false, false), NumberSetElement<double>.Create(7, 8, false, false)), false),
                new Tuple<INumberSetElement<double>, INumberSet<double>, bool>(NumberSetElement<double>.Create(2, 5, false, false), NumberSet<double>.Create(NumberSetElement<double>.Create(2, 3, false, true), NumberSetElement<double>.Create(4, 5, false, true), NumberSetElement<double>.Create(7, 8, false, false)), false),
                new Tuple<INumberSetElement<double>, INumberSet<double>, bool>(NumberSetElement<double>.Create(2, 5, false, false), NumberSet<double>.Create(NumberSetElement<double>.Create(2, 3, true, false), NumberSetElement<double>.Create(4, 5, true, false), NumberSetElement<double>.Create(7, 8, false, false)), false),
                new Tuple<INumberSetElement<double>, INumberSet<double>, bool>(NumberSetElement<double>.Create(2, 5, false, false), NumberSet<double>.Create(NumberSetElement<double>.Create(2, 3, true, true), NumberSetElement<double>.Create(4, 5, true, true), NumberSetElement<double>.Create(7, 8, false, false)), false),

                new Tuple<INumberSetElement<double>, INumberSet<double>, bool>(NumberSetElement<double>.Create(2, 5, true, true), NumberSet<double>.Create(NumberSetElement<double>.Create(2.2, 2.8, true, true), NumberSetElement<double>.Create(4.2, 4.8, true, true), NumberSetElement<double>.Create(7, 8, false, false)), false),
                new Tuple<INumberSetElement<double>, INumberSet<double>, bool>(NumberSetElement<double>.Create(2, 5, true, true), NumberSet<double>.Create(NumberSetElement<double>.Create(2.2, 3, true, true), NumberSetElement<double>.Create(4.2, 5, true, true), NumberSetElement<double>.Create(7, 8, false, false)), false),
                new Tuple<INumberSetElement<double>, INumberSet<double>, bool>(NumberSetElement<double>.Create(2, 5, true, true), NumberSet<double>.Create(NumberSetElement<double>.Create(2, 2.8, true, true), NumberSetElement<double>.Create(4, 4.8, true, true), NumberSetElement<double>.Create(7, 8, false, false)), false),

                new Tuple<INumberSetElement<double>, INumberSet<double>, bool>(NumberSetElement<double>.Create(2, 5, true, true), NumberSet<double>.Create(NumberSetElement<double>.Create(2.2, 4, true, true), NumberSetElement<double>.Create(4.2, 6, true, true), NumberSetElement<double>.Create(7, 8, false, false)), false),
                new Tuple<INumberSetElement<double>, INumberSet<double>, bool>(NumberSetElement<double>.Create(2, 5, true, true), NumberSet<double>.Create(NumberSetElement<double>.Create(1, 2.5, true, true), NumberSetElement<double>.Create(3, 4.5, true, true), NumberSetElement<double>.Create(7, 8, false, false)), false),
                new Tuple<INumberSetElement<double>, INumberSet<double>, bool>(NumberSetElement<double>.Create(2, 5, true, true), NumberSet<double>.Create(NumberSetElement<double>.Create(2, 4, true, true), NumberSetElement<double>.Create(4, 6, true, true), NumberSetElement<double>.Create(7, 8, false, false)), false),
                new Tuple<INumberSetElement<double>, INumberSet<double>, bool>(NumberSetElement<double>.Create(2, 5, true, true), NumberSet<double>.Create(NumberSetElement<double>.Create(1, 3, true, true), NumberSetElement<double>.Create(3, 5, true, true), NumberSetElement<double>.Create(7, 8, false, false)), false),
                new Tuple<INumberSetElement<double>, INumberSet<double>, bool>(NumberSetElement<double>.Create(2, 5, true, true), NumberSet<double>.Create(NumberSetElement<double>.Create(1, 4, true, true), NumberSetElement<double>.Create(3, 6, true, true), NumberSetElement<double>.Create(7, 8, false, false)), false),

                new Tuple<INumberSetElement<double>, INumberSet<double>, bool>(NumberSetElement<double>.Create(2, 2, true, true), NumberSet<double>.Create(NumberSetElement<double>.Create(0, 1, false, false), NumberSetElement<double>.Create(2, 2, true, true)), false),
                new Tuple<INumberSetElement<double>, INumberSet<double>, bool>(NumberSetElement<double>.Create(2, 2, true, true), NumberSet<double>.Create(NumberSetElement<double>.Create(0, 1, false, false), NumberSetElement<double>.Create(2, 3, true, true)), false),
                new Tuple<INumberSetElement<double>, INumberSet<double>, bool>(NumberSetElement<double>.Create(2, 2, true, true), NumberSet<double>.Create(NumberSetElement<double>.Create(0, 1, false, false), NumberSetElement<double>.Create(1, 2, true, true)), false),
                new Tuple<INumberSetElement<double>, INumberSet<double>, bool>(NumberSetElement<double>.Create(2, 2, true, true), NumberSet<double>.Create(NumberSetElement<double>.Create(0, 1, false, false), NumberSetElement<double>.Create(1, 3, true, true)), false),

                new Tuple<INumberSetElement<double>, INumberSet<double>, bool>(NumberSetElement<double>.Create(2, 2, true, true), NumberSet<double>.Create(NumberSetElement<double>.Create(1, 1, true, true), NumberSetElement<double>.Create(2, 2, true, true)), false),
                new Tuple<INumberSetElement<double>, INumberSet<double>, bool>(NumberSetElement<double>.Create(2, 2, true, true), NumberSet<double>.Create(NumberSetElement<double>.Create(1, 1, true, true), NumberSetElement<double>.Create(2, 3, true, true)), false),
                new Tuple<INumberSetElement<double>, INumberSet<double>, bool>(NumberSetElement<double>.Create(2, 2, true, true), NumberSet<double>.Create(NumberSetElement<double>.Create(1, 1, true, true), NumberSetElement<double>.Create(1, 2, true, true)), false),
                new Tuple<INumberSetElement<double>, INumberSet<double>, bool>(NumberSetElement<double>.Create(2, 2, true, true), NumberSet<double>.Create(NumberSetElement<double>.Create(1, 1, true, true), NumberSetElement<double>.Create(1, 3, true, true)), false),

                new Tuple<INumberSetElement<double>, INumberSet<double>, bool>(NumberSetElement<double>.Create(2, 2, true, true), NumberSet<double>.Create(NumberSetElement<double>.Create(2, 2, true, true), NumberSetElement<double>.Create(7, 8, false, false)), false),
                new Tuple<INumberSetElement<double>, INumberSet<double>, bool>(NumberSetElement<double>.Create(2, 2, true, true), NumberSet<double>.Create(NumberSetElement<double>.Create(2, 3, true, true), NumberSetElement<double>.Create(7, 8, false, false)), false),
                new Tuple<INumberSetElement<double>, INumberSet<double>, bool>(NumberSetElement<double>.Create(2, 2, true, true), NumberSet<double>.Create(NumberSetElement<double>.Create(1, 2, true, true), NumberSetElement<double>.Create(7, 8, false, false)), false),
                new Tuple<INumberSetElement<double>, INumberSet<double>, bool>(NumberSetElement<double>.Create(2, 2, true, true), NumberSet<double>.Create(NumberSetElement<double>.Create(1, 3, true, true), NumberSetElement<double>.Create(7, 8, false, false)), false),

                new Tuple<INumberSetElement<double>, INumberSet<double>, bool>(NumberSetElement<double>.Create(2, 2, true, true), NumberSet<double>.Create(NumberSetElement<double>.Create(2, 2, true, true), NumberSetElement<double>.Create(8, 8, true, true)), false),
                new Tuple<INumberSetElement<double>, INumberSet<double>, bool>(NumberSetElement<double>.Create(2, 2, true, true), NumberSet<double>.Create(NumberSetElement<double>.Create(2, 3, true, true), NumberSetElement<double>.Create(8, 8, true, true)), false),
                new Tuple<INumberSetElement<double>, INumberSet<double>, bool>(NumberSetElement<double>.Create(2, 2, true, true), NumberSet<double>.Create(NumberSetElement<double>.Create(1, 2, true, true), NumberSetElement<double>.Create(8, 8, true, true)), false),
                new Tuple<INumberSetElement<double>, INumberSet<double>, bool>(NumberSetElement<double>.Create(2, 2, true, true), NumberSet<double>.Create(NumberSetElement<double>.Create(1, 3, true, true), NumberSetElement<double>.Create(8, 8, true, true)), false),

                new Tuple<INumberSetElement<double>, INumberSet<double>, bool>(NumberSetElement<double>.Create(2, 8, false, false), NumberSet<double>.Create(NumberSetElement<double>.Create(2.5, 3, true, true), NumberSetElement<double>.Create(4, 5, true, true), NumberSetElement<double>.Create(6, 7, false, true)), true),
            };
            for (int i = 0; i < elementList.Count; i++)
                Assert.IsTrue(elementList[i].Item1.Contains(elementList[i].Item2) == elementList[i].Item3);
        }
    }
}
