namespace UKPoliceCrimeReporter.Client.Tests.ModelTests;

[TestFixture]
public class LocationTests
{
    [Test]
    public void Location_Properties_ShouldBeSettableAndRetrievable()
    {
        // Arrange
        var location = new Location
        {
            Latitude = "51.5074",
            Longitude = "0.1278",
            Street = new Street { Name = "Baker Street", Id = 123 }
        };

        // Assert
        Assert.Multiple(() =>
        {
            Assert.That(location.Latitude, Is.EqualTo("51.5074"));
            Assert.That(location.Longitude, Is.EqualTo("0.1278"));
            Assert.That(location.Street, Is.Not.Null);
            Assert.That(location.Street.Name, Is.EqualTo("Baker Street"));
            Assert.That(location.Street.Id, Is.EqualTo(123));
        });
    }

    [Test]
    public void Location_Serialization_ShouldProduceExpectedJson()
    {
        // Arrange
        var location = new Location
        {
            Latitude = "51.5074",
            Longitude = "0.1278",
            Street = new Street { Name = "Baker Street", Id = 123 }
        };

        // Act
        var json = JsonSerializer.Serialize(location);

        // Assert
        var expectedJson = "{\"latitude\":\"51.5074\",\"longitude\":\"0.1278\",\"street\":{\"id\":123,\"name\":\"Baker Street\"}}";
        Assert.That(json, Is.EqualTo(expectedJson));
    }

    [Test]
    public void Location_Deserialization_ShouldCreateValidObject()
    {
        // Arrange
        var json = "{\"latitude\":\"51.5074\",\"longitude\":\"0.1278\",\"street\":{\"name\":\"Baker Street\",\"id\":123}}";

        // Act
        var location = JsonSerializer.Deserialize<Location>(json);

        // Assert
        Assert.Multiple(() =>
        {
            Assert.That(location, Is.Not.Null);
            Assert.That(location.Latitude, Is.EqualTo("51.5074"));
            Assert.That(location.Longitude, Is.EqualTo("0.1278"));
            Assert.That(location.Street, Is.Not.Null);
            Assert.That(location.Street.Name, Is.EqualTo("Baker Street"));
            Assert.That(location.Street.Id, Is.EqualTo(123));
        });
    }
}