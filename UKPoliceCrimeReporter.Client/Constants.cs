
namespace UKPoliceCrimeReporter.Client;


//creating a separate contants class to keep things like the API endpoints, parameter names, etc. all in once place
//this means we can reuse strings where needed and not have any magic strings, plus we can run tests against the contants values

internal static class Constants
{
    //endpoints
    public const string API_ENDPOINT_CRIMES_STREET = "crimes-street";
    public const string API_ENDPOINT_ALL_CRIMES = "all-crime";
    public const string API_ENDPOINT_CRIME_LAST_UPDATED = "crime-last-updated";

    //query parameters
    public const string API_QUERY_PARAMETER_LATITUDE = "lat";
    public const string API_QUERY_PARAMETER_LONGITUTE = "lng";
    public const string API_QUERY_PARAMETER_DATE = "date";
}