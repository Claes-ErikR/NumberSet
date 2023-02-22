using NumberSet;

namespace NumberSetUnitTest.NumberSetUnitTest.Double
{
    [TestClass]
    public class EqualityNumberSetTest
    {

        [TestMethod]
        public void TestEqualsNumberSet()
        {
            for (int i = 0; i < 2; i++)
            {
                var includeLowerBound = i == 1;
                for (int k = 0; k < 2; k++)
                {
                    var includeUpperBound = k == 1;
                    var element1 = NumberSetElement<double>.Create(2, 3, includeLowerBound, includeUpperBound);
                    var element2 = NumberSet<double>.Create(NumberSetElement<double>.Create(2, 3, includeLowerBound, includeUpperBound));
                    Assert.IsTrue(element2.Equals(element1));
                }
            }
        }

        [TestMethod]
        public void TestEqualsZeroEmptyNumberSet()
        {
            var element1 = NumberSetElement<double>.Create(0, 0, false, false);
            var element2 = NumberSet<double>.Empty;
            Assert.IsTrue(element2.Equals(element1));
        }

        [TestMethod]
        public void TestEqualsEmptyNumberSet()
        {
            var element1 = NumberSet<double>.Empty;
            var element2 = NumberSetElement<double>.Empty;
            Assert.IsTrue(element1.Equals(element2));
        }

        [TestMethod]
        public void TestEqualsNullNumberSet()
        {
            var element1 = NumberSet<double>.Empty;
            NumberSetElement<double> element2 = null;
            Assert.IsFalse(element1.Equals(element2));
        }

        [TestMethod]
        public void TestInEqualsNumberSet()
        {
            var elementList1 = new List<NumberSetElement<double>>()
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
            var elementList2 = new List<NumberSet<double>>()
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
            for (int i = 0; i < elementList1.Count - 1; i++)
            {
                for (int k = i + 1; k < elementList2.Count; k++)
                {
                    Assert.IsFalse(elementList2[i].Equals(elementList1[k]));
                }
            }
        }

        [TestMethod]
        public void TestInEqualsNumberSetFirstEqual()
        {
            var element1 = NumberSetElement<double>.Create(2, 3, true, true);
            var element2 = NumberSet<double>.Create(NumberSetElement<double>.Create(2, 3, true, true), NumberSetElement<double>.Create(4, 5, true, true));
            Assert.IsFalse(element2.Equals(element1));
        }

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
        public void TestEqualsZeroEmpty()
        {
            var element1 = NumberSet<double>.Create(NumberSetElement<double>.Create(0, 0, false, false));
            var element2 = NumberSet<double>.Empty;
            Assert.IsTrue(element1.Equals(element2));
        }

        [TestMethod]
        public void TestEqualityEmpty()
        {
            var numberSet1 = NumberSet<double>.Empty;
            var numberSet2 = NumberSet<double>.Empty;
            Assert.IsTrue(numberSet1.Equals(numberSet2));
        }

        [TestMethod]
        public void TestEqualityNull()
        {
            var numberSet1 = NumberSet<double>.Empty;
            NumberSet<double> numberSet2 = null;
            Assert.IsFalse(numberSet1.Equals(numberSet2));
        }

                [TestMethod]
        public void TestEqualsStringNull()
        {
            var element1 = NumberSet<double>.Empty;
            string element2 = null;
            Assert.IsFalse(element1.Equals(element2));
        }

        [TestMethod]
        public void TestEqualsString()
        {
            var element1 = NumberSet<double>.Empty;
            string element2 = "TestString";
            Assert.IsFalse(element1.Equals(element2));
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
                NumberSet<double>.Create(new List<NumberSetElement<double>>() { NumberSetElement<double>.Empty })
            };
            for (int i = 0; i < numberSetList.Count - 1; i++)
            {
                for (int k = i + 1; k < numberSetList.Count; k++)
                {
                    Assert.IsFalse(numberSetList[i].Equals(numberSetList[k]));
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
                    var element1 = NumberSet<double>.Create(NumberSetElement<double>.Create(2, 3, includeLowerBound, includeUpperBound));
                    var element2 = NumberSetElement<double>.Create(2, 3, includeLowerBound, includeUpperBound);
                    Assert.IsTrue(element1 == element2);
                    Assert.IsFalse(element1 != element2);
                }
            }
        }

        [TestMethod]
        public void TestEqualityEmptyOperator()
        {
            var element1 = NumberSet<double>.Empty;
            var element2 = NumberSetElement<double>.Empty;
            Assert.IsTrue(element1 == element2);
            Assert.IsFalse(element1 != element2);
        }

        [TestMethod]
        public void TestInEqualityOperator()
        {
            var elementList1 = new List<NumberSet<double>>()
            {
                NumberSet<double>.Create(NumberSetElement<double>.Create(2, 3, true, true)),
                NumberSet<double>.Create(NumberSetElement<double>.Create(2, 3, true, false)),
                NumberSet<double>.Create(NumberSetElement<double>.Create(2, 3, false, true)),
                NumberSet<double>.Create(NumberSetElement<double>.Create(2, 3, false, false)),
                NumberSet<double>.Create(NumberSetElement<double>.Create(2.1, 3, true, true)),
                NumberSet<double>.Create(NumberSetElement<double>.Create(1.9, 3, true, true)),
                NumberSet<double>.Create(NumberSetElement<double>.Create(2, 3.1, true, true)),
                NumberSet<double>.Create(NumberSetElement<double>.Create(2, 2.9, true, true)),
                NumberSet<double>.Create(NumberSetElement<double>.Empty)
            };
            var elementList2 = new List<NumberSetElement<double>>()
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
            for (int i = 0; i < elementList1.Count - 1; i++)
            {
                for (int k = i + 1; k < elementList2.Count; k++)
                {
                    Assert.IsTrue(elementList1[i] != elementList2[k]);
                    Assert.IsFalse(elementList1[i] == elementList2[k]);
                }
            }
        }

        [TestMethod]
        public void TestEqualityFirstEqualOperator()
        {
            var element1 = NumberSet<double>.Create(NumberSetElement<double>.Create(2, 3, true, true), NumberSetElement<double>.Create(4, 5, true, true));
            var element2 = NumberSetElement<double>.Create(2, 3, true, true);
            Assert.IsTrue(element1 != element2);
            Assert.IsFalse(element1 == element2);
        }

        [TestMethod]
        public void TestEqualityNumberSetOperator()
        {
            for (int i = 0; i < 2; i++)
            {
                var includeLowerBound = i == 1;
                for (int k = 0; k < 2; k++)
                {
                    var includeUpperBound = k == 1;
                    var element1 = NumberSet<double>.Create(NumberSetElement<double>.Create(2, 3, includeLowerBound, includeUpperBound));
                    var element2 = NumberSet<double>.Create(NumberSetElement<double>.Create(2, 3, includeLowerBound, includeUpperBound));
                    Assert.IsTrue(element1 == element2);
                    Assert.IsFalse(element1 != element2);
                }
            }
        }

        [TestMethod]
        public void TestEqualityEmptyNumberSetOperator()
        {
            var element1 = NumberSet<double>.Empty;
            var element2 = NumberSet<double>.Empty;
            Assert.IsTrue(element1 == element2);
            Assert.IsFalse(element1 != element2);
        }

        [TestMethod]
        public void TestInEqualityNumberSetOperator()
        {
            var elementList1 = new List<NumberSet<double>>()
            {
                NumberSet<double>.Create(NumberSetElement<double>.Create(2, 3, true, true)),
                NumberSet<double>.Create(NumberSetElement<double>.Create(2, 3, true, false)),
                NumberSet<double>.Create(NumberSetElement<double>.Create(2, 3, false, true)),
                NumberSet<double>.Create(NumberSetElement<double>.Create(2, 3, false, false)),
                NumberSet<double>.Create(NumberSetElement<double>.Create(2.1, 3, true, true)),
                NumberSet<double>.Create(NumberSetElement<double>.Create(1.9, 3, true, true)),
                NumberSet<double>.Create(NumberSetElement<double>.Create(2, 3.1, true, true)),
                NumberSet<double>.Create(NumberSetElement<double>.Create(2, 2.9, true, true)),
                NumberSet<double>.Create(NumberSetElement<double>.Empty)
            };
            var elementList2 = new List<NumberSet<double>>()
            {
                NumberSet<double>.Create(NumberSetElement<double>.Create(2, 3, true, true)),
                NumberSet<double>.Create(NumberSetElement<double>.Create(2, 3, true, false)),
                NumberSet<double>.Create(NumberSetElement<double>.Create(2, 3, false, true)),
                NumberSet<double>.Create(NumberSetElement<double>.Create(2, 3, false, false)),
                NumberSet<double>.Create(NumberSetElement<double>.Create(2.1, 3, true, true)),
                NumberSet<double>.Create(NumberSetElement<double>.Create(1.9, 3, true, true)),
                NumberSet<double>.Create(NumberSetElement<double>.Create(2, 3.1, true, true)),
                NumberSet<double>.Create(NumberSetElement<double>.Create(2, 2.9, true, true)),
                NumberSet<double>.Create(NumberSetElement<double>.Empty)
            };
            for (int i = 0; i < elementList1.Count - 1; i++)
            {
                for (int k = i + 1; k < elementList2.Count; k++)
                {
                    Assert.IsTrue(elementList1[i] != elementList2[k]);
                    Assert.IsFalse(elementList1[i] == elementList2[k]);
                }
            }
        }

        [TestMethod]
        public void TestEqualityFirstEqualNumberSetOperator()
        {
            var element1 = NumberSet<double>.Create(NumberSetElement<double>.Create(2, 3, true, true), NumberSetElement<double>.Create(4, 5, true, true));
            var element2 = NumberSet<double>.Create(NumberSetElement<double>.Create(2, 3, true, true));
            Assert.IsTrue(element1 != element2);
            Assert.IsFalse(element1 == element2);
            Assert.IsTrue(element2 != element1);
            Assert.IsFalse(element2 == element1);
        }

        [TestMethod]
        public void TestEquality3ElementsNumberSetOperator()
        {
            var element1 = NumberSet<double>.Create(NumberSetElement<double>.Create(2, 3, true, true), NumberSetElement<double>.Create(4, 5, false, true), NumberSetElement<double>.Create(6, 8, false, true));
            var element2 = NumberSet<double>.Create(NumberSetElement<double>.Create(2, 3, true, true), NumberSetElement<double>.Create(4, 5, false, true), NumberSetElement<double>.Create(6, 8, false, true));
            Assert.IsTrue(element1 == element2);
            Assert.IsFalse(element1 != element2);
            Assert.IsTrue(element2 == element1);
            Assert.IsFalse(element2 != element1);
        }

        [TestMethod]
        public void TestInEquality3ElementsNumberSetOperator()
        {
            var element1 = NumberSet<double>.Create(NumberSetElement<double>.Create(2, 3, true, true), NumberSetElement<double>.Create(4, 5, true, true), NumberSetElement<double>.Create(6, 8, false, true));
            var element2 = NumberSet<double>.Create(NumberSetElement<double>.Create(2, 3, true, true), NumberSetElement<double>.Create(4, 5, false, true), NumberSetElement<double>.Create(6, 8, false, true));
            Assert.IsTrue(element1 != element2);
            Assert.IsFalse(element1 == element2);
            Assert.IsTrue(element2 != element1);
            Assert.IsFalse(element2 == element1);
        }
    }
}
