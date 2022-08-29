using System;
using System.Collections.Generic;
using System.Linq;

public class GradeSchool
{
    protected Dictionary<string, int> roster = new Dictionary<string, int>();

    public void Add(string student, int grade)
    {
        roster.Add(student, grade);
    }

    public IEnumerable<string> Roster()
    {
        return roster.OrderBy(f => f.Value + f.Key).Select(f => f.Key);
    }

    
    public IEnumerable<string> Roster2()
    {
        return roster.GroupBy(f => f.Value)
            .OrderBy(f => f.Key)
            .SelectMany(f => f.AsEnumerable().OrderBy(f => f.Key))
            .Select(f => f.Key);
    }

    public IEnumerable<string> Grade(int grade)
    {
        return roster.Where(f => f.Value == grade).OrderBy(f => f.Key).Select(f => f.Key);
    }
}