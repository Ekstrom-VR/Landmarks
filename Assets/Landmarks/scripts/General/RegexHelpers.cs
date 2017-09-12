using System.Text.RegularExpressions;

public static class RegexHelpers
{
    const string FOLDER_FILE_PATTERN = "^(.+)[/|'\']([^/|'\']+)$";

    public static string GetFolderFromFilepath(string filepath)
    {
        var matches = Regex.Match(filepath, FOLDER_FILE_PATTERN);
        //Group 0 is the full match
        return matches.Groups[1].Value;
    }

    public static string GetFileFromFilepath(string filepath)
    {
        var matches = Regex.Match(filepath, FOLDER_FILE_PATTERN);
        //Group 0 is hte full match
        return matches.Groups[2].Value;
    }
}
