using NUnit.Framework;

[TestFixture]
public class CentaurTests
{
    // Тест для випадку з базовими даними
    [Test]
    public void MinMoves_BasicTest()
    {
        // Вхідні дані H6 -> E5
        var start = Program.ConvertPosition("H6");
        var end = Program.ConvertPosition("E5");
        int result = Program.MinMoves(start.Item1, start.Item2, end.Item1, end.Item2);
        Assert.That(result, Is.EqualTo(2));  // Очікується 2 кроки
    }

    // Тест для випадку з неможливим шляхом
    [Test]
    public void MinMoves_ImpossibleMove()
    {
        // Вхідні дані з неможливим шляхом (дві чорні клітини, до яких не можна дійти)
        var start = Program.ConvertPosition("A1");
        var end = Program.ConvertPosition("A3");
        int result = Program.MinMoves(start.Item1, start.Item2, end.Item1, end.Item2);
        Assert.That(result, Is.EqualTo(2));  // Очікується 2 кроки
    }

    // Тест для випадку, коли початкова і кінцева позиція однакові
    [Test]
    public void MinMoves_SamePosition()
    {
        // Вхідні дані H6 -> H6 (ті ж самі координати)
        var start = Program.ConvertPosition("H6");
        var end = Program.ConvertPosition("H6");
        int result = Program.MinMoves(start.Item1, start.Item2, end.Item1, end.Item2);
        Assert.That(result, Is.EqualTo(0));  // Нуль кроків, так як позиції однакові
    }

    // Тест для випадку з двома платформами
    [Test]
    public void MinMoves_TwoStepMove()
    {
        // Вхідні дані A6 -> F6 (необхідно три кроки)
        var start = Program.ConvertPosition("A6");
        var end = Program.ConvertPosition("F6");
        int result = Program.MinMoves(start.Item1, start.Item2, end.Item1, end.Item2);
        Assert.That(result, Is.EqualTo(3));  // Очікується 3 кроки
    }

    // Тест для випадку з максимальною кількістю ходів (велике поле)
    [Test]
    public void MinMoves_LargeBoardTest()
    {
        // Вхідні дані A1 -> I9 (максимальна відстань)
        var start = Program.ConvertPosition("A1");
        var end = Program.ConvertPosition("I9");
        int result = Program.MinMoves(start.Item1, start.Item2, end.Item1, end.Item2);
        Assert.That(result, Is.EqualTo(1));  // Очікується 1 кроки, так як рух можливий по діагоналях
    }
}
