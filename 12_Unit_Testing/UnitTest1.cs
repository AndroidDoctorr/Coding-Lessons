using System.Reflection;
using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using _06_Classes;
using System.IO;
using System.Diagnostics;

namespace _12_Unit_Testing;

// ! Start by creating the CalcTest method and demo the AAA pattern
// Then create the repo field and add the first two repo test methods
// Then create the TestInitialize method and the delete test method

[TestClass]
public class UnitTest1
{
    StreamingContentRepository _repo = new StreamingContentRepository();

    [TestInitialize]
    public void RunBeforeTests()
    {
        _repo.AddContentToDirectory(new StreamingContent(
            "Hawk Jones",
            "Buddy Cop movie but all the parts are played by children with fake mustaches",
            MaturityRating.U,
            4.5,
            Genre.Comedy
        ));
    }

    [TestMethod]
    public void CalcTest()
    {
        // AAA Pattern
        // Arrange - set up everything needed for the test
        Calculator calc = new Calculator();

        // Act - perform the action you're testing
        int actual = calc.Add(2, 2);
        int expected = 4;

        // Assert - compare the actual result with the the expected result
        Assert.AreEqual(expected, actual);
    }

    [TestMethod]
    public void GetExistingMovie_ShouldGetMovie()
    {
        // Arrange, Act
        var pi = _repo.GetContentByTitle("pi");

        // Assert
        Assert.IsNotNull(pi);
        // Sometimes it's appropriate to use multiple assertions in a test.
        // In this case, we may want to ensure that we've grabbed the correct
        // StreamingContent item from the "database"
        if (pi != null)
        {
            Assert.AreEqual(pi.Title, "Pi");
        }
        // If you're testing different things, you should create different test methods

        // The whole point of a Unit test is isolating functionality, so you can test
        // the individual components of an application, in addition to what are called
        // Integration Tests, where complete app functionalities are tested together.
        // These types of tests can reveal different information. Components of an
        // app can work individually but conflict when used together, or in stranger
        // scenarios, parts can account for each other's failures and work together
        // while failing individually
    }

    [TestMethod]
    public void GetNonExistentMovie_ShouldGetNull()
    {
        // Arrange, Act
        var pi = _repo.GetContentByTitle("poo");

        // Assert
        Assert.IsNull(pi);
    }

    [TestMethod]
    public void DeleteMovie_ShouldGetNull()
    {
        var hawkJones = _repo.DeleteExistingContent("hawk jones");

        var noHawkJones = _repo.GetContentByTitle("hawk jones");

        Assert.IsNull(noHawkJones);
    }

    [DataTestMethod]
    public void DataTestExample() {
        StreamingContent sc = new StreamingContent();
        sc.MaturityRating = MaturityRating.G;
        
    }
}