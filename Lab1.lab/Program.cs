using System;
using System.IO;

public class Program
{
    public static void Main()
    {
        string[] input = File.ReadAllText("INPUT.TXT").Split();
        int n = int.Parse(input[0]);
        int m = int.Parse(input[1]);

        int result = CalculateWinningSequences(n, m);
        File.WriteAllText("OUTPUT.TXT", result.ToString());
    }

    // Метод для підрахунку виграшних варіантів
    public static int CalculateWinningSequences(int n, int m)
    {
        int result = 0;
        for (int k = m; k <= n; k++)
        {
            result += BinomialCoefficient(n, k);
        }
        return result;
    }

    // Метод для обчислення біноміальних коефіцієнтів
    public static int BinomialCoefficient(int n, int k)
    {
        if (k > n) return 0;
        if (k == 0 || k == n) return 1;

        int res = 1;
        for (int i = 1; i <= k; i++)
        {
            res = res * (n - i + 1) / i;
        }

        return res;
    }
}
