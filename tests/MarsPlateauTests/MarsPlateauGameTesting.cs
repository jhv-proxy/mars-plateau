using MarsPlateau;
using MarsPlateau.Enums;

namespace MarsPlateauTests;

[TestClass]
public class MarsPlateauGameTesting
{
    [TestMethod]
    public void TestAddingInvalidMotionsToTheGame()
    {
        var plateauGame = new MarsPlateauGame(new PlanetSize("5x5"));
        plateauGame.AddMotion(new Motion('a'));
        plateauGame.AddMotion(new Motion('b'));
        plateauGame.AddMotion(new Motion('c'));
        
        plateauGame.Play();
        Assert.AreEqual(1, plateauGame.GetRobotPosition().GetXPosition());
        Assert.AreEqual(1, plateauGame.GetRobotPosition().GetYPosition());
        
        Assert.AreEqual(1, plateauGame.GetRobotPosition().GetXPosition());
        Assert.AreEqual(1, plateauGame.GetRobotPosition().GetYPosition());
        Assert.AreEqual(FacingDirection.North, plateauGame.GetRobotFacingDirection());
    }
    
    [TestMethod]
    public void TestAddingInvalidMotionsStringToTheGame()
    {
        var plateauGame = new MarsPlateauGame(new PlanetSize("5x5"));
        plateauGame.AddMotionsString("abcde");
        
        plateauGame.Play();
        Assert.AreEqual(1, plateauGame.GetRobotPosition().GetXPosition());
        Assert.AreEqual(1, plateauGame.GetRobotPosition().GetYPosition());
        
        Assert.AreEqual(1, plateauGame.GetRobotPosition().GetXPosition());
        Assert.AreEqual(1, plateauGame.GetRobotPosition().GetYPosition());
        Assert.AreEqual(FacingDirection.North, plateauGame.GetRobotFacingDirection());
    }

    [TestMethod]
    public void TestThatGameResetsProperly()
    {
        var plateauGame = new MarsPlateauGame(new PlanetSize("2x2"));
        plateauGame.AddMotionsString("ffrff");
        
        plateauGame.Play();
        Assert.AreEqual(2, plateauGame.GetRobotPosition().GetXPosition());
        Assert.AreEqual(2, plateauGame.GetRobotPosition().GetYPosition());
        Assert.AreEqual(FacingDirection.East, plateauGame.GetRobotFacingDirection());

        plateauGame.Reset();
        Assert.AreEqual(1, plateauGame.GetRobotPosition().GetXPosition());
        Assert.AreEqual(1, plateauGame.GetRobotPosition().GetYPosition());
        Assert.AreEqual(FacingDirection.North, plateauGame.GetRobotFacingDirection());
    }
    
    [TestMethod]
    public void TestRobotDoesNotGoOutbounds()
    {
        var plateauGame = new MarsPlateauGame(new PlanetSize("2x2"));
        plateauGame.AddMotionsString("fffff");
        
        plateauGame.Play();
        Assert.AreEqual(1, plateauGame.GetRobotPosition().GetXPosition());
        Assert.AreEqual(2, plateauGame.GetRobotPosition().GetYPosition());
        Assert.AreEqual(FacingDirection.North, plateauGame.GetRobotFacingDirection());
    }
    
    [TestMethod]
    public void TestRobotInTheCorrectPosition()
    {
        var plateauGame = new MarsPlateauGame(new PlanetSize("5x5"));
        plateauGame.AddMotionsString("FF");
        plateauGame.Play();
        Assert.AreEqual(1, plateauGame.GetRobotPosition().GetXPosition());
        Assert.AreEqual(3, plateauGame.GetRobotPosition().GetYPosition());
        Assert.AreEqual(FacingDirection.North, plateauGame.GetRobotFacingDirection());
        
        plateauGame.AddMotionsString("RF");
        plateauGame.Play();
        Assert.AreEqual(2, plateauGame.GetRobotPosition().GetXPosition());
        Assert.AreEqual(3, plateauGame.GetRobotPosition().GetYPosition());
        Assert.AreEqual(FacingDirection.East, plateauGame.GetRobotFacingDirection());
        
        plateauGame.AddMotionsString("LF");
        plateauGame.Play();
        Assert.AreEqual(2, plateauGame.GetRobotPosition().GetXPosition());
        Assert.AreEqual(4, plateauGame.GetRobotPosition().GetYPosition());
        Assert.AreEqual(FacingDirection.North, plateauGame.GetRobotFacingDirection());

        plateauGame.AddMotionsString("LF");
        plateauGame.Play();
        Assert.AreEqual(1, plateauGame.GetRobotPosition().GetXPosition());
        Assert.AreEqual(4, plateauGame.GetRobotPosition().GetYPosition());
        Assert.AreEqual(FacingDirection.West, plateauGame.GetRobotFacingDirection());
    }
}