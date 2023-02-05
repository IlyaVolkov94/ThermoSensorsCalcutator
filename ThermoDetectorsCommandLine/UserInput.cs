using System.Text.RegularExpressions;

namespace ThermoDetectorsCommandLine;

internal class UserInput
{
    private string UserLine { get; }
    internal UserInput(string userLine)
    {
        this.UserLine = userLine.ToLower().Trim();
    }
    internal string[] Split()
    {
        string pattern = @"[^a-z-0-9\,]";
        return Regex.Split(UserLine,pattern);
    }
}
