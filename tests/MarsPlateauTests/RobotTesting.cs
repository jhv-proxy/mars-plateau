using MarsPlateau;
using MarsPlateau.Enums;

namespace MarsPlateauTests;

[TestClass]
public class RobotTesting
{
    [TestMethod]
    public void TestTurnRobotToTheRightShouldPointToEast()
    {
        Robot robot = new Robot();
            
        robot.Turn(TurnDirection.Right);
        Assert.AreEqual(FacingDirection.East, robot.GetFacingDirection());
    }

    [TestMethod]
    public void TestTurnRobotToTheLefShouldPointToWest()
    {
        Robot robot = new Robot();
            
        robot.Turn(TurnDirection.Left);
        Assert.AreEqual(FacingDirection.West, robot.GetFacingDirection());
    }
    
    [TestMethod]
    public void TestTurnRobotTwiceToLeftOrRightShouldPointToSouth()
    {
        Robot robot1 = new Robot();
        Robot robot2 = new Robot();
            
        robot1.Turn(TurnDirection.Left);
        robot1.Turn(TurnDirection.Left);
        Assert.AreEqual(FacingDirection.South, robot1.GetFacingDirection());
        
        robot2.Turn(TurnDirection.Right);
        robot2.Turn(TurnDirection.Right);
        Assert.AreEqual(FacingDirection.South, robot2.GetFacingDirection());
    }
    
    [TestMethod]
    public void TestRobotShouldReturnToItsOriginalPlace()
    {
        Robot robot1 = new Robot();
        Robot robot2 = new Robot();
            
        robot1.Turn(TurnDirection.Right);
        robot1.Turn(TurnDirection.Left);
        Assert.AreEqual(FacingDirection.North, robot1.GetFacingDirection());
        
        robot2.Turn(TurnDirection.Left);
        robot2.Turn(TurnDirection.Right);
        Assert.AreEqual(FacingDirection.North, robot2.GetFacingDirection());
    }

    [TestMethod]
    public void TestThatTheRobotWontGetOutOfBoundsOnceTurn360Degrees()
    {
        Robot robot1 = new Robot();
        robot1.Turn(TurnDirection.Left);
        robot1.Turn(TurnDirection.Left);
        robot1.Turn(TurnDirection.Left);
        robot1.Turn(TurnDirection.Left);
        
        Robot robot2 = new Robot();
        robot2.Turn(TurnDirection.Right);
        robot2.Turn(TurnDirection.Right);
        robot2.Turn(TurnDirection.Right);
        robot2.Turn(TurnDirection.Right);
        
        Assert.AreEqual(FacingDirection.North, robot1.GetFacingDirection());
        Assert.AreEqual(FacingDirection.North, robot2.GetFacingDirection());
    }
}