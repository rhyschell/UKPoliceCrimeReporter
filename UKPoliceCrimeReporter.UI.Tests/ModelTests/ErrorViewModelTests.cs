namespace UKPoliceCrimeReporter.Client.Tests.ModelTests;

[TestFixture]
public class ErrorViewModelTests
{
    [Test]
    public void ErrorViewModel_RequestId_ShouldBeSettableAndRetrievable()
    {
        // Arrange
        var errorViewModel = new ErrorViewModel();
        var requestId = "12345";

        // Act
        errorViewModel.RequestId = requestId;

        // Assert
        Assert.That(errorViewModel.RequestId, Is.EqualTo(requestId));
    }

    [Test]
    public void ErrorViewModel_ShowRequestId_ShouldReturnTrue_WhenRequestIdIsNotNullOrEmpty()
    {
        // Arrange
        var errorViewModel = new ErrorViewModel();
        errorViewModel.RequestId = "12345";

        // Act
        bool showRequestId = errorViewModel.ShowRequestId;

        // Assert
        Assert.That(showRequestId, Is.True);
    }

    [Test]
    public void ErrorViewModel_ShowRequestId_ShouldReturnFalse_WhenRequestIdIsNullOrEmpty()
    {
        // Arrange
        var errorViewModel = new ErrorViewModel();
        errorViewModel.RequestId = null;

        // Act
        bool showRequestId = errorViewModel.ShowRequestId;

        // Assert
        Assert.That(showRequestId, Is.False);

        // Arrange
        errorViewModel.RequestId = string.Empty;

        // Act
        showRequestId = errorViewModel.ShowRequestId;

        // Assert
        Assert.That(showRequestId, Is.False);
    }
}