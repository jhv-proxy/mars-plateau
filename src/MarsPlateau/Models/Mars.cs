namespace MarsPlateau;

public class Mars : ISizeablePlanet
{
    private PlanetSize _planetSize;

    public Mars(PlanetSize planetSize)
    {
        _planetSize = planetSize;
    }

    public PlanetSize GetPlanetSize()
    {
        return _planetSize;
    }
}