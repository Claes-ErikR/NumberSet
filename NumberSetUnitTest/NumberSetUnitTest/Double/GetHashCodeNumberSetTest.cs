using NumberSet;

namespace NumberSetUnitTest.NumberSetUnitTest.Double
{
    [TestClass]
    public class GetHashCodeNumberSetTest
    {
        [TestMethod]
        public void TestHashCodeEqual()
        {
            var element1 = NumberSet<double>.Create(NumberSetElement<double>.Create(2, 3, true, true));
            var element2 = NumberSet<double>.Create(NumberSetElement<double>.Create(2, 3, true, true));
            Assert.IsTrue(element1.GetHashCode().Equals(element2.GetHashCode()));
        }

        [TestMethod]
        public void TestHashCodeEqualNumberSetElement()
        {
            var element1 = NumberSet<double>.Create(NumberSetElement<double>.Create(2, 3, true, true));
            var element2 = NumberSetElement<double>.Create(2, 3, true, true);
            Assert.IsTrue(element1.GetHashCode().Equals(element2.GetHashCode()));
        }

        [TestMethod]
        public void TestHashCodeNotEqualNumberSetElement()
        {
            var element1 = NumberSet<double>.Create(NumberSetElement<double>.Create(2, 3, true, true), NumberSetElement<double>.Create(4, 5, true, true));
            var element2 = NumberSetElement<double>.Create(2, 3, true, true);
            Assert.IsFalse(element1.GetHashCode().Equals(element2.GetHashCode()));
        }

        [TestMethod]
        public void TestHashCodeNotEqual()
        {
            var elementList = new List<INumberSet<double>>()
            {
                NumberSet<double>.Create(NumberSetElement<double>.Create(2, 3, true, true)),
                NumberSet<double>.Create(NumberSetElement<double>.Create(2, 3, true, false)),
                NumberSet<double>.Create(NumberSetElement<double>.Create(2, 3, false, true)),
                NumberSet<double>.Create(NumberSetElement<double>.Create(2, 3, false, false)),
                NumberSet<double>.Create(NumberSetElement<double>.Create(2.1, 3, true, true)),
                NumberSet<double>.Create(NumberSetElement<double>.Create(1.9, 3, true, true)),
                NumberSet<double>.Create(NumberSetElement<double>.Create(2, 3.1, true, true)),
                NumberSet<double>.Create(NumberSetElement<double>.Create(2, 2.9, true, true)),
                NumberSet<double>.Empty
            };
            for (int i = 0; i < elementList.Count - 1; i++)
            {
                for (int k = i + 1; k < elementList.Count; k++)
                {
                    Assert.IsFalse(elementList[i].GetHashCode().Equals(elementList[k].GetHashCode()));
                }
            }
        }
    }
}
