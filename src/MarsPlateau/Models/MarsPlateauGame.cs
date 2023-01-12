using MarsPlateau.Enums;

namespace MarsPlateau;

public class MarsPlateauGame
{
    private ISizeablePlanet _planet;
    private Robot _robot;
    private RobotPosition _robotPosition;
    private List<Motion> _motions = new List<Motion>();

    public MarsPlateauGame(PlanetSize planetSize)
    {
        _planet = new Mars(planetSize);
        _robot = new Robot();
        _robotPosition = new RobotPosition();
    }

    public void AddMotion(Motion motion)
    {
        if (!motion.IsValid())
        {
            return;
        }

        _motions.Add(motion);
    }

    public RobotPosition GetRobotPosition()
    {
        return _robotPosition;
    }

    public FacingDirection GetRobotFacingDirection()
    {
        return _robot.GetFacingDirection();
    }

    public void Play()
    {
        foreach (var m in _motions)
        {
            switch (m.Value())
            {
                case 'R':
                    _robot.Turn(TurnDirection.Right);
                    break;
                
                case 'L':
                    _robot.Turn(TurnDirection.Left);
                    break;
                
                case 'F':
                    ChangeRobotPosition();
                    break;                    
            }
        }
        
        _motions.Clear();
    }

    private void ChangeRobotPosition()
    {
        switch (_robot.GetFacingDirection())
        {
            case FacingDirection.East:
                if (_robotPosition.GetXPosition() < _planet.GetPlanetSize().X)
                {
                    _robotPosition.IncrementX();
                }
                break;
            
            case FacingDirection.West:
                if (_robotPosition.GetXPosition() > 1)
                {
                    _robotPosition.DecrementX();
                }
                break;
            
            
            case FacingDirection.North:
                if (_robotPosition.GetYPosition() < _planet.GetPlanetSize().Y)
                {
                    _robotPosition.IncrementY();
                }
                break;
            
            
            case FacingDirection.South:
                if (_robotPosition.GetYPosition() > 1)
                {
                    _robotPosition.DecrementY();
                }
                break;
        }
    }

    public void AddMotionsString(string motionInstructions)
    {
        foreach (var c in motionInstructions.ToCharArray())
        {
            AddMotion(new Motion(c));
        }
    }

    public void Reset()
    {
        _robot = new Robot();
        _robotPosition = new RobotPosition();
        _motions.Clear();
    }
}