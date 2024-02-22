using Microsoft.AspNetCore.Mvc;
using UKPoliceCrimeReporter.Client.Models;

namespace UKPoliceCrimeReporter.UI.Models;

public class CrimeDataViewModel
{
    public double? Latitude { get; set; }
    public double? Longitude { get; set; }
    public int? Month { get; set; }
    public int? Year { get; set; }

    public Dictionary<string, List<Crime>>? CategoryGroupedCrimes { get; set; }

    public bool ShowResults => Latitude != null && Longitude != null && Month != null && Year != null;
    public bool LookupFailed { get; set; }
    public DateTime? MaxAllowedDate { get; set; }

    public CrimeDataViewModel() { }

    public CrimeDataViewModel(double? lat, double? lng, int? month, int? year)
    {
        Latitude = lat;
        Longitude = lng;
        Month = month;
        Year = year;

    }
}
