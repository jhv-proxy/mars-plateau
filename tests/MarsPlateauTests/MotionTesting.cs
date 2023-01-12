using MarsPlateau;

namespace MarsPlateauTests;

[TestClass]
public class MotionTesting
{
    [TestMethod]
    public void TestMotionHasInvalidChars()
    {
        char[] invalidChars = { 'a', '2', 'X', 't' };
        foreach (var c in invalidChars)
        {
            var m = new Motion(c);
            Assert.IsFalse(m.IsValid());
        }
    }
    
    [TestMethod]
    public void TestMotionHasValidChars()
    {
        char[] invalidChars = { 'L', 'r', 'f', 'F', 'R', 'l' };
        foreach (var c in invalidChars)
        {
            var m = new Motion(c);
            Assert.IsTrue(m.IsValid());
        }
    }
}