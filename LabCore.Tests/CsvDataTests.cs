using System.Globalization;
using CsvHelper;
using LabCore;

namespace LabCore.Tests;

public class CsvDataTests
{
    public static IEnumerable<object[]> MathRows()
    {
        using var reader = new StreamReader(Path.Combine(AppContext.BaseDirectory, "TestData", "math_testdata.csv"));
        using var csv = new CsvReader(reader, CultureInfo.InvariantCulture);
        foreach (var row in csv.GetRecords<MathRow>()) yield return new object[] { row.Operation, row.A, row.B, row.Expected };
    }

    [Theory]
    [MemberData(nameof(MathRows))]
    public void BasicMath_CsvData_ReturnsExpected(string operation, double a, double b, double expected)
    {
        var math = new BasicMaths();
        var actual = operation switch
        {
            "Add" => math.Add(a, b), "Subtract" => math.Subtract(a, b),
            "Multiply" => math.Multiply(a, b), "Divide" => math.Divide(a, b),
            _ => throw new InvalidDataException("Unknown operation")
        };
        Assert.Equal(expected, actual);
    }

    public record MathRow(string Operation, double A, double B, double Expected);
}
