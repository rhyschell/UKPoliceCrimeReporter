using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using UKPoliceCrimeReporter.Client.Interfaces;
using UKPoliceCrimeReporter.UI.Models;

namespace UKPoliceCrimeReporter.UI.Controllers;

public class HomeController : Controller
{
    private readonly ILogger<HomeController> _logger;
    private readonly IUKCrimeClient _crimeClient;

    public HomeController(ILogger<HomeController> logger, IUKCrimeClient crimeClient)
    {
        _logger = logger;
        _crimeClient = crimeClient;
    }

    public async Task<IActionResult> Index(double? lat, double? lng, int? month, int? year)
    {
        //save the values in the view model so we can forward them on to the client
        CrimeDataViewModel vm = new CrimeDataViewModel(lat, lng, month, year);

        //get the max allowed date - this will help build our UI
        await TryGetMaxAllowedDate(vm);

        //as long as we've got everything, call the service and get a list of crimes to display
        if (lat.HasValue && lng.HasValue && month.HasValue && year.HasValue)
        {
            await TryGetCrimesGroupedByCategory(vm, lat.Value, lng.Value, month.Value, year.Value);
        }

        return View(vm);
    }

    //just use some helper methods wrapping the service calls in try/catch - keeps the controller a bit tidier and easier to read
    private async Task TryGetMaxAllowedDate(CrimeDataViewModel vm)
    {
        try
        {
            vm.MaxAllowedDate = await _crimeClient.GetCrimeLastUpdatedDateAsync();
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, $"Error getting max allowed date");
        }
    }

    private async Task TryGetCrimesGroupedByCategory(CrimeDataViewModel vm, double lat, double lng, int month, int year)
    {
        try
        {
            //TODO: This will fail if an invalid year or month is used, would need to add validation
            DateTime date = new DateTime(year, month, 1);

            var crimes = await _crimeClient.GetAllCrimesForLocationAsync(lat, lng, date);
            if (crimes == null || crimes.Count == 0) return;

            //TODO: this should probably live in a helper class somewhere so we can test the logic
            vm.CategoryGroupedCrimes = crimes.GroupBy(x => x.Category)
                .OrderBy(x=> x.Key)
                .ToDictionary(x => x.Key, x => x.ToList());
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, $"Error getting crimes for lat: {lat}, long: {lng}, month: {month}, year: {year}");

            //if the lookup failed for whatever reason, set a marker on our view model
            vm.LookupFailed = true;
        }
    }

    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
}