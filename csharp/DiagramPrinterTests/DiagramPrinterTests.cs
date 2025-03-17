using System.Diagnostics.CodeAnalysis;
using DiagramPrinter;
using Microsoft.VisualStudio.TestPlatform.CrossPlatEngine.Helpers;
using Moq;

namespace DiagramPrinterTests;

public class DiagramPrinterTests
{

        [Test]
    public void PrintSummary_ShouldGenerateSummary_WhenDiagramIsValid()
    {
        // Arrange
        var mockDiagram = new Mock<IDiagram>();
        mockDiagram.Setup(d => d.Name()).Returns("TestDiagram");
        mockDiagram.Setup(d => d.SerialNumber()).Returns("SN-123456");
        mockDiagram.Setup(d => d.SummaryInformation()).Returns("Test Summary");
        mockDiagram.Setup(d => d.FlowchartThumbnail()).Returns(new PngDocument("FakeName.png"));

        string summaryText = "";
        var printer = new DiagramPrinter.DiagramPrinter(); // Assuming this contains PrintSummary

        // Act
        bool result = printer.PrintSummary(mockDiagram.Object, "en", ref summaryText);

        // Assert
        Assert.IsTrue(result);

        string expected = "TestDiagram\nSN-123456\nTest Summary\nFakeName.png";
        Assert.AreEqual(expected, summaryText);
    }

    // [Test]
    // public void PrintSummary_ShouldReturnFalse_WhenDiagramIsNull()
    // {
    //     // Arrange
    //     string summaryText = "Should be cleared";
    //     var printer = new DiagramPrinterService();

    //     // Act
    //     bool result = printer.PrintSummary(null, "en", ref summaryText);

    //     // Assert
    //     Assert.IsFalse(result);
    //     Assert.AreEqual("", summaryText);
    // }



    [Test]
    public void PrintingEmptyDocumentFails()
    {
        var printer = new DiagramPrinter.DiagramPrinter();
        var result = printer.PrintDiagram(null);
        Assert.IsFalse(result);
    }

    [Test]
    public void TranslatingEmptyDocumentFails()
    {
        var printer = new DiagramPrinter.DiagramPrinter();
        var output = "";
        var result = printer.PrintSummary(null, "swedish", ref output);
        // null diagram returns false
        Assert.IsFalse(result);
        Assert.IsEmpty(output);
    }

    // Plan:
    // Validate PrintSummary's output given IDiagram input


    // DiagramSummary gets parameter object that contains the 4 fields that create a string.
    // Somewhat related to loader/saver.
    // Step 1 - Extract data object ^^^above out of diagram
    // - Pass to summary class to get string


    // HOWTO get going again
    // cd csharp && dotnet test
}



