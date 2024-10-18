using System;
using System.IO;

public class Program
{
    // Метод, який обчислює мінімальну кількість енергії для подолання всіх платформ
    public static int CalculateMinEnergy(int[] heights)
    {
        int n = heights.Length;

        // Масив для збереження мінімальної кількості енергії для досягнення кожної платформи
        int[] dp = new int[n];

        // Початкові умови
        dp[0] = 0; // Герой починає на першій платформі

        if (n > 1)
            dp[1] = Math.Abs(heights[1] - heights[0]); // Перехід на другу платформу

        // Розрахунок мінімальної кількості енергії для кожної платформи
        for (int i = 2; i < n; i++)
        {
            int jump1 = dp[i - 1] + Math.Abs(heights[i] - heights[i - 1]);
            int jump2 = dp[i - 2] + 3 * Math.Abs(heights[i] - heights[i - 2]);
            dp[i] = Math.Min(jump1, jump2);
        }

        return dp[n - 1]; // Мінімальна кількість енергії для досягнення останньої платформи
    }

    // Основний метод, який зчитує дані з файлу і записує результат
    static void Main()
    {
        // Читання даних із файлу INPUT.TXT
        var input = File.ReadAllLines("INPUT.TXT");
        int n = int.Parse(input[0]);
        var heights = Array.ConvertAll(input[1].Split(), int.Parse);

        // Обчислення мінімальної кількості енергії
        int result = CalculateMinEnergy(heights);

        // Запис результату у файл OUTPUT.TXT
        File.WriteAllText("OUTPUT.TXT", result.ToString());
    }
}
