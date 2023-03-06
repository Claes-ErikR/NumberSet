using Utte.NumberSet;

namespace NumberSetUnitTest.NumberSetElementUnitTest.Double
{
    [TestClass]
    public class GetHashCodeNumberSetElementTest
    {
        [TestMethod]
        public void TestHashCodeEqual()
        {
            var element1 = NumberSetElement<double>.Create(2, 3, true, true);
            var element2 = NumberSetElement<double>.Create(2, 3, true, true);
            Assert.IsTrue(element1.GetHashCode().Equals(element2.GetHashCode()));
        }

        [TestMethod]
        public void TestHashCodeNotEqual()
        {
            var elementList = new List<INumberSetElement<double>>()
            {
                NumberSetElement<double>.Create(2, 3, true, true),
                NumberSetElement<double>.Create(2, 3, true, false),
                NumberSetElement<double>.Create(2, 3, false, true),
                NumberSetElement<double>.Create(2, 3, false, false),
                NumberSetElement<double>.Create(2.1, 3, true, true),
                NumberSetElement<double>.Create(1.9, 3, true, true),
                NumberSetElement<double>.Create(2, 3.1, true, true),
                NumberSetElement<double>.Create(2, 2.9, true, true),
                NumberSetElement<double>.Empty
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
