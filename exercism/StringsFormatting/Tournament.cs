using System.Text;
using System.Text.RegularExpressions;

namespace Exercism.StringsFormatting;

/**
"Team                           | MP |  W |  D |  L |  P\n" +
"Allegoric Alaskans             |  1 |  1 |  0 |  0 |  3\n" +
"Blithering Badgers             |  1 |  0 |  0 |  1 |  0";
 */


enum TournamentScores  {
    Loss,
    Draw,
    Win = 3,
}

public static class Tournament
{   
    
    private static UTF8Encoding _encoding = new UTF8Encoding();
    private static string _tableHeader = "Team                           | MP |  W |  D |  L |  P\n";
    private static Dictionary<string, int[]> _scores = new ();
    
    public static void Tally(Stream inStream, Stream outStream)
    {
        byte[] buffer = new byte[inStream.Length];
        inStream.Read(buffer, 0, buffer.Length);
        string input = _encoding.GetString(buffer);
        outStream.Write(_encoding.GetBytes(ParseTournament(input)));
    }
    
    
    private static string ParseTournament(string input)
    {
        var playedGames = Regex.Matches(input, @".*;[win|loss|draw].*");

        foreach (Match match in playedGames)
        {
            var matchInfo = match.Value.Split(";");
            var (team1, team2, result) = (matchInfo[0], matchInfo[1], matchInfo[2]);

            HandleResult(team1, result);
            HandleResult(team2, GetOppositeResult(result));
        }
        
        const string header = "Team                           | MP |  W |  D |  L |  P";
        var sb = new StringBuilder();
        sb.AppendLine(header);

        foreach (var teamName in _scores.Keys)
        {
            sb.AppendLine(string.Format("{0,-30} | {1,2} | {2,2} | {3,2} | {4,2} | {5,2}",
                teamName, _scores[teamName][0], _scores[teamName][1], _scores[teamName][2], _scores[teamName][3], _scores[teamName][4]));
        }

        _scores = new ();

        return sb.ToString();

    }
    
    private static void HandleResult(string team, string result)
    {
        if (_scores.ContainsKey(team))
        {
            _scores[team] = CalculateScores(result, _scores[team]);
            return;
        }
        
        _scores.Add(team, CalculateScores(result, new int[5]));
    }

    private static string GetOppositeResult(string result) =>
        result switch
        {
            "win" => "loss",
            "loss" => "win",
            _ => result
        };
    
    private static int[] CalculateScores(string result, int[] scoresTable)
    {
        scoresTable[0] += 1;

        switch (result)
        {
            case "win":
                scoresTable[1] += 1;
                break;
            case "loss":
                scoresTable[3] += 1;
                break;
            default:
                scoresTable[2] += 1;
                break;
        }

        scoresTable[4] = scoresTable[1] * (int)TournamentScores.Win + scoresTable[2] * (int)TournamentScores.Draw;

        return scoresTable;

    }

}