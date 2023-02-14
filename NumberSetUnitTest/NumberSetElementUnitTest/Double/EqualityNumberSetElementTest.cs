using NumberSet;

namespace NumberSetUnitTest.NumberSetElementUnitTest.Double
{
    [TestClass]
    public class EqualityNumberSetElementTest
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
                    var element1 = NumberSetElement<double>.Create(2, 3, includeLowerBound, includeUpperBound);
                    var element2 = NumberSetElement<double>.Create(2, 3, includeLowerBound, includeUpperBound);
                    Assert.IsTrue(element1.Equals(element2));
                }
            }
        }

        [TestMethod]
        public void TestEqualityEmpty()
        {
            var element1 = NumberSetElement<double>.CreateEmpty();
            var element2 = NumberSetElement<double>.CreateEmpty();
            Assert.IsTrue(element1.Equals(element2));
        }

        [TestMethod]
        public void TestEqualityNull()
        {
            var element1 = NumberSetElement<double>.CreateEmpty();
            NumberSetElement<double> element2 = null;
            Assert.IsFalse(element1.Equals(element2));
        }

        [TestMethod]
        public void TestInEquality()
        {
            var elementList = new List<NumberSetElement<double>>()
            {
                NumberSetElement<double>.Create(2, 3, true, true),
                NumberSetElement<double>.Create(2, 3, true, false),
                NumberSetElement<double>.Create(2, 3, false, true),
                NumberSetElement<double>.Create(2, 3, false, false),
                NumberSetElement<double>.Create(2.1, 3, true, true),
                NumberSetElement<double>.Create(1.9, 3, true, true),
                NumberSetElement<double>.Create(2, 3.1, true, true),
                NumberSetElement<double>.Create(2, 2.9, true, true),
                NumberSetElement<double>.CreateEmpty()
            };
            for (int i = 0; i < elementList.Count - 1; i++)
            {
                for (int k = i + 1; k < elementList.Count; k++)
                {
                    Assert.IsFalse(elementList[i].Equals(elementList[k]));
                }
            }
        }

        [TestMethod]
        public void TestEqualityOperator()
        {
            for (int i = 0; i < 2; i++)
            {
                var includeLowerBound = i == 1;
                for (int k = 0; k < 2; k++)
                {
                    var includeUpperBound = k == 1;
                    var element1 = NumberSetElement<double>.Create(2, 3, includeLowerBound, includeUpperBound);
                    var element2 = NumberSetElement<double>.Create(2, 3, includeLowerBound, includeUpperBound);
                    Assert.IsTrue(element1 == element2);
                    Assert.IsFalse(element1 != element2);
                }
            }
        }

        [TestMethod]
        public void TestEqualityEmptyOperator()
        {
            var element1 = NumberSetElement<double>.CreateEmpty();
            var element2 = NumberSetElement<double>.CreateEmpty();
            Assert.IsTrue(element1 == element2);
            Assert.IsFalse(element1 != element2);
        }

        [TestMethod]
        public void TestInEqualityOperator()
        {
            var elementList = new List<NumberSetElement<double>>()
            {
                NumberSetElement<double>.Create(2, 3, true, true),
                NumberSetElement<double>.Create(2, 3, true, false),
                NumberSetElement<double>.Create(2, 3, false, true),
                NumberSetElement<double>.Create(2, 3, false, false),
                NumberSetElement<double>.Create(2.1, 3, true, true),
                NumberSetElement<double>.Create(1.9, 3, true, true),
                NumberSetElement<double>.Create(2, 3.1, true, true),
                NumberSetElement<double>.Create(2, 2.9, true, true),
                NumberSetElement<double>.CreateEmpty()
            };
            for (int i = 0; i < elementList.Count - 1; i++)
            {
                for (int k = i + 1; k < elementList.Count; k++)
                {
                    Assert.IsTrue(elementList[i] != elementList[k]);
                    Assert.IsFalse(elementList[i] == elementList[k]);
                }
            }
        }

        [TestMethod]
        public void TestEqualityOperatorNull()
        {
            var element1 = NumberSetElement<double>.CreateEmpty();
            var element2 = NumberSetElement<double>.CreateEmpty();
            Assert.IsFalse(null == element2);
            Assert.IsFalse(element1 == null);
            Assert.IsTrue(null != element2);
            Assert.IsTrue(element1 != null);
        }
    }
}
