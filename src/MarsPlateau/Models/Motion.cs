using System.Text.RegularExpressions;

namespace MarsPlateau;

public class Motion : IMotion
{
    private char _char;

    public Motion(char c)
    {
        _char = char.ToUpper(c);
    }

    public bool IsValid()
    {
        string pattern = @"^(?:R|L|F)";
        Regex regex = new Regex(pattern);

        if (Char.IsLetter(_char) && regex.IsMatch(_char.ToString()))
        {
            return true;
        }

        return false;
    }

    public char Value()
    {
        return _char;
    }
}