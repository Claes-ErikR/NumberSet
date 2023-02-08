using NumberSet;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
    }
}
