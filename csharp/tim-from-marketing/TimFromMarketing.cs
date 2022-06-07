using System;
using System.Collections;

static class Badge
{
    public static string Print(int? id, string name, string? department)
    {
        return (id == null ? "": $"[{id}] - ") + $"{name} - {(department ?? "OWNER").ToUpper()}";
    }
}
