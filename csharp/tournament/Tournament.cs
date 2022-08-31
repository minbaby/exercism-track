using System;
using System.IO;
using System.Text;
using System.Collections.Generic;
using System.Linq;

public static class Tournament
{
    public static void Tally(Stream inStream, Stream outStream)
    {
        var encoding = new UTF8Encoding();


        var container = new Dictionary<string, (int MP, int W, int D, int L, int P)>();

        Stream2string(inStream, f =>
        {
            var parseData = f.Split(';');

            var team1Name = parseData[0];
            var team2Name = parseData[1];
            var gameStatus = parseData[2];

            container.TryGetValue(team1Name, out var team1);
            container.TryGetValue(team2Name, out var team2);
            team1.MP++;
            team2.MP++;
            if (gameStatus == "win")
            {
                team1.W++;
                team1.P += 3;

                team2.L++;
            }
            else if (gameStatus == "draw")
            {
                team1.D++;
                team1.P += 1;

                team2.D++;
                team2.P += 1;
            }
            else
            {
                team1.L++;

                team2.W++;
                team2.P += 3;
            }

            container[team1Name] = team1;
            container[team2Name] = team2;
        });

        DrawBoard(outStream, container);
    }

    private static void Stream2string(Stream stream, Action<string> action)
    {
        var sr = new StreamReader(stream);
        while (!sr.EndOfStream)
        {
            action.Invoke(sr.ReadLine());
        }

        sr.Close();
    }

    private static void DrawBoard(Stream stream, Dictionary<string, (int MP, int W, int D, int L, int P)> data)
    {
        var sw = new StreamWriter(stream);

        sw.Write("Team                           | MP |  W |  D |  L |  P");

        var query = data.OrderByDescending(f => f.Value.P)
            .ThenBy(f => f.Key)
            .Select(f => $"{f.Key,-30} | {f.Value.MP,2} | {f.Value.W,2} | {f.Value.D,2} | {f.Value.L,2} |  {f.Value.P}");

        foreach (var row in query)
        {
            sw.Write('\n');
            sw.Write(row);
        }

        sw.Flush();
        sw.Close();
    }
}
