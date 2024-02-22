# UKPoliceCrimeReporter
Built using .NET 8, VS 2022.

The solution is made up of the following projects:
- Client
- Client.Tests
- UI
- UI.Tests

## Client
The client project is a class library for accessing the public police API. Whilst it would have been possible to complete this project by calling the police API directly from the front-end, I opted to write a wrapper client in C# for several reasons, including but not limited to:

- Reusability - if a new project needed to be added, which also needed to utilise the police API, the client wrapper can be used.
- Logging/Monitoring - incoming requests can be easily logged, allowing us to track API usage metrics, monitor performance, and troubleshoot issues more effectively.
- Security - although the police API is public and not owned by us, it is hidden behind our own application. If the API ever required authentication, such as a private API key, this can be easily done without exposing the credentials.

Tests for the **Client** project can be found in the **Client.Tests** project.

## UI
The UI project is an MVC application, with a very simple form for entering the values for lat/long and date. Upon submission, the summary of crimes is displayed on the right, grouped by category with the count.

Tests for the **UI** project can be found in the **UI.Tests** project.

## Improvements / unfinished code
Whilst I believe the criteria for the task has been met, given the timeframe in which this was completed, there are several improvements that could be made:

- UI / UX
  - A map / search could be implemented to set the lat/long values for the user (much like the linked site in the application).
  - The crime category summaries could use a more human-readable name. It's possible to retrieve this using the API, or they have also provided a static list of mappings which we could use in our application.
  - Validation could be implemented to ensure only a UK lat/long and a valid date is selected. This could be done both client and server side. Although validation is not currently implemented, the application will still fail gracefully and catch and exceptions from the police API and display an error to the user.
- UKCrimeClientTests
  - I didn't get round to implementing the tests for the client service (the class calling the police API). It may need a slight refactoring so it's not as dependent on the HttpClient class.
- Home controller logic
  - There is some logic to group the crime data by category, order it, and convert to a dictionary. This could ideally be moved to a helper class so it can be tested.
- Index minimum year hard coding
  - There is currently a value of "2021" hard coded in to the Home/Index page, which controls the minimum year that can be selected from the dropdown. I couldn't find a way to retrieve this from the police API, but ideally this value would come from a config source like the appSettings so it can be easily tweaked without a code change.
- UKCrimeClient HttpClient BaseAddress
  - HttpClient required that the base address ends in a trailing slash. We are in control of the base address, but it would be good to implement a helper to ensure the value we set always ends in a single trailing slash.
