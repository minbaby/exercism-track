using System;
using System.Collections.Generic;
using System.Linq;

public static class BeerSong
{
    public static string Recite(int startBottles, int takeDown)
    {
        var ret = string.Empty;

        var wall = startBottles;
        for (int i = 1; i <= takeDown; i++)
        {
            ret += "\n";
            ret += wall switch
            {
                1 => "1 bottle of beer on the wall, 1 bottle of beer.\n",
                0 => "No more bottles of beer on the wall, no more bottles of beer.\n",
                _ => $"{wall} bottles of beer on the wall, {wall} bottles of beer.\n"
            };

            ret += (wall - 1) switch
            {
                1 => "Take one down and pass it around, 1 bottle of beer on the wall.\n",
                0 => "Take it down and pass it around, no more bottles of beer on the wall.\n",
                -1 => "Go to the store and buy some more, 99 bottles of beer on the wall.\n",
                _ => $"Take one down and pass it around, {wall - 1} bottles of beer on the wall.\n",
            };
            wall--;
        }
        
        return ret.Trim();
    }
}