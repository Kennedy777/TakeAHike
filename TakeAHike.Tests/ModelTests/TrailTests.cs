using Microsoft.VisualStudio.TestTools.UnitTesting;
using TakeAHike.Models;
using System.Collections.Generic;
using System;

namespace TakeAHike.Tests
{
  [TestClass]
  public class TrailTest : IDisposable
  {
    public TrailTest()
    {
      DBConfiguration.ConnectionString = "server=localhost;user id=root;password=root;port=8889;database=takeahiketest;";
    }

    public void Dispose()
    {
      Trail.ClearAll();
    }

    [TestMethod]
    public void TrailConstructor_CreatesNewInstanceOfObject_Trail()
    {
    Trail testTrail = new Trail("Test Name", 1, 5.5f);
    Assert.AreEqual(typeof(Trail), testTrail.GetType());
    }

    [TestMethod]
    public void Save_SavesTrailToDatabase_TrailList()
    {
      Trail testTrail = new Trail("Test Name", 1, 5.5f);
      testTrail.Save();
      List<Trail> result = Trail.GetAll();
      List<Trail> testList = new List<Trail>{testTrail};
      CollectionAssert.AreEqual(testList, result);
    }

    [TestMethod]
    public void Save_DatabaseAssignsIdToTrail_Id()
    {
      Trail testTrail = new Trail("Test Name", 1, 5.5f);
      testTrail.Save();
      Trail savedTrail = Trail.GetAll()[0];
      int result = savedTrail.GetId();
      int testId = testTrail.GetId();
      Assert.AreEqual(testId, result);
    }

    [TestMethod]
    public void Equals_ReturnsTrueIfPropertiesAreTheSame_Trail()
    {
      Trail testTrail1 = new Trail("Test Name", 1, 5.5f);
      Trail testTrail2 = new Trail("Test Name", 1, 5.5f);
      Assert.AreEqual(testTrail1, testTrail2);
    }

    [TestMethod]
    public void GetAll_TrailsStartEmpty_TrailList()
    {
      int result = Trail.GetAll().Count;
      Assert.AreEqual(0, result);
    }

    [TestMethod]
    public void GetAll_ReturnsAllTrails_TrailList()
    {
      Trail testTrail1 = new Trail("Test Name", 1, 5.5f);
      Trail testTrail2 = new Trail("Test Name", 1, 5.5f);
      testTrail1.Save();
      testTrail2.Save();
      List<Trail> result = Trail.GetAll();
      List<Trail> newList = new List<Trail> { testTrail1, testTrail2 };
      CollectionAssert.AreEqual(result, newList);
    }

  }
}
