using System;
using System.Collections.Generic;
using System.IO;

public class Program
{
    // Ходи коня
    static int[] knightRow = { -2, -2, -1, -1, 1, 1, 2, 2 };
    static int[] knightCol = { -1, 1, -2, 2, -2, 2, -1, 1 };

    // Ходи слона
    static int[] bishopRow = { -1, -1, 1, 1 };
    static int[] bishopCol = { -1, 1, -1, 1 };

    // Перевірка чи координати валідні
    public static bool IsValid(int row, int col)
    {
        return row >= 0 && row < 9 && col >= 0 && col < 9;
    }

    // Перевірка чи клітина чорна (кутові клітини та діагональні)
    public static bool IsBlackCell(int row, int col)
    {
        return (row % 2 == col % 2); // Чорні клітини мають однакові парності
    }

    // BFS для пошуку мінімальної кількості ходів
    public static int MinMoves(int startRow, int startCol, int endRow, int endCol)
    {
        // Відвідані позиції
        bool[,] visited = new bool[9, 9];
        Queue<Tuple<int, int, int>> queue = new Queue<Tuple<int, int, int>>();
        queue.Enqueue(Tuple.Create(startRow, startCol, 0));
        visited[startRow, startCol] = true;

        while (queue.Count > 0)
        {
            var current = queue.Dequeue();
            int row = current.Item1;
            int col = current.Item2;
            int steps = current.Item3;

            // Якщо дійшли до цілі
            if (row == endRow && col == endCol)
                return steps;

            // Визначення чи стоїмо на чорній клітині
            bool isBlack = IsBlackCell(row, col);

            if (isBlack) // Якщо чорна клітина — ходи слона
            {
                for (int i = 0; i < 4; i++)
                {
                    int newRow = row;
                    int newCol = col;
                    while (true)
                    {
                        newRow += bishopRow[i];
                        newCol += bishopCol[i];
                        if (!IsValid(newRow, newCol)) break; // Якщо координати не валідні, виходимо
                        if (!visited[newRow, newCol])
                        {
                            visited[newRow, newCol] = true;
                            queue.Enqueue(Tuple.Create(newRow, newCol, steps + 1));
                        }
                    }
                }
            }
            else // Якщо біла клітина — ходи коня
            {
                for (int i = 0; i < 8; i++)
                {
                    int newRow = row + knightRow[i];
                    int newCol = col + knightCol[i];
                    if (IsValid(newRow, newCol) && !visited[newRow, newCol])
                    {
                        visited[newRow, newCol] = true;
                        queue.Enqueue(Tuple.Create(newRow, newCol, steps + 1));
                    }
                }
            }
        }

        // Якщо неможливо дістатися
        return -1;
    }

    // Перетворення шахових координат на індекси
    public static (int, int) ConvertPosition(string pos)
    {
        int col = pos[0] - 'A';
        int row = 8 - (pos[1] - '1');
        return (row, col);
    }

    public static void Main(string[] args)
    {
        // Читання вхідних даних
        string[] input = File.ReadAllText("INPUT.TXT").Trim().Split();
        var start = ConvertPosition(input[0]);
        var end = ConvertPosition(input[1]);

        // Обчислення мінімальної кількості ходів
        int result = MinMoves(start.Item1, start.Item2, end.Item1, end.Item2);

        // Виведення результату
        File.WriteAllText("OUTPUT.TXT", result.ToString());
    }
}
