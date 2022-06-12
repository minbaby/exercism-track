using System;
using System.Collections.Generic;
using System.Linq;

public struct Coord
{
    public Coord(ushort x, ushort y)
    {
        X = x;
        Y = y;
    }

    public ushort X { get; }
    public ushort Y { get; }
}

public struct Plot
{
    public Coord x;
    public Coord y;
    public Coord z;
    public Coord a;

    public Plot(Coord x, Coord y, Coord z, Coord a)
    {
        this.x = x;
        this.y = y;
        this.z = z;
        this.a = a;
    }
}


public class ClaimsHandler
{
    protected List<Plot> c = new();

    public void StakeClaim(Plot plot)
    {
        c.Add(plot);
    }

    public bool IsClaimStaked(Plot plot)
    {
        return c.Contains(plot);
    }

    public bool IsLastClaim(Plot plot)
    {
        return c[^1].Equals(plot);
    }

    public Plot GetClaimWithLongestSide()
    {
        return c.OrderByDescending(f =>
            sumLength(f.x, f.y) + sumLength(f.y, f.z) + sumLength(f.z, f.a) + sumLength(f.a, f.x)
        ).First();
    }

    protected double sumLength(Coord a, Coord b)
    {
        return Math.Sqrt(Math.Abs(a.X - b.X)) + Math.Sqrt(Math.Abs(a.Y - b.Y));
    }
}
