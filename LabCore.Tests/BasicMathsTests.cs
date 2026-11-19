using LabCore;

namespace LabCore.Tests;

public class BasicMathsTests
{
    private readonly BasicMaths _math = new();

    [Theory]
    [InlineData(1, 2, 3)]
    [InlineData(-1, -2, -3)]
    [InlineData(0, 0, 0)]
    [InlineData(double.MaxValue, 0, double.MaxValue)]
    public void Add_MultipleValues_ReturnsExpected(double a, double b, double expected) => Assert.Equal(expected, _math.Add(a, b));

    [Theory]
    [InlineData(5, 3, 2)]
    [InlineData(-5, -3, -2)]
    [InlineData(0, 0, 0)]
    public void Subtract_MultipleValues_ReturnsExpected(double a, double b, double expected) => Assert.Equal(expected, _math.Subtract(a, b));

    [Theory]
    [InlineData(2, 3, 6)]
    [InlineData(-2, -3, 6)]
    [InlineData(0, 5, 0)]
    public void Multiply_MultipleValues_ReturnsExpected(double a, double b, double expected) => Assert.Equal(expected, _math.Multiply(a, b));

    [Theory]
    [InlineData(6, 3, 2)]
    [InlineData(-6, -3, 2)]
    [InlineData(0, 1, 0)]
    public void Divide_MultipleValues_ReturnsExpected(double a, double b, double expected) => Assert.Equal(expected, _math.Divide(a, b));

    [Fact]
    public void Divide_ByZero_ThrowsException() => Assert.Throws<DivideByZeroException>(() => _math.Divide(10, 0));
}
