using MarsPlateau;
using MarsPlateau.Exception;

game:
try
{
    Console.WriteLine("Please type the planet size with the format XxY (eg: 5x5)");
    var planetSizeStr = Console.ReadLine();
    
    Console.WriteLine("");
    Console.WriteLine("Please type the instructions for the robot to move");
    var motionInstructions = Console.ReadLine();
    
    
    if (String.IsNullOrEmpty(planetSizeStr) || String.IsNullOrEmpty(motionInstructions))
    {
        Console.WriteLine("");
        Console.WriteLine("Err: Motion instructions or Planet size not defined");
        Environment.Exit(1);
    }

    var planetSize = new PlanetSize(planetSizeStr);
    var marsPlateauGame = new MarsPlateauGame(planetSize);
    
    marsPlateauGame.AddMotionsString(motionInstructions);
    marsPlateauGame.Play();
    
    Console.WriteLine(
        "\r\nResult: {0},{1},{2}", 
        marsPlateauGame.GetRobotPosition().GetXPosition(),
        marsPlateauGame.GetRobotPosition().GetYPosition(),
        marsPlateauGame.GetRobotFacingDirection()
    );
    
    Console.WriteLine("");
    Console.WriteLine("- - - - - - - - - - - - - - - - - - -");
    Console.WriteLine("Would you like to play again? Y/N");
    Console.WriteLine("- - - - - - - - - - - - - - - - - - -");
    var playAgain = Console.ReadLine();

    if (!String.IsNullOrEmpty(playAgain) && playAgain == "Y")
    {
        Console.WriteLine("");
        goto game;
    }
    
    Environment.Exit(0);
}
catch (InvalidPlanetSizeException e)
{
    Console.WriteLine("");
    Console.WriteLine("Err: Invalid Planet Size");
    Environment.Exit(1);
}
