namespace Exercism.Nullability;

static class Badge
{
    public static string Print(int? id, string name, string? department)
    {
        var badge = "";

        if (id != null) badge += $"[{id}] - ";

        return badge + $"{name} - {(department ?? "owner").ToUpper()}";
    }
}