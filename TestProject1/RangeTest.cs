using TestProject1.Base;

namespace TestProject1;

[TestClass]
public class RangeTest
{
    [TestMethod]
    [TestTraits(Trait.Numbers)]
    public void BetweenIntegers_FirstThree()
    {
        List<int> list = [1, 2, 3, 4, 5];
        List<int> expected = [1, 2, 3];

        var firstThree1 = list.ToArray()[..3];
        CollectionAssert.AreEqual(firstThree1, expected);

        var firstThree2 = list.GetRange(0, 3);
        CollectionAssert.AreEqual(firstThree2, expected);

        var firstThree3 = list.GetRange(0, 3);
        CollectionAssert.AreEqual(firstThree3, expected);
    }
}