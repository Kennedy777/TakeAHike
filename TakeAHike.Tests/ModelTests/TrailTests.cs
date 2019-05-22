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
    Trail newTrail = new Trail("TrailName1", 1, 2.5f, 3, true, true, true, true, true, true);
    Assert.AreEqual(typeof(Trail), newTrail.GetType());
    }

    [TestMethod]
    public void GetName_ReturnsTrailName_String()
    {
      string name = "Test Name";
      Trail newTrail = new Trail(name, 1, 2.5f, 3, true, true, true, true, true, true);
      string result = newTrail.GetName();
      Assert.AreEqual(name, result);
    }

    [TestMethod]
    public void GetWaterfalls_ReturnsTrailWaterfalls_True()
    {
      Trail newTrail = new Trail("Test Name", 1, 2.5f, 3, true, true, true, true, true, true);
      bool result = newTrail.GetWaterfalls();
      Assert.AreEqual(true, result);
    }

    [TestMethod]
    public void Save_SavesTrailToDatabase_TrailList()
    {
      List<Trail> testList1 = new List<Trail>();
      Trail testTrail1 = new Trail("TrailName1", 1, 2.5f, 3, true, true, true, true, true, true);
      testTrail1.Save();
      testList1.Add(testTrail1);
      Trail testTrail2 = new Trail("TrailName1", 1, 2.5f, 3, true, true, true, true, true, true);
      testTrail2.Save();
      testList1.Add(testTrail2);
      List<Trail> testList2 = Trail.GetAll();
      CollectionAssert.AreEqual(testList1, testList2);
    }

    [TestMethod]
    public void Save_DatabaseAssignsIdToTrail_Id()
    {
      Trail testTrail = new Trail("TrailName1", 1, 2.5f, 3, true, true, true, true, true, true);
      testTrail.Save();
      Trail savedTrail = Trail.GetAll()[0];
      int result = savedTrail.GetId();
      int testId = testTrail.GetId();
      Assert.AreEqual(testId, result);
    }

    [TestMethod]
    public void Equals_ReturnsTrueIfPropertiesAreTheSame_Trail()
    {
      Trail testTrail1 = new Trail("TrailName1", 1, 2.5f, 3, true, true, true, true, true, true);
      Trail testTrail2 = new Trail("TrailName1", 1, 2.5f, 3, true, true, true, true, true, true);
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
      Trail testTrail1 = new Trail("TrailName1", 1, 2.5f, 3, true, true, true, true, true, true);
      Trail testTrail2 = new Trail("TrailName1", 1, 2.5f, 3, true, true, true, true, true, true);
      testTrail1.Save();
      testTrail2.Save();
      List<Trail> result = Trail.GetAll();
      List<Trail> newList = new List<Trail> { testTrail1, testTrail2 };
      CollectionAssert.AreEqual(result, newList);
    }

    [TestMethod]
    public void Find_ReturnsTrailInDataBase_Trail()
    {
      Trail testTrail = new Trail("TrailName1", 1, 2.5f, 3, true, true, true, true, true, true);
      testTrail.Save();
      Trail foundTrail = Trail.Find(testTrail.GetId());
      Assert.AreEqual(testTrail, foundTrail);
    }

    [TestMethod]
    public void AddTrail_AddsTrailToUser_TrailList()
    {
      Trail testTrail = new Trail("TrailName1", 1, 2.5f, 3, true, true, true, true, true, true);
      testTrail.Save();
      User testUser = new User("Test Name", "first", "last", 98105, "(803)234-5554", "email@email.com", 1, 1);
      testUser.Save();
      testUser.AddTrail(testTrail);
      List<Trail> result = testUser.GetTrails();
      List<Trail> testList = new List<Trail>{ testTrail };
      CollectionAssert.AreEqual(testList, result);
    }

    [TestMethod]
    public void GetFiltered_ReturnsSelectedTrailsInDatabase_TrailList()
    {
      Trail testTrail1 = new Trail("TrailName1", 1, 2.5f, 3, true, true, true, true, true, true);
      testTrail1.Save();
      Trail testTrail2 = new Trail("TrailName2", 1, 2.5f, 3, false, true, true, true, true, true);
      testTrail2.Save();
      List<Trail> result = Trail.GetFiltered(1, 2.5f, 3, true, true, true, true, true, true);
      List<Trail> testList = new List<Trail>{ testTrail1 };
      CollectionAssert.AreEqual(testList, result);
    }

    [TestMethod]
    public void FilterByDifficulty_ReturnsSelectedTrailsInDatabase_TrailList()
    {
      Trail testTrail1 = new Trail("TrailName1", 1, 2.5f, 3, true, true, true, true, true, true);
      testTrail1.Save();
      Trail testTrail2 = new Trail("TrailName2", 5, 2.5f, 3, false, true, true, true, true, true);
      testTrail2.Save();
      List<Trail> result = Trail.FilterByDifficulty(1);
      List<Trail> testList = new List<Trail>{ testTrail1 };
      CollectionAssert.AreEqual(testList, result);
    }
  }
}
