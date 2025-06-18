using Utte.NumberSet;

namespace NumberSetUnitTest.IBoundedSetUnitTest.Double;



[TestClass]
public class IntersectionIBoundedSetTest
{
    [TestMethod]
    public void TestNumberSetNumberSetIntersection()
    {
        IBoundedSet<double> element1 = NumberSet<double>.Create(NumberSetElement<double>.Create(1.2, 4.3, true, false));
        IBoundedSet<double> element2 = NumberSet<double>.Create(NumberSetElement<double>.Create(2.1, 7.2, true, false));
        var result = element1.Intersection(element2);
        Assert.AreEqual(result.Count, 1);
        Assert.AreEqual(result[0].LowerBound, 2.1);
        Assert.AreEqual(result[0].UpperBound, 4.3);
        Assert.IsTrue(result[0].IncludeLowerBound);
        Assert.IsFalse(result[0].IncludeUpperBound);
    }

    [TestMethod]
    public void TestNumberSetNumberSetElementIntersection()
    {
        IBoundedSet<double> element1 = NumberSet<double>.Create(NumberSetElement<double>.Create(1.2, 4.3, true, false));
        IBoundedSet<double> element2 = NumberSetElement<double>.Create(2.1, 7.2, true, false);
        var result = element1.Intersection(element2);
        Assert.AreEqual(result.Count, 1);
        Assert.AreEqual(result[0].LowerBound, 2.1);
        Assert.AreEqual(result[0].UpperBound, 4.3);
        Assert.IsTrue(result[0].IncludeLowerBound);
        Assert.IsFalse(result[0].IncludeUpperBound);
    }

    [TestMethod]
    public void TestNumberSetElementNumberSetIntersection()
    {
        IBoundedSet<double> element1 = NumberSetElement<double>.Create(1.2, 4.3, true, false);
        IBoundedSet<double> element2 = NumberSet<double>.Create(NumberSetElement<double>.Create(2.1, 7.2, true, false));
        var result = element1.Intersection(element2);
        Assert.AreEqual(result.Count, 1);
        Assert.AreEqual(result[0].LowerBound, 2.1);
        Assert.AreEqual(result[0].UpperBound, 4.3);
        Assert.IsTrue(result[0].IncludeLowerBound);
        Assert.IsFalse(result[0].IncludeUpperBound);
    }

    [TestMethod]
    public void TestNumberSetElementNumberSetElementIntersection()
    {
        IBoundedSet<double> element1 = NumberSetElement<double>.Create(1.2, 4.3, true, false);
        IBoundedSet<double> element2 = NumberSetElement<double>.Create(2.1, 7.2, true, false);
        var result = element1.Intersection(element2);
        Assert.AreEqual(result.Count, 1);
        Assert.AreEqual(result[0].LowerBound, 2.1);
        Assert.AreEqual(result[0].UpperBound, 4.3);
        Assert.IsTrue(result[0].IncludeLowerBound);
        Assert.IsFalse(result[0].IncludeUpperBound);
    }
}
