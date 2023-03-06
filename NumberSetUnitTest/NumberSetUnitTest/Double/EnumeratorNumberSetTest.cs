using Utte.NumberSet;

namespace NumberSetUnitTest.NumberSetUnitTest.Double
{
    [TestClass]
    public class EnumeratorNumberSetTest
    {
        [TestMethod]
        public void TestEmptyElementEnumerator()
        {
            var item = NumberSet<double>.Empty;

            int count = 0;
            foreach (var element in item)
                count++;
            Assert.AreEqual(count, 1);
        }

        [TestMethod]
        public void Test1ElementEnumerator()
        {
            var item = NumberSet<double>.Create(NumberSetElement<double>.Create(2, 3, false, true));

            int count = 0;
            foreach (var element in item)
                count++;
            Assert.AreEqual(count, 1);
        }

        [TestMethod]
        public void Test2ElementEnumerator()
        {
            var item = NumberSet<double>.Create(NumberSetElement<double>.Create(2, 3, false, true), NumberSetElement<double>.Create(4, 5, true, false));

            int count = 0;
            foreach (var element in item)
                count++;
            Assert.AreEqual(count, 2);
        }

        [TestMethod]
        public void Test3ElementEnumerator()
        {
            var item = NumberSet<double>.Create(NumberSetElement<double>.Create(2, 3, false, true), NumberSetElement<double>.Create(4, 5, true, false), NumberSetElement<double>.Create(5, 6, false, false));

            int count = 0;
            foreach (var element in item)
                count++;
            Assert.AreEqual(count, 3);
        }
    }
}
