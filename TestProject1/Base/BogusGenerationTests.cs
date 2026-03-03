using BogusLibrary.Classes;
using BogusLibrary.Models;
using KellermanSoftware.CompareNetObjects;
using System.Diagnostics;
using System.Reflection;
using System.Text.Json;
using TestProject1.Classes;

#pragma warning disable IDE0130

namespace TestProject1;
public sealed partial class BogusGenerationTests
{
    private static Human _human;
    private static Human _testHuman;

    /// <summary>
    /// Initializes the test class by setting up necessary resources and configurations.
    /// </summary>
    /// <param name="testContext">
    /// The <see cref="TestContext"/> instance that provides information about the current test run.
    /// </param>
    /// <exception cref="InvalidOperationException">
    /// Thrown when the <see cref="HumanGenerator.Create(int,bool)"/> method does not
    /// return any items.
    /// </exception>
    [ClassInitialize]
    public static void ClassInitialize(TestContext testContext)
    {
        TestResults = new List<TestContext>();
        
        _human = TestConfiguration.Instance.Human;
        _testHuman = TestConfiguration.Instance.TestHuman;

    }

    [TestCleanup]
    public void TestCleanup()
    {
        // Access the name of the test that just ran
        Console.WriteLine($"Test Cleanup for: {TestContext.TestName}");

        // You can also check the test outcome (e.g., Passed, Failed)
        if (TestContext.CurrentTestOutcome == UnitTestOutcome.Passed)
        {
            // Do something specific for a passed test
        } else if (TestContext.CurrentTestOutcome == UnitTestOutcome.Timeout)
        {
            Console.WriteLine("Test Timeout");
        }   
        {
            // Do something specific for a failed test
        }
    }
}
