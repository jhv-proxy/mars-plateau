using MarsPlateau;
using MarsPlateau.Exception;

namespace MarsPlateauTests;

[TestClass]
public class PlanetSizeTesting
{
    [TestMethod]
    public void TestInvalidPlanetSizesShouldThrowAnException()
    {
        string[] inputs = { "2", "bbb", "axb", "e1x0", "0x1" };

        foreach (var i in inputs)
        {
            try
            {
                new PlanetSize(i);
                Assert.Fail();
            }
            catch (InvalidPlanetSizeException e)
            {
            }
        }
    }
    
    [TestMethod]
    public void TestValidPlanetSizes()
    {
        var p1 = new PlanetSize("2x2");
        Assert.AreEqual(2, p1.X);
        Assert.AreEqual(2, p1.Y);

        var p2 = new PlanetSize("55x1");
        Assert.AreEqual(55, p2.X);
        Assert.AreEqual(1, p2.Y);

        var p3 = new PlanetSize("2x55");
        Assert.AreEqual(2, p3.X);
        Assert.AreEqual(55, p3.Y);
        
    }
}