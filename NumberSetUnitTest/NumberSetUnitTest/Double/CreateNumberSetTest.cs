﻿using Utte.NumberSet;

namespace NumberSetUnitTest.NumberSetUnitTest.Double
{
    [TestClass]
    public class CreateNumberSetTest
    {
        [TestMethod]
        public void TestCreateClosedSet()
        {
            var element = NumberSetElement<double>.Create(2, 3, true, true);
            var numberSet = NumberSet<double>.Create(new List<INumberSetElement<double>>() { element });
            Assert.AreEqual(numberSet.LowerBound, 2);
            Assert.AreEqual(numberSet.UpperBound, 3);
            Assert.IsFalse(numberSet.IsEmpty);
            Assert.IsTrue(numberSet.IsClosed);
            Assert.IsFalse(numberSet.IsOpen);
            Assert.AreEqual(numberSet.Measure, 1);
            Assert.AreEqual(numberSet.Count, 1);
        }

        [TestMethod]
        public void TestCreateOpenSet()
        {
            var element = NumberSetElement<double>.Create(2, 3, false, false);
            var numberSet = NumberSet<double>.Create(new List<INumberSetElement<double>>() { element });
            Assert.AreEqual(numberSet.LowerBound, 2);
            Assert.AreEqual(numberSet.UpperBound, 3);
            Assert.IsFalse(numberSet.IsEmpty);
            Assert.IsFalse(numberSet.IsClosed);
            Assert.IsTrue(numberSet.IsOpen);
            Assert.AreEqual(numberSet.Measure, 1);
            Assert.AreEqual(numberSet.Count, 1);
        }

        [TestMethod]
        public void TestCreateLeftOpenRightClosedSet()
        {
            var element = NumberSetElement<double>.Create(2, 3, false, true);
            var numberSet = NumberSet<double>.Create(new List<INumberSetElement<double>>() { element });
            Assert.AreEqual(numberSet.LowerBound, 2);
            Assert.AreEqual(numberSet.UpperBound, 3);
            Assert.IsFalse(numberSet.IsEmpty);
            Assert.IsFalse(numberSet.IsClosed);
            Assert.IsFalse(numberSet.IsOpen);
            Assert.AreEqual(numberSet.Measure, 1);
            Assert.AreEqual(numberSet.Count, 1);
        }

        [TestMethod]
        public void TestCreateLeftClosedRightOpenSet()
        {
            var element = NumberSetElement<double>.Create(2, 3, true, false);
            var numberSet = NumberSet<double>.Create(new List<INumberSetElement<double>>() { element });
            Assert.AreEqual(numberSet.LowerBound, 2);
            Assert.AreEqual(numberSet.UpperBound, 3);
            Assert.IsFalse(numberSet.IsEmpty);
            Assert.IsFalse(numberSet.IsClosed);
            Assert.IsFalse(numberSet.IsOpen);
            Assert.AreEqual(numberSet.Measure, 1);
            Assert.AreEqual(numberSet.Count, 1);
        }

        [TestMethod]
        public void TestCreateNoParametersSet()
        {
            var numberSet = NumberSet<double>.Create();
            Assert.AreEqual(numberSet.LowerBound, default(double));
            Assert.AreEqual(numberSet.UpperBound, default(double));
            Assert.IsTrue(numberSet.IsEmpty);
            Assert.IsFalse(numberSet.IsClosed);
            Assert.IsTrue(numberSet.IsOpen);
            Assert.AreEqual(numberSet.Measure, 0);
            Assert.AreEqual(numberSet.Count, 1);
        }

        [TestMethod]
        public void TestCreateEmptySet()
        {
            var numberSet = NumberSet<double>.Empty;
            Assert.AreEqual(numberSet.LowerBound, default(double));
            Assert.AreEqual(numberSet.UpperBound, default(double));
            Assert.IsTrue(numberSet.IsEmpty);
            Assert.IsFalse(numberSet.IsClosed);
            Assert.IsTrue(numberSet.IsOpen);
            Assert.AreEqual(numberSet.Measure, 0);
            Assert.AreEqual(numberSet.Count, 1);
        }

        [TestMethod]
        public void TestCreateFromNullList()
        {
            var numberSet = NumberSet<double>.Create(null!);
            Assert.AreEqual(numberSet.LowerBound, default(double));
            Assert.AreEqual(numberSet.UpperBound, default(double));
            Assert.IsTrue(numberSet.IsEmpty);
            Assert.IsFalse(numberSet.IsClosed);
            Assert.IsTrue(numberSet.IsOpen);
            Assert.AreEqual(numberSet.Measure, 0);
            Assert.AreEqual(numberSet.Count, 1);
        }

        [TestMethod]
        public void TestCreateFromListContainingNull()
        {
            var numberSet = NumberSet<double>.Create(new List<INumberSetElement<double>?>() { null });
            Assert.AreEqual(numberSet.LowerBound, default(double));
            Assert.AreEqual(numberSet.UpperBound, default(double));
            Assert.IsTrue(numberSet.IsEmpty);
            Assert.IsFalse(numberSet.IsClosed);
            Assert.IsTrue(numberSet.IsOpen);
            Assert.AreEqual(numberSet.Measure, 0);
            Assert.AreEqual(numberSet.Count, 1);
        }

        [TestMethod]
        public void TestCreateFromListContainingNullFirst()
        {
            var numberSet = NumberSet<double>.Create(new List<INumberSetElement<double>?>() { null, NumberSetElement<double>.Create(2, 3, true, false) });
            Assert.AreEqual(numberSet.LowerBound, 2);
            Assert.AreEqual(numberSet.UpperBound, 3);
            Assert.IsFalse(numberSet.IsEmpty);
            Assert.IsFalse(numberSet.IsClosed);
            Assert.IsFalse(numberSet.IsOpen);
            Assert.AreEqual(numberSet.Measure, 1);
            Assert.AreEqual(numberSet.Count, 1);
        }

        [TestMethod]
        public void TestCreateFromListContainingNullLast()
        {
            var numberSet = NumberSet<double>.Create(new List<INumberSetElement<double>?>() { NumberSetElement<double>.Create(2, 3, true, false), null });
            Assert.AreEqual(numberSet.LowerBound, 2);
            Assert.AreEqual(numberSet.UpperBound, 3);
            Assert.IsFalse(numberSet.IsEmpty);
            Assert.IsFalse(numberSet.IsClosed);
            Assert.IsFalse(numberSet.IsOpen);
            Assert.AreEqual(numberSet.Measure, 1);
            Assert.AreEqual(numberSet.Count, 1);
        }

        [TestMethod]
        public void TestCreateFromEmptyList()
        {
            var numberSet = NumberSet<double>.Create(new List<INumberSetElement<double>>());
            Assert.AreEqual(numberSet.LowerBound, default(double));
            Assert.AreEqual(numberSet.UpperBound, default(double));
            Assert.IsTrue(numberSet.IsEmpty);
            Assert.IsFalse(numberSet.IsClosed);
            Assert.IsTrue(numberSet.IsOpen);
            Assert.AreEqual(numberSet.Measure, 0);
            Assert.AreEqual(numberSet.Count, 1);
        }

        [TestMethod]
        public void TestCreateFromPointBoundsFalseFalse()
        {
            var element = NumberSetElement<double>.Create(2, 2, false, false);
            var numberSet = NumberSet<double>.Create(new List<INumberSetElement<double>>() { element });
            Assert.AreEqual(numberSet.LowerBound, default(double));
            Assert.AreEqual(numberSet.UpperBound, default(double));
            Assert.IsTrue(numberSet.IsEmpty);
            Assert.IsFalse(numberSet.IsClosed);
            Assert.IsTrue(numberSet.IsOpen);
            Assert.AreEqual(numberSet.Measure, 0);
            Assert.AreEqual(numberSet.Count, 1);
        }

        [TestMethod]
        public void TestCreateFromPointBoundsFalseTrue()
        {
            var element = NumberSetElement<double>.Create(2, 2, false, true);
            var numberSet = NumberSet<double>.Create(new List<INumberSetElement<double>>() { element });
            Assert.AreEqual(numberSet.LowerBound, default(double));
            Assert.AreEqual(numberSet.UpperBound, default(double));
            Assert.IsTrue(numberSet.IsEmpty);
            Assert.IsFalse(numberSet.IsClosed);
            Assert.IsTrue(numberSet.IsOpen);
            Assert.AreEqual(numberSet.Measure, 0);
            Assert.AreEqual(numberSet.Count, 1);
        }

        [TestMethod]
        public void TestCreateFromPointBoundsTrueFalse()
        {
            var element = NumberSetElement<double>.Create(2, 2, true, false);
            var numberSet = NumberSet<double>.Create(new List<INumberSetElement<double>>() { element });
            Assert.AreEqual(numberSet.LowerBound, default(double));
            Assert.AreEqual(numberSet.UpperBound, default(double));
            Assert.IsTrue(numberSet.IsEmpty);
            Assert.IsFalse(numberSet.IsClosed);
            Assert.IsTrue(numberSet.IsOpen);
            Assert.AreEqual(numberSet.Measure, 0);
            Assert.AreEqual(numberSet.Count, 1);
        }

        [TestMethod]
        public void TestCreateFromPointBoundsTrueTrue()
        {
            var element = NumberSetElement<double>.Create(2, 2, true, true);
            var numberSet = NumberSet<double>.Create(new List<INumberSetElement<double>>() { element });
            Assert.AreEqual(numberSet.LowerBound, 2);
            Assert.AreEqual(numberSet.UpperBound, 2);
            Assert.IsFalse(numberSet.IsEmpty);
            Assert.IsTrue(numberSet.IsClosed);
            Assert.IsFalse(numberSet.IsOpen);
            Assert.AreEqual(numberSet.Measure, 0);
            Assert.AreEqual(numberSet.Count, 1);
        }

        [TestMethod]
        public void TestCreateLowerBoundHigherThanUpperBound()
        {
            var element = NumberSetElement<double>.Create(3, 2, false, false);
            var numberSet = NumberSet<double>.Create(new List<INumberSetElement<double>>() { element });
            Assert.AreEqual(numberSet.LowerBound, default(double));
            Assert.AreEqual(numberSet.UpperBound, default(double));
            Assert.IsTrue(numberSet.IsEmpty);
            Assert.IsFalse(numberSet.IsClosed);
            Assert.IsTrue(numberSet.IsOpen);
            Assert.AreEqual(numberSet.Measure, 0);
            Assert.AreEqual(numberSet.Count, 1);
        }

        [TestMethod]
        public void TestCreateSet2Elements()
        {
            for (var i = 0; i < 2; i++)
            {
                var bool1 = i == 0;
                for (int k = 0; k < 2; k++)
                {
                    var bool2 = k == 0;
                    for (int l = 0; l < 2; l++)
                    {
                        var bool3 = l == 0;
                        for (int m = 0; m < 2; m++)
                        {
                            var bool4 = m == 0;
                            var element1 = NumberSetElement<double>.Create(2, 3, bool1, bool2);
                            var element2 = NumberSetElement<double>.Create(4, 6, bool3, bool4);
                            var numberSet = NumberSet<double>.Create(new List<INumberSetElement<double>>() { element1, element2 });

                            Assert.AreEqual(numberSet.LowerBound, 2);
                            Assert.AreEqual(numberSet.UpperBound, 6);
                            Assert.IsFalse(numberSet.IsEmpty);
                            Assert.AreEqual(numberSet.Measure, 3);
                            Assert.AreEqual(numberSet.Count, 2);

                            if (bool1 && bool2 && bool3 && bool4)
                            {
                                Assert.IsTrue(numberSet.IsClosed);
                                Assert.IsFalse(numberSet.IsOpen);
                            }
                            else if (!bool1 && !bool2 && !bool3 && !bool4)
                            {
                                Assert.IsFalse(numberSet.IsClosed);
                                Assert.IsTrue(numberSet.IsOpen);
                            }
                            else
                            {
                                Assert.IsFalse(numberSet.IsClosed);
                                Assert.IsFalse(numberSet.IsOpen);
                            }
                        }
                    }
                }
            }
        }

        [TestMethod]
        public void TestCreateSet2ElementsSharingBoundary()
        {
            for (var i = 0; i < 2; i++)
            {
                var bool1 = i == 0;
                for (int k = 0; k < 2; k++)
                {
                    var bool2 = k == 0;
                    for (int l = 0; l < 2; l++)
                    {
                        var bool3 = l == 0;
                        for (int m = 0; m < 2; m++)
                        {
                            var bool4 = m == 0;
                            var element1 = NumberSetElement<double>.Create(2, 4, bool1, bool2);
                            var element2 = NumberSetElement<double>.Create(4, 6, bool3, bool4);
                            var numberSet1 = NumberSet<double>.Create(new List<INumberSetElement<double>>() { element1, element2 });
                            var numberSet2 = NumberSet<double>.Create(new List<INumberSetElement<double>>() { element2, element1 });

                            Assert.AreEqual(numberSet1.LowerBound, 2);
                            Assert.AreEqual(numberSet1.UpperBound, 6);
                            Assert.IsFalse(numberSet1.IsEmpty);
                            Assert.AreEqual(numberSet1.Measure, 4);
                            if (!bool2 && !bool3)
                            {
                                Assert.AreEqual(numberSet1.Count, 2);
                                Assert.AreEqual(numberSet2.Count, 2);

                                Assert.IsFalse(numberSet1.IsClosed);
                                Assert.IsFalse(numberSet2.IsClosed);

                                if (!bool1 && !bool4)
                                {
                                    Assert.IsTrue(numberSet1.IsOpen);
                                    Assert.IsTrue(numberSet2.IsOpen);
                                }
                                else
                                {
                                    Assert.IsFalse(numberSet1.IsOpen);
                                    Assert.IsFalse(numberSet2.IsOpen);
                                }
                            }
                            else
                            {
                                Assert.AreEqual(numberSet1.Count, 1);
                                Assert.AreEqual(numberSet2.Count, 1);

                                if (bool1 && bool4)
                                {
                                    Assert.IsTrue(numberSet1.IsClosed);
                                    Assert.IsFalse(numberSet1.IsOpen);
                                    Assert.IsTrue(numberSet2.IsClosed);
                                    Assert.IsFalse(numberSet2.IsOpen);
                                }
                                else if (!bool1 && !bool4)
                                {
                                    Assert.IsFalse(numberSet1.IsClosed);
                                    Assert.IsTrue(numberSet1.IsOpen);
                                    Assert.IsFalse(numberSet2.IsClosed);
                                    Assert.IsTrue(numberSet2.IsOpen);
                                }
                                else
                                {
                                    Assert.IsFalse(numberSet1.IsClosed);
                                    Assert.IsFalse(numberSet1.IsOpen);
                                    Assert.IsFalse(numberSet2.IsClosed);
                                    Assert.IsFalse(numberSet2.IsOpen);
                                }
                            }
                        }
                    }
                }
            }
        }

        [TestMethod]
        public void TestCreateSet4Elements()
        {
            var element1 = NumberSetElement<double>.Create(2, 3, true, true);
            var element2 = NumberSetElement<double>.Create(4, 6, true, true);
            var element3 = NumberSetElement<double>.Create(7, 8.5, false, true);
            var element4 = NumberSetElement<double>.Create(9, 10, true, true);
            var numberSet = NumberSet<double>.Create(new List<INumberSetElement<double>>() { element1, element2, element3, element4 });
            Assert.AreEqual(numberSet.LowerBound, 2);
            Assert.AreEqual(numberSet.UpperBound, 10);
            Assert.IsFalse(numberSet.IsEmpty);
            Assert.IsFalse(numberSet.IsClosed);
            Assert.IsFalse(numberSet.IsOpen);
            Assert.AreEqual(numberSet.Measure, 5.5);
            Assert.AreEqual(numberSet.Count, 4);
        }

        [TestMethod]
        public void TestCreateSetWithEmptySet1()
        {
            var element1 = NumberSetElement<double>.Empty;
            var element2 = NumberSetElement<double>.Create(2, 3, true, false);
            var numberSet = NumberSet<double>.Create(new List<INumberSetElement<double>>() { element1, element2 });
            Assert.AreEqual(numberSet.LowerBound, 2);
            Assert.AreEqual(numberSet.UpperBound, 3);
            Assert.IsFalse(numberSet.IsEmpty);
            Assert.IsFalse(numberSet.IsClosed);
            Assert.IsFalse(numberSet.IsOpen);
            Assert.AreEqual(numberSet.Measure, 1);
            Assert.AreEqual(numberSet.Count, 1);
        }

        [TestMethod]
        public void TestCreateSetWithEmptySet3()
        {
            var element1 = NumberSetElement<double>.Create(2, 3, true, true);
            var element2 = NumberSetElement<double>.Create(4, 6, true, true);
            var element3 = NumberSetElement<double>.Create(7, 8.5, false, true);
            var element4 = NumberSetElement<double>.Empty;
            var numberSet = NumberSet<double>.Create(new List<INumberSetElement<double>>() { element1, element2, element3, element4 });
            Assert.AreEqual(numberSet.LowerBound, 2);
            Assert.AreEqual(numberSet.UpperBound, 8.5);
            Assert.IsFalse(numberSet.IsEmpty);
            Assert.IsFalse(numberSet.IsClosed);
            Assert.IsFalse(numberSet.IsOpen);
            Assert.AreEqual(numberSet.Measure, 4.5);
            Assert.AreEqual(numberSet.Count, 3);
        }

        [TestMethod]
        public void TestCreateSet4ElementsWrongOrder()
        {
            var element1 = NumberSetElement<double>.Create(2, 3, true, true);
            var element2 = NumberSetElement<double>.Create(4, 6, true, true);
            var element3 = NumberSetElement<double>.Create(7, 8.5, false, true);
            var element4 = NumberSetElement<double>.Create(9, 10, true, true);
            var numberSetList = new List<INumberSet<double>>()
            {
                NumberSet<double>.Create(new List<INumberSetElement<double>>() { element4, element1, element2, element3 }),
                NumberSet<double>.Create(new List<INumberSetElement<double>>() { element2, element3, element4, element1 }),
                NumberSet<double>.Create(new List<INumberSetElement<double>>() { element3, element1, element2, element4 }),
                NumberSet<double>.Create(new List<INumberSetElement<double>>() { element1, element3, element4, element2 }),
                NumberSet<double>.Create(new List<INumberSetElement<double>>() { element2, element3, element1, element4 }),
                NumberSet<double>.Create(new List<INumberSetElement<double>>() { element4, element3, element2, element1 }),
                NumberSet<double>.Create(new List<INumberSetElement<double>>() { element1, element4, element2, element3 }),
            };
            foreach (var numberSet in numberSetList)
            {
                Assert.AreEqual(numberSet.LowerBound, 2);
                Assert.AreEqual(numberSet.UpperBound, 10);
                Assert.IsFalse(numberSet.IsEmpty);
                Assert.IsFalse(numberSet.IsClosed);
                Assert.IsFalse(numberSet.IsOpen);
                Assert.AreEqual(numberSet.Measure, 5.5);
                Assert.AreEqual(numberSet.Count, 4);
                Assert.IsTrue((NumberSetElement<double>)numberSet[0] == element1);
                Assert.IsTrue((NumberSetElement<double>)numberSet[1] == element2);
                Assert.IsTrue((NumberSetElement<double>)numberSet[2] == element3);
                Assert.IsTrue((NumberSetElement<double>)numberSet[3] == element4);
            }
        }

        [TestMethod]
        public void TestCreateSetCoveringSet()
        {
            var element1 = NumberSetElement<double>.Create(1, 5, true, false);
            var element2 = NumberSetElement<double>.Create(2, 3, true, false);
            var numberSet = NumberSet<double>.Create(new List<INumberSetElement<double>>() { element1, element2 });
            Assert.AreEqual(numberSet.LowerBound, 1);
            Assert.AreEqual(numberSet.UpperBound, 5);
        }

        [TestMethod]
        public void TestCreateSetSetCovering()
        {
            var element1 = NumberSetElement<double>.Create(2, 3, true, false);
            var element2 = NumberSetElement<double>.Create(1, 5, true, false);
            var numberSet = NumberSet<double>.Create(new List<INumberSetElement<double>>() { element1, element2 });
            Assert.AreEqual(numberSet.LowerBound, 1);
            Assert.AreEqual(numberSet.UpperBound, 5);
        }

        [TestMethod]
        public void TestCreateSetCoveringSetExceptPossiblyEdges()
        {
            for (var i = 0; i < 2; i++)
            {
                var bool1 = i == 0;
                for (int k = 0; k < 2; k++)
                {
                    var bool2 = k == 0;
                    for (int l = 0; l < 2; l++)
                    {
                        var bool3 = l == 0;
                        for (int m = 0; m < 2; m++)
                        {
                            var bool4 = m == 0;
                            var element1 = NumberSetElement<double>.Create(2, 3, bool1, bool2);
                            var element2 = NumberSetElement<double>.Create(2, 3, bool3, bool4);
                            var numberSet = NumberSet<double>.Create(new List<INumberSetElement<double>>() { element1, element2 });
                            Assert.AreEqual(numberSet.LowerBound, 2);
                            Assert.AreEqual(numberSet.UpperBound, 3);
                            Assert.IsFalse(numberSet.IsEmpty);
                            if ((bool1 || bool3) && (bool2 || bool4))
                                Assert.IsTrue(numberSet.IsClosed);
                            else
                                Assert.IsFalse(numberSet.IsClosed);
                            if (!bool1 && !bool2 && !bool3 && !bool4)
                                Assert.IsTrue(numberSet.IsOpen);
                            else
                                Assert.IsFalse(numberSet.IsOpen);
                            Assert.AreEqual(numberSet.Measure, 1);
                            Assert.AreEqual(numberSet.Count, 1);
                        }
                    }
                }
            }
        }

        [TestMethod]
        public void TestCreateSetCoveringSetPartlyFromRight()
        {
            for (var i = 0; i < 2; i++)
            {
                var bool1 = i == 0;
                for (int k = 0; k < 2; k++)
                {
                    var bool2 = k == 0;
                    for (int l = 0; l < 2; l++)
                    {
                        var bool3 = l == 0;
                        for (int m = 0; m < 2; m++)
                        {
                            var bool4 = m == 0;
                            var element1 = NumberSetElement<double>.Create(2, 4, bool1, bool2);
                            var element2 = NumberSetElement<double>.Create(3, 5, bool3, bool4);
                            var numberSet = NumberSet<double>.Create(new List<INumberSetElement<double>>() { element1, element2 });
                            Assert.AreEqual(numberSet.LowerBound, 2);
                            Assert.AreEqual(numberSet.UpperBound, 5);
                            Assert.IsFalse(numberSet.IsEmpty);
                            if (bool1 && bool4)
                                Assert.IsTrue(numberSet.IsClosed);
                            else
                                Assert.IsFalse(numberSet.IsClosed);
                            if (!bool1 && !bool4)
                                Assert.IsTrue(numberSet.IsOpen);
                            else
                                Assert.IsFalse(numberSet.IsOpen);
                            Assert.AreEqual(numberSet.Measure, 3);
                            Assert.AreEqual(numberSet.Count, 1);
                        }
                    }
                }
            }
        }

        [TestMethod]
        public void TestCreateSetCoveringSetPartlyFromLeft()
        {
            for (var i = 0; i < 2; i++)
            {
                var bool1 = i == 0;
                for (int k = 0; k < 2; k++)
                {
                    var bool2 = k == 0;
                    for (int l = 0; l < 2; l++)
                    {
                        var bool3 = l == 0;
                        for (int m = 0; m < 2; m++)
                        {
                            var bool4 = m == 0;
                            var element1 = NumberSetElement<double>.Create(3, 5, bool1, bool2);
                            var element2 = NumberSetElement<double>.Create(2, 4, bool3, bool4);
                            var numberSet = NumberSet<double>.Create(new List<INumberSetElement<double>>() { element1, element2 });
                            Assert.AreEqual(numberSet.LowerBound, 2);
                            Assert.AreEqual(numberSet.UpperBound, 5);
                            Assert.IsFalse(numberSet.IsEmpty);
                            if (bool2 && bool3)
                                Assert.IsTrue(numberSet.IsClosed);
                            else
                                Assert.IsFalse(numberSet.IsClosed);
                            if (!bool2 && !bool3)
                                Assert.IsTrue(numberSet.IsOpen);
                            else
                                Assert.IsFalse(numberSet.IsOpen);
                            Assert.AreEqual(numberSet.Measure, 3);
                            Assert.AreEqual(numberSet.Count, 1);
                        }
                    }
                }
            }
        }

        [TestMethod]
        public void TestCreateSet7ElementsComplexWrongOrder()
        {
            var element1 = NumberSetElement<double>.Create(2, 3, true, true);
            var element2 = NumberSetElement<double>.Create(5, 8, true, true);
            var element3 = NumberSetElement<double>.Create(4, 6, true, true);
            var element4 = NumberSetElement<double>.Create(5, 6, true, true);
            var element5 = NumberSetElement<double>.Create(7, 10, true, true);
            var element6 = NumberSetElement<double>.Create(11, 13, true, false);
            var element7 = NumberSetElement<double>.Create(12, 13, true, true);
            var numberSetList = new List<INumberSet<double>>()
            {
                NumberSet<double>.Create(new List<INumberSetElement<double>>() { element4, element5, element1, element7, element6, element2, element3 }),
                NumberSet<double>.Create(new List<INumberSetElement<double>>() { element2, element7, element3, element4, element1, element6, element5 }),
                NumberSet<double>.Create(new List<INumberSetElement<double>>() { element5, element6, element3, element1, element2, element4, element7 }),
                NumberSet<double>.Create(new List<INumberSetElement<double>>() { element6, element1, element5, element3, element7, element4, element2 }),
                NumberSet<double>.Create(new List<INumberSetElement<double>>() { element7, element2, element3, element1, element4, element6, element5 }),
                NumberSet<double>.Create(new List<INumberSetElement<double>>() { element6, element4, element7, element3, element2, element5, element1 }),
                NumberSet<double>.Create(new List<INumberSetElement<double>>() { element1, element4, element5, element2, element3, element7, element6 }),
                NumberSet<double>.Create(new List<INumberSetElement<double>>() { element7, element6, element5, element4, element3, element2, element1 }),
            };
            foreach (var numberSet in numberSetList)
            {
                Assert.AreEqual(numberSet.LowerBound, 2);
                Assert.AreEqual(numberSet.UpperBound, 13);
                Assert.IsFalse(numberSet.IsEmpty);
                Assert.IsTrue(numberSet.IsClosed);
                Assert.IsFalse(numberSet.IsOpen);
                Assert.AreEqual(numberSet.Measure, 9);
                Assert.AreEqual(numberSet.Count, 3);
                Assert.IsTrue(numberSet[0].Equals(element1));
                Assert.IsTrue(numberSet[1].Equals(NumberSetElement<double>.Create(4, 10, true, true)));
                Assert.IsTrue(numberSet[2].Equals(NumberSetElement<double>.Create(11, 13, true, true)));
            }
        }

        [TestMethod]
        public void TestCreateDifferingOrder()
        {
            var elementList = new List<INumberSetElement<double>>()
            {
                NumberSetElement<double>.Create(2, 5, true, true),
                NumberSetElement<double>.Create(3, 8, true, false),
                NumberSetElement<double>.Create(4, 7, false, true),
                NumberSetElement<double>.Create(9,12, false, false),
                NumberSetElement<double>.Create(7, 9, true, true),
            };
            for (int i = 0; i < elementList.Count - 1; i++)
            {
                for (int j = 0; j < elementList.Count; j++)
                {
                    if (j != i)
                    {
                        for (int k = 0; k < elementList.Count; k++)
                        {
                            if (k != j && k != i)
                            {
                                for (int l = 0; l < elementList.Count; l++)
                                {
                                    if (l != j && l != i && l != k)
                                    {
                                        for (int m = 0; m < elementList.Count; m++)
                                        {
                                            if (m != j && m != i && m != k && m != l)
                                            {
                                                var numberSet = NumberSet<double>.Create(new List<INumberSetElement<double>>() { elementList[i], elementList[j], elementList[k], elementList[l], elementList[m] });
                                                Assert.AreEqual(numberSet.LowerBound, 2);
                                                Assert.AreEqual(numberSet.UpperBound, 12);
                                                Assert.IsFalse(numberSet.IsEmpty);
                                                Assert.IsFalse(numberSet.IsClosed);
                                                Assert.IsFalse(numberSet.IsOpen);
                                                Assert.AreEqual(numberSet.Measure, 10);
                                                Assert.AreEqual(numberSet.Count, 1);
                                            }
                                        }
                                    }
                                }
                            }
                        }
                    }
                }
            }
        }
    }
}
