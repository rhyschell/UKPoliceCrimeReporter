namespace UKPoliceCrimeReporter.Client.Tests.ModelTests;

[TestFixture]
public class OutcomeStatusTests
{
    [Test]
    public void OutcomeStatus_Properties_ShouldBeSettableAndRetrievable()
    {
        // Arrange
        var outcomeStatus = new OutcomeStatus
        {
            Category = "Investigation complete; no suspect identified",
            Date = "2023-01"
        };

        // Assert
        Assert.Multiple(() =>
        {
            Assert.That(outcomeStatus.Category, Is.EqualTo("Investigation complete; no suspect identified"));
            Assert.That(outcomeStatus.Date, Is.EqualTo("2023-01"));
        });
    }

    [Test]
    public void OutcomeStatus_Serialization_ShouldProduceExpectedJson()
    {
        // Arrange
        var outcomeStatus = new OutcomeStatus
        {
            Category = "Investigation complete; no suspect identified",
            Date = "2023-01"
        };

        // Act
        var json = JsonSerializer.Serialize(outcomeStatus);

        // Assert
        var expectedJson = "{\"category\":\"Investigation complete; no suspect identified\",\"date\":\"2023-01\"}";
        Assert.That(json, Is.EqualTo(expectedJson));
    }

    [Test]
    public void OutcomeStatus_Deserialization_ShouldCreateValidObject()
    {
        // Arrange
        var json = "{\"category\":\"Investigation complete; no suspect identified\",\"date\":\"2023-01\"}";

        // Act
        var outcomeStatus = JsonSerializer.Deserialize<OutcomeStatus>(json);

        // Assert
        Assert.Multiple(() =>
        {
            Assert.That(outcomeStatus, Is.Not.Null);
            Assert.That(outcomeStatus.Category, Is.EqualTo("Investigation complete; no suspect identified"));
            Assert.That(outcomeStatus.Date, Is.EqualTo("2023-01"));
        });
    }
}