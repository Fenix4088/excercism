namespace Exercism.Dictionaries;

using System;
using System.Collections.Generic;
using System.Linq;

public class GradeSchool
{
    private readonly Dictionary<string, int> _roaster = new Dictionary<string, int>();

    public bool Add(string student, int grade) => _roaster.TryAdd(student, grade);

    public IEnumerable<string> Roster()
    {
        return _roaster.OrderBy(student => student.Value).ThenBy(student => student.Key).Select(student => student.Key);
    }

    public IEnumerable<string> Grade(int grade)
    {
        return _roaster.OrderBy(student => student.Value).ThenBy(student => student.Key).Where(student => student.Value == grade).Select(student => student.Key);
    }
}