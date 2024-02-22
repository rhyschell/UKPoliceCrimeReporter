namespace UKPoliceCrimeReporter.Client.Tests.OptionsTests;

[TestFixture]
public class UKCrimeClientOptionsTests
{
    [Test]
    public void UKCrimeClientOptions_Properties_ShouldBeSettableAndRetrievable()
    {
        // Arrange
        var options = new UKCrimeClientOptions
        {
            BaseAddress = "https://example.com/api"
        };

        // Assert
        Assert.That(options.BaseAddress, Is.EqualTo("https://example.com/api"));
    }
}