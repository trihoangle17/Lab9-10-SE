using System.Globalization;
using CsvHelper;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;

namespace LabWebApp.SeleniumTests;

public class LoginTests
{
    public static IEnumerable<object[]> Credentials()
    {
        using var reader = new StreamReader(Path.Combine(AppContext.BaseDirectory, "LoginTestData.csv"));
        using var csv = new CsvReader(reader, CultureInfo.InvariantCulture);
        foreach (var row in csv.GetRecords<LoginRow>()) yield return new object[] { row.Username, row.Password, row.ExpectedMessage };
    }

    [Theory]
    [MemberData(nameof(Credentials))]
    public void Login_WithCsvCredentials_ShowsExpectedMessage(string username, string password, string expectedMessage)
    {
        var options = new ChromeOptions();
        options.AddArgument("--headless=new");
        using IWebDriver driver = new ChromeDriver(options);
        driver.Navigate().GoToUrl("http://localhost:8080/Account/Login");
        driver.FindElement(By.Id("username")).SendKeys(username);
        driver.FindElement(By.Id("password")).SendKeys(password);
        driver.FindElement(By.Id("loginButton")).Click();
        Assert.Contains(expectedMessage, driver.FindElement(By.Id("result")).Text);
    }

    public record LoginRow(string Username, string Password, string ExpectedMessage);
}
