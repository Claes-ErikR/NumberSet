using NumberSet;

namespace NumberSetUnitTest.NumberSetUnitTest.Double
{
    [TestClass]
    public class EqualityNumberSetTest
    {
        [TestMethod]
        public void TestEquality()
        {
            for (int i = 0; i < 2; i++)
            {
                var includeLowerBound = i == 1;
                for (int k = 0; k < 2; k++)
                {
                    var includeUpperBound = k == 1;
                    var numberSet1 = NumberSet<double>.Create(new List<NumberSetElement<double>>() { NumberSetElement<double>.Create(2, 3, includeLowerBound, includeUpperBound) });
                    var numberSet2 = NumberSet<double>.Create(new List<NumberSetElement<double>>() { NumberSetElement<double>.Create(2, 3, includeLowerBound, includeUpperBound) });
                    Assert.IsTrue(numberSet1.Equals(numberSet2));
                }
            }
        }

        [TestMethod]
        public void TestEquality2Elements()
        {
            for (int i = 0; i < 2; i++)
            {
                var includeLowerBound = i == 1;
                for (int k = 0; k < 2; k++)
                {
                    var includeUpperBound = k == 1;
                    var numberSet1 = NumberSet<double>.Create(new List<NumberSetElement<double>>() { NumberSetElement<double>.Create(2, 3, includeLowerBound, includeUpperBound), NumberSetElement<double>.Create(4, 5, includeLowerBound, includeUpperBound) });
                    var numberSet2 = NumberSet<double>.Create(new List<NumberSetElement<double>>() { NumberSetElement<double>.Create(2, 3, includeLowerBound, includeUpperBound), NumberSetElement<double>.Create(4, 5, includeLowerBound, includeUpperBound) });
                    Assert.IsTrue(numberSet1.Equals(numberSet2));
                }
            }
        }

        [TestMethod]
        public void TestEqualityEmpty()
        {
            var numberSet1 = NumberSet<double>.CreateEmpty();
            var numberSet2 = NumberSet<double>.CreateEmpty();
            Assert.IsTrue(numberSet1.Equals(numberSet2));
        }

        [TestMethod]
        public void TestEqualityNull()
        {
            var numberSet1 = NumberSet<double>.CreateEmpty();
            NumberSet<double> numberSet2 = null;
            Assert.IsFalse(numberSet1.Equals(numberSet2));
        }

        [TestMethod]
        public void TestInEquality()
        {
            var numberSetList = new List<NumberSet<double>>()
            {
                NumberSet<double>.Create(new List<NumberSetElement<double>>() { NumberSetElement<double>.Create(2, 3, true, true) }),
                NumberSet<double>.Create(new List<NumberSetElement<double>>() { NumberSetElement<double>.Create(2, 3, true, false) }),
                NumberSet<double>.Create(new List<NumberSetElement<double>>() { NumberSetElement<double>.Create(2, 3, false, true) }),
                NumberSet<double>.Create(new List<NumberSetElement<double>>() { NumberSetElement<double>.Create(2, 3, false, false) }),
                NumberSet<double>.Create(new List<NumberSetElement<double>>() { NumberSetElement<double>.Create(2, 3, true, true), NumberSetElement<double>.Create(4, 5, true, true) }),
                NumberSet<double>.Create(new List<NumberSetElement<double>>() { NumberSetElement<double>.Create(0, 1, true, true), NumberSetElement<double>.Create(2, 3, true, true) }),
                NumberSet<double>.Create(new List<NumberSetElement<double>>() { NumberSetElement<double>.Create(2.1, 3, true, true) }),
                NumberSet<double>.Create(new List<NumberSetElement<double>>() { NumberSetElement<double>.Create(1.9, 3, true, true) }),
                NumberSet<double>.Create(new List<NumberSetElement<double>>() { NumberSetElement<double>.Create(2, 3.1, true, true) }),
                NumberSet<double>.Create(new List<NumberSetElement<double>>() { NumberSetElement<double>.Create(2, 2.9, true, true) }),
                NumberSet<double>.Create(new List<NumberSetElement<double>>() { NumberSetElement<double>.CreateEmpty() })
            };
            for (int i = 0; i < numberSetList.Count - 1; i++)
            {
                for (int k = i + 1; k < numberSetList.Count; k++)
                {
                    Assert.IsFalse(numberSetList[i].Equals(numberSetList[k]));
                }
            }
        }
    }
}
