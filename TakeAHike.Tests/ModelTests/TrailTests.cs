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
      DBConfiguration.ConnectionString = "server=localhost;user id=root;password=root;port=8889;database=takeahike_test;";
    }

    public void Dispose()
    {
      Trail.ClearAll();
    }

    [TestMethod]
    public void TrailConstructor_CreatesNewInstanceOfObject_Trail()
    {
    Trail newTrail = new Trail("Test Name", 1, 5.5f);
    Assert.AreEqual(typeof(Trail), newTrail.GetType());
    }

    [TestMethod]
    public void GetName_ReturnsTrailName_String()
    {
      string name = "Test Name";
      Trail newTrail = new Trail(name, 1, 5.5f);
      string result = newTrail.GetName();
      Assert.AreEqual(name, result);
    }

    [TestMethod]
    public void Save_SavesTrailToDatabase_TrailList()
    {
      List<Trail> testList1 = new List<Trail>();
      Trail testTrail1 = new Trail("Test Name1", 1, 5.6f);
      testTrail1.Save();
      testList1.Add(testTrail1);
      Trail testTrail2 = new Trail("Test Name2", 1, 5.6f);
      testTrail2.Save();
      testList1.Add(testTrail2);
      List<Trail> testList2 = Trail.GetAll();
      CollectionAssert.AreEqual(testList1, testList2);
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

    [TestMethod]
    public void Find_ReturnsTrailInDataBase_Trail()
    {
      Trail testTrail = new Trail("Test Name", 1, 5.5f);
      testTrail.Save();
      Trail foundTrail = Trail.Find(testTrail.GetId());
      Assert.AreEqual(testTrail, foundTrail);
    }

  }
}
