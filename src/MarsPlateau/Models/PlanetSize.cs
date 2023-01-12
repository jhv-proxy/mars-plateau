using MarsPlateau.Exception;

namespace MarsPlateau;

public class PlanetSize
{
    public int X { get; }
    public int Y { get; }

    public PlanetSize(string planetSize)
    {
        string[] xy = SplitPlanetSizeIntoXYStrings(planetSize);

        var isXNumeric = int.TryParse(xy[0], out int x);
        var isYNumeric = int.TryParse(xy[1], out int y);

        if (!isXNumeric || !isYNumeric || x < 1 || y < 1)
        {
            throw new InvalidPlanetSizeException();
        }

        X = x;
        Y = y;
    }

    private string[] SplitPlanetSizeIntoXYStrings(string planetSize)
    {
        string[] xy = planetSize.Split("x", 2, StringSplitOptions.RemoveEmptyEntries);
        if (xy.Length != 2)
        {
            throw new InvalidPlanetSizeException();
        }

        return xy;
    }
}