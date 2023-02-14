﻿using NumberSet;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace NumberSetUnitTest
{
    [TestClass]
    public class NumberSetElementUnitTestOld
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
            for (int i = 0;i < elementList.Count - 1; i++)
            {
                for (int k = i+1; k < elementList.Count; k++)
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

        [TestMethod]
        public void TestToString()
        {
            var elementList = new List<Tuple<NumberSetElement<double>, string>>()
            {
                new Tuple<NumberSetElement<double>, string>(NumberSetElement<double>.Create(2, 3, true, true), "[2, 3]"),
                new Tuple<NumberSetElement<double>, string>(NumberSetElement<double>.Create(2, 3, true, false), "[2, 3)"),
                new Tuple<NumberSetElement<double>, string>(NumberSetElement<double>.Create(2, 3, false, true), "(2, 3]"),
                new Tuple<NumberSetElement<double>, string>(NumberSetElement<double>.Create(2, 3, false, false), "(2, 3)"),
                new Tuple<NumberSetElement<double>, string>(NumberSetElement<double>.CreateEmpty(), "Empty"),
            };
            for (int i = 0; i < elementList.Count; i++)
            {
                Assert.AreEqual(elementList[i].Item1.ToString(), elementList[i].Item2);
            }
        }

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
                if(NumberSetElement<double>.TryParse(elementList[i].Item2, null, out NumberSetElement<double> result))
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
            };
            for (int i = 0; i < elementList.Count; i++)
            {
                if (NumberSetElement<double>.TryParse(elementList[i], null, out NumberSetElement<double> result))
                    Assert.Fail();
            }
        }

        [TestMethod]
        public void TestContainsPoint()
        {
            var elementList = new List<Tuple<NumberSetElement<double>, double, bool>>()
            {
                new Tuple<NumberSetElement<double>, double, bool>(NumberSetElement<double>.Create(2, 3, true, true), 1.9, false),
                new Tuple<NumberSetElement<double>, double, bool>(NumberSetElement<double>.Create(2, 3, true, true), 2, true),
                new Tuple<NumberSetElement<double>, double, bool>(NumberSetElement<double>.Create(2, 3, true, true), 2.5, true),
                new Tuple<NumberSetElement<double>, double, bool>(NumberSetElement<double>.Create(2, 3, true, true), 3, true),
                new Tuple<NumberSetElement<double>, double, bool>(NumberSetElement<double>.Create(2, 3, true, true), 3.1, false),

                new Tuple<NumberSetElement<double>, double, bool>(NumberSetElement<double>.Create(2, 3, false, true), 1.9, false),
                new Tuple<NumberSetElement<double>, double, bool>(NumberSetElement<double>.Create(2, 3, false, true), 2, false),
                new Tuple<NumberSetElement<double>, double, bool>(NumberSetElement<double>.Create(2, 3, false, true), 2.5, true),
                new Tuple<NumberSetElement<double>, double, bool>(NumberSetElement<double>.Create(2, 3, false, true), 3, true),
                new Tuple<NumberSetElement<double>, double, bool>(NumberSetElement<double>.Create(2, 3, false, true), 3.1, false),

                new Tuple<NumberSetElement<double>, double, bool>(NumberSetElement<double>.Create(2, 3, true, false), 1.9, false),
                new Tuple<NumberSetElement<double>, double, bool>(NumberSetElement<double>.Create(2, 3, true, false), 2, true),
                new Tuple<NumberSetElement<double>, double, bool>(NumberSetElement<double>.Create(2, 3, true, false), 2.5, true),
                new Tuple<NumberSetElement<double>, double, bool>(NumberSetElement<double>.Create(2, 3, true, false), 3, false),
                new Tuple<NumberSetElement<double>, double, bool>(NumberSetElement<double>.Create(2, 3, true, false), 3.1, false),

                new Tuple<NumberSetElement<double>, double, bool>(NumberSetElement<double>.Create(2, 2, true, true), 1.9, false),
                new Tuple<NumberSetElement<double>, double, bool>(NumberSetElement<double>.Create(2, 2, true, true), 2, true),
                new Tuple<NumberSetElement<double>, double, bool>(NumberSetElement<double>.Create(2, 2, true, true), 2.1, false),

                new Tuple<NumberSetElement<double>, double, bool>(NumberSetElement<double>.CreateEmpty(), 2, false),
            };
            for (int i = 0; i < elementList.Count; i++)
                Assert.IsTrue(elementList[i].Item1.Contains(elementList[i].Item2) == elementList[i].Item3);
        }

        [TestMethod]
        public void TestContainsNumberSetElement()
        {
            var elementList = new List<Tuple<NumberSetElement<double>, NumberSetElement<double>, bool>>()
            {
                new Tuple<NumberSetElement<double>, NumberSetElement<double>, bool>(NumberSetElement<double>.Create(2, 3, true, true), NumberSetElement<double>.Create(2, 3, false, false), true),
                new Tuple<NumberSetElement<double>, NumberSetElement<double>, bool>(NumberSetElement<double>.Create(2, 3, true, true), NumberSetElement<double>.Create(2, 3, false, true), true),
                new Tuple<NumberSetElement<double>, NumberSetElement<double>, bool>(NumberSetElement<double>.Create(2, 3, true, true), NumberSetElement<double>.Create(2, 3, true, false), true),
                new Tuple<NumberSetElement<double>, NumberSetElement<double>, bool>(NumberSetElement<double>.Create(2, 3, true, true), NumberSetElement<double>.Create(2, 3, true, true), true),

                new Tuple<NumberSetElement<double>, NumberSetElement<double>, bool>(NumberSetElement<double>.Create(2, 3, true, false), NumberSetElement<double>.Create(2, 3, false, false), true),
                new Tuple<NumberSetElement<double>, NumberSetElement<double>, bool>(NumberSetElement<double>.Create(2, 3, true, false), NumberSetElement<double>.Create(2, 3, false, true), false),
                new Tuple<NumberSetElement<double>, NumberSetElement<double>, bool>(NumberSetElement<double>.Create(2, 3, true, false), NumberSetElement<double>.Create(2, 3, true, false), true),
                new Tuple<NumberSetElement<double>, NumberSetElement<double>, bool>(NumberSetElement<double>.Create(2, 3, true, false), NumberSetElement<double>.Create(2, 3, true, true), false),

                new Tuple<NumberSetElement<double>, NumberSetElement<double>, bool>(NumberSetElement<double>.Create(2, 3, false, true), NumberSetElement<double>.Create(2, 3, false, false), true),
                new Tuple<NumberSetElement<double>, NumberSetElement<double>, bool>(NumberSetElement<double>.Create(2, 3, false, true), NumberSetElement<double>.Create(2, 3, false, true), true),
                new Tuple<NumberSetElement<double>, NumberSetElement<double>, bool>(NumberSetElement<double>.Create(2, 3, false, true), NumberSetElement<double>.Create(2, 3, true, false), false),
                new Tuple<NumberSetElement<double>, NumberSetElement<double>, bool>(NumberSetElement<double>.Create(2, 3, false, true), NumberSetElement<double>.Create(2, 3, true, true), false),

                new Tuple<NumberSetElement<double>, NumberSetElement<double>, bool>(NumberSetElement<double>.Create(2, 3, false, false), NumberSetElement<double>.Create(2, 3, false, false), true),
                new Tuple<NumberSetElement<double>, NumberSetElement<double>, bool>(NumberSetElement<double>.Create(2, 3, false, false), NumberSetElement<double>.Create(2, 3, false, true), false),
                new Tuple<NumberSetElement<double>, NumberSetElement<double>, bool>(NumberSetElement<double>.Create(2, 3, false, false), NumberSetElement<double>.Create(2, 3, true, false), false),
                new Tuple<NumberSetElement<double>, NumberSetElement<double>, bool>(NumberSetElement<double>.Create(2, 3, false, false), NumberSetElement<double>.Create(2, 3, true, true), false),

                new Tuple<NumberSetElement<double>, NumberSetElement<double>, bool>(NumberSetElement<double>.Create(2, 3, true, true), NumberSetElement<double>.Create(2.2, 2.8, true, true), true),
                new Tuple<NumberSetElement<double>, NumberSetElement<double>, bool>(NumberSetElement<double>.Create(2, 3, true, true), NumberSetElement<double>.Create(2.2, 3, true, true), true),
                new Tuple<NumberSetElement<double>, NumberSetElement<double>, bool>(NumberSetElement<double>.Create(2, 3, true, true), NumberSetElement<double>.Create(2, 2.8, true, true), true),
                new Tuple<NumberSetElement<double>, NumberSetElement<double>, bool>(NumberSetElement<double>.Create(2, 3, true, true), NumberSetElement<double>.CreateEmpty(), true),

                new Tuple<NumberSetElement<double>, NumberSetElement<double>, bool>(NumberSetElement<double>.Create(2, 2, true, true), NumberSetElement<double>.Create(2, 2, true, true), true),
                new Tuple<NumberSetElement<double>, NumberSetElement<double>, bool>(NumberSetElement<double>.Create(2, 2, true, true), NumberSetElement<double>.CreateEmpty(), true),

                new Tuple<NumberSetElement<double>, NumberSetElement<double>, bool>(NumberSetElement<double>.Create(2, 3, true, true), NumberSetElement<double>.Create(2.2, 4, true, true), false),
                new Tuple<NumberSetElement<double>, NumberSetElement<double>, bool>(NumberSetElement<double>.Create(2, 3, true, true), NumberSetElement<double>.Create(1, 2.5, true, true), false),
                new Tuple<NumberSetElement<double>, NumberSetElement<double>, bool>(NumberSetElement<double>.Create(2, 3, true, true), NumberSetElement<double>.Create(2, 4, true, true), false),
                new Tuple<NumberSetElement<double>, NumberSetElement<double>, bool>(NumberSetElement<double>.Create(2, 3, true, true), NumberSetElement<double>.Create(1, 3, true, true), false),
                new Tuple<NumberSetElement<double>, NumberSetElement<double>, bool>(NumberSetElement<double>.Create(2, 3, true, true), NumberSetElement<double>.Create(1, 4, true, true), false),

                new Tuple<NumberSetElement<double>, NumberSetElement<double>, bool>(NumberSetElement<double>.Create(2, 2, true, true), NumberSetElement<double>.Create(2, 3, true, true), false),
                new Tuple<NumberSetElement<double>, NumberSetElement<double>, bool>(NumberSetElement<double>.Create(2, 2, true, true), NumberSetElement<double>.Create(1, 2, true, true), false),
                new Tuple<NumberSetElement<double>, NumberSetElement<double>, bool>(NumberSetElement<double>.Create(2, 2, true, true), NumberSetElement<double>.Create(1, 3, true, true), false),

                new Tuple<NumberSetElement<double>, NumberSetElement<double>, bool>(NumberSetElement<double>.CreateEmpty(), NumberSetElement<double>.Create(2, 2, true, true), false),
                new Tuple<NumberSetElement<double>, NumberSetElement<double>, bool>(NumberSetElement<double>.CreateEmpty(), NumberSetElement<double>.Create(1, 2, true, true), false),
                new Tuple<NumberSetElement<double>, NumberSetElement<double>, bool>(NumberSetElement<double>.CreateEmpty(), NumberSetElement<double>.CreateEmpty(), true),
            };
            for (int i = 0; i < elementList.Count; i++)
                Assert.IsTrue(elementList[i].Item1.Contains(elementList[i].Item2) == elementList[i].Item3);
        }

        [TestMethod]
        public void TestContainsNumberSet()
        {
            var elementList = new List<Tuple<NumberSetElement<double>, NumberSet<double>, bool>>()
            {
                new Tuple<NumberSetElement<double>, NumberSet<double>, bool>(NumberSetElement<double>.Create(2, 3, true, true), NumberSet<double>.Create(NumberSetElement<double>.Create(2, 3, false, false)), true),
                new Tuple<NumberSetElement<double>, NumberSet<double>, bool>(NumberSetElement<double>.Create(2, 3, true, true), NumberSet<double>.Create(NumberSetElement<double>.Create(2, 3, false, true)), true),
                new Tuple<NumberSetElement<double>, NumberSet<double>, bool>(NumberSetElement<double>.Create(2, 3, true, true), NumberSet<double>.Create(NumberSetElement<double>.Create(2, 3, true, false)), true),
                new Tuple<NumberSetElement<double>, NumberSet<double>, bool>(NumberSetElement<double>.Create(2, 3, true, true), NumberSet<double>.Create(NumberSetElement<double>.Create(2, 3, true, true)), true),

                new Tuple<NumberSetElement<double>, NumberSet<double>, bool>(NumberSetElement<double>.Create(2, 3, true, false), NumberSet<double>.Create(NumberSetElement<double>.Create(2, 3, false, false)), true),
                new Tuple<NumberSetElement<double>, NumberSet<double>, bool>(NumberSetElement<double>.Create(2, 3, true, false), NumberSet<double>.Create(NumberSetElement<double>.Create(2, 3, false, true)), false),
                new Tuple<NumberSetElement<double>, NumberSet<double>, bool>(NumberSetElement<double>.Create(2, 3, true, false), NumberSet<double>.Create(NumberSetElement<double>.Create(2, 3, true, false)), true),
                new Tuple<NumberSetElement<double>, NumberSet<double>, bool>(NumberSetElement<double>.Create(2, 3, true, false), NumberSet<double>.Create(NumberSetElement<double>.Create(2, 3, true, true)), false),

                new Tuple<NumberSetElement<double>, NumberSet<double>, bool>(NumberSetElement<double>.Create(2, 3, false, true), NumberSet<double>.Create(NumberSetElement<double>.Create(2, 3, false, false)), true),
                new Tuple<NumberSetElement<double>, NumberSet<double>, bool>(NumberSetElement<double>.Create(2, 3, false, true), NumberSet<double>.Create(NumberSetElement<double>.Create(2, 3, false, true)), true),
                new Tuple<NumberSetElement<double>, NumberSet<double>, bool>(NumberSetElement<double>.Create(2, 3, false, true), NumberSet<double>.Create(NumberSetElement<double>.Create(2, 3, true, false)), false),
                new Tuple<NumberSetElement<double>, NumberSet<double>, bool>(NumberSetElement<double>.Create(2, 3, false, true), NumberSet<double>.Create(NumberSetElement<double>.Create(2, 3, true, true)), false),

                new Tuple<NumberSetElement<double>, NumberSet<double>, bool>(NumberSetElement<double>.Create(2, 3, false, false), NumberSet<double>.Create(NumberSetElement<double>.Create(2, 3, false, false)), true),
                new Tuple<NumberSetElement<double>, NumberSet<double>, bool>(NumberSetElement<double>.Create(2, 3, false, false), NumberSet<double>.Create(NumberSetElement<double>.Create(2, 3, false, true)), false),
                new Tuple<NumberSetElement<double>, NumberSet<double>, bool>(NumberSetElement<double>.Create(2, 3, false, false), NumberSet<double>.Create(NumberSetElement<double>.Create(2, 3, true, false)), false),
                new Tuple<NumberSetElement<double>, NumberSet<double>, bool>(NumberSetElement<double>.Create(2, 3, false, false), NumberSet<double>.Create(NumberSetElement<double>.Create(2, 3, true, true)), false),

                new Tuple<NumberSetElement<double>, NumberSet<double>, bool>(NumberSetElement<double>.Create(2, 3, true, true), NumberSet<double>.Create(NumberSetElement<double>.Create(2.2, 2.8, true, true)), true),
                new Tuple<NumberSetElement<double>, NumberSet<double>, bool>(NumberSetElement<double>.Create(2, 3, true, true), NumberSet<double>.Create(NumberSetElement<double>.Create(2.2, 3, true, true)), true),
                new Tuple<NumberSetElement<double>, NumberSet<double>, bool>(NumberSetElement<double>.Create(2, 3, true, true), NumberSet<double>.Create(NumberSetElement<double>.Create(2, 2.8, true, true)), true),
                new Tuple<NumberSetElement<double>, NumberSet<double>, bool>(NumberSetElement<double>.Create(2, 3, true, true), NumberSet<double>.Create(NumberSetElement<double>.CreateEmpty()), true),

                new Tuple<NumberSetElement<double>, NumberSet<double>, bool>(NumberSetElement<double>.Create(2, 2, true, true), NumberSet<double>.Create(NumberSetElement<double>.Create(2, 2, true, true)), true),
                new Tuple<NumberSetElement<double>, NumberSet<double>, bool>(NumberSetElement<double>.Create(2, 2, true, true), NumberSet<double>.Create(NumberSetElement<double>.CreateEmpty()), true),

                new Tuple<NumberSetElement<double>, NumberSet<double>, bool>(NumberSetElement<double>.Create(2, 3, true, true), NumberSet<double>.Create(NumberSetElement<double>.Create(2.2, 4, true, true)), false),
                new Tuple<NumberSetElement<double>, NumberSet<double>, bool>(NumberSetElement<double>.Create(2, 3, true, true), NumberSet<double>.Create(NumberSetElement<double>.Create(1, 2.5, true, true)), false),
                new Tuple<NumberSetElement<double>, NumberSet<double>, bool>(NumberSetElement<double>.Create(2, 3, true, true), NumberSet<double>.Create(NumberSetElement<double>.Create(2, 4, true, true)), false),
                new Tuple<NumberSetElement<double>, NumberSet<double>, bool>(NumberSetElement<double>.Create(2, 3, true, true), NumberSet<double>.Create(NumberSetElement<double>.Create(1, 3, true, true)), false),
                new Tuple<NumberSetElement<double>, NumberSet<double>, bool>(NumberSetElement<double>.Create(2, 3, true, true), NumberSet<double>.Create(NumberSetElement<double>.Create(1, 4, true, true)), false),

                new Tuple<NumberSetElement<double>, NumberSet<double>, bool>(NumberSetElement<double>.Create(2, 2, true, true), NumberSet<double>.Create(NumberSetElement<double>.Create(2, 3, true, true)), false),
                new Tuple<NumberSetElement<double>, NumberSet<double>, bool>(NumberSetElement<double>.Create(2, 2, true, true), NumberSet<double>.Create(NumberSetElement<double>.Create(1, 2, true, true)), false),
                new Tuple<NumberSetElement<double>, NumberSet<double>, bool>(NumberSetElement<double>.Create(2, 2, true, true), NumberSet<double>.Create(NumberSetElement<double>.Create(1, 3, true, true)), false),

                new Tuple<NumberSetElement<double>, NumberSet<double>, bool>(NumberSetElement<double>.CreateEmpty(), NumberSet<double>.Create(NumberSetElement<double>.Create(2, 2, true, true)), false),
                new Tuple<NumberSetElement<double>, NumberSet<double>, bool>(NumberSetElement<double>.CreateEmpty(), NumberSet<double>.Create(NumberSetElement<double>.Create(1, 2, true, true)), false),
                new Tuple<NumberSetElement<double>, NumberSet<double>, bool>(NumberSetElement<double>.CreateEmpty(), NumberSet<double>.Create(NumberSetElement<double>.CreateEmpty()), true),

                new Tuple<NumberSetElement<double>, NumberSet<double>, bool>(NumberSetElement<double>.Create(2, 5, true, true), NumberSet<double>.Create(NumberSetElement<double>.Create(2, 3, false, false), NumberSetElement<double>.Create(4, 5, false, false)), true),
                new Tuple<NumberSetElement<double>, NumberSet<double>, bool>(NumberSetElement<double>.Create(2, 5, true, true), NumberSet<double>.Create(NumberSetElement<double>.Create(2, 3, false, true), NumberSetElement<double>.Create(4, 5, false, true)), true),
                new Tuple<NumberSetElement<double>, NumberSet<double>, bool>(NumberSetElement<double>.Create(2, 5, true, true), NumberSet<double>.Create(NumberSetElement<double>.Create(2, 3, true, false), NumberSetElement<double>.Create(4, 5, true, false)), true),
                new Tuple<NumberSetElement<double>, NumberSet<double>, bool>(NumberSetElement<double>.Create(2, 5, true, true), NumberSet<double>.Create(NumberSetElement<double>.Create(2, 3, true, true), NumberSetElement<double>.Create(4, 5, true, true)), true),

                new Tuple<NumberSetElement<double>, NumberSet<double>, bool>(NumberSetElement<double>.Create(2, 5, true, false), NumberSet<double>.Create(NumberSetElement<double>.Create(2, 3, false, false), NumberSetElement<double>.Create(4, 5, false, false)), true),
                new Tuple<NumberSetElement<double>, NumberSet<double>, bool>(NumberSetElement<double>.Create(2, 5, true, false), NumberSet<double>.Create(NumberSetElement<double>.Create(2, 3, false, true), NumberSetElement<double>.Create(4, 5, false, true)), false),
                new Tuple<NumberSetElement<double>, NumberSet<double>, bool>(NumberSetElement<double>.Create(2, 5, true, false), NumberSet<double>.Create(NumberSetElement<double>.Create(2, 3, true, false), NumberSetElement<double>.Create(4, 5, true, false)), true),
                new Tuple<NumberSetElement<double>, NumberSet<double>, bool>(NumberSetElement<double>.Create(2, 5, true, false), NumberSet<double>.Create(NumberSetElement<double>.Create(2, 3, true, true), NumberSetElement<double>.Create(4, 5, true, true)), false),

                new Tuple<NumberSetElement<double>, NumberSet<double>, bool>(NumberSetElement<double>.Create(2, 5, false, true), NumberSet<double>.Create(NumberSetElement<double>.Create(2, 3, false, false), NumberSetElement<double>.Create(4, 5, false, false)), true),
                new Tuple<NumberSetElement<double>, NumberSet<double>, bool>(NumberSetElement<double>.Create(2, 5, false, true), NumberSet<double>.Create(NumberSetElement<double>.Create(2, 3, false, true), NumberSetElement<double>.Create(4, 5, false, true)), true),
                new Tuple<NumberSetElement<double>, NumberSet<double>, bool>(NumberSetElement<double>.Create(2, 5, false, true), NumberSet<double>.Create(NumberSetElement<double>.Create(2, 3, true, false), NumberSetElement<double>.Create(4, 5, true, false)), false),
                new Tuple<NumberSetElement<double>, NumberSet<double>, bool>(NumberSetElement<double>.Create(2, 5, false, true), NumberSet<double>.Create(NumberSetElement<double>.Create(2, 3, true, true), NumberSetElement<double>.Create(4, 5, true, true)), false),

                new Tuple<NumberSetElement<double>, NumberSet<double>, bool>(NumberSetElement<double>.Create(2, 5, false, false), NumberSet<double>.Create(NumberSetElement<double>.Create(2, 3, false, false), NumberSetElement<double>.Create(4, 5, false, false)), true),
                new Tuple<NumberSetElement<double>, NumberSet<double>, bool>(NumberSetElement<double>.Create(2, 5, false, false), NumberSet<double>.Create(NumberSetElement<double>.Create(2, 3, false, true), NumberSetElement<double>.Create(4, 5, false, true)), false),
                new Tuple<NumberSetElement<double>, NumberSet<double>, bool>(NumberSetElement<double>.Create(2, 5, false, false), NumberSet<double>.Create(NumberSetElement<double>.Create(2, 3, true, false), NumberSetElement<double>.Create(4, 5, true, false)), false),
                new Tuple<NumberSetElement<double>, NumberSet<double>, bool>(NumberSetElement<double>.Create(2, 5, false, false), NumberSet<double>.Create(NumberSetElement<double>.Create(2, 3, true, true), NumberSetElement<double>.Create(4, 5, true, true)), false),

                new Tuple<NumberSetElement<double>, NumberSet<double>, bool>(NumberSetElement<double>.Create(2, 5, true, true), NumberSet<double>.Create(NumberSetElement<double>.Create(2.2, 2.8, true, true), NumberSetElement<double>.Create(4.2, 4.8, true, true)), true),
                new Tuple<NumberSetElement<double>, NumberSet<double>, bool>(NumberSetElement<double>.Create(2, 5, true, true), NumberSet<double>.Create(NumberSetElement<double>.Create(2.2, 3, true, true), NumberSetElement<double>.Create(4.2, 5, true, true)), true),
                new Tuple<NumberSetElement<double>, NumberSet<double>, bool>(NumberSetElement<double>.Create(2, 5, true, true), NumberSet<double>.Create(NumberSetElement<double>.Create(2, 2.8, true, true), NumberSetElement<double>.Create(4, 4.8, true, true)), true),

                new Tuple<NumberSetElement<double>, NumberSet<double>, bool>(NumberSetElement<double>.Create(2, 5, true, true), NumberSet<double>.Create(NumberSetElement<double>.Create(2.2, 4, true, true), NumberSetElement<double>.Create(4.2, 6, true, true)), false),
                new Tuple<NumberSetElement<double>, NumberSet<double>, bool>(NumberSetElement<double>.Create(2, 5, true, true), NumberSet<double>.Create(NumberSetElement<double>.Create(1, 2.5, true, true), NumberSetElement<double>.Create(3, 4.5, true, true)), false),
                new Tuple<NumberSetElement<double>, NumberSet<double>, bool>(NumberSetElement<double>.Create(2, 5, true, true), NumberSet<double>.Create(NumberSetElement<double>.Create(2, 4, true, true), NumberSetElement<double>.Create(4, 6, true, true)), false),
                new Tuple<NumberSetElement<double>, NumberSet<double>, bool>(NumberSetElement<double>.Create(2, 5, true, true), NumberSet<double>.Create(NumberSetElement<double>.Create(1, 3, true, true), NumberSetElement<double>.Create(3, 5, true, true)), false),
                new Tuple<NumberSetElement<double>, NumberSet<double>, bool>(NumberSetElement<double>.Create(2, 5, true, true), NumberSet<double>.Create(NumberSetElement<double>.Create(1, 4, true, true), NumberSetElement<double>.Create(3, 6, true, true)), false),

                new Tuple<NumberSetElement<double>, NumberSet<double>, bool>(NumberSetElement<double>.Create(2, 5, true, true), NumberSet<double>.Create(NumberSetElement<double>.Create(0, 1, false, false), NumberSetElement<double>.Create(2, 3, false, false), NumberSetElement<double>.Create(4, 5, false, false)), false),
                new Tuple<NumberSetElement<double>, NumberSet<double>, bool>(NumberSetElement<double>.Create(2, 5, true, true), NumberSet<double>.Create(NumberSetElement<double>.Create(0, 1, false, false), NumberSetElement<double>.Create(2, 3, false, true), NumberSetElement<double>.Create(4, 5, false, true)), false),
                new Tuple<NumberSetElement<double>, NumberSet<double>, bool>(NumberSetElement<double>.Create(2, 5, true, true), NumberSet<double>.Create(NumberSetElement<double>.Create(0, 1, false, false), NumberSetElement<double>.Create(2, 3, true, false), NumberSetElement<double>.Create(4, 5, true, false)), false),
                new Tuple<NumberSetElement<double>, NumberSet<double>, bool>(NumberSetElement<double>.Create(2, 5, true, true), NumberSet<double>.Create(NumberSetElement<double>.Create(0, 1, false, false), NumberSetElement<double>.Create(2, 3, true, true), NumberSetElement<double>.Create(4, 5, true, true)), false),
                new Tuple<NumberSetElement<double>, NumberSet<double>, bool>(NumberSetElement<double>.Create(2, 5, true, true), NumberSet<double>.Create(NumberSetElement<double>.Create(1, 1, true, true), NumberSetElement<double>.Create(2, 3, false, false), NumberSetElement<double>.Create(4, 5, false, false)), false),

                new Tuple<NumberSetElement<double>, NumberSet<double>, bool>(NumberSetElement<double>.Create(2, 5, true, false), NumberSet<double>.Create(NumberSetElement<double>.Create(0, 1, false, false), NumberSetElement<double>.Create(2, 3, false, false), NumberSetElement<double>.Create(4, 5, false, false)), false),
                new Tuple<NumberSetElement<double>, NumberSet<double>, bool>(NumberSetElement<double>.Create(2, 5, true, false), NumberSet<double>.Create(NumberSetElement<double>.Create(0, 1, false, false), NumberSetElement<double>.Create(2, 3, false, true), NumberSetElement<double>.Create(4, 5, false, true)), false),
                new Tuple<NumberSetElement<double>, NumberSet<double>, bool>(NumberSetElement<double>.Create(2, 5, true, false), NumberSet<double>.Create(NumberSetElement<double>.Create(0, 1, false, false), NumberSetElement<double>.Create(2, 3, true, false), NumberSetElement<double>.Create(4, 5, true, false)), false),
                new Tuple<NumberSetElement<double>, NumberSet<double>, bool>(NumberSetElement<double>.Create(2, 5, true, false), NumberSet<double>.Create(NumberSetElement<double>.Create(0, 1, false, false), NumberSetElement<double>.Create(2, 3, true, true), NumberSetElement<double>.Create(4, 5, true, true)), false),

                new Tuple<NumberSetElement<double>, NumberSet<double>, bool>(NumberSetElement<double>.Create(2, 5, false, true), NumberSet<double>.Create(NumberSetElement<double>.Create(0, 1, false, false), NumberSetElement<double>.Create(2, 3, false, false), NumberSetElement<double>.Create(4, 5, false, false)), false),
                new Tuple<NumberSetElement<double>, NumberSet<double>, bool>(NumberSetElement<double>.Create(2, 5, false, true), NumberSet<double>.Create(NumberSetElement<double>.Create(0, 1, false, false), NumberSetElement<double>.Create(2, 3, false, true), NumberSetElement<double>.Create(4, 5, false, true)), false),
                new Tuple<NumberSetElement<double>, NumberSet<double>, bool>(NumberSetElement<double>.Create(2, 5, false, true), NumberSet<double>.Create(NumberSetElement<double>.Create(0, 1, false, false), NumberSetElement<double>.Create(2, 3, true, false), NumberSetElement<double>.Create(4, 5, true, false)), false),
                new Tuple<NumberSetElement<double>, NumberSet<double>, bool>(NumberSetElement<double>.Create(2, 5, false, true), NumberSet<double>.Create(NumberSetElement<double>.Create(0, 1, false, false), NumberSetElement<double>.Create(2, 3, true, true), NumberSetElement<double>.Create(4, 5, true, true)), false),

                new Tuple<NumberSetElement<double>, NumberSet<double>, bool>(NumberSetElement<double>.Create(2, 5, false, false), NumberSet<double>.Create(NumberSetElement<double>.Create(0, 1, false, false), NumberSetElement<double>.Create(2, 3, false, false), NumberSetElement<double>.Create(4, 5, false, false)), false),
                new Tuple<NumberSetElement<double>, NumberSet<double>, bool>(NumberSetElement<double>.Create(2, 5, false, false), NumberSet<double>.Create(NumberSetElement<double>.Create(0, 1, false, false), NumberSetElement<double>.Create(2, 3, false, true), NumberSetElement<double>.Create(4, 5, false, true)), false),
                new Tuple<NumberSetElement<double>, NumberSet<double>, bool>(NumberSetElement<double>.Create(2, 5, false, false), NumberSet<double>.Create(NumberSetElement<double>.Create(0, 1, false, false), NumberSetElement<double>.Create(2, 3, true, false), NumberSetElement<double>.Create(4, 5, true, false)), false),
                new Tuple<NumberSetElement<double>, NumberSet<double>, bool>(NumberSetElement<double>.Create(2, 5, false, false), NumberSet<double>.Create(NumberSetElement<double>.Create(0, 1, false, false), NumberSetElement<double>.Create(2, 3, true, true), NumberSetElement<double>.Create(4, 5, true, true)), false),

                new Tuple<NumberSetElement<double>, NumberSet<double>, bool>(NumberSetElement<double>.Create(2, 5, true, true), NumberSet<double>.Create(NumberSetElement<double>.Create(0, 1, false, false), NumberSetElement<double>.Create(2.2, 2.8, true, true), NumberSetElement<double>.Create(4.2, 4.8, true, true)), false),
                new Tuple<NumberSetElement<double>, NumberSet<double>, bool>(NumberSetElement<double>.Create(2, 5, true, true), NumberSet<double>.Create(NumberSetElement<double>.Create(0, 1, false, false), NumberSetElement<double>.Create(2.2, 3, true, true), NumberSetElement<double>.Create(4.2, 5, true, true)), false),
                new Tuple<NumberSetElement<double>, NumberSet<double>, bool>(NumberSetElement<double>.Create(2, 5, true, true), NumberSet<double>.Create(NumberSetElement<double>.Create(0, 1, false, false), NumberSetElement<double>.Create(2, 2.8, true, true), NumberSetElement<double>.Create(4, 4.8, true, true)), false),

                new Tuple<NumberSetElement<double>, NumberSet<double>, bool>(NumberSetElement<double>.Create(2, 5, true, true), NumberSet<double>.Create(NumberSetElement<double>.Create(0, 1, false, false), NumberSetElement<double>.Create(2.2, 4, true, true), NumberSetElement<double>.Create(4.2, 6, true, true)), false),
                new Tuple<NumberSetElement<double>, NumberSet<double>, bool>(NumberSetElement<double>.Create(2, 5, true, true), NumberSet<double>.Create(NumberSetElement<double>.Create(0, 1, false, false), NumberSetElement<double>.Create(1, 2.5, true, true), NumberSetElement<double>.Create(3, 4.5, true, true)), false),
                new Tuple<NumberSetElement<double>, NumberSet<double>, bool>(NumberSetElement<double>.Create(2, 5, true, true), NumberSet<double>.Create(NumberSetElement<double>.Create(0, 1, false, false), NumberSetElement<double>.Create(2, 4, true, true), NumberSetElement<double>.Create(4, 6, true, true)), false),
                new Tuple<NumberSetElement<double>, NumberSet<double>, bool>(NumberSetElement<double>.Create(2, 5, true, true), NumberSet<double>.Create(NumberSetElement<double>.Create(0, 1, false, false), NumberSetElement<double>.Create(1, 3, true, true), NumberSetElement<double>.Create(3, 5, true, true)), false),
                new Tuple<NumberSetElement<double>, NumberSet<double>, bool>(NumberSetElement<double>.Create(2, 5, true, true), NumberSet<double>.Create(NumberSetElement<double>.Create(0, 1, false, false), NumberSetElement<double>.Create(1, 4, true, true), NumberSetElement<double>.Create(3, 6, true, true)), false),

                new Tuple<NumberSetElement<double>, NumberSet<double>, bool>(NumberSetElement<double>.Create(2, 5, true, true), NumberSet<double>.Create(NumberSetElement<double>.Create(2, 3, false, false), NumberSetElement<double>.Create(4, 5, false, false), NumberSetElement<double>.Create(7, 8, false, false)), false),
                new Tuple<NumberSetElement<double>, NumberSet<double>, bool>(NumberSetElement<double>.Create(2, 5, true, true), NumberSet<double>.Create(NumberSetElement<double>.Create(2, 3, false, true), NumberSetElement<double>.Create(4, 5, false, true), NumberSetElement<double>.Create(7, 8, false, false)), false),
                new Tuple<NumberSetElement<double>, NumberSet<double>, bool>(NumberSetElement<double>.Create(2, 5, true, true), NumberSet<double>.Create(NumberSetElement<double>.Create(2, 3, true, false), NumberSetElement<double>.Create(4, 5, true, false), NumberSetElement<double>.Create(7, 8, false, false)), false),
                new Tuple<NumberSetElement<double>, NumberSet<double>, bool>(NumberSetElement<double>.Create(2, 5, true, true), NumberSet<double>.Create(NumberSetElement<double>.Create(2, 3, true, true), NumberSetElement<double>.Create(4, 5, true, true), NumberSetElement<double>.Create(7, 8, false, false)), false),
                new Tuple<NumberSetElement<double>, NumberSet<double>, bool>(NumberSetElement<double>.Create(2, 5, true, true), NumberSet<double>.Create(NumberSetElement<double>.Create(2, 3, false, false), NumberSetElement<double>.Create(4, 5, false, false), NumberSetElement<double>.Create(8, 8, true, true)), false),

                new Tuple<NumberSetElement<double>, NumberSet<double>, bool>(NumberSetElement<double>.Create(2, 5, true, false), NumberSet<double>.Create(NumberSetElement<double>.Create(2, 3, false, false), NumberSetElement<double>.Create(4, 5, false, false), NumberSetElement<double>.Create(7, 8, false, false)), false),
                new Tuple<NumberSetElement<double>, NumberSet<double>, bool>(NumberSetElement<double>.Create(2, 5, true, false), NumberSet<double>.Create(NumberSetElement<double>.Create(2, 3, false, true), NumberSetElement<double>.Create(4, 5, false, true), NumberSetElement<double>.Create(7, 8, false, false)), false),
                new Tuple<NumberSetElement<double>, NumberSet<double>, bool>(NumberSetElement<double>.Create(2, 5, true, false), NumberSet<double>.Create(NumberSetElement<double>.Create(2, 3, true, false), NumberSetElement<double>.Create(4, 5, true, false), NumberSetElement<double>.Create(7, 8, false, false)), false),
                new Tuple<NumberSetElement<double>, NumberSet<double>, bool>(NumberSetElement<double>.Create(2, 5, true, false), NumberSet<double>.Create(NumberSetElement<double>.Create(2, 3, true, true), NumberSetElement<double>.Create(4, 5, true, true), NumberSetElement<double>.Create(7, 8, false, false)), false),

                new Tuple<NumberSetElement<double>, NumberSet<double>, bool>(NumberSetElement<double>.Create(2, 5, false, true), NumberSet<double>.Create(NumberSetElement<double>.Create(2, 3, false, false), NumberSetElement<double>.Create(4, 5, false, false), NumberSetElement<double>.Create(7, 8, false, false)), false),
                new Tuple<NumberSetElement<double>, NumberSet<double>, bool>(NumberSetElement<double>.Create(2, 5, false, true), NumberSet<double>.Create(NumberSetElement<double>.Create(2, 3, false, true), NumberSetElement<double>.Create(4, 5, false, true), NumberSetElement<double>.Create(7, 8, false, false)), false),
                new Tuple<NumberSetElement<double>, NumberSet<double>, bool>(NumberSetElement<double>.Create(2, 5, false, true), NumberSet<double>.Create(NumberSetElement<double>.Create(2, 3, true, false), NumberSetElement<double>.Create(4, 5, true, false), NumberSetElement<double>.Create(7, 8, false, false)), false),
                new Tuple<NumberSetElement<double>, NumberSet<double>, bool>(NumberSetElement<double>.Create(2, 5, false, true), NumberSet<double>.Create(NumberSetElement<double>.Create(2, 3, true, true), NumberSetElement<double>.Create(4, 5, true, true), NumberSetElement<double>.Create(7, 8, false, false)), false),

                new Tuple<NumberSetElement<double>, NumberSet<double>, bool>(NumberSetElement<double>.Create(2, 5, false, false), NumberSet<double>.Create(NumberSetElement<double>.Create(2, 3, false, false), NumberSetElement<double>.Create(4, 5, false, false), NumberSetElement<double>.Create(7, 8, false, false)), false),
                new Tuple<NumberSetElement<double>, NumberSet<double>, bool>(NumberSetElement<double>.Create(2, 5, false, false), NumberSet<double>.Create(NumberSetElement<double>.Create(2, 3, false, true), NumberSetElement<double>.Create(4, 5, false, true), NumberSetElement<double>.Create(7, 8, false, false)), false),
                new Tuple<NumberSetElement<double>, NumberSet<double>, bool>(NumberSetElement<double>.Create(2, 5, false, false), NumberSet<double>.Create(NumberSetElement<double>.Create(2, 3, true, false), NumberSetElement<double>.Create(4, 5, true, false), NumberSetElement<double>.Create(7, 8, false, false)), false),
                new Tuple<NumberSetElement<double>, NumberSet<double>, bool>(NumberSetElement<double>.Create(2, 5, false, false), NumberSet<double>.Create(NumberSetElement<double>.Create(2, 3, true, true), NumberSetElement<double>.Create(4, 5, true, true), NumberSetElement<double>.Create(7, 8, false, false)), false),

                new Tuple<NumberSetElement<double>, NumberSet<double>, bool>(NumberSetElement<double>.Create(2, 5, true, true), NumberSet<double>.Create(NumberSetElement<double>.Create(2.2, 2.8, true, true), NumberSetElement<double>.Create(4.2, 4.8, true, true), NumberSetElement<double>.Create(7, 8, false, false)), false),
                new Tuple<NumberSetElement<double>, NumberSet<double>, bool>(NumberSetElement<double>.Create(2, 5, true, true), NumberSet<double>.Create(NumberSetElement<double>.Create(2.2, 3, true, true), NumberSetElement<double>.Create(4.2, 5, true, true), NumberSetElement<double>.Create(7, 8, false, false)), false),
                new Tuple<NumberSetElement<double>, NumberSet<double>, bool>(NumberSetElement<double>.Create(2, 5, true, true), NumberSet<double>.Create(NumberSetElement<double>.Create(2, 2.8, true, true), NumberSetElement<double>.Create(4, 4.8, true, true), NumberSetElement<double>.Create(7, 8, false, false)), false),

                new Tuple<NumberSetElement<double>, NumberSet<double>, bool>(NumberSetElement<double>.Create(2, 5, true, true), NumberSet<double>.Create(NumberSetElement<double>.Create(2.2, 4, true, true), NumberSetElement<double>.Create(4.2, 6, true, true), NumberSetElement<double>.Create(7, 8, false, false)), false),
                new Tuple<NumberSetElement<double>, NumberSet<double>, bool>(NumberSetElement<double>.Create(2, 5, true, true), NumberSet<double>.Create(NumberSetElement<double>.Create(1, 2.5, true, true), NumberSetElement<double>.Create(3, 4.5, true, true), NumberSetElement<double>.Create(7, 8, false, false)), false),
                new Tuple<NumberSetElement<double>, NumberSet<double>, bool>(NumberSetElement<double>.Create(2, 5, true, true), NumberSet<double>.Create(NumberSetElement<double>.Create(2, 4, true, true), NumberSetElement<double>.Create(4, 6, true, true), NumberSetElement<double>.Create(7, 8, false, false)), false),
                new Tuple<NumberSetElement<double>, NumberSet<double>, bool>(NumberSetElement<double>.Create(2, 5, true, true), NumberSet<double>.Create(NumberSetElement<double>.Create(1, 3, true, true), NumberSetElement<double>.Create(3, 5, true, true), NumberSetElement<double>.Create(7, 8, false, false)), false),
                new Tuple<NumberSetElement<double>, NumberSet<double>, bool>(NumberSetElement<double>.Create(2, 5, true, true), NumberSet<double>.Create(NumberSetElement<double>.Create(1, 4, true, true), NumberSetElement<double>.Create(3, 6, true, true), NumberSetElement<double>.Create(7, 8, false, false)), false),

                new Tuple<NumberSetElement<double>, NumberSet<double>, bool>(NumberSetElement<double>.Create(2, 2, true, true), NumberSet<double>.Create(NumberSetElement<double>.Create(0, 1, false, false), NumberSetElement<double>.Create(2, 2, true, true)), false),
                new Tuple<NumberSetElement<double>, NumberSet<double>, bool>(NumberSetElement<double>.Create(2, 2, true, true), NumberSet<double>.Create(NumberSetElement<double>.Create(0, 1, false, false), NumberSetElement<double>.Create(2, 3, true, true)), false),
                new Tuple<NumberSetElement<double>, NumberSet<double>, bool>(NumberSetElement<double>.Create(2, 2, true, true), NumberSet<double>.Create(NumberSetElement<double>.Create(0, 1, false, false), NumberSetElement<double>.Create(1, 2, true, true)), false),
                new Tuple<NumberSetElement<double>, NumberSet<double>, bool>(NumberSetElement<double>.Create(2, 2, true, true), NumberSet<double>.Create(NumberSetElement<double>.Create(0, 1, false, false), NumberSetElement<double>.Create(1, 3, true, true)), false),

                new Tuple<NumberSetElement<double>, NumberSet<double>, bool>(NumberSetElement<double>.Create(2, 2, true, true), NumberSet<double>.Create(NumberSetElement<double>.Create(1, 1, true, true), NumberSetElement<double>.Create(2, 2, true, true)), false),
                new Tuple<NumberSetElement<double>, NumberSet<double>, bool>(NumberSetElement<double>.Create(2, 2, true, true), NumberSet<double>.Create(NumberSetElement<double>.Create(1, 1, true, true), NumberSetElement<double>.Create(2, 3, true, true)), false),
                new Tuple<NumberSetElement<double>, NumberSet<double>, bool>(NumberSetElement<double>.Create(2, 2, true, true), NumberSet<double>.Create(NumberSetElement<double>.Create(1, 1, true, true), NumberSetElement<double>.Create(1, 2, true, true)), false),
                new Tuple<NumberSetElement<double>, NumberSet<double>, bool>(NumberSetElement<double>.Create(2, 2, true, true), NumberSet<double>.Create(NumberSetElement<double>.Create(1, 1, true, true), NumberSetElement<double>.Create(1, 3, true, true)), false),

                new Tuple<NumberSetElement<double>, NumberSet<double>, bool>(NumberSetElement<double>.Create(2, 2, true, true), NumberSet<double>.Create(NumberSetElement<double>.Create(2, 2, true, true), NumberSetElement<double>.Create(7, 8, false, false)), false),
                new Tuple<NumberSetElement<double>, NumberSet<double>, bool>(NumberSetElement<double>.Create(2, 2, true, true), NumberSet<double>.Create(NumberSetElement<double>.Create(2, 3, true, true), NumberSetElement<double>.Create(7, 8, false, false)), false),
                new Tuple<NumberSetElement<double>, NumberSet<double>, bool>(NumberSetElement<double>.Create(2, 2, true, true), NumberSet<double>.Create(NumberSetElement<double>.Create(1, 2, true, true), NumberSetElement<double>.Create(7, 8, false, false)), false),
                new Tuple<NumberSetElement<double>, NumberSet<double>, bool>(NumberSetElement<double>.Create(2, 2, true, true), NumberSet<double>.Create(NumberSetElement<double>.Create(1, 3, true, true), NumberSetElement<double>.Create(7, 8, false, false)), false),

                new Tuple<NumberSetElement<double>, NumberSet<double>, bool>(NumberSetElement<double>.Create(2, 2, true, true), NumberSet<double>.Create(NumberSetElement<double>.Create(2, 2, true, true), NumberSetElement<double>.Create(8, 8, true, true)), false),
                new Tuple<NumberSetElement<double>, NumberSet<double>, bool>(NumberSetElement<double>.Create(2, 2, true, true), NumberSet<double>.Create(NumberSetElement<double>.Create(2, 3, true, true), NumberSetElement<double>.Create(8, 8, true, true)), false),
                new Tuple<NumberSetElement<double>, NumberSet<double>, bool>(NumberSetElement<double>.Create(2, 2, true, true), NumberSet<double>.Create(NumberSetElement<double>.Create(1, 2, true, true), NumberSetElement<double>.Create(8, 8, true, true)), false),
                new Tuple<NumberSetElement<double>, NumberSet<double>, bool>(NumberSetElement<double>.Create(2, 2, true, true), NumberSet<double>.Create(NumberSetElement<double>.Create(1, 3, true, true), NumberSetElement<double>.Create(8, 8, true, true)), false),

                new Tuple<NumberSetElement<double>, NumberSet<double>, bool>(NumberSetElement<double>.Create(2, 8, false, false), NumberSet<double>.Create(NumberSetElement<double>.Create(2.5, 3, true, true), NumberSetElement<double>.Create(4, 5, true, true), NumberSetElement<double>.Create(6, 7, false, true)), true),
            };
            for (int i = 0; i < elementList.Count; i++)
                Assert.IsTrue(elementList[i].Item1.Contains(elementList[i].Item2) == elementList[i].Item3);
        }
        
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
