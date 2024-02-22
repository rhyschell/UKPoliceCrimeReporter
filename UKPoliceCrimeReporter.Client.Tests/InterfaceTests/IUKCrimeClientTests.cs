using Moq;

namespace UKPoliceCrimeReporter.Client.Tests.InterfaceTests;

[TestFixture]
public class IUKCrimeClientTests
{
    private Mock<IUKCrimeClient> _mockClient;

    [SetUp]
    public void Setup()
    {
        _mockClient = new Mock<IUKCrimeClient>();
    }

    [Test]
    public async Task GetAllCrimesForLocationAsync_ShouldReturnListOfCrimes()
    {
        // Arrange
        var expectedCrimes = new List<Crime>
        {
            new Crime { Category = "Burglary", LocationType = "Force", Location = new Location(), Context = "Occurred during the night", OutcomeStatus = new OutcomeStatus(), PersistentId = "abcdef123456", Id = 123, LocationSubtype = "Suburb", Month = "2023-01" }
        };

        _mockClient.Setup(client => client.GetAllCrimesForLocationAsync(It.IsAny<double>(), It.IsAny<double>(), It.IsAny<DateTime>()))
            .ReturnsAsync(expectedCrimes);

        // Act
        var result = await _mockClient.Object.GetAllCrimesForLocationAsync(0, 0, DateTime.Now);

        // Assert
        Assert.That(result, Is.EqualTo(expectedCrimes));
    }

    [Test]
    public async Task GetCrimeLastUpdatedDateAsync_ShouldReturnDateTime()
    {
        // Arrange
        var expectedDate = DateTime.Now;

        _mockClient.Setup(client => client.GetCrimeLastUpdatedDateAsync())
            .ReturnsAsync(expectedDate);

        // Act
        var result = await _mockClient.Object.GetCrimeLastUpdatedDateAsync();

        // Assert
        Assert.That(result, Is.EqualTo(expectedDate));
    }

    [Test]
    public void Dispose_ShouldThrowNotImplementedException()
    {
        // Arrange
        _mockClient.Setup(client => client.Dispose())
                  .Throws(new NotImplementedException());

        // Act & Assert
        Assert.Throws<NotImplementedException>(() => _mockClient.Object.Dispose());
    }

    [TearDown]
    public void TearDown()
    {
        _mockClient.VerifyAll();
    }
}