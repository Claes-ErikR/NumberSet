using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Utte.NumberSet;

namespace NumberSetUnitTest.IBoundedSetUnitTest.Double
{
    [TestClass]
    public class UnionIBoundedSetTest
    {
        [TestMethod]
        public void TestNumberSetNumberSetUnion()
        {
            IBoundedSet<double> element1 = NumberSet<double>.Create(NumberSetElement<double>.Create(1.2, 4.3, true, false));
            IBoundedSet<double> element2 = NumberSet<double>.Create(NumberSetElement<double>.Create(2.1, 7.2, true, false));
            var result = element1.Union(element2);
            Assert.AreEqual(result.Count, 1);
            Assert.AreEqual(result[0].LowerBound, 1.2);
            Assert.AreEqual(result[0].UpperBound, 7.2);
            Assert.IsTrue(result[0].IncludeLowerBound);
            Assert.IsFalse(result[0].IncludeUpperBound);
        }

        [TestMethod]
        public void TestNumberSetNumberSetElementUnion()
        {
            IBoundedSet<double> element1 = NumberSet<double>.Create(NumberSetElement<double>.Create(1.2, 4.3, true, false));
            IBoundedSet<double> element2 = NumberSetElement<double>.Create(2.1, 7.2, true, false);
            var result = element1.Union(element2);
            Assert.AreEqual(result.Count, 1);
            Assert.AreEqual(result[0].LowerBound, 1.2);
            Assert.AreEqual(result[0].UpperBound, 7.2);
            Assert.IsTrue(result[0].IncludeLowerBound);
            Assert.IsFalse(result[0].IncludeUpperBound);
        }

        [TestMethod]
        public void TestNumberSetElementNumberSetUnion()
        {
            IBoundedSet<double> element1 = NumberSetElement<double>.Create(1.2, 4.3, true, false);
            IBoundedSet<double> element2 = NumberSet<double>.Create(NumberSetElement<double>.Create(2.1, 7.2, true, false));
            var result = element1.Union(element2);
            Assert.AreEqual(result.Count, 1);
            Assert.AreEqual(result[0].LowerBound, 1.2);
            Assert.AreEqual(result[0].UpperBound, 7.2);
            Assert.IsTrue(result[0].IncludeLowerBound);
            Assert.IsFalse(result[0].IncludeUpperBound);
        }

        [TestMethod]
        public void TestNumberSetElementNumberSetElementUnion()
        {
            IBoundedSet<double> element1 = NumberSetElement<double>.Create(1.2, 4.3, true, false);
            IBoundedSet<double> element2 = NumberSetElement<double>.Create(2.1, 7.2, true, false);
            var result = element1.Union(element2);
            Assert.AreEqual(result.Count, 1);
            Assert.AreEqual(result[0].LowerBound, 1.2);
            Assert.AreEqual(result[0].UpperBound, 7.2);
            Assert.IsTrue(result[0].IncludeLowerBound);
            Assert.IsFalse(result[0].IncludeUpperBound);
        }
    }
}
