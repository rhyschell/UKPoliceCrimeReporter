namespace UKPoliceCrimeReporter.Client.Tests.ModelTests;

[TestFixture]
public class CrimeTests
{
    [Test]
    public void Crime_Properties_ShouldBeSettableAndRetrievable()
    {
        // Arrange
        var crime = new Crime
        {
            Category = "Burglary",
            LocationType = "Force",
            Location = new Location { Latitude = "51.5074", Longitude = "0.1278" },
            Context = "Occurred during the night",
            OutcomeStatus = new OutcomeStatus { Category = "Investigation complete; no suspect identified", Date = "2023-01" },
            PersistentId = "abcdef123456",
            Id = 123,
            LocationSubtype = "Suburb",
            Month = "2023-01"
        };

        // Assert
        Assert.Multiple(() =>
        {
            Assert.That(crime.Category, Is.EqualTo("Burglary"));
            Assert.That(crime.LocationType, Is.EqualTo("Force"));
            Assert.That(crime.Location, Is.Not.Null);
            Assert.That(crime.Context, Is.EqualTo("Occurred during the night"));
            Assert.That(crime.OutcomeStatus, Is.Not.Null);
            Assert.That(crime.PersistentId, Is.EqualTo("abcdef123456"));
            Assert.That(crime.Id, Is.EqualTo(123));
            Assert.That(crime.LocationSubtype, Is.EqualTo("Suburb"));
            Assert.That(crime.Month, Is.EqualTo("2023-01"));
        });
    }

    [Test]
    public void Crime_Serialization_ShouldProduceExpectedJson()
    {
        // Arrange
        var crime = new Crime
        {
            Category = "Burglary",
            LocationType = "Force",
            Location = new Location { Latitude = "51.5074", Longitude = "0.1278" },
            Context = "Occurred during the night",
            OutcomeStatus = new OutcomeStatus { Category = "Investigation complete; no suspect identified", Date = "2023-01" },
            PersistentId = "abcdef123456",
            Id = 123,
            LocationSubtype = "Suburb",
            Month = "2023-01"
        };

        // Act
        var json = JsonSerializer.Serialize(crime);

        // Assert
        var expectedJson = "{\"category\":\"Burglary\",\"location_type\":\"Force\",\"location\":{\"latitude\":\"51.5074\",\"longitude\":\"0.1278\",\"street\":null},\"context\":\"Occurred during the night\",\"outcome_status\":{\"category\":\"Investigation complete; no suspect identified\",\"date\":\"2023-01\"},\"persistent_id\":\"abcdef123456\",\"id\":123,\"location_subtype\":\"Suburb\",\"month\":\"2023-01\"}";
        Assert.That(json, Is.EqualTo(expectedJson));
    }

    [Test]
    public void Crime_Deserialization_ShouldCreateValidObject()
    {
        // Arrange
        var json = "{\"category\":\"Burglary\",\"location_type\":\"Force\",\"location\":{\"latitude\":\"51.5074\",\"longitude\":\"0.1278\"},\"context\":\"Occurred during the night\",\"outcome_status\":{\"category\":\"Investigation complete; no suspect identified\",\"date\":\"2023-01\"},\"persistent_id\":\"abcdef123456\",\"id\":123,\"location_subtype\":\"Suburb\",\"month\":\"2023-01\"}";

        // Act
        var crime = JsonSerializer.Deserialize<Crime>(json);

        // Assert
        Assert.Multiple(() =>
        {
            Assert.That(crime, Is.Not.Null);
            Assert.That(crime.Category, Is.EqualTo("Burglary"));
            Assert.That(crime.LocationType, Is.EqualTo("Force"));
            Assert.That(crime.Location, Is.Not.Null);
            Assert.That(crime.Context, Is.EqualTo("Occurred during the night"));
            Assert.That(crime.OutcomeStatus, Is.Not.Null);
            Assert.That(crime.PersistentId, Is.EqualTo("abcdef123456"));
            Assert.That(crime.Id, Is.EqualTo(123));
            Assert.That(crime.LocationSubtype, Is.EqualTo("Suburb"));
            Assert.That(crime.Month, Is.EqualTo("2023-01"));
        });
    }
}