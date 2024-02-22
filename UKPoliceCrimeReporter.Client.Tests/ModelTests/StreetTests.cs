namespace UKPoliceCrimeReporter.Client.Tests.ModelTests;

[TestFixture]
public class StreetTests
{
    [Test]
    public void Street_Properties_ShouldBeSettableAndRetrievable()
    {
        // Arrange
        var street = new Street
        {
            Id = 1,
            Name = "Baker Street"
        };

        // Assert
        Assert.Multiple(() =>
        {
            Assert.That(street.Id, Is.EqualTo(1));
            Assert.That(street.Name, Is.EqualTo("Baker Street"));
        });
    }

    [Test]
    public void Street_Serialization_ShouldProduceExpectedJson()
    {
        // Arrange
        var street = new Street
        {
            Id = 1,
            Name = "Baker Street"
        };

        // Act
        var json = JsonSerializer.Serialize(street);

        // Assert
        var expectedJson = "{\"id\":1,\"name\":\"Baker Street\"}";
        Assert.That(json, Is.EqualTo(expectedJson));
    }

    [Test]
    public void Street_Deserialization_ShouldCreateValidObject()
    {
        // Arrange
        var json = "{\"id\":1,\"name\":\"Baker Street\"}";

        // Act
        var street = JsonSerializer.Deserialize<Street>(json);

        // Assert
        Assert.Multiple(() =>
        {
            Assert.That(street, Is.Not.Null);
            Assert.That(street.Id, Is.EqualTo(1));
            Assert.That(street.Name, Is.EqualTo("Baker Street"));
        });
    }
}