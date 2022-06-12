using System;
using System.Collections.Generic;
using System.Linq;

public class FacialFeatures
{
    public string EyeColor { get; }
    public decimal PhiltrumWidth { get; }

    public FacialFeatures(string eyeColor, decimal philtrumWidth)
    {
        EyeColor = eyeColor;
        PhiltrumWidth = philtrumWidth;
    }
    // TODO: implement equality and GetHashCode() methods
    public override int GetHashCode()
    {
        return HashCode.Combine(EyeColor, PhiltrumWidth);
    }

    public override bool Equals(object obj)
    {
        return obj is FacialFeatures 
                    && EyeColor == (obj as FacialFeatures).EyeColor
                    && PhiltrumWidth == (obj as FacialFeatures).PhiltrumWidth;
    }
}

public class Identity
{
    public string Email { get; }
    public FacialFeatures FacialFeatures { get; }

    public Identity(string email, FacialFeatures facialFeatures)
    {
        Email = email;
        FacialFeatures = facialFeatures;
    }
    // TODO: implement equality and GetHashCode() methods
    public override int GetHashCode()
    {
        return HashCode.Combine(Email, FacialFeatures);
    }

    public override bool Equals(object obj)
    {
        return obj is Identity && Email == (obj as Identity).Email && FacialFeatures.Equals((obj as Identity).FacialFeatures);
    }
}

public class Authenticator
{

    protected static Identity AdminAccount = new Identity("admin@exerc.ism", new FacialFeatures("green", 0.9m));

    protected HashSet<Identity> reg = new HashSet<Identity>();
    public static bool AreSameFace(FacialFeatures faceA, FacialFeatures faceB)
    {
        return faceA.Equals(faceB);
    }

    public bool IsAdmin(Identity identity)
    {
        return identity.Equals(AdminAccount);
    }

    public bool Register(Identity identity)
    {
        return !reg.Contains(identity) && reg.Add(identity);
    }

    public bool IsRegistered(Identity identity)
    {
        return reg.Contains(identity);
    }

    public static bool AreSameObject(Identity identityA, Identity identityB)
    {
        return identityA == identityB;
    }
}
