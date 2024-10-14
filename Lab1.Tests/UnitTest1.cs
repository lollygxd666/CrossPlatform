using NUnit.Framework;

[TestFixture]
public class GameTests
{
    // Тест для функции BinomialCoefficient (проверяет правильность вычисления комбинаций)
    [Test]
    public void BinomialCoefficientTest()
    {
        Assert.AreEqual(1, Program.BinomialCoefficient(2, 0));  // C(2, 0) = 1
        Assert.AreEqual(2, Program.BinomialCoefficient(2, 1));  // C(2, 1) = 2
        Assert.AreEqual(1, Program.BinomialCoefficient(2, 2));  // C(2, 2) = 1
        Assert.AreEqual(3, Program.BinomialCoefficient(3, 1));  // C(3, 1) = 3
        Assert.AreEqual(6, Program.BinomialCoefficient(4, 2));  // C(4, 2) = 6
    }

    // Тест для подсчета количества выигрышных вариантов для конкретных входов
    [Test]
    public void WinningSequencesTest()
    {
        Assert.AreEqual(4, Program.CalculateWinningSequences(2, 0));  // 2 подкидывания, выигрыш хотя бы с 0 "решек" (C(2, 0) + C(2, 1) + C(2, 2) = 1 + 2 + 1 = 4)
        Assert.AreEqual(4, Program.CalculateWinningSequences(3, 2));  // 3 подкидывания, выигрыш хотя бы с 2 "решками" (C(3, 2) + C(3, 3) = 3 + 1 = 4)
        Assert.AreEqual(11, Program.CalculateWinningSequences(4, 2));  // 4 подкидывания, выигрыш хотя бы с 2 "решками" (C(4, 2) + C(4, 3) + C(4, 4) = 6 + 4 + 1 = 11)
        Assert.AreEqual(1, Program.CalculateWinningSequences(1, 1));  // 1 подкидывание, выигрыш с 1 "решкой" (C(1, 1) = 1)
        Assert.AreEqual(2, Program.CalculateWinningSequences(1, 0));  // 1 подкидывание, выигрыш хотя бы с 0 "решек" (C(1, 0) = 1)
    }
}
