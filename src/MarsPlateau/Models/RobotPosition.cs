namespace MarsPlateau;

public class RobotPosition
{
    private int _x = 1;
    private int _y = 1;

    public int GetXPosition()
    {
        return _x;
    }

    public int GetYPosition()
    {
        return _y;
    }

    public void IncrementX()
    {
        _x++;
        
    }
    public void IncrementY()
    {
        _y++;
    }

    public void DecrementX()
    {
        _x--;
        
    }
    public void DecrementY()
    {
        _y--;
    }
}