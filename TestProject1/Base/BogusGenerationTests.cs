using BogusLibrary.Classes;
using BogusLibrary.Models;
using KellermanSoftware.CompareNetObjects;
using Serilog;
using Serilog.Events;
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

    /// <summary>
    /// Cleans up resources and performs necessary actions after each test execution.
    /// </summary>
    /// <remarks>
    /// This method is executed after every test in the class to ensure proper cleanup.
    /// It logs the name of the test that just ran and checks the test outcome to perform
    /// specific actions based on whether the test passed, failed, or timed out.
    /// </remarks>
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
        } else if (TestContext.CurrentTestOutcome == UnitTestOutcome.Failed)
        {
            if (TestContext.TestName == nameof(CompareHumans))
            {
                // handle the specific case for the CompareHumans test failure
            }
            Console.WriteLine("Test Failed");
        }
    }
    
    [AssemblyInitialize]
    public static void AssemblyInit(TestContext _)
    {
        SeriLogging.Setup();
    }

    [AssemblyCleanup]
    public static void AssemblyCleanup()
    {
        Log.CloseAndFlush();
    }
}
