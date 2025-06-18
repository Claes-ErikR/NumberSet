using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Utte.NumberSet;

namespace NumberSetUnitTest.IBoundedSetUnitTest.Double;

[TestClass]
public class IntersectsIBoundedSetTest
{
    [TestMethod]
    public void TestNumberSetNumberSetIntersects()
    {
        IBoundedSet<double> element1 = NumberSet<double>.Create(NumberSetElement<double>.Create(1.2, 4.3, true, false));
        IBoundedSet<double> element2 = NumberSet<double>.Create(NumberSetElement<double>.Create(2.1, 7.2, true, false));
        var result = element1.Intersects(element2);
        Assert.IsTrue(result);
    }

    [TestMethod]
    public void TestNumberSetNumberSetElementIntersects()
    {
        IBoundedSet<double> element1 = NumberSet<double>.Create(NumberSetElement<double>.Create(1.2, 4.3, true, false));
        IBoundedSet<double> element2 = NumberSetElement<double>.Create(2.1, 7.2, true, false);
        var result = element1.Intersects(element2);
        Assert.IsTrue(result);
    }

    [TestMethod]
    public void TestNumberSetElementNumberSetIntersects()
    {
        IBoundedSet<double> element1 = NumberSetElement<double>.Create(1.2, 4.3, true, false);
        IBoundedSet<double> element2 = NumberSet<double>.Create(NumberSetElement<double>.Create(2.1, 7.2, true, false));
        var result = element1.Intersects(element2);
        Assert.IsTrue(result);
    }

    [TestMethod]
    public void TestNumberSetElementNumberSetElementIntersects()
    {
        IBoundedSet<double> element1 = NumberSetElement<double>.Create(1.2, 4.3, true, false);
        IBoundedSet<double> element2 = NumberSetElement<double>.Create(2.1, 7.2, true, false);
        var result = element1.Intersects(element2);
        Assert.IsTrue(result);
    }

    [TestMethod]
    public void TestNumberSetNumberSetIntersectsNot()
    {
        IBoundedSet<double> element1 = NumberSet<double>.Create(NumberSetElement<double>.Create(1.2, 4.3, true, false));
        IBoundedSet<double> element2 = NumberSet<double>.Create(NumberSetElement<double>.Create(5, 7.2, true, false));
        var result = element1.Intersects(element2);
        Assert.IsFalse(result);
    }

    [TestMethod]
    public void TestNumberSetNumberSetElementIntersectsNot()
    {
        IBoundedSet<double> element1 = NumberSet<double>.Create(NumberSetElement<double>.Create(1.2, 4.3, true, false));
        IBoundedSet<double> element2 = NumberSetElement<double>.Create(5, 7.2, true, false);
        var result = element1.Intersects(element2);
        Assert.IsFalse(result);
    }

    [TestMethod]
    public void TestNumberSetElementNumberSetIntersectsNot()
    {
        IBoundedSet<double> element1 = NumberSetElement<double>.Create(1.2, 4.3, true, false);
        IBoundedSet<double> element2 = NumberSet<double>.Create(NumberSetElement<double>.Create(5, 7.2, true, false));
        var result = element1.Intersects(element2);
        Assert.IsFalse(result);
    }

    [TestMethod]
    public void TestNumberSetElementNumberSetElementIntersectsNot()
    {
        IBoundedSet<double> element1 = NumberSetElement<double>.Create(1.2, 4.3, true, false);
        IBoundedSet<double> element2 = NumberSetElement<double>.Create(5, 7.2, true, false);
        var result = element1.Intersects(element2);
        Assert.IsFalse(result);
    }
}
