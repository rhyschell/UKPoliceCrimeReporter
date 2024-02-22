using UKPoliceCrimeReporter.Client.Models;

namespace UKPoliceCrimeReporter.Client.Interfaces;

public interface IUKCrimeClient : IDisposable
{
    public Task<List<Crime>?> GetAllCrimesForLocationAsync(double latitude, double longitude, DateTime date);
    public Task<DateTime?> GetCrimeLastUpdatedDateAsync();
}