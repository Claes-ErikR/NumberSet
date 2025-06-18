using Utte.NumberSet;

namespace NumberSetUnitTest.IBoundedSetUnitTest.Double;

[TestClass]
public class ContainsIBoundedSetTest
{
    [TestMethod]
    public void TestNumberSetNumberSetContains()
    {
        IBoundedSet<double> element1 = NumberSet<double>.Create(NumberSetElement<double>.Create(1.2, 4.3, true, false));
        IBoundedSet<double> element2 = NumberSet<double>.Create(NumberSetElement<double>.Create(2.1, 3, true, false));
        var result = element1.Contains(element2);
        Assert.IsTrue(result);
    }

    [TestMethod]
    public void TestNumberSetNumberSetElementContains()
    {
        IBoundedSet<double> element1 = NumberSet<double>.Create(NumberSetElement<double>.Create(1.2, 4.3, true, false));
        IBoundedSet<double> element2 = NumberSetElement<double>.Create(2.1, 3, true, false);
        var result = element1.Contains(element2);
        Assert.IsTrue(result);
    }

    [TestMethod]
    public void TestNumberSetElementNumberSetContains()
    {
        IBoundedSet<double> element1 = NumberSetElement<double>.Create(1.2, 4.3, true, false);
        IBoundedSet<double> element2 = NumberSet<double>.Create(NumberSetElement<double>.Create(2.1, 3, true, false));
        var result = element1.Contains(element2);
        Assert.IsTrue(result);
    }

    [TestMethod]
    public void TestNumberSetElementNumberSetElementContains()
    {
        IBoundedSet<double> element1 = NumberSetElement<double>.Create(1.2, 4.3, true, false);
        IBoundedSet<double> element2 = NumberSetElement<double>.Create(2.1, 3, true, false);
        var result = element1.Contains(element2);
        Assert.IsTrue(result);
    }

    [TestMethod]
    public void TestNumberSetNumberSetIContainsNot()
    {
        IBoundedSet<double> element1 = NumberSet<double>.Create(NumberSetElement<double>.Create(1.2, 4.3, true, false));
        IBoundedSet<double> element2 = NumberSet<double>.Create(NumberSetElement<double>.Create(5, 7.2, true, false));
        var result = element1.Contains(element2);
        Assert.IsFalse(result);
    }

    [TestMethod]
    public void TestNumberSetNumberSetElementContainsNot()
    {
        IBoundedSet<double> element1 = NumberSet<double>.Create(NumberSetElement<double>.Create(1.2, 4.3, true, false));
        IBoundedSet<double> element2 = NumberSetElement<double>.Create(5, 7.2, true, false);
        var result = element1.Contains(element2);
        Assert.IsFalse(result);
    }

    [TestMethod]
    public void TestNumberSetElementNumberSetContainsNot()
    {
        IBoundedSet<double> element1 = NumberSetElement<double>.Create(1.2, 4.3, true, false);
        IBoundedSet<double> element2 = NumberSet<double>.Create(NumberSetElement<double>.Create(5, 7.2, true, false));
        var result = element1.Contains(element2);
        Assert.IsFalse(result);
    }

    [TestMethod]
    public void TestNumberSetElementNumberSetElementContainsNot()
    {
        IBoundedSet<double> element1 = NumberSetElement<double>.Create(1.2, 4.3, true, false);
        IBoundedSet<double> element2 = NumberSetElement<double>.Create(5, 7.2, true, false);
        var result = element1.Contains(element2);
        Assert.IsFalse(result);
    }
}