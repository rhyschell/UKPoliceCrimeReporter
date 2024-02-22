using UKPoliceCrimeReporter.Client.Models;

namespace UKPoliceCrimeReporter.Client.Tests.ModelTests;

[TestFixture]
public class CrimeDataViewModelTests
{
    [Test]
    public void CrimeDataViewModel_ShowResults_ShouldReturnTrue_WhenAllPropertiesAreSet()
    {
        // Arrange
        var crimeDataViewModel = new CrimeDataViewModel
        {
            Latitude = 51.5074,
            Longitude = 0.1278,
            Month = 1,
            Year = 2023
        };

        // Act
        bool showResults = crimeDataViewModel.ShowResults;

        // Assert
        Assert.That(showResults, Is.True);
    }

    [Test]
    public void CrimeDataViewModel_ShowResults_ShouldReturnFalse_WhenAnyPropertyIsNull()
    {
        // Arrange
        var crimeDataViewModel = new CrimeDataViewModel
        {
            Latitude = 51.5074,
            Longitude = null,
            Month = 1,
            Year = 2023
        };

        // Act
        bool showResults = crimeDataViewModel.ShowResults;

        // Assert
        Assert.That(showResults, Is.False);
    }

    [Test]
    public void CrimeDataViewModel_Constructor_ShouldSetProperties()
    {
        // Arrange
        double? latitude = 51.5074;
        double? longitude = 0.1278;
        int? month = 1;
        int? year = 2023;

        // Act
        var crimeDataViewModel = new CrimeDataViewModel(latitude, longitude, month, year);

        // Assert
        Assert.Multiple(() =>
        {
            Assert.That(crimeDataViewModel.Latitude, Is.EqualTo(latitude));
            Assert.That(crimeDataViewModel.Longitude, Is.EqualTo(longitude));
            Assert.That(crimeDataViewModel.Month, Is.EqualTo(month));
            Assert.That(crimeDataViewModel.Year, Is.EqualTo(year));
        });
    }

    [Test]
    public void CrimeDataViewModel_Properties_ShouldBeSettableAndRetrievable()
    {
        // Arrange
        double? latitude = 51.5074;
        double? longitude = 0.1278;
        int? month = 1;
        int? year = 2023;
        var crimeDataViewModel = new CrimeDataViewModel();

        // Act
        crimeDataViewModel.Latitude = latitude;
        crimeDataViewModel.Longitude = longitude;
        crimeDataViewModel.Month = month;
        crimeDataViewModel.Year = year;
        crimeDataViewModel.LookupFailed = true;
        var maxAllowedDate = new DateTime(2023, 12, 31);
        crimeDataViewModel.MaxAllowedDate = maxAllowedDate;
        var crimes = new List<Crime>();
        crimeDataViewModel.CategoryGroupedCrimes = new Dictionary<string, List<Crime>>();
        crimeDataViewModel.CategoryGroupedCrimes.Add("Category1", crimes);

        // Assert
        Assert.Multiple(() =>
        {
            Assert.That(crimeDataViewModel.Latitude, Is.EqualTo(latitude));
            Assert.That(crimeDataViewModel.Longitude, Is.EqualTo(longitude));
            Assert.That(crimeDataViewModel.Month, Is.EqualTo(month));
            Assert.That(crimeDataViewModel.Year, Is.EqualTo(year));
            Assert.That(crimeDataViewModel.LookupFailed, Is.True);
            Assert.That(crimeDataViewModel.MaxAllowedDate, Is.EqualTo(maxAllowedDate));
            Assert.That(crimeDataViewModel.CategoryGroupedCrimes, Is.Not.Null);
            Assert.That(crimeDataViewModel.CategoryGroupedCrimes.ContainsKey("Category1"), Is.True);
            Assert.That(crimeDataViewModel.CategoryGroupedCrimes["Category1"], Is.EqualTo(crimes));
        });
    }
}