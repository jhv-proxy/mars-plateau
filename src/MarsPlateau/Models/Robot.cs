using MarsPlateau.Enums;

namespace MarsPlateau;

public class Robot
{
    private FacingDirection _facingDirection;

    public Robot()
    {
        _facingDirection = FacingDirection.North;
    }

    public void Turn(TurnDirection t)
    {
        int currentOrientation = (int)_facingDirection;
        currentOrientation += (t == TurnDirection.Right) ? 1 : -1;

        if (IsOrientationOutOfBounds(currentOrientation))
        {
            currentOrientation = (currentOrientation < 1) ? 3 : 0;
        }

        _facingDirection = (FacingDirection)currentOrientation;
    }

    public FacingDirection GetFacingDirection()
    {
        return _facingDirection;
    }

    private bool IsOrientationOutOfBounds(int orientation)
    {
        return orientation is < (int)FacingDirection.North or > (int)FacingDirection.West;
    }
}