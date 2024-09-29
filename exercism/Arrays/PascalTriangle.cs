namespace Exercism.Arrays;

public static class PascalsTriangle
{
    public static IEnumerable<IEnumerable<int>> Calculate(int rows)
    {
        var res = new List<List<int>>{};

        if (rows <= 0) return res;

        res.Add([1]);

        if (rows >= 2) res.Add([1, 1]);
        
        for (int i = 2; i < rows; i++)
        {
            var newRow = new List<int> { 1 };
            
            for (int j = 1; j < i; j++)
            {
                newRow.Add(res[i - 1][j - 1] + res[i - 1][j]);
            }
            
            newRow.Add(1);
            res.Add(newRow);
        }

        return res;
    }

}