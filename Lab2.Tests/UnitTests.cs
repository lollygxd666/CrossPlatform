using NUnit.Framework;

[TestFixture]

public class GameTests
{
    // Тест на базові дані
    [Test]
    public void CalculateMinEnergy_BasicTest()
    {
        // Приклад з умови: 3 платформи, висоти [1, 5, 10]
        int[] heights = { 1, 5, 10 };
        Assert.AreEqual(9, Program.CalculateMinEnergy(heights));
    }

    // Тест для випадку з мінімальною кількістю платформ
    [Test]
    public void CalculateMinEnergy_OnePlatform()
    {
        int[] heights = { 5 };
        Assert.AreEqual(0, Program.CalculateMinEnergy(heights));  // Герой вже на місці
    }

    // Тест для випадку з двома платформами
    [Test]
    public void CalculateMinEnergy_TwoPlatforms()
    {
        int[] heights = { 5, 2 };
        Assert.AreEqual(3, Program.CalculateMinEnergy(heights));  // Різниця між 5 і 2
    }

    // Тест для стрибка через платформу
    [Test]
    public void CalculateMinEnergy_JumpOver()
    {
        int[] heights = { 1, 5, 2 };
        Assert.AreEqual(3, Program.CalculateMinEnergy(heights));  // Краще перескочити через платформу 5
    }

    // Тест на випадок із великою кількістю платформ
    [Test]
    public void CalculateMinEnergy_LargeInput()
    {
        int[] heights = new int[30000];
        for (int i = 0; i < heights.Length; i++)
        {
            heights[i] = i % 2 == 0 ? 10000 : 0;  // Чередування висот
        }
        Assert.DoesNotThrow(() => Program.CalculateMinEnergy(heights));  // Перевірка на те, що програма обробляє великі входи
    }
}
