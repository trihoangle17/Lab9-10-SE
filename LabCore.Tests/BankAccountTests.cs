using LabCore;

namespace LabCore.Tests;

public class BankAccountTests
{
    [Theory]
    [InlineData("Trung Pham", 1000, 200, 800)]
    [InlineData("Ky Pham", 500, 100, 400)]
    [InlineData("Thai Pham", 300, 50, 250)]
    [InlineData("Boundary", 100, 100, 0)]
    public void Debit_ValidAmount_UpdatesBalance(string name, decimal initial, decimal amount, decimal expected)
    {
        var account = new BankAccount(name, initial);
        account.Debit(amount);
        Assert.Equal(expected, account.Balance);
    }

    [Fact]
    public void Debit_InsufficientFunds_ThrowsException()
    {
        var account = new BankAccount("Ky Trung Pham", 100);
        Assert.Throws<InvalidOperationException>(() => account.Debit(150));
    }

    [Fact]
    public void Credit_ValidAmount_UpdatesBalance()
    {
        var account = new BankAccount("Student", 100);
        account.Credit(50);
        Assert.Equal(150, account.Balance);
    }

    [Fact]
    public void Withdraw_ValidAmount_UpdatesBalance()
    {
        var account = new BankAccount("Student", 100);
        account.Withdraw(40);
        Assert.Equal(60, account.Balance);
    }
}
