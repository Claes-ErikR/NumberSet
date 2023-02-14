using NumberSet;

namespace NumberSetUnitTest.NumberSetElementUnitTest.Double
{
    [TestClass]
    public class IntersectNumberSetElementTest
    {
        [TestMethod]
        public void TestIntersectsNumberSetElement()
        {
            var elementList = new List<Tuple<NumberSetElement<double>, NumberSetElement<double>, bool>>()
            {
                new Tuple<NumberSetElement<double>, NumberSetElement<double>, bool>(NumberSetElement<double>.Create(2, 3, true, true), NumberSetElement<double>.Create(2, 3, false, false), true),
                new Tuple<NumberSetElement<double>, NumberSetElement<double>, bool>(NumberSetElement<double>.Create(2, 3, true, true), NumberSetElement<double>.Create(2, 3, false, true), true),
                new Tuple<NumberSetElement<double>, NumberSetElement<double>, bool>(NumberSetElement<double>.Create(2, 3, true, true), NumberSetElement<double>.Create(2, 3, true, false), true),
                new Tuple<NumberSetElement<double>, NumberSetElement<double>, bool>(NumberSetElement<double>.Create(2, 3, true, true), NumberSetElement<double>.Create(2, 3, true, true), true),

                new Tuple<NumberSetElement<double>, NumberSetElement<double>, bool>(NumberSetElement<double>.Create(2, 3, true, false), NumberSetElement<double>.Create(2, 3, false, false), true),
                new Tuple<NumberSetElement<double>, NumberSetElement<double>, bool>(NumberSetElement<double>.Create(2, 3, true, false), NumberSetElement<double>.Create(2, 3, false, true), true),
                new Tuple<NumberSetElement<double>, NumberSetElement<double>, bool>(NumberSetElement<double>.Create(2, 3, true, false), NumberSetElement<double>.Create(2, 3, true, false), true),
                new Tuple<NumberSetElement<double>, NumberSetElement<double>, bool>(NumberSetElement<double>.Create(2, 3, true, false), NumberSetElement<double>.Create(2, 3, true, true), true),

                new Tuple<NumberSetElement<double>, NumberSetElement<double>, bool>(NumberSetElement<double>.Create(2, 3, false, true), NumberSetElement<double>.Create(2, 3, false, false), true),
                new Tuple<NumberSetElement<double>, NumberSetElement<double>, bool>(NumberSetElement<double>.Create(2, 3, false, true), NumberSetElement<double>.Create(2, 3, false, true), true),
                new Tuple<NumberSetElement<double>, NumberSetElement<double>, bool>(NumberSetElement<double>.Create(2, 3, false, true), NumberSetElement<double>.Create(2, 3, true, false), true),
                new Tuple<NumberSetElement<double>, NumberSetElement<double>, bool>(NumberSetElement<double>.Create(2, 3, false, true), NumberSetElement<double>.Create(2, 3, true, true), true),

                new Tuple<NumberSetElement<double>, NumberSetElement<double>, bool>(NumberSetElement<double>.Create(2, 3, false, false), NumberSetElement<double>.Create(2, 3, false, false), true),
                new Tuple<NumberSetElement<double>, NumberSetElement<double>, bool>(NumberSetElement<double>.Create(2, 3, false, false), NumberSetElement<double>.Create(2, 3, false, true), true),
                new Tuple<NumberSetElement<double>, NumberSetElement<double>, bool>(NumberSetElement<double>.Create(2, 3, false, false), NumberSetElement<double>.Create(2, 3, true, false), true),
                new Tuple<NumberSetElement<double>, NumberSetElement<double>, bool>(NumberSetElement<double>.Create(2, 3, false, false), NumberSetElement<double>.Create(2, 3, true, true), true),

                new Tuple<NumberSetElement<double>, NumberSetElement<double>, bool>(NumberSetElement<double>.Create(2, 3, true, true), NumberSetElement<double>.Create(2.2, 2.8, true, true), true),
                new Tuple<NumberSetElement<double>, NumberSetElement<double>, bool>(NumberSetElement<double>.Create(2, 3, true, true), NumberSetElement<double>.Create(2.2, 3, true, true), true),
                new Tuple<NumberSetElement<double>, NumberSetElement<double>, bool>(NumberSetElement<double>.Create(2, 3, true, true), NumberSetElement<double>.Create(2, 2.8, true, true), true),
                new Tuple<NumberSetElement<double>, NumberSetElement<double>, bool>(NumberSetElement<double>.Create(2, 3, true, true), NumberSetElement<double>.CreateEmpty(), true),

                new Tuple<NumberSetElement<double>, NumberSetElement<double>, bool>(NumberSetElement<double>.Create(2, 2, true, true), NumberSetElement<double>.Create(2, 2, true, true), true),
                new Tuple<NumberSetElement<double>, NumberSetElement<double>, bool>(NumberSetElement<double>.Create(2, 2, true, true), NumberSetElement<double>.CreateEmpty(), true),

                new Tuple<NumberSetElement<double>, NumberSetElement<double>, bool>(NumberSetElement<double>.Create(2, 3, true, true), NumberSetElement<double>.Create(2.2, 4, true, true), true),
                new Tuple<NumberSetElement<double>, NumberSetElement<double>, bool>(NumberSetElement<double>.Create(2, 3, true, true), NumberSetElement<double>.Create(1, 2.5, true, true), true),
                new Tuple<NumberSetElement<double>, NumberSetElement<double>, bool>(NumberSetElement<double>.Create(2, 3, true, true), NumberSetElement<double>.Create(2, 4, true, true), true),
                new Tuple<NumberSetElement<double>, NumberSetElement<double>, bool>(NumberSetElement<double>.Create(2, 3, true, true), NumberSetElement<double>.Create(1, 3, true, true), true),
                new Tuple<NumberSetElement<double>, NumberSetElement<double>, bool>(NumberSetElement<double>.Create(2, 3, true, true), NumberSetElement<double>.Create(1, 4, true, true), true),

                new Tuple<NumberSetElement<double>, NumberSetElement<double>, bool>(NumberSetElement<double>.Create(2, 2, true, true), NumberSetElement<double>.Create(2, 3, true, true), true),
                new Tuple<NumberSetElement<double>, NumberSetElement<double>, bool>(NumberSetElement<double>.Create(2, 2, true, true), NumberSetElement<double>.Create(1, 2, true, true), true),
                new Tuple<NumberSetElement<double>, NumberSetElement<double>, bool>(NumberSetElement<double>.Create(2, 2, true, true), NumberSetElement<double>.Create(1, 3, true, true), true),

                new Tuple<NumberSetElement<double>, NumberSetElement<double>, bool>(NumberSetElement<double>.CreateEmpty(), NumberSetElement<double>.Create(2, 2, true, true), true),
                new Tuple<NumberSetElement<double>, NumberSetElement<double>, bool>(NumberSetElement<double>.CreateEmpty(), NumberSetElement<double>.Create(1, 2, true, true), true),
                new Tuple<NumberSetElement<double>, NumberSetElement<double>, bool>(NumberSetElement<double>.CreateEmpty(), NumberSetElement<double>.CreateEmpty(), true),

                new Tuple<NumberSetElement<double>, NumberSetElement<double>, bool>(NumberSetElement<double>.Create(2, 3, true, true), NumberSetElement<double>.Create(3, 4, true, true), true),
                new Tuple<NumberSetElement<double>, NumberSetElement<double>, bool>(NumberSetElement<double>.Create(2, 3, true, false), NumberSetElement<double>.Create(3, 4, true, true), false),
                new Tuple<NumberSetElement<double>, NumberSetElement<double>, bool>(NumberSetElement<double>.Create(2, 3, true, true), NumberSetElement<double>.Create(3, 4, false, true), false),
                new Tuple<NumberSetElement<double>, NumberSetElement<double>, bool>(NumberSetElement<double>.Create(2, 3, true, false), NumberSetElement<double>.Create(3, 4, false, true), false),
                new Tuple<NumberSetElement<double>, NumberSetElement<double>, bool>(NumberSetElement<double>.Create(2, 3, true, true), NumberSetElement<double>.Create(3.5, 4, true, true), false),
                new Tuple<NumberSetElement<double>, NumberSetElement<double>, bool>(NumberSetElement<double>.Create(2, 3, true, true), NumberSetElement<double>.Create(1, 2, true, true), true),
                new Tuple<NumberSetElement<double>, NumberSetElement<double>, bool>(NumberSetElement<double>.Create(2, 3, true, true), NumberSetElement<double>.Create(1, 2, true, false), false),
                new Tuple<NumberSetElement<double>, NumberSetElement<double>, bool>(NumberSetElement<double>.Create(2, 3, false, true), NumberSetElement<double>.Create(1, 2, true, true), false),
                new Tuple<NumberSetElement<double>, NumberSetElement<double>, bool>(NumberSetElement<double>.Create(2, 3, false, true), NumberSetElement<double>.Create(1, 2, true, false), false),
                new Tuple<NumberSetElement<double>, NumberSetElement<double>, bool>(NumberSetElement<double>.Create(2, 3, true, true), NumberSetElement<double>.Create(1, 1.5, true, true), false),

                new Tuple<NumberSetElement<double>, NumberSetElement<double>, bool>(NumberSetElement<double>.Create(3, 3, true, true), NumberSetElement<double>.Create(3, 4, true, true), true),
                new Tuple<NumberSetElement<double>, NumberSetElement<double>, bool>(NumberSetElement<double>.Create(3, 3, true, true), NumberSetElement<double>.Create(3, 4, false, true), false),
                new Tuple<NumberSetElement<double>, NumberSetElement<double>, bool>(NumberSetElement<double>.Create(3, 3, true, true), NumberSetElement<double>.Create(3.5, 4, true, true), false),
                new Tuple<NumberSetElement<double>, NumberSetElement<double>, bool>(NumberSetElement<double>.Create(2, 2, true, true), NumberSetElement<double>.Create(1, 2, true, true), true),
                new Tuple<NumberSetElement<double>, NumberSetElement<double>, bool>(NumberSetElement<double>.Create(2, 2, true, true), NumberSetElement<double>.Create(1, 2, true, false), false),
                new Tuple<NumberSetElement<double>, NumberSetElement<double>, bool>(NumberSetElement<double>.Create(2, 2, true, true), NumberSetElement<double>.Create(1, 1.5, true, true), false),

                new Tuple<NumberSetElement<double>, NumberSetElement<double>, bool>(NumberSetElement<double>.Create(2, 3, true, true), NumberSetElement<double>.Create(3, 3, true, true), true),
                new Tuple<NumberSetElement<double>, NumberSetElement<double>, bool>(NumberSetElement<double>.Create(2, 3, true, false), NumberSetElement<double>.Create(3, 3, true, true), false),
                new Tuple<NumberSetElement<double>, NumberSetElement<double>, bool>(NumberSetElement<double>.Create(2, 3, true, true), NumberSetElement<double>.Create(4, 4, true, true), false),
                new Tuple<NumberSetElement<double>, NumberSetElement<double>, bool>(NumberSetElement<double>.Create(2, 3, true, true), NumberSetElement<double>.Create(2, 2, true, true), true),
                new Tuple<NumberSetElement<double>, NumberSetElement<double>, bool>(NumberSetElement<double>.Create(2, 3, false, true), NumberSetElement<double>.Create(2, 2, true, true), false),
                new Tuple<NumberSetElement<double>, NumberSetElement<double>, bool>(NumberSetElement<double>.Create(2, 3, true, true), NumberSetElement<double>.Create(1, 1, true, true), false),

            };
            for (int i = 0; i < elementList.Count; i++)
                Assert.IsTrue(elementList[i].Item1.Intersects(elementList[i].Item2) == elementList[i].Item3);
        }

        [Ignore("Until NumberSet is done")]
        [TestMethod]
        public void TestIntersectsNumberSet()
        {
            //var elementList = new List<Tuple<NumberSetElement<double>, NumberSetElement<double>, bool>>()
            //{
            //    new Tuple<NumberSetElement<double>, NumberSetElement<double>, bool>(NumberSetElement<double>.Create(2, 3, true, true), NumberSetElement<double>.Create(2, 3, false, false), true),
            //    new Tuple<NumberSetElement<double>, NumberSetElement<double>, bool>(NumberSetElement<double>.Create(2, 3, true, true), NumberSetElement<double>.Create(2, 3, false, true), true),
            //    new Tuple<NumberSetElement<double>, NumberSetElement<double>, bool>(NumberSetElement<double>.Create(2, 3, true, true), NumberSetElement<double>.Create(2, 3, true, false), true),
            //    new Tuple<NumberSetElement<double>, NumberSetElement<double>, bool>(NumberSetElement<double>.Create(2, 3, true, true), NumberSetElement<double>.Create(2, 3, true, true), true),

            //    new Tuple<NumberSetElement<double>, NumberSetElement<double>, bool>(NumberSetElement<double>.Create(2, 3, true, false), NumberSetElement<double>.Create(2, 3, false, false), true),
            //    new Tuple<NumberSetElement<double>, NumberSetElement<double>, bool>(NumberSetElement<double>.Create(2, 3, true, false), NumberSetElement<double>.Create(2, 3, false, true), false),
            //    new Tuple<NumberSetElement<double>, NumberSetElement<double>, bool>(NumberSetElement<double>.Create(2, 3, true, false), NumberSetElement<double>.Create(2, 3, true, false), true),
            //    new Tuple<NumberSetElement<double>, NumberSetElement<double>, bool>(NumberSetElement<double>.Create(2, 3, true, false), NumberSetElement<double>.Create(2, 3, true, true), false),

            //    new Tuple<NumberSetElement<double>, NumberSetElement<double>, bool>(NumberSetElement<double>.Create(2, 3, false, true), NumberSetElement<double>.Create(2, 3, false, false), true),
            //    new Tuple<NumberSetElement<double>, NumberSetElement<double>, bool>(NumberSetElement<double>.Create(2, 3, false, true), NumberSetElement<double>.Create(2, 3, false, true), true),
            //    new Tuple<NumberSetElement<double>, NumberSetElement<double>, bool>(NumberSetElement<double>.Create(2, 3, false, true), NumberSetElement<double>.Create(2, 3, true, false), false),
            //    new Tuple<NumberSetElement<double>, NumberSetElement<double>, bool>(NumberSetElement<double>.Create(2, 3, false, true), NumberSetElement<double>.Create(2, 3, true, true), false),

            //    new Tuple<NumberSetElement<double>, NumberSetElement<double>, bool>(NumberSetElement<double>.Create(2, 3, false, false), NumberSetElement<double>.Create(2, 3, false, false), true),
            //    new Tuple<NumberSetElement<double>, NumberSetElement<double>, bool>(NumberSetElement<double>.Create(2, 3, false, false), NumberSetElement<double>.Create(2, 3, false, true), false),
            //    new Tuple<NumberSetElement<double>, NumberSetElement<double>, bool>(NumberSetElement<double>.Create(2, 3, false, false), NumberSetElement<double>.Create(2, 3, true, false), false),
            //    new Tuple<NumberSetElement<double>, NumberSetElement<double>, bool>(NumberSetElement<double>.Create(2, 3, false, false), NumberSetElement<double>.Create(2, 3, true, true), false),

            //    new Tuple<NumberSetElement<double>, NumberSetElement<double>, bool>(NumberSetElement<double>.Create(2, 3, true, true), NumberSetElement<double>.Create(2.2, 2.8, true, true), true),
            //    new Tuple<NumberSetElement<double>, NumberSetElement<double>, bool>(NumberSetElement<double>.Create(2, 3, true, true), NumberSetElement<double>.Create(2.2, 3, true, true), true),
            //    new Tuple<NumberSetElement<double>, NumberSetElement<double>, bool>(NumberSetElement<double>.Create(2, 3, true, true), NumberSetElement<double>.Create(2, 2.8, true, true), true),
            //    new Tuple<NumberSetElement<double>, NumberSetElement<double>, bool>(NumberSetElement<double>.Create(2, 3, true, true), NumberSetElement<double>.CreateEmpty(), true),

            //    new Tuple<NumberSetElement<double>, NumberSetElement<double>, bool>(NumberSetElement<double>.Create(2, 2, true, true), NumberSetElement<double>.Create(2, 2, true, true), true),
            //    new Tuple<NumberSetElement<double>, NumberSetElement<double>, bool>(NumberSetElement<double>.Create(2, 2, true, true), NumberSetElement<double>.CreateEmpty(), true),

            //    new Tuple<NumberSetElement<double>, NumberSetElement<double>, bool>(NumberSetElement<double>.Create(2, 3, true, true), NumberSetElement<double>.Create(2.2, 4, true, true), false),
            //    new Tuple<NumberSetElement<double>, NumberSetElement<double>, bool>(NumberSetElement<double>.Create(2, 3, true, true), NumberSetElement<double>.Create(1, 2.5, true, true), false),
            //    new Tuple<NumberSetElement<double>, NumberSetElement<double>, bool>(NumberSetElement<double>.Create(2, 3, true, true), NumberSetElement<double>.Create(2, 4, true, true), false),
            //    new Tuple<NumberSetElement<double>, NumberSetElement<double>, bool>(NumberSetElement<double>.Create(2, 3, true, true), NumberSetElement<double>.Create(1, 3, true, true), false),
            //    new Tuple<NumberSetElement<double>, NumberSetElement<double>, bool>(NumberSetElement<double>.Create(2, 3, true, true), NumberSetElement<double>.Create(1, 4, true, true), false),

            //    new Tuple<NumberSetElement<double>, NumberSetElement<double>, bool>(NumberSetElement<double>.Create(2, 2, true, true), NumberSetElement<double>.Create(2, 3, true, true), false),
            //    new Tuple<NumberSetElement<double>, NumberSetElement<double>, bool>(NumberSetElement<double>.Create(2, 2, true, true), NumberSetElement<double>.Create(1, 2, true, true), false),
            //    new Tuple<NumberSetElement<double>, NumberSetElement<double>, bool>(NumberSetElement<double>.Create(2, 2, true, true), NumberSetElement<double>.Create(1, 3, true, true), false),

            //    new Tuple<NumberSetElement<double>, NumberSetElement<double>, bool>(NumberSetElement<double>.CreateEmpty(), NumberSetElement<double>.Create(2, 2, true, true), false),
            //    new Tuple<NumberSetElement<double>, NumberSetElement<double>, bool>(NumberSetElement<double>.CreateEmpty(), NumberSetElement<double>.Create(1, 2, true, true), false),
            //    new Tuple<NumberSetElement<double>, NumberSetElement<double>, bool>(NumberSetElement<double>.CreateEmpty(), NumberSetElement<double>.CreateEmpty(), true),
            //};
            //for (int i = 0; i < elementList.Count; i++)
            //    Assert.IsTrue(elementList[i].Item1.Contains(elementList[i].Item2) == elementList[i].Item3);
        }
    }
}
