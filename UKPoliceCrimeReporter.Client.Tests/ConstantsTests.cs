namespace UKPoliceCrimeReporter.Client.Tests;

[TestFixture]
public class ConstantsTests
{

    //as constants grows, it might make more sense to group these tests in to their logical groups
    //E.g. tests the api endpoint strings, tests for the query parameter strings, etc.
    //given the size, individual tests fine for now

    [Test]
    public void Constants_ApiEndpointCrimesStreet_ShouldHaveCorrectValue()
    {
        // Arrange
        const string expectedEndpoint = "crimes-street";

        // Act
        var actualEndpoint = Constants.API_ENDPOINT_CRIMES_STREET;

        // Assert
        Assert.That(actualEndpoint, Is.EqualTo(expectedEndpoint));
    }

    [Test]
    public void Constants_ApiEndpointAllCrimes_ShouldHaveCorrectValue()
    {
        // Arrange
        const string expectedEndpoint = "all-crime";

        // Act
        var actualEndpoint = Constants.API_ENDPOINT_ALL_CRIMES;

        // Assert
        Assert.That(actualEndpoint, Is.EqualTo(expectedEndpoint));
    }   
    
    [Test]
    public void Constants_ApiEndpointCrimeLastUpdated_ShouldHaveCorrectValue()
    {
        // Arrange
        const string expectedEndpoint = "crime-last-updated";

        // Act
        var actualEndpoint = Constants.API_ENDPOINT_CRIME_LAST_UPDATED;

        // Assert
        Assert.That(actualEndpoint, Is.EqualTo(expectedEndpoint));
    }

    [Test]
    public void Constants_ApiQueryParameterLatitude_ShouldHaveCorrectValue()
    {
        // Arrange
        const string expectedParameter = "lat";

        // Act
        var actualParameter = Constants.API_QUERY_PARAMETER_LATITUDE;

        // Assert
        Assert.That(actualParameter, Is.EqualTo(expectedParameter));
    }

    [Test]
    public void Constants_ApiQueryParameterLongitude_ShouldHaveCorrectValue()
    {
        // Arrange
        const string expectedParameter = "lng";

        // Act
        var actualParameter = Constants.API_QUERY_PARAMETER_LONGITUTE;

        // Assert
        Assert.That(actualParameter, Is.EqualTo(expectedParameter));
    }

    [Test]
    public void Constants_ApiQueryParameterDate_ShouldHaveCorrectValue()
    {
        // Arrange
        const string expectedParameter = "date";

        // Act
        var actualParameter = Constants.API_QUERY_PARAMETER_DATE;

        // Assert
        Assert.That(actualParameter, Is.EqualTo(expectedParameter));
    }
}