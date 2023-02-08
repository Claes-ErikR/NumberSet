using NumberSet;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace NumberSetUnitTest
{
    [TestClass]
    public class NumberSetElementUnitTest
    {
        [TestMethod]
        public void TestCreateClosedSet()
        {
            var element = NumberSetElement<double>.Create(2, 3, true, true);
            Assert.AreEqual(element.LowerBound, 2);
            Assert.AreEqual(element.UpperBound, 3);
            Assert.IsTrue(element.IncludeLowerBound);
            Assert.IsTrue(element.IncludeUpperBound);
            Assert.IsFalse(element.IsEmpty);
            Assert.IsTrue(element.IsClosed);
            Assert.IsFalse(element.IsOpen);
            Assert.AreEqual(element.Measure, 1);
        }

        [TestMethod]
        public void TestCreateOpenSet()
        {
            var element = NumberSetElement<double>.Create(2, 3, false, false);
            Assert.AreEqual(element.LowerBound, 2);
            Assert.AreEqual(element.UpperBound, 3);
            Assert.IsFalse(element.IncludeLowerBound);
            Assert.IsFalse(element.IncludeUpperBound);
            Assert.IsFalse(element.IsEmpty);
            Assert.IsFalse(element.IsClosed);
            Assert.IsTrue(element.IsOpen);
            Assert.AreEqual(element.Measure, 1);
        }

        [TestMethod]
        public void TestCreateLeftOpenRightClosedSet()
        {
            var element = NumberSetElement<double>.Create(2, 3, false, true);
            Assert.AreEqual(element.LowerBound, 2);
            Assert.AreEqual(element.UpperBound, 3);
            Assert.IsFalse(element.IncludeLowerBound);
            Assert.IsTrue(element.IncludeUpperBound);
            Assert.IsFalse(element.IsEmpty);
            Assert.IsFalse(element.IsClosed);
            Assert.IsFalse(element.IsOpen);
            Assert.AreEqual(element.Measure, 1);
        }

        [TestMethod]
        public void TestCreateLeftClosedRightOpenSet()
        {
            var element = NumberSetElement<double>.Create(2, 3, true, false);
            Assert.AreEqual(element.LowerBound, 2);
            Assert.AreEqual(element.UpperBound, 3);
            Assert.IsTrue(element.IncludeLowerBound);
            Assert.IsFalse(element.IncludeUpperBound);
            Assert.IsFalse(element.IsEmpty);
            Assert.IsFalse(element.IsClosed);
            Assert.IsFalse(element.IsOpen);
            Assert.AreEqual(element.Measure, 1);
        }

        [TestMethod]
        public void TestCreateEmptySet()
        {
            var element = NumberSetElement<double>.CreateEmpty();
            Assert.AreEqual(element.LowerBound, default(double));
            Assert.AreEqual(element.UpperBound, default(double));
            Assert.IsFalse(element.IncludeLowerBound);
            Assert.IsFalse(element.IncludeUpperBound);
            Assert.IsTrue(element.IsEmpty);
            Assert.IsFalse(element.IsClosed);
            Assert.IsTrue(element.IsOpen);
            Assert.AreEqual(element.Measure, 0);
        }

        [TestMethod]
        public void TestCreateFromPointBoundsFalseFalse()
        {
            var element = NumberSetElement<double>.Create(2, 2, false, false);
            Assert.AreEqual(element.LowerBound, default(double));
            Assert.AreEqual(element.UpperBound, default(double));
            Assert.IsFalse(element.IncludeLowerBound);
            Assert.IsFalse(element.IncludeUpperBound);
            Assert.IsTrue(element.IsEmpty);
            Assert.IsFalse(element.IsClosed);
            Assert.IsTrue(element.IsOpen);
            Assert.AreEqual(element.Measure, 0);
        }

        [TestMethod]
        public void TestCreateFromPointBoundsFalseTrue()
        {
            var element = NumberSetElement<double>.Create(2, 2, false, true);
            Assert.AreEqual(element.LowerBound, default(double));
            Assert.AreEqual(element.UpperBound, default(double));
            Assert.IsFalse(element.IncludeLowerBound);
            Assert.IsFalse(element.IncludeUpperBound);
            Assert.IsTrue(element.IsEmpty);
            Assert.IsFalse(element.IsClosed);
            Assert.IsTrue(element.IsOpen);
            Assert.AreEqual(element.Measure, 0);
        }

        [TestMethod]
        public void TestCreateFromPointBoundsTrueFalse()
        {
            var element = NumberSetElement<double>.Create(2, 2, true, false);
            Assert.AreEqual(element.LowerBound, default(double));
            Assert.AreEqual(element.UpperBound, default(double));
            Assert.IsFalse(element.IncludeLowerBound);
            Assert.IsFalse(element.IncludeUpperBound);
            Assert.IsTrue(element.IsEmpty);
            Assert.IsFalse(element.IsClosed);
            Assert.IsTrue(element.IsOpen);
            Assert.AreEqual(element.Measure, 0);
        }

        [TestMethod]
        public void TestCreateFromPointBoundsTrueTrue()
        {
            var element = NumberSetElement<double>.Create(2, 2, true, true);
            Assert.AreEqual(element.LowerBound, 2);
            Assert.AreEqual(element.UpperBound, 2);
            Assert.IsTrue(element.IncludeLowerBound);
            Assert.IsTrue(element.IncludeUpperBound);
            Assert.IsFalse(element.IsEmpty);
            Assert.IsTrue(element.IsClosed);
            Assert.IsFalse(element.IsOpen);
            Assert.AreEqual(element.Measure, 0);
        }

        [TestMethod]
        public void TestCreateLowerBoundHigherThanUpperBound()
        {
            var element = NumberSetElement<double>.Create(3, 2, false, false);
            Assert.AreEqual(element.LowerBound, default(double));
            Assert.AreEqual(element.UpperBound, default(double));
            Assert.IsFalse(element.IncludeLowerBound);
            Assert.IsFalse(element.IncludeUpperBound);
            Assert.IsTrue(element.IsEmpty);
            Assert.IsFalse(element.IsClosed);
            Assert.IsTrue(element.IsOpen);
            Assert.AreEqual(element.Measure, 0);
        }

        //[TestMethod]
        //public void TestCreateFromLowerBoundNaN()
        //{
        //    var element = NumberSetElement<double>.Create(double.NaN, 2, true, true);
        //    Assert.AreEqual(element.LowerBound, default(double));
        //    Assert.AreEqual(element.UpperBound, default(double));
        //    Assert.IsFalse(element.IncludeLowerBound);
        //    Assert.IsFalse(element.IncludeUpperBound);
        //    Assert.IsTrue(element.IsEmpty);
        //    Assert.IsFalse(element.IsClosed);
        //    Assert.IsTrue(element.IsOpen);
        //    Assert.AreEqual(element.Measure, 0);
        //}

        //[TestMethod]
        //public void TestCreateFromUpperBoundNaN()
        //{
        //    var element = NumberSetElement<double>.Create(2, double.NaN, true, true);
        //    Assert.AreEqual(element.LowerBound, default(double));
        //    Assert.AreEqual(element.UpperBound, default(double));
        //    Assert.IsFalse(element.IncludeLowerBound);
        //    Assert.IsFalse(element.IncludeUpperBound);
        //    Assert.IsTrue(element.IsEmpty);
        //    Assert.IsFalse(element.IsClosed);
        //    Assert.IsTrue(element.IsOpen);
        //    Assert.AreEqual(element.Measure, 0);
        //}

        //[TestMethod]
        //public void TestCreateFromLowerBoundInfinity()
        //{
        //    var element = NumberSetElement<double>.Create(double.NegativeInfinity, 2, true, true);
        //    Assert.AreEqual(element.LowerBound, default(double));
        //    Assert.AreEqual(element.UpperBound, default(double));
        //    Assert.IsFalse(element.IncludeLowerBound);
        //    Assert.IsFalse(element.IncludeUpperBound);
        //    Assert.IsTrue(element.IsEmpty);
        //    Assert.IsFalse(element.IsClosed);
        //    Assert.IsTrue(element.IsOpen);
        //    Assert.AreEqual(element.Measure, 0);
        //}

        //[TestMethod]
        //public void TestCreateFromUpperBoundInfinity()
        //{
        //    var element = NumberSetElement<double>.Create(2, double.PositiveInfinity, true, true);
        //    Assert.AreEqual(element.LowerBound, default(double));
        //    Assert.AreEqual(element.UpperBound, default(double));
        //    Assert.IsFalse(element.IncludeLowerBound);
        //    Assert.IsFalse(element.IncludeUpperBound);
        //    Assert.IsTrue(element.IsEmpty);
        //    Assert.IsFalse(element.IsClosed);
        //    Assert.IsTrue(element.IsOpen);
        //    Assert.AreEqual(element.Measure, 0);
        //}

        [TestMethod]
        public void TestEquality()
        {
            var element1 = NumberSetElement<double>.Create(2, 3, true, true);
            var element2 = NumberSetElement<double>.Create(2, 3, true, true);
            Assert.IsTrue(element1.Equals(element2));
        }

        [TestMethod]
        public void TestEqualityEmpty()
        {
            var element1 = NumberSetElement<double>.CreateEmpty();
            var element2 = NumberSetElement<double>.CreateEmpty();
            Assert.IsTrue(element1.Equals(element2));
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
    }
}
