using NumberSet;

namespace NumberSetUnitTest.NumberSetElementUnitTest.Double
{
    [TestClass]
    public class IntersectNumberSetElementTest
    {
        [TestMethod]
        public void TestIntersectsNumberSetElement()
        {
            var elementList = new List<Tuple<INumberSetElement<double>, INumberSetElement<double>, bool>>()
            {
                new Tuple<INumberSetElement<double>, INumberSetElement<double>, bool>(NumberSetElement<double>.Create(2, 3, true, true), NumberSetElement<double>.Create(2, 3, false, false), true),
                new Tuple<INumberSetElement<double>, INumberSetElement<double>, bool>(NumberSetElement<double>.Create(2, 3, true, true), NumberSetElement<double>.Create(2, 3, false, true), true),
                new Tuple<INumberSetElement<double>, INumberSetElement<double>, bool>(NumberSetElement<double>.Create(2, 3, true, true), NumberSetElement<double>.Create(2, 3, true, false), true),
                new Tuple<INumberSetElement<double>, INumberSetElement<double>, bool>(NumberSetElement<double>.Create(2, 3, true, true), NumberSetElement<double>.Create(2, 3, true, true), true),

                new Tuple<INumberSetElement<double>, INumberSetElement<double>, bool>(NumberSetElement<double>.Create(2, 3, true, false), NumberSetElement<double>.Create(2, 3, false, false), true),
                new Tuple<INumberSetElement<double>, INumberSetElement<double>, bool>(NumberSetElement<double>.Create(2, 3, true, false), NumberSetElement<double>.Create(2, 3, false, true), true),
                new Tuple<INumberSetElement<double>, INumberSetElement<double>, bool>(NumberSetElement<double>.Create(2, 3, true, false), NumberSetElement<double>.Create(2, 3, true, false), true),
                new Tuple<INumberSetElement<double>, INumberSetElement<double>, bool>(NumberSetElement<double>.Create(2, 3, true, false), NumberSetElement<double>.Create(2, 3, true, true), true),

                new Tuple<INumberSetElement<double>, INumberSetElement<double>, bool>(NumberSetElement<double>.Create(2, 3, false, true), NumberSetElement<double>.Create(2, 3, false, false), true),
                new Tuple<INumberSetElement<double>, INumberSetElement<double>, bool>(NumberSetElement<double>.Create(2, 3, false, true), NumberSetElement<double>.Create(2, 3, false, true), true),
                new Tuple<INumberSetElement<double>, INumberSetElement<double>, bool>(NumberSetElement<double>.Create(2, 3, false, true), NumberSetElement<double>.Create(2, 3, true, false), true),
                new Tuple<INumberSetElement<double>, INumberSetElement<double>, bool>(NumberSetElement<double>.Create(2, 3, false, true), NumberSetElement<double>.Create(2, 3, true, true), true),

                new Tuple<INumberSetElement<double>, INumberSetElement<double>, bool>(NumberSetElement<double>.Create(2, 3, false, false), NumberSetElement<double>.Create(2, 3, false, false), true),
                new Tuple<INumberSetElement<double>, INumberSetElement<double>, bool>(NumberSetElement<double>.Create(2, 3, false, false), NumberSetElement<double>.Create(2, 3, false, true), true),
                new Tuple<INumberSetElement<double>, INumberSetElement<double>, bool>(NumberSetElement<double>.Create(2, 3, false, false), NumberSetElement<double>.Create(2, 3, true, false), true),
                new Tuple<INumberSetElement<double>, INumberSetElement<double>, bool>(NumberSetElement<double>.Create(2, 3, false, false), NumberSetElement<double>.Create(2, 3, true, true), true),

                new Tuple<INumberSetElement<double>, INumberSetElement<double>, bool>(NumberSetElement<double>.Create(2, 3, true, true), NumberSetElement<double>.Create(2.2, 2.8, true, true), true),
                new Tuple<INumberSetElement<double>, INumberSetElement<double>, bool>(NumberSetElement<double>.Create(2, 3, true, true), NumberSetElement<double>.Create(2.2, 3, true, true), true),
                new Tuple<INumberSetElement<double>, INumberSetElement<double>, bool>(NumberSetElement<double>.Create(2, 3, true, true), NumberSetElement<double>.Create(2, 2.8, true, true), true),
                new Tuple<INumberSetElement<double>, INumberSetElement<double>, bool>(NumberSetElement<double>.Create(2, 3, true, true), NumberSetElement<double>.Empty, true),

                new Tuple<INumberSetElement<double>, INumberSetElement<double>, bool>(NumberSetElement<double>.Create(2, 2, true, true), NumberSetElement<double>.Create(2, 2, true, true), true),
                new Tuple<INumberSetElement<double>, INumberSetElement<double>, bool>(NumberSetElement<double>.Create(2, 2, true, true), NumberSetElement<double>.Empty, true),

                new Tuple<INumberSetElement<double>, INumberSetElement<double>, bool>(NumberSetElement<double>.Create(2, 3, true, true), NumberSetElement<double>.Create(2.2, 4, true, true), true),
                new Tuple<INumberSetElement<double>, INumberSetElement<double>, bool>(NumberSetElement<double>.Create(2, 3, true, true), NumberSetElement<double>.Create(1, 2.5, true, true), true),
                new Tuple<INumberSetElement<double>, INumberSetElement<double>, bool>(NumberSetElement<double>.Create(2, 3, true, true), NumberSetElement<double>.Create(2, 4, true, true), true),
                new Tuple<INumberSetElement<double>, INumberSetElement<double>, bool>(NumberSetElement<double>.Create(2, 3, true, true), NumberSetElement<double>.Create(1, 3, true, true), true),
                new Tuple<INumberSetElement<double>, INumberSetElement<double>, bool>(NumberSetElement<double>.Create(2, 3, true, true), NumberSetElement<double>.Create(1, 4, true, true), true),

                new Tuple<INumberSetElement<double>, INumberSetElement<double>, bool>(NumberSetElement<double>.Create(2, 2, true, true), NumberSetElement<double>.Create(2, 3, true, true), true),
                new Tuple<INumberSetElement<double>, INumberSetElement<double>, bool>(NumberSetElement<double>.Create(2, 2, true, true), NumberSetElement<double>.Create(1, 2, true, true), true),
                new Tuple<INumberSetElement<double>, INumberSetElement<double>, bool>(NumberSetElement<double>.Create(2, 2, true, true), NumberSetElement<double>.Create(1, 3, true, true), true),

                new Tuple<INumberSetElement<double>, INumberSetElement<double>, bool>(NumberSetElement<double>.Empty, NumberSetElement<double>.Create(2, 2, true, true), true),
                new Tuple<INumberSetElement<double>, INumberSetElement<double>, bool>(NumberSetElement<double>.Empty, NumberSetElement<double>.Create(1, 2, true, true), true),
                new Tuple<INumberSetElement<double>, INumberSetElement<double>, bool>(NumberSetElement<double>.Empty, NumberSetElement<double>.Empty, true),

                new Tuple<INumberSetElement<double>, INumberSetElement<double>, bool>(NumberSetElement<double>.Create(2, 3, true, true), NumberSetElement<double>.Create(3, 4, true, true), true),
                new Tuple<INumberSetElement<double>, INumberSetElement<double>, bool>(NumberSetElement<double>.Create(2, 3, true, false), NumberSetElement<double>.Create(3, 4, true, true), false),
                new Tuple<INumberSetElement<double>, INumberSetElement<double>, bool>(NumberSetElement<double>.Create(2, 3, true, true), NumberSetElement<double>.Create(3, 4, false, true), false),
                new Tuple<INumberSetElement<double>, INumberSetElement<double>, bool>(NumberSetElement<double>.Create(2, 3, true, false), NumberSetElement<double>.Create(3, 4, false, true), false),
                new Tuple<INumberSetElement<double>, INumberSetElement<double>, bool>(NumberSetElement<double>.Create(2, 3, true, true), NumberSetElement<double>.Create(3.5, 4, true, true), false),
                new Tuple<INumberSetElement<double>, INumberSetElement<double>, bool>(NumberSetElement<double>.Create(2, 3, true, true), NumberSetElement<double>.Create(1, 2, true, true), true),
                new Tuple<INumberSetElement<double>, INumberSetElement<double>, bool>(NumberSetElement<double>.Create(2, 3, true, true), NumberSetElement<double>.Create(1, 2, true, false), false),
                new Tuple<INumberSetElement<double>, INumberSetElement<double>, bool>(NumberSetElement<double>.Create(2, 3, false, true), NumberSetElement<double>.Create(1, 2, true, true), false),
                new Tuple<INumberSetElement<double>, INumberSetElement<double>, bool>(NumberSetElement<double>.Create(2, 3, false, true), NumberSetElement<double>.Create(1, 2, true, false), false),
                new Tuple<INumberSetElement<double>, INumberSetElement<double>, bool>(NumberSetElement<double>.Create(2, 3, true, true), NumberSetElement<double>.Create(1, 1.5, true, true), false),

                new Tuple<INumberSetElement<double>, INumberSetElement<double>, bool>(NumberSetElement<double>.Create(3, 3, true, true), NumberSetElement<double>.Create(3, 4, true, true), true),
                new Tuple<INumberSetElement<double>, INumberSetElement<double>, bool>(NumberSetElement<double>.Create(3, 3, true, true), NumberSetElement<double>.Create(3, 4, false, true), false),
                new Tuple<INumberSetElement<double>, INumberSetElement<double>, bool>(NumberSetElement<double>.Create(3, 3, true, true), NumberSetElement<double>.Create(3.5, 4, true, true), false),
                new Tuple<INumberSetElement<double>, INumberSetElement<double>, bool>(NumberSetElement<double>.Create(2, 2, true, true), NumberSetElement<double>.Create(1, 2, true, true), true),
                new Tuple<INumberSetElement<double>, INumberSetElement<double>, bool>(NumberSetElement<double>.Create(2, 2, true, true), NumberSetElement<double>.Create(1, 2, true, false), false),
                new Tuple<INumberSetElement<double>, INumberSetElement<double>, bool>(NumberSetElement<double>.Create(2, 2, true, true), NumberSetElement<double>.Create(1, 1.5, true, true), false),

                new Tuple<INumberSetElement<double>, INumberSetElement<double>, bool>(NumberSetElement<double>.Create(2, 3, true, true), NumberSetElement<double>.Create(3, 3, true, true), true),
                new Tuple<INumberSetElement<double>, INumberSetElement<double>, bool>(NumberSetElement<double>.Create(2, 3, true, false), NumberSetElement<double>.Create(3, 3, true, true), false),
                new Tuple<INumberSetElement<double>, INumberSetElement<double>, bool>(NumberSetElement<double>.Create(2, 3, true, true), NumberSetElement<double>.Create(4, 4, true, true), false),
                new Tuple<INumberSetElement<double>, INumberSetElement<double>, bool>(NumberSetElement<double>.Create(2, 3, true, true), NumberSetElement<double>.Create(2, 2, true, true), true),
                new Tuple<INumberSetElement<double>, INumberSetElement<double>, bool>(NumberSetElement<double>.Create(2, 3, false, true), NumberSetElement<double>.Create(2, 2, true, true), false),
                new Tuple<INumberSetElement<double>, INumberSetElement<double>, bool>(NumberSetElement<double>.Create(2, 3, true, true), NumberSetElement<double>.Create(1, 1, true, true), false),

            };
            for (int i = 0; i < elementList.Count; i++)
                Assert.IsTrue(elementList[i].Item1.Intersects(elementList[i].Item2) == elementList[i].Item3);
        }

        [TestMethod]
        public void TestIntersectionNumberSetElement()
        {
            var elementList = new List<Tuple<INumberSetElement<double>, INumberSetElement<double>, NumberSet<double>>>()
            {
                new Tuple<INumberSetElement<double>, INumberSetElement<double>, NumberSet<double>>(NumberSetElement<double>.Create(2, 3, true, true), NumberSetElement<double>.Create(2, 3, false, false), NumberSet<double>.Create(NumberSetElement<double>.Create(2, 3, false, false))),
                new Tuple<INumberSetElement<double>, INumberSetElement<double>, NumberSet<double>>(NumberSetElement<double>.Create(2, 3, true, true), NumberSetElement<double>.Create(2, 3, false, true), NumberSet<double>.Create(NumberSetElement<double>.Create(2, 3, false, true))),
                new Tuple<INumberSetElement<double>, INumberSetElement<double>, NumberSet<double>>(NumberSetElement<double>.Create(2, 3, true, true), NumberSetElement<double>.Create(2, 3, true, false), NumberSet<double>.Create(NumberSetElement<double>.Create(2, 3, true, false))),
                new Tuple<INumberSetElement<double>, INumberSetElement<double>, NumberSet<double>>(NumberSetElement<double>.Create(2, 3, true, true), NumberSetElement<double>.Create(2, 3, true, true), NumberSet<double>.Create(NumberSetElement<double>.Create(2, 3, true, true))),

                new Tuple<INumberSetElement<double>, INumberSetElement<double>, NumberSet<double>>(NumberSetElement<double>.Create(2, 3, true, false), NumberSetElement<double>.Create(2, 3, false, false), NumberSet<double>.Create(NumberSetElement<double>.Create(2, 3, false, false))),
                new Tuple<INumberSetElement<double>, INumberSetElement<double>, NumberSet<double>>(NumberSetElement<double>.Create(2, 3, true, false), NumberSetElement<double>.Create(2, 3, false, true), NumberSet<double>.Create(NumberSetElement<double>.Create(2, 3, false, false))),
                new Tuple<INumberSetElement<double>, INumberSetElement<double>, NumberSet<double>>(NumberSetElement<double>.Create(2, 3, true, false), NumberSetElement<double>.Create(2, 3, true, false), NumberSet<double>.Create(NumberSetElement<double>.Create(2, 3, true, false))),
                new Tuple<INumberSetElement<double>, INumberSetElement<double>, NumberSet<double>>(NumberSetElement<double>.Create(2, 3, true, false), NumberSetElement<double>.Create(2, 3, true, true), NumberSet<double>.Create(NumberSetElement<double>.Create(2, 3, true, false))),

                new Tuple<INumberSetElement<double>, INumberSetElement<double>, NumberSet<double>>(NumberSetElement<double>.Create(2, 3, false, true), NumberSetElement<double>.Create(2, 3, false, false), NumberSet<double>.Create(NumberSetElement<double>.Create(2, 3, false, false))),
                new Tuple<INumberSetElement<double>, INumberSetElement<double>, NumberSet<double>>(NumberSetElement<double>.Create(2, 3, false, true), NumberSetElement<double>.Create(2, 3, false, true), NumberSet<double>.Create(NumberSetElement<double>.Create(2, 3, false, true))),
                new Tuple<INumberSetElement<double>, INumberSetElement<double>, NumberSet<double>>(NumberSetElement<double>.Create(2, 3, false, true), NumberSetElement<double>.Create(2, 3, true, false), NumberSet<double>.Create(NumberSetElement<double>.Create(2, 3, false, false))),
                new Tuple<INumberSetElement<double>, INumberSetElement<double>, NumberSet<double>>(NumberSetElement<double>.Create(2, 3, false, true), NumberSetElement<double>.Create(2, 3, true, true), NumberSet<double>.Create(NumberSetElement<double>.Create(2, 3, false, true))),

                new Tuple<INumberSetElement<double>, INumberSetElement<double>, NumberSet<double>>(NumberSetElement<double>.Create(2, 3, false, false), NumberSetElement<double>.Create(2, 3, false, false), NumberSet<double>.Create(NumberSetElement<double>.Create(2, 3, false, false))),
                new Tuple<INumberSetElement<double>, INumberSetElement<double>, NumberSet<double>>(NumberSetElement<double>.Create(2, 3, false, false), NumberSetElement<double>.Create(2, 3, false, true), NumberSet<double>.Create(NumberSetElement<double>.Create(2, 3, false, false))),
                new Tuple<INumberSetElement<double>, INumberSetElement<double>, NumberSet<double>>(NumberSetElement<double>.Create(2, 3, false, false), NumberSetElement<double>.Create(2, 3, true, false), NumberSet<double>.Create(NumberSetElement<double>.Create(2, 3, false, false))),
                new Tuple<INumberSetElement<double>, INumberSetElement<double>, NumberSet<double>>(NumberSetElement<double>.Create(2, 3, false, false), NumberSetElement<double>.Create(2, 3, true, true), NumberSet<double>.Create(NumberSetElement<double>.Create(2, 3, false, false))),

                new Tuple<INumberSetElement<double>, INumberSetElement<double>, NumberSet<double>>(NumberSetElement<double>.Create(2, 3, true, true), NumberSetElement<double>.Create(2.2, 2.8, true, true), NumberSet<double>.Create(NumberSetElement<double>.Create(2.2, 2.8, true, true))),
                new Tuple<INumberSetElement<double>, INumberSetElement<double>, NumberSet<double>>(NumberSetElement<double>.Create(2, 3, true, true), NumberSetElement<double>.Create(2.2, 3, true, true), NumberSet<double>.Create(NumberSetElement<double>.Create(2.2, 3, true, true))),
                new Tuple<INumberSetElement<double>, INumberSetElement<double>, NumberSet<double>>(NumberSetElement<double>.Create(2, 3, true, true), NumberSetElement<double>.Create(2, 2.8, true, true), NumberSet<double>.Create(NumberSetElement<double>.Create(2, 2.8, true, true))),
                new Tuple<INumberSetElement<double>, INumberSetElement<double>, NumberSet<double>>(NumberSetElement<double>.Create(2, 3, true, true), NumberSetElement<double>.Empty, NumberSet<double>.Empty),

                new Tuple<INumberSetElement<double>, INumberSetElement<double>, NumberSet<double>>(NumberSetElement<double>.Create(2, 2, true, true), NumberSetElement<double>.Create(2, 2, true, true), NumberSet<double>.Create(NumberSetElement<double>.Create(2, 2, true, true))),
                new Tuple<INumberSetElement<double>, INumberSetElement<double>, NumberSet<double>>(NumberSetElement<double>.Create(2, 2, true, true), NumberSetElement<double>.Empty, NumberSet<double>.Empty),

                new Tuple<INumberSetElement<double>, INumberSetElement<double>, NumberSet<double>>(NumberSetElement<double>.Create(2, 3, true, true), NumberSetElement<double>.Create(2.2, 4, true, true), NumberSet<double>.Create(NumberSetElement<double>.Create(2.2, 3, true, true))),
                new Tuple<INumberSetElement<double>, INumberSetElement<double>, NumberSet<double>>(NumberSetElement<double>.Create(2, 3, true, true), NumberSetElement<double>.Create(1, 2.5, true, true), NumberSet<double>.Create(NumberSetElement<double>.Create(2, 2.5, true, true))),
                new Tuple<INumberSetElement<double>, INumberSetElement<double>, NumberSet<double>>(NumberSetElement<double>.Create(2, 3, true, true), NumberSetElement<double>.Create(2, 4, true, true), NumberSet<double>.Create(NumberSetElement<double>.Create(2, 3, true, true))),
                new Tuple<INumberSetElement<double>, INumberSetElement<double>, NumberSet<double>>(NumberSetElement<double>.Create(2, 3, true, true), NumberSetElement<double>.Create(1, 3, true, true), NumberSet<double>.Create(NumberSetElement<double>.Create(2, 3, true, true))),
                new Tuple<INumberSetElement<double>, INumberSetElement<double>, NumberSet<double>>(NumberSetElement<double>.Create(2, 3, true, true), NumberSetElement<double>.Create(1, 4, true, true), NumberSet<double>.Create(NumberSetElement<double>.Create(2, 3, true, true))),

                new Tuple<INumberSetElement<double>, INumberSetElement<double>, NumberSet<double>>(NumberSetElement<double>.Create(2, 2, true, true), NumberSetElement<double>.Create(2, 3, true, true), NumberSet<double>.Create(NumberSetElement<double>.Create(2, 2, true, true))),
                new Tuple<INumberSetElement<double>, INumberSetElement<double>, NumberSet<double>>(NumberSetElement<double>.Create(2, 2, true, true), NumberSetElement<double>.Create(1, 2, true, true), NumberSet<double>.Create(NumberSetElement<double>.Create(2, 2, true, true))),
                new Tuple<INumberSetElement<double>, INumberSetElement<double>, NumberSet<double>>(NumberSetElement<double>.Create(2, 2, true, true), NumberSetElement<double>.Create(1, 3, true, true), NumberSet<double>.Create(NumberSetElement<double>.Create(2, 2, true, true))),

                new Tuple<INumberSetElement<double>, INumberSetElement<double>, NumberSet<double>>(NumberSetElement<double>.Empty, NumberSetElement<double>.Create(2, 2, true, true), NumberSet<double>.Empty),
                new Tuple<INumberSetElement<double>, INumberSetElement<double>, NumberSet<double>>(NumberSetElement<double>.Empty, NumberSetElement<double>.Create(1, 2, true, true), NumberSet<double>.Empty),
                new Tuple<INumberSetElement<double>, INumberSetElement<double>, NumberSet<double>>(NumberSetElement<double>.Empty, NumberSetElement<double>.Empty, NumberSet<double>.Empty),

                new Tuple<INumberSetElement<double>, INumberSetElement<double>, NumberSet<double>>(NumberSetElement<double>.Create(2, 3, true, true), NumberSetElement<double>.Create(3, 4, true, true), NumberSet<double>.Create(NumberSetElement<double>.Create(3, 3, true, true))),
                new Tuple<INumberSetElement<double>, INumberSetElement<double>, NumberSet<double>>(NumberSetElement<double>.Create(2, 3, true, false), NumberSetElement<double>.Create(3, 4, true, true), NumberSet<double>.Empty),
                new Tuple<INumberSetElement<double>, INumberSetElement<double>, NumberSet<double>>(NumberSetElement<double>.Create(2, 3, true, true), NumberSetElement<double>.Create(3, 4, false, true), NumberSet<double>.Empty),
                new Tuple<INumberSetElement<double>, INumberSetElement<double>, NumberSet<double>>(NumberSetElement<double>.Create(2, 3, true, false), NumberSetElement<double>.Create(3, 4, false, true), NumberSet<double>.Empty),
                new Tuple<INumberSetElement<double>, INumberSetElement<double>, NumberSet<double>>(NumberSetElement<double>.Create(2, 3, true, true), NumberSetElement<double>.Create(3.5, 4, true, true), NumberSet<double>.Empty),
                new Tuple<INumberSetElement<double>, INumberSetElement<double>, NumberSet<double>>(NumberSetElement<double>.Create(2, 3, true, true), NumberSetElement<double>.Create(1, 2, true, true), NumberSet<double>.Create(NumberSetElement<double>.Create(2, 2, true, true))),
                new Tuple<INumberSetElement<double>, INumberSetElement<double>, NumberSet<double>>(NumberSetElement<double>.Create(2, 3, true, true), NumberSetElement<double>.Create(1, 2, true, false), NumberSet<double>.Empty),
                new Tuple<INumberSetElement<double>, INumberSetElement<double>, NumberSet<double>>(NumberSetElement<double>.Create(2, 3, false, true), NumberSetElement<double>.Create(1, 2, true, true), NumberSet<double>.Empty),
                new Tuple<INumberSetElement<double>, INumberSetElement<double>, NumberSet<double>>(NumberSetElement<double>.Create(2, 3, false, true), NumberSetElement<double>.Create(1, 2, true, false), NumberSet<double>.Empty),
                new Tuple<INumberSetElement<double>, INumberSetElement<double>, NumberSet<double>>(NumberSetElement<double>.Create(2, 3, true, true), NumberSetElement<double>.Create(1, 1.5, true, true), NumberSet<double>.Empty),

                new Tuple<INumberSetElement<double>, INumberSetElement<double>, NumberSet<double>>(NumberSetElement<double>.Create(3, 3, true, true), NumberSetElement<double>.Create(3, 4, true, true), NumberSet<double>.Create(NumberSetElement<double>.Create(3, 3, true, true))),
                new Tuple<INumberSetElement<double>, INumberSetElement<double>, NumberSet<double>>(NumberSetElement<double>.Create(3, 3, true, true), NumberSetElement<double>.Create(3, 4, false, true), NumberSet<double>.Empty),
                new Tuple<INumberSetElement<double>, INumberSetElement<double>, NumberSet<double>>(NumberSetElement<double>.Create(3, 3, true, true), NumberSetElement<double>.Create(3.5, 4, true, true), NumberSet<double>.Empty),
                new Tuple<INumberSetElement<double>, INumberSetElement<double>, NumberSet<double>>(NumberSetElement<double>.Create(2, 2, true, true), NumberSetElement<double>.Create(1, 2, true, true), NumberSet<double>.Create(NumberSetElement<double>.Create(2, 2, true, true))),
                new Tuple<INumberSetElement<double>, INumberSetElement<double>, NumberSet<double>>(NumberSetElement<double>.Create(2, 2, true, true), NumberSetElement<double>.Create(1, 2, true, false), NumberSet<double>.Empty),
                new Tuple<INumberSetElement<double>, INumberSetElement<double>, NumberSet<double>>(NumberSetElement<double>.Create(2, 2, true, true), NumberSetElement<double>.Create(1, 1.5, true, true), NumberSet<double>.Empty),

                new Tuple<INumberSetElement<double>, INumberSetElement<double>, NumberSet<double>>(NumberSetElement<double>.Create(2, 3, true, true), NumberSetElement<double>.Create(3, 3, true, true), NumberSet<double>.Create(NumberSetElement<double>.Create(3, 3, true, true))),
                new Tuple<INumberSetElement<double>, INumberSetElement<double>, NumberSet<double>>(NumberSetElement<double>.Create(2, 3, true, false), NumberSetElement<double>.Create(3, 3, true, true), NumberSet<double>.Empty),
                new Tuple<INumberSetElement<double>, INumberSetElement<double>, NumberSet<double>>(NumberSetElement<double>.Create(2, 3, true, true), NumberSetElement<double>.Create(4, 4, true, true), NumberSet<double>.Empty),
                new Tuple<INumberSetElement<double>, INumberSetElement<double>, NumberSet<double>>(NumberSetElement<double>.Create(2, 3, true, true), NumberSetElement<double>.Create(2, 2, true, true), NumberSet<double>.Create(NumberSetElement<double>.Create(2, 2, true, true))),
                new Tuple<INumberSetElement<double>, INumberSetElement<double>, NumberSet<double>>(NumberSetElement<double>.Create(2, 3, false, true), NumberSetElement<double>.Create(2, 2, true, true), NumberSet<double>.Empty),
                new Tuple<INumberSetElement<double>, INumberSetElement<double>, NumberSet<double>>(NumberSetElement<double>.Create(2, 3, true, true), NumberSetElement<double>.Create(1, 1, true, true), NumberSet<double>.Empty),

            };
            for (int i = 0; i < elementList.Count; i++)
                Assert.IsTrue(elementList[i].Item1.Intersection(elementList[i].Item2).Equals(elementList[i].Item3));
        }

        [TestMethod]
        public void TestIntersectsNumberSet()
        {
            var elementList = new List<Tuple<INumberSetElement<double>, NumberSet<double>, bool>>()
            {
                new Tuple<INumberSetElement<double>, NumberSet<double>, bool>(NumberSetElement<double>.Create(2, 3, true, true), NumberSet<double>.Create(NumberSetElement<double>.Create(2, 3, false, false)), true),
                new Tuple<INumberSetElement<double>, NumberSet<double>, bool>(NumberSetElement<double>.Create(2, 3, true, true), NumberSet<double>.Create(NumberSetElement<double>.Create(2, 3, false, true)), true),
                new Tuple<INumberSetElement<double>, NumberSet<double>, bool>(NumberSetElement<double>.Create(2, 3, true, true), NumberSet<double>.Create(NumberSetElement<double>.Create(2, 3, true, false)), true),
                new Tuple<INumberSetElement<double>, NumberSet<double>, bool>(NumberSetElement<double>.Create(2, 3, true, true), NumberSet<double>.Create(NumberSetElement<double>.Create(2, 3, true, true)), true),

                new Tuple<INumberSetElement<double>, NumberSet<double>, bool>(NumberSetElement<double>.Create(2, 3, true, false), NumberSet<double>.Create(NumberSetElement<double>.Create(2, 3, false, false)), true),
                new Tuple<INumberSetElement<double>, NumberSet<double>, bool>(NumberSetElement<double>.Create(2, 3, true, false), NumberSet<double>.Create(NumberSetElement<double>.Create(2, 3, false, true)), true),
                new Tuple<INumberSetElement<double>, NumberSet<double>, bool>(NumberSetElement<double>.Create(2, 3, true, false), NumberSet<double>.Create(NumberSetElement<double>.Create(2, 3, true, false)), true),
                new Tuple<INumberSetElement<double>, NumberSet<double>, bool>(NumberSetElement<double>.Create(2, 3, true, false), NumberSet<double>.Create(NumberSetElement<double>.Create(2, 3, true, true)), true),

                new Tuple<INumberSetElement<double>, NumberSet<double>, bool>(NumberSetElement<double>.Create(2, 3, false, true), NumberSet<double>.Create(NumberSetElement<double>.Create(2, 3, false, false)), true),
                new Tuple<INumberSetElement<double>, NumberSet<double>, bool>(NumberSetElement<double>.Create(2, 3, false, true), NumberSet<double>.Create(NumberSetElement<double>.Create(2, 3, false, true)), true),
                new Tuple<INumberSetElement<double>, NumberSet<double>, bool>(NumberSetElement<double>.Create(2, 3, false, true), NumberSet<double>.Create(NumberSetElement<double>.Create(2, 3, true, false)), true),
                new Tuple<INumberSetElement<double>, NumberSet<double>, bool>(NumberSetElement<double>.Create(2, 3, false, true), NumberSet<double>.Create(NumberSetElement<double>.Create(2, 3, true, true)), true),

                new Tuple<INumberSetElement<double>, NumberSet<double>, bool>(NumberSetElement<double>.Create(2, 3, false, false), NumberSet<double>.Create(NumberSetElement<double>.Create(2, 3, false, false)), true),
                new Tuple<INumberSetElement<double>, NumberSet<double>, bool>(NumberSetElement<double>.Create(2, 3, false, false), NumberSet<double>.Create(NumberSetElement<double>.Create(2, 3, false, true)), true),
                new Tuple<INumberSetElement<double>, NumberSet<double>, bool>(NumberSetElement<double>.Create(2, 3, false, false), NumberSet<double>.Create(NumberSetElement<double>.Create(2, 3, true, false)), true),
                new Tuple<INumberSetElement<double>, NumberSet<double>, bool>(NumberSetElement<double>.Create(2, 3, false, false), NumberSet<double>.Create(NumberSetElement<double>.Create(2, 3, true, true)), true),

                new Tuple<INumberSetElement<double>, NumberSet<double>, bool>(NumberSetElement<double>.Create(2, 3, true, true), NumberSet<double>.Create(NumberSetElement<double>.Create(2.2, 2.8, true, true)), true),
                new Tuple<INumberSetElement<double>, NumberSet<double>, bool>(NumberSetElement<double>.Create(2, 3, true, true), NumberSet<double>.Create(NumberSetElement<double>.Create(2.2, 3, true, true)), true),
                new Tuple<INumberSetElement<double>, NumberSet<double>, bool>(NumberSetElement<double>.Create(2, 3, true, true), NumberSet<double>.Create(NumberSetElement<double>.Create(2, 2.8, true, true)), true),
                new Tuple<INumberSetElement<double>, NumberSet<double>, bool>(NumberSetElement<double>.Create(2, 3, true, true), NumberSet<double>.Empty, true),

                new Tuple<INumberSetElement<double>, NumberSet<double>, bool>(NumberSetElement<double>.Create(2, 2, true, true), NumberSet<double>.Create(NumberSetElement<double>.Create(2, 2, true, true)), true),
                new Tuple<INumberSetElement<double>, NumberSet<double>, bool>(NumberSetElement<double>.Create(2, 2, true, true), NumberSet<double>.Empty, true),

                new Tuple<INumberSetElement<double>, NumberSet<double>, bool>(NumberSetElement<double>.Create(2, 3, true, true), NumberSet<double>.Create(NumberSetElement<double>.Create(2.2, 4, true, true)), true),
                new Tuple<INumberSetElement<double>, NumberSet<double>, bool>(NumberSetElement<double>.Create(2, 3, true, true), NumberSet<double>.Create(NumberSetElement<double>.Create(1, 2.5, true, true)), true),
                new Tuple<INumberSetElement<double>, NumberSet<double>, bool>(NumberSetElement<double>.Create(2, 3, true, true), NumberSet<double>.Create(NumberSetElement<double>.Create(2, 4, true, true)), true),
                new Tuple<INumberSetElement<double>, NumberSet<double>, bool>(NumberSetElement<double>.Create(2, 3, true, true), NumberSet<double>.Create(NumberSetElement<double>.Create(1, 3, true, true)), true),
                new Tuple<INumberSetElement<double>, NumberSet<double>, bool>(NumberSetElement<double>.Create(2, 3, true, true), NumberSet<double>.Create(NumberSetElement<double>.Create(1, 4, true, true)), true),

                new Tuple<INumberSetElement<double>, NumberSet<double>, bool>(NumberSetElement<double>.Create(2, 2, true, true), NumberSet<double>.Create(NumberSetElement<double>.Create(2, 3, true, true)), true),
                new Tuple<INumberSetElement<double>, NumberSet<double>, bool>(NumberSetElement<double>.Create(2, 2, true, true), NumberSet<double>.Create(NumberSetElement<double>.Create(1, 2, true, true)), true),
                new Tuple<INumberSetElement<double>, NumberSet<double>, bool>(NumberSetElement<double>.Create(2, 2, true, true), NumberSet<double>.Create(NumberSetElement<double>.Create(1, 3, true, true)), true),

                new Tuple<INumberSetElement<double>, NumberSet<double>, bool>(NumberSetElement<double>.Empty, NumberSet<double>.Create(NumberSetElement<double>.Create(2, 2, true, true)), true),
                new Tuple<INumberSetElement<double>, NumberSet<double>, bool>(NumberSetElement<double>.Empty, NumberSet<double>.Create(NumberSetElement<double>.Create(1, 2, true, true)), true),
                new Tuple<INumberSetElement<double>, NumberSet<double>, bool>(NumberSetElement<double>.Empty, NumberSet<double>.Empty, true),

                new Tuple<INumberSetElement<double>, NumberSet<double>, bool>(NumberSetElement<double>.Create(2, 3, true, true), NumberSet<double>.Create(NumberSetElement<double>.Create(3, 4, true, true)), true),
                new Tuple<INumberSetElement<double>, NumberSet<double>, bool>(NumberSetElement<double>.Create(2, 3, true, false), NumberSet<double>.Create(NumberSetElement<double>.Create(3, 4, true, true)), false),
                new Tuple<INumberSetElement<double>, NumberSet<double>, bool>(NumberSetElement<double>.Create(2, 3, true, true), NumberSet<double>.Create(NumberSetElement<double>.Create(3, 4, false, true)), false),
                new Tuple<INumberSetElement<double>, NumberSet<double>, bool>(NumberSetElement<double>.Create(2, 3, true, false), NumberSet<double>.Create(NumberSetElement<double>.Create(3, 4, false, true)), false),
                new Tuple<INumberSetElement<double>, NumberSet<double>, bool>(NumberSetElement<double>.Create(2, 3, true, true), NumberSet<double>.Create(NumberSetElement<double>.Create(3.5, 4, true, true)), false),
                new Tuple<INumberSetElement<double>, NumberSet<double>, bool>(NumberSetElement<double>.Create(2, 3, true, true), NumberSet<double>.Create(NumberSetElement<double>.Create(1, 2, true, true)), true),
                new Tuple<INumberSetElement<double>, NumberSet<double>, bool>(NumberSetElement<double>.Create(2, 3, true, true), NumberSet<double>.Create(NumberSetElement<double>.Create(1, 2, true, false)), false),
                new Tuple<INumberSetElement<double>, NumberSet<double>, bool>(NumberSetElement<double>.Create(2, 3, false, true), NumberSet<double>.Create(NumberSetElement<double>.Create(1, 2, true, true)), false),
                new Tuple<INumberSetElement<double>, NumberSet<double>, bool>(NumberSetElement<double>.Create(2, 3, false, true), NumberSet<double>.Create(NumberSetElement<double>.Create(1, 2, true, false)), false),
                new Tuple<INumberSetElement<double>, NumberSet<double>, bool>(NumberSetElement<double>.Create(2, 3, true, true), NumberSet<double>.Create(NumberSetElement<double>.Create(1, 1.5, true, true)), false),

                new Tuple<INumberSetElement<double>, NumberSet<double>, bool>(NumberSetElement<double>.Create(3, 3, true, true), NumberSet<double>.Create(NumberSetElement<double>.Create(3, 4, true, true)), true),
                new Tuple<INumberSetElement<double>, NumberSet<double>, bool>(NumberSetElement<double>.Create(3, 3, true, true), NumberSet<double>.Create(NumberSetElement<double>.Create(3, 4, false, true)), false),
                new Tuple<INumberSetElement<double>, NumberSet<double>, bool>(NumberSetElement<double>.Create(3, 3, true, true), NumberSet<double>.Create(NumberSetElement<double>.Create(3.5, 4, true, true)), false),
                new Tuple<INumberSetElement<double>, NumberSet<double>, bool>(NumberSetElement<double>.Create(2, 2, true, true), NumberSet<double>.Create(NumberSetElement<double>.Create(1, 2, true, true)), true),
                new Tuple<INumberSetElement<double>, NumberSet<double>, bool>(NumberSetElement<double>.Create(2, 2, true, true), NumberSet<double>.Create(NumberSetElement<double>.Create(1, 2, true, false)), false),
                new Tuple<INumberSetElement<double>, NumberSet<double>, bool>(NumberSetElement<double>.Create(2, 2, true, true), NumberSet<double>.Create(NumberSetElement<double>.Create(1, 1.5, true, true)), false),

                new Tuple<INumberSetElement<double>, NumberSet<double>, bool>(NumberSetElement<double>.Create(2, 3, true, true), NumberSet<double>.Create(NumberSetElement<double>.Create(3, 3, true, true)), true),
                new Tuple<INumberSetElement<double>, NumberSet<double>, bool>(NumberSetElement<double>.Create(2, 3, true, false), NumberSet<double>.Create(NumberSetElement<double>.Create(3, 3, true, true)), false),
                new Tuple<INumberSetElement<double>, NumberSet<double>, bool>(NumberSetElement<double>.Create(2, 3, true, true), NumberSet<double>.Create(NumberSetElement<double>.Create(4, 4, true, true)), false),
                new Tuple<INumberSetElement<double>, NumberSet<double>, bool>(NumberSetElement<double>.Create(2, 3, true, true), NumberSet<double>.Create(NumberSetElement<double>.Create(2, 2, true, true)), true),
                new Tuple<INumberSetElement<double>, NumberSet<double>, bool>(NumberSetElement<double>.Create(2, 3, false, true), NumberSet<double>.Create(NumberSetElement<double>.Create(2, 2, true, true)), false),
                new Tuple<INumberSetElement<double>, NumberSet<double>, bool>(NumberSetElement<double>.Create(2, 3, true, true), NumberSet<double>.Create(NumberSetElement<double>.Create(1, 1, true, true)), false),

                new Tuple<INumberSetElement<double>, NumberSet<double>, bool>(NumberSetElement<double>.Create(2, 3, true, true), NumberSet<double>.Create(NumberSetElement<double>.Create(0, 0.5, false, false), NumberSetElement<double>.Create(2, 3, false, false)), true),
                new Tuple<INumberSetElement<double>, NumberSet<double>, bool>(NumberSetElement<double>.Create(2, 3, true, true), NumberSet<double>.Create(NumberSetElement<double>.Create(2, 3, false, false), NumberSetElement<double>.Create(7, 8, false, false)), true),

                new Tuple<INumberSetElement<double>, NumberSet<double>, bool>(NumberSetElement<double>.Create(2, 2, true, true), NumberSet<double>.Create(NumberSetElement<double>.Create(0, 0.5, false, false), NumberSetElement<double>.Create(2, 2, true, true)), true),
                new Tuple<INumberSetElement<double>, NumberSet<double>, bool>(NumberSetElement<double>.Create(2, 2, true, true), NumberSet<double>.Create(NumberSetElement<double>.Create(2, 2, true, true), NumberSetElement<double>.Create(7, 8, false, false)), true),

                new Tuple<INumberSetElement<double>, NumberSet<double>, bool>(NumberSetElement<double>.Create(2, 3, true, true), NumberSet<double>.Create(NumberSetElement<double>.Create(0, 0.5, false, false), NumberSetElement<double>.Create(2.2, 4, true, true)), true),
                new Tuple<INumberSetElement<double>, NumberSet<double>, bool>(NumberSetElement<double>.Create(2, 3, true, true), NumberSet<double>.Create(NumberSetElement<double>.Create(0, 0.5, false, false), NumberSetElement<double>.Create(1, 2.5, true, true)), true),
                new Tuple<INumberSetElement<double>, NumberSet<double>, bool>(NumberSetElement<double>.Create(2, 3, true, true), NumberSet<double>.Create(NumberSetElement<double>.Create(0, 0.5, false, false), NumberSetElement<double>.Create(2, 4, true, true)), true),
                new Tuple<INumberSetElement<double>, NumberSet<double>, bool>(NumberSetElement<double>.Create(2, 3, true, true), NumberSet<double>.Create(NumberSetElement<double>.Create(0, 0.5, false, false), NumberSetElement<double>.Create(1, 3, true, true)), true),
                new Tuple<INumberSetElement<double>, NumberSet<double>, bool>(NumberSetElement<double>.Create(2, 3, true, true), NumberSet<double>.Create(NumberSetElement<double>.Create(0, 0.5, false, false), NumberSetElement<double>.Create(1, 4, true, true)), true),
                new Tuple<INumberSetElement<double>, NumberSet<double>, bool>(NumberSetElement<double>.Create(2, 3, true, true), NumberSet<double>.Create(NumberSetElement<double>.Create(2.2, 4, true, true), NumberSetElement<double>.Create(7, 8, false, false)), true),
                new Tuple<INumberSetElement<double>, NumberSet<double>, bool>(NumberSetElement<double>.Create(2, 3, true, true), NumberSet<double>.Create(NumberSetElement<double>.Create(1, 2.5, true, true), NumberSetElement<double>.Create(7, 8, false, false)), true),
                new Tuple<INumberSetElement<double>, NumberSet<double>, bool>(NumberSetElement<double>.Create(2, 3, true, true), NumberSet<double>.Create(NumberSetElement<double>.Create(2, 4, true, true), NumberSetElement<double>.Create(7, 8, false, false)), true),
                new Tuple<INumberSetElement<double>, NumberSet<double>, bool>(NumberSetElement<double>.Create(2, 3, true, true), NumberSet<double>.Create(NumberSetElement<double>.Create(1, 3, true, true), NumberSetElement<double>.Create(7, 8, false, false)), true),
                new Tuple<INumberSetElement<double>, NumberSet<double>, bool>(NumberSetElement<double>.Create(2, 3, true, true), NumberSet<double>.Create(NumberSetElement<double>.Create(1, 4, true, true), NumberSetElement<double>.Create(7, 8, false, false)), true),

                new Tuple<INumberSetElement<double>, NumberSet<double>, bool>(NumberSetElement<double>.Empty, NumberSet<double>.Create(NumberSetElement<double>.Create(0, 0.5, false, false), NumberSetElement<double>.Create(2, 2, true, true)), true),
                new Tuple<INumberSetElement<double>, NumberSet<double>, bool>(NumberSetElement<double>.Empty, NumberSet<double>.Create(NumberSetElement<double>.Create(0, 0.5, false, false), NumberSetElement<double>.Create(1, 2, true, true)), true),
                new Tuple<INumberSetElement<double>, NumberSet<double>, bool>(NumberSetElement<double>.Empty, NumberSet<double>.Create(NumberSetElement<double>.Create(2, 2, true, true), NumberSetElement<double>.Create(7, 8, false, false)), true),
                new Tuple<INumberSetElement<double>, NumberSet<double>, bool>(NumberSetElement<double>.Empty, NumberSet<double>.Create(NumberSetElement<double>.Create(1, 2, true, true), NumberSetElement<double>.Create(7, 8, false, false)), true),

                new Tuple<INumberSetElement<double>, NumberSet<double>, bool>(NumberSetElement<double>.Create(2, 3, true, true), NumberSet<double>.Create(NumberSetElement<double>.Create(0, 0.5, false, false), NumberSetElement<double>.Create(3.5, 4, true, true)), false),
                new Tuple<INumberSetElement<double>, NumberSet<double>, bool>(NumberSetElement<double>.Create(2, 3, true, true), NumberSet<double>.Create(NumberSetElement<double>.Create(0, 0.5, false, false), NumberSetElement<double>.Create(1, 1.5, true, true)), false),
                new Tuple<INumberSetElement<double>, NumberSet<double>, bool>(NumberSetElement<double>.Create(2, 3, true, true), NumberSet<double>.Create(NumberSetElement<double>.Create(3.5, 4, true, true), NumberSetElement<double>.Create(7, 8, false, false)), false),
                new Tuple<INumberSetElement<double>, NumberSet<double>, bool>(NumberSetElement<double>.Create(2, 3, true, true), NumberSet<double>.Create(NumberSetElement<double>.Create(1, 1.5, true, true), NumberSetElement<double>.Create(7, 8, false, false)), false),

                new Tuple<INumberSetElement<double>, NumberSet<double>, bool>(NumberSetElement<double>.Create(2, 2, true, true), NumberSet<double>.Create(NumberSetElement<double>.Create(0, 0.5, false, false), NumberSetElement<double>.Create(2, 2, true, true)), true),
                new Tuple<INumberSetElement<double>, NumberSet<double>, bool>(NumberSetElement<double>.Create(2, 2, true, true), NumberSet<double>.Create(NumberSetElement<double>.Create(2, 2, true, true), NumberSetElement<double>.Create(7, 8, false, false)), true),
            };
            for (int i = 0; i < elementList.Count; i++)
                Assert.IsTrue(elementList[i].Item1.Intersects(elementList[i].Item2) == elementList[i].Item3);
        }

        [TestMethod]
        public void TestIntersectionNumberSet()
        {
            var elementList = new List<Tuple<INumberSetElement<double>, NumberSet<double>, NumberSet<double>>>()
            {
                new Tuple<INumberSetElement<double>, NumberSet<double>, NumberSet<double>>(NumberSetElement<double>.Create(2, 3, true, true), NumberSet<double>.Create(NumberSetElement<double>.Create(2, 3, false, false)), NumberSet<double>.Create(NumberSetElement<double>.Create(2, 3, false, false))),
                new Tuple<INumberSetElement<double>, NumberSet<double>, NumberSet<double>>(NumberSetElement<double>.Create(2, 3, true, true), NumberSet<double>.Create(NumberSetElement<double>.Create(2, 3, false, true)), NumberSet<double>.Create(NumberSetElement<double>.Create(2, 3, false, true))),
                new Tuple<INumberSetElement<double>, NumberSet<double>, NumberSet<double>>(NumberSetElement<double>.Create(2, 3, true, true), NumberSet<double>.Create(NumberSetElement<double>.Create(2, 3, true, false)), NumberSet<double>.Create(NumberSetElement<double>.Create(2, 3, true, false))),
                new Tuple<INumberSetElement<double>, NumberSet<double>, NumberSet<double>>(NumberSetElement<double>.Create(2, 3, true, true), NumberSet<double>.Create(NumberSetElement<double>.Create(2, 3, true, true)), NumberSet<double>.Create(NumberSetElement<double>.Create(2, 3, true, true))),

                new Tuple<INumberSetElement<double>, NumberSet<double>, NumberSet<double>>(NumberSetElement<double>.Create(2, 3, true, false), NumberSet<double>.Create(NumberSetElement<double>.Create(2, 3, false, false)), NumberSet<double>.Create(NumberSetElement<double>.Create(2, 3, false, false))),
                new Tuple<INumberSetElement<double>, NumberSet<double>, NumberSet<double>>(NumberSetElement<double>.Create(2, 3, true, false), NumberSet<double>.Create(NumberSetElement<double>.Create(2, 3, false, true)), NumberSet<double>.Create(NumberSetElement<double>.Create(2, 3, false, false))),
                new Tuple<INumberSetElement<double>, NumberSet<double>, NumberSet<double>>(NumberSetElement<double>.Create(2, 3, true, false), NumberSet<double>.Create(NumberSetElement<double>.Create(2, 3, true, false)), NumberSet<double>.Create(NumberSetElement<double>.Create(2, 3, true, false))),
                new Tuple<INumberSetElement<double>, NumberSet<double>, NumberSet<double>>(NumberSetElement<double>.Create(2, 3, true, false), NumberSet<double>.Create(NumberSetElement<double>.Create(2, 3, true, true)), NumberSet<double>.Create(NumberSetElement<double>.Create(2, 3, true, false))),

                new Tuple<INumberSetElement<double>, NumberSet<double>, NumberSet<double>>(NumberSetElement<double>.Create(2, 3, false, true), NumberSet<double>.Create(NumberSetElement<double>.Create(2, 3, false, false)), NumberSet<double>.Create(NumberSetElement<double>.Create(2, 3, false, false))),
                new Tuple<INumberSetElement<double>, NumberSet<double>, NumberSet<double>>(NumberSetElement<double>.Create(2, 3, false, true), NumberSet<double>.Create(NumberSetElement<double>.Create(2, 3, false, true)), NumberSet<double>.Create(NumberSetElement<double>.Create(2, 3, false, true))),
                new Tuple<INumberSetElement<double>, NumberSet<double>, NumberSet<double>>(NumberSetElement<double>.Create(2, 3, false, true), NumberSet<double>.Create(NumberSetElement<double>.Create(2, 3, true, false)), NumberSet<double>.Create(NumberSetElement<double>.Create(2, 3, false, false))),
                new Tuple<INumberSetElement<double>, NumberSet<double>, NumberSet<double>>(NumberSetElement<double>.Create(2, 3, false, true), NumberSet<double>.Create(NumberSetElement<double>.Create(2, 3, true, true)), NumberSet<double>.Create(NumberSetElement<double>.Create(2, 3, false, true))),

                new Tuple<INumberSetElement<double>, NumberSet<double>, NumberSet<double>>(NumberSetElement<double>.Create(2, 3, false, false), NumberSet<double>.Create(NumberSetElement<double>.Create(2, 3, false, false)), NumberSet<double>.Create(NumberSetElement<double>.Create(2, 3, false, false))),
                new Tuple<INumberSetElement<double>, NumberSet<double>, NumberSet<double>>(NumberSetElement<double>.Create(2, 3, false, false), NumberSet<double>.Create(NumberSetElement<double>.Create(2, 3, false, true)), NumberSet<double>.Create(NumberSetElement<double>.Create(2, 3, false, false))),
                new Tuple<INumberSetElement<double>, NumberSet<double>, NumberSet<double>>(NumberSetElement<double>.Create(2, 3, false, false), NumberSet<double>.Create(NumberSetElement<double>.Create(2, 3, true, false)), NumberSet<double>.Create(NumberSetElement<double>.Create(2, 3, false, false))),
                new Tuple<INumberSetElement<double>, NumberSet<double>, NumberSet<double>>(NumberSetElement<double>.Create(2, 3, false, false), NumberSet<double>.Create(NumberSetElement<double>.Create(2, 3, true, true)), NumberSet<double>.Create(NumberSetElement<double>.Create(2, 3, false, false))),

                new Tuple<INumberSetElement<double>, NumberSet<double>, NumberSet<double>>(NumberSetElement<double>.Create(2, 3, true, true), NumberSet<double>.Create(NumberSetElement<double>.Create(2.2, 2.8, true, true)), NumberSet<double>.Create(NumberSetElement<double>.Create(2.2, 2.8, true, true))),
                new Tuple<INumberSetElement<double>, NumberSet<double>, NumberSet<double>>(NumberSetElement<double>.Create(2, 3, true, true), NumberSet<double>.Create(NumberSetElement<double>.Create(2.2, 3, true, true)), NumberSet<double>.Create(NumberSetElement<double>.Create(2.2, 3, true, true))),
                new Tuple<INumberSetElement<double>, NumberSet<double>, NumberSet<double>>(NumberSetElement<double>.Create(2, 3, true, true), NumberSet<double>.Create(NumberSetElement<double>.Create(2, 2.8, true, true)), NumberSet<double>.Create(NumberSetElement<double>.Create(2, 2.8, true, true))),
                new Tuple<INumberSetElement<double>, NumberSet<double>, NumberSet<double>>(NumberSetElement<double>.Create(2, 3, true, true), NumberSet<double>.Create(NumberSetElement<double>.Empty), NumberSet<double>.Empty),

                new Tuple<INumberSetElement<double>, NumberSet<double>, NumberSet<double>>(NumberSetElement<double>.Create(2, 2, true, true), NumberSet<double>.Create(NumberSetElement<double>.Create(2, 2, true, true)), NumberSet<double>.Create(NumberSetElement<double>.Create(2, 2, true, true))),
                new Tuple<INumberSetElement<double>, NumberSet<double>, NumberSet<double>>(NumberSetElement<double>.Create(2, 2, true, true), NumberSet<double>.Empty, NumberSet<double>.Empty),

                new Tuple<INumberSetElement<double>, NumberSet<double>, NumberSet<double>>(NumberSetElement<double>.Create(2, 3, true, true), NumberSet<double>.Create(NumberSetElement<double>.Create(2.2, 4, true, true)), NumberSet<double>.Create(NumberSetElement<double>.Create(2.2, 3, true, true))),
                new Tuple<INumberSetElement<double>, NumberSet<double>, NumberSet<double>>(NumberSetElement<double>.Create(2, 3, true, true), NumberSet<double>.Create(NumberSetElement<double>.Create(1, 2.5, true, true)), NumberSet<double>.Create(NumberSetElement<double>.Create(2, 2.5, true, true))),
                new Tuple<INumberSetElement<double>, NumberSet<double>, NumberSet<double>>(NumberSetElement<double>.Create(2, 3, true, true), NumberSet<double>.Create(NumberSetElement<double>.Create(2, 4, true, true)), NumberSet<double>.Create(NumberSetElement<double>.Create(2, 3, true, true))),
                new Tuple<INumberSetElement<double>, NumberSet<double>, NumberSet<double>>(NumberSetElement<double>.Create(2, 3, true, true), NumberSet<double>.Create(NumberSetElement<double>.Create(1, 3, true, true)), NumberSet<double>.Create(NumberSetElement<double>.Create(2, 3, true, true))),
                new Tuple<INumberSetElement<double>, NumberSet<double>, NumberSet<double>>(NumberSetElement<double>.Create(2, 3, true, true), NumberSet<double>.Create(NumberSetElement<double>.Create(1, 4, true, true)), NumberSet<double>.Create(NumberSetElement<double>.Create(2, 3, true, true))),

                new Tuple<INumberSetElement<double>, NumberSet<double>, NumberSet<double>>(NumberSetElement<double>.Create(2, 2, true, true), NumberSet<double>.Create(NumberSetElement<double>.Create(2, 3, true, true)), NumberSet<double>.Create(NumberSetElement<double>.Create(2, 2, true, true))),
                new Tuple<INumberSetElement<double>, NumberSet<double>, NumberSet<double>>(NumberSetElement<double>.Create(2, 2, true, true), NumberSet<double>.Create(NumberSetElement<double>.Create(1, 2, true, true)), NumberSet<double>.Create(NumberSetElement<double>.Create(2, 2, true, true))),
                new Tuple<INumberSetElement<double>, NumberSet<double>, NumberSet<double>>(NumberSetElement<double>.Create(2, 2, true, true), NumberSet<double>.Create(NumberSetElement<double>.Create(1, 3, true, true)), NumberSet<double>.Create(NumberSetElement<double>.Create(2, 2, true, true))),

                new Tuple<INumberSetElement<double>, NumberSet<double>, NumberSet<double>>(NumberSetElement<double>.Empty, NumberSet<double>.Create(NumberSetElement<double>.Create(2, 2, true, true)), NumberSet<double>.Empty),
                new Tuple<INumberSetElement<double>, NumberSet<double>, NumberSet<double>>(NumberSetElement<double>.Empty, NumberSet<double>.Create(NumberSetElement<double>.Create(1, 2, true, true)), NumberSet<double>.Empty),
                new Tuple<INumberSetElement<double>, NumberSet<double>, NumberSet<double>>(NumberSetElement<double>.Empty, NumberSet<double>.Create(NumberSetElement<double>.Empty), NumberSet<double>.Empty),

                new Tuple<INumberSetElement<double>, NumberSet<double>, NumberSet<double>>(NumberSetElement<double>.Create(2, 3, true, true), NumberSet<double>.Create(NumberSetElement<double>.Create(3, 4, true, true)), NumberSet<double>.Create(NumberSetElement<double>.Create(3, 3, true, true))),
                new Tuple<INumberSetElement<double>, NumberSet<double>, NumberSet<double>>(NumberSetElement<double>.Create(2, 3, true, false), NumberSet<double>.Create(NumberSetElement<double>.Create(3, 4, true, true)), NumberSet<double>.Empty),
                new Tuple<INumberSetElement<double>, NumberSet<double>, NumberSet<double>>(NumberSetElement<double>.Create(2, 3, true, true), NumberSet<double>.Create(NumberSetElement<double>.Create(3, 4, false, true)), NumberSet<double>.Empty),
                new Tuple<INumberSetElement<double>, NumberSet<double>, NumberSet<double>>(NumberSetElement<double>.Create(2, 3, true, false), NumberSet<double>.Create(NumberSetElement<double>.Create(3, 4, false, true)), NumberSet<double>.Empty),
                new Tuple<INumberSetElement<double>, NumberSet<double>, NumberSet<double>>(NumberSetElement<double>.Create(2, 3, true, true), NumberSet<double>.Create(NumberSetElement<double>.Create(3.5, 4, true, true)), NumberSet<double>.Empty),
                new Tuple<INumberSetElement<double>, NumberSet<double>, NumberSet<double>>(NumberSetElement<double>.Create(2, 3, true, true), NumberSet<double>.Create(NumberSetElement<double>.Create(1, 2, true, true)), NumberSet<double>.Create(NumberSetElement<double>.Create(2, 2, true, true))),
                new Tuple<INumberSetElement<double>, NumberSet<double>, NumberSet<double>>(NumberSetElement<double>.Create(2, 3, true, true), NumberSet<double>.Create(NumberSetElement<double>.Create(1, 2, true, false)), NumberSet<double>.Empty),
                new Tuple<INumberSetElement<double>, NumberSet<double>, NumberSet<double>>(NumberSetElement<double>.Create(2, 3, false, true), NumberSet<double>.Create(NumberSetElement<double>.Create(1, 2, true, true)), NumberSet<double>.Empty),
                new Tuple<INumberSetElement<double>, NumberSet<double>, NumberSet<double>>(NumberSetElement<double>.Create(2, 3, false, true), NumberSet<double>.Create(NumberSetElement<double>.Create(1, 2, true, false)), NumberSet<double>.Empty),
                new Tuple<INumberSetElement<double>, NumberSet<double>, NumberSet<double>>(NumberSetElement<double>.Create(2, 3, true, true), NumberSet<double>.Create(NumberSetElement<double>.Create(1, 1.5, true, true)), NumberSet<double>.Empty),

                new Tuple<INumberSetElement<double>, NumberSet<double>, NumberSet<double>>(NumberSetElement<double>.Create(3, 3, true, true), NumberSet<double>.Create(NumberSetElement<double>.Create(3, 4, true, true)), NumberSet<double>.Create(NumberSetElement<double>.Create(3, 3, true, true))),
                new Tuple<INumberSetElement<double>, NumberSet<double>, NumberSet<double>>(NumberSetElement<double>.Create(3, 3, true, true), NumberSet<double>.Create(NumberSetElement<double>.Create(3, 4, false, true)), NumberSet<double>.Empty),
                new Tuple<INumberSetElement<double>, NumberSet<double>, NumberSet<double>>(NumberSetElement<double>.Create(3, 3, true, true), NumberSet<double>.Create(NumberSetElement<double>.Create(3.5, 4, true, true)), NumberSet<double>.Empty),
                new Tuple<INumberSetElement<double>, NumberSet<double>, NumberSet<double>>(NumberSetElement<double>.Create(2, 2, true, true), NumberSet<double>.Create(NumberSetElement<double>.Create(1, 2, true, true)), NumberSet<double>.Create(NumberSetElement<double>.Create(2, 2, true, true))),
                new Tuple<INumberSetElement<double>, NumberSet<double>, NumberSet<double>>(NumberSetElement<double>.Create(2, 2, true, true), NumberSet<double>.Create(NumberSetElement<double>.Create(1, 2, true, false)), NumberSet<double>.Empty),
                new Tuple<INumberSetElement<double>, NumberSet<double>, NumberSet<double>>(NumberSetElement<double>.Create(2, 2, true, true), NumberSet<double>.Create(NumberSetElement<double>.Create(1, 1.5, true, true)), NumberSet<double>.Empty),

                new Tuple<INumberSetElement<double>, NumberSet<double>, NumberSet<double>>(NumberSetElement<double>.Create(2, 3, true, true), NumberSet<double>.Create(NumberSetElement<double>.Create(3, 3, true, true)), NumberSet<double>.Create(NumberSetElement<double>.Create(3, 3, true, true))),
                new Tuple<INumberSetElement<double>, NumberSet<double>, NumberSet<double>>(NumberSetElement<double>.Create(2, 3, true, false), NumberSet<double>.Create(NumberSetElement<double>.Create(3, 3, true, true)), NumberSet<double>.Empty),
                new Tuple<INumberSetElement<double>, NumberSet<double>, NumberSet<double>>(NumberSetElement<double>.Create(2, 3, true, true), NumberSet<double>.Create(NumberSetElement<double>.Create(4, 4, true, true)), NumberSet<double>.Empty),
                new Tuple<INumberSetElement<double>, NumberSet<double>, NumberSet<double>>(NumberSetElement<double>.Create(2, 3, true, true), NumberSet<double>.Create(NumberSetElement<double>.Create(2, 2, true, true)), NumberSet<double>.Create(NumberSetElement<double>.Create(2, 2, true, true))),
                new Tuple<INumberSetElement<double>, NumberSet<double>, NumberSet<double>>(NumberSetElement<double>.Create(2, 3, false, true), NumberSet<double>.Create(NumberSetElement<double>.Create(2, 2, true, true)), NumberSet<double>.Empty),
                new Tuple<INumberSetElement<double>, NumberSet<double>, NumberSet<double>>(NumberSetElement<double>.Create(2, 3, true, true), NumberSet<double>.Create(NumberSetElement<double>.Create(1, 1, true, true)), NumberSet<double>.Empty),

                new Tuple<INumberSetElement<double>, NumberSet<double>, NumberSet<double>>(NumberSetElement<double>.Create(2, 3, true, true), NumberSet<double>.Create(NumberSetElement<double>.Create(0, 0.5, false, false), NumberSetElement<double>.Create(2, 3, false, false)), NumberSet<double>.Create(NumberSetElement<double>.Create(2, 3, false, false))),
                new Tuple<INumberSetElement<double>, NumberSet<double>, NumberSet<double>>(NumberSetElement<double>.Create(2, 3, true, true), NumberSet<double>.Create(NumberSetElement<double>.Create(2, 3, false, false), NumberSetElement<double>.Create(7, 8, false, false)), NumberSet<double>.Create(NumberSetElement<double>.Create(2, 3, false, false))),

                new Tuple<INumberSetElement<double>, NumberSet<double>, NumberSet<double>>(NumberSetElement<double>.Create(2, 2, true, true), NumberSet<double>.Create(NumberSetElement<double>.Create(0, 0.5, false, false), NumberSetElement<double>.Create(2, 2, true, true)), NumberSet<double>.Create(NumberSetElement<double>.Create(2, 2, true, true))),
                new Tuple<INumberSetElement<double>, NumberSet<double>, NumberSet<double>>(NumberSetElement<double>.Create(2, 2, true, true), NumberSet<double>.Create(NumberSetElement<double>.Create(2, 2, true, true), NumberSetElement<double>.Create(7, 8, false, false)), NumberSet<double>.Create(NumberSetElement<double>.Create(2, 2, true, true))),

                new Tuple<INumberSetElement<double>, NumberSet<double>, NumberSet<double>>(NumberSetElement<double>.Create(2, 3, true, true), NumberSet<double>.Create(NumberSetElement<double>.Create(0, 0.5, false, false), NumberSetElement<double>.Create(2.2, 4, true, true)), NumberSet<double>.Create(NumberSetElement<double>.Create(2.2, 3, true, true))),
                new Tuple<INumberSetElement<double>, NumberSet<double>, NumberSet<double>>(NumberSetElement<double>.Create(2, 3, true, true), NumberSet<double>.Create(NumberSetElement<double>.Create(0, 0.5, false, false), NumberSetElement<double>.Create(1, 2.5, true, true)), NumberSet<double>.Create(NumberSetElement<double>.Create(2, 2.5, true, true))),
                new Tuple<INumberSetElement<double>, NumberSet<double>, NumberSet<double>>(NumberSetElement<double>.Create(2, 3, true, true), NumberSet<double>.Create(NumberSetElement<double>.Create(0, 0.5, false, false), NumberSetElement<double>.Create(2, 4, true, true)), NumberSet<double>.Create(NumberSetElement<double>.Create(2, 3, true, true))),
                new Tuple<INumberSetElement<double>, NumberSet<double>, NumberSet<double>>(NumberSetElement<double>.Create(2, 3, true, true), NumberSet<double>.Create(NumberSetElement<double>.Create(0, 0.5, false, false), NumberSetElement<double>.Create(1, 3, true, true)), NumberSet<double>.Create(NumberSetElement<double>.Create(2, 3, true, true))),
                new Tuple<INumberSetElement<double>, NumberSet<double>, NumberSet<double>>(NumberSetElement<double>.Create(2, 3, true, true), NumberSet<double>.Create(NumberSetElement<double>.Create(0, 0.5, false, false), NumberSetElement<double>.Create(1, 4, false, false)), NumberSet<double>.Create(NumberSetElement<double>.Create(2, 3, true, true))),
                new Tuple<INumberSetElement<double>, NumberSet<double>, NumberSet<double>>(NumberSetElement<double>.Create(2, 3, true, true), NumberSet<double>.Create(NumberSetElement<double>.Create(2.2, 4, true, true), NumberSetElement<double>.Create(7, 8, false, false)), NumberSet<double>.Create(NumberSetElement<double>.Create(2.2, 3, true, true))),
                new Tuple<INumberSetElement<double>, NumberSet<double>, NumberSet<double>>(NumberSetElement<double>.Create(2, 3, true, true), NumberSet<double>.Create(NumberSetElement<double>.Create(1, 2.5, true, true), NumberSetElement<double>.Create(7, 8, false, false)), NumberSet<double>.Create(NumberSetElement<double>.Create(2, 2.5, true, true))),
                new Tuple<INumberSetElement<double>, NumberSet<double>, NumberSet<double>>(NumberSetElement<double>.Create(2, 3, true, true), NumberSet<double>.Create(NumberSetElement<double>.Create(2, 4, true, true), NumberSetElement<double>.Create(7, 8, false, false)), NumberSet<double>.Create(NumberSetElement<double>.Create(2, 3, true, true))),
                new Tuple<INumberSetElement<double>, NumberSet<double>, NumberSet<double>>(NumberSetElement<double>.Create(2, 3, true, true), NumberSet<double>.Create(NumberSetElement<double>.Create(1, 3, true, true), NumberSetElement<double>.Create(7, 8, false, false)), NumberSet<double>.Create(NumberSetElement<double>.Create(2, 3, true, true))),
                new Tuple<INumberSetElement<double>, NumberSet<double>, NumberSet<double>>(NumberSetElement<double>.Create(2, 3, true, true), NumberSet<double>.Create(NumberSetElement<double>.Create(1, 4, false, false), NumberSetElement<double>.Create(7, 8, false, false)), NumberSet<double>.Create(NumberSetElement<double>.Create(2, 3, true, true))),

                new Tuple<INumberSetElement<double>, NumberSet<double>, NumberSet<double>>(NumberSetElement<double>.Empty, NumberSet<double>.Create(NumberSetElement<double>.Create(0, 0.5, false, false), NumberSetElement<double>.Create(2, 2, true, true)), NumberSet<double>.Empty),
                new Tuple<INumberSetElement<double>, NumberSet<double>, NumberSet<double>>(NumberSetElement<double>.Empty, NumberSet<double>.Create(NumberSetElement<double>.Create(0, 0.5, false, false), NumberSetElement<double>.Create(1, 2, true, true)), NumberSet<double>.Empty),
                new Tuple<INumberSetElement<double>, NumberSet<double>, NumberSet<double>>(NumberSetElement<double>.Empty, NumberSet<double>.Create(NumberSetElement<double>.Create(2, 2, true, true), NumberSetElement<double>.Create(7, 8, false, false)), NumberSet<double>.Empty),
                new Tuple<INumberSetElement<double>, NumberSet<double>, NumberSet<double>>(NumberSetElement<double>.Empty, NumberSet<double>.Create(NumberSetElement<double>.Create(1, 2, true, true), NumberSetElement<double>.Create(7, 8, false, false)), NumberSet<double>.Empty),

                new Tuple<INumberSetElement<double>, NumberSet<double>, NumberSet<double>>(NumberSetElement<double>.Create(2, 3, true, true), NumberSet<double>.Create(NumberSetElement<double>.Create(0, 0.5, false, false), NumberSetElement<double>.Create(3.5, 4, true, true)), NumberSet<double>.Empty),
                new Tuple<INumberSetElement<double>, NumberSet<double>, NumberSet<double>>(NumberSetElement<double>.Create(2, 3, true, true), NumberSet<double>.Create(NumberSetElement<double>.Create(0, 0.5, false, false), NumberSetElement<double>.Create(1, 1.5, true, true)), NumberSet<double>.Empty),
                new Tuple<INumberSetElement<double>, NumberSet<double>, NumberSet<double>>(NumberSetElement<double>.Create(2, 3, true, true), NumberSet<double>.Create(NumberSetElement<double>.Create(3.5, 4, true, true), NumberSetElement<double>.Create(7, 8, false, false)), NumberSet<double>.Empty),
                new Tuple<INumberSetElement<double>, NumberSet<double>, NumberSet<double>>(NumberSetElement<double>.Create(2, 3, true, true), NumberSet<double>.Create(NumberSetElement<double>.Create(1, 1.5, true, true), NumberSetElement<double>.Create(7, 8, false, false)), NumberSet<double>.Empty),

                new Tuple<INumberSetElement<double>, NumberSet<double>, NumberSet<double>>(NumberSetElement<double>.Create(2, 2, true, true), NumberSet<double>.Create(NumberSetElement<double>.Create(0, 0.5, false, false), NumberSetElement<double>.Create(2, 2, true, true)), NumberSet<double>.Create(NumberSetElement<double>.Create(2, 2, true, true))),
                new Tuple<INumberSetElement<double>, NumberSet<double>, NumberSet<double>>(NumberSetElement<double>.Create(2, 2, true, true), NumberSet<double>.Create(NumberSetElement<double>.Create(2, 2, true, true), NumberSetElement<double>.Create(7, 8, false, false)), NumberSet<double>.Create(NumberSetElement<double>.Create(2, 2, true, true))),

                new Tuple<INumberSetElement<double>, NumberSet<double>, NumberSet<double>>(NumberSetElement<double>.Create(2, 7, true, true), NumberSet<double>.Create(NumberSetElement<double>.Create(3, 4, false, false), NumberSetElement<double>.Create(5, 6, false, false)), NumberSet<double>.Create(NumberSetElement<double>.Create(3, 4, false, false), NumberSetElement<double>.Create(5, 6, false, false))),
                new Tuple<INumberSetElement<double>, NumberSet<double>, NumberSet<double>>(NumberSetElement<double>.Create(2, 7, true, true), NumberSet<double>.Create(NumberSetElement<double>.Create(1, 4, false, false), NumberSetElement<double>.Create(5, 6, false, false)), NumberSet<double>.Create(NumberSetElement<double>.Create(2, 4, true, false), NumberSetElement<double>.Create(5, 6, false, false))),
                new Tuple<INumberSetElement<double>, NumberSet<double>, NumberSet<double>>(NumberSetElement<double>.Create(2, 7, true, true), NumberSet<double>.Create(NumberSetElement<double>.Create(3, 4, false, false), NumberSetElement<double>.Create(5, 8, false, false)), NumberSet<double>.Create(NumberSetElement<double>.Create(3, 4, false, false), NumberSetElement<double>.Create(5, 7, false, true))),
                new Tuple<INumberSetElement<double>, NumberSet<double>, NumberSet<double>>(NumberSetElement<double>.Create(2, 7, true, true), NumberSet<double>.Create(NumberSetElement<double>.Create(1, 4, false, false), NumberSetElement<double>.Create(5, 8, false, false)), NumberSet<double>.Create(NumberSetElement<double>.Create(2, 4, true, false), NumberSetElement<double>.Create(5, 7, false, true))),
                new Tuple<INumberSetElement<double>, NumberSet<double>, NumberSet<double>>(NumberSetElement<double>.Create(2, 7, true, true), NumberSet<double>.Create(NumberSetElement<double>.Create(1, 4, false, false), NumberSetElement<double>.Create(4.1, 4.9, true, false), NumberSetElement<double>.Create(5, 8, false, false)), NumberSet<double>.Create(NumberSetElement<double>.Create(2, 4, true, false), NumberSetElement<double>.Create(4.1, 4.9, true, false), NumberSetElement<double>.Create(5, 7, false, true))),
                new Tuple<INumberSetElement<double>, NumberSet<double>, NumberSet<double>>(NumberSetElement<double>.Create(2, 7, true, true), NumberSet<double>.Create(NumberSetElement<double>.Create(1, 4, false, false), NumberSetElement<double>.Create(4, 5, false, false), NumberSetElement<double>.Create(5, 8, false, false)), NumberSet<double>.Create(NumberSetElement<double>.Create(2, 4, true, false), NumberSetElement<double>.Create(4, 5, false, false), NumberSetElement<double>.Create(5, 7, false, true))),
            };
            for (int i = 0; i < elementList.Count; i++)
                Assert.IsTrue(elementList[i].Item1.Intersection(elementList[i].Item2).Equals(elementList[i].Item3));
        }
    }
}
