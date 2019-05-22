using Microsoft.VisualStudio.TestTools.UnitTesting;
using TakeAHike.Models;
using System.Collections.Generic;
using System;

namespace TakeAHike.Tests
{
  [TestClass]
  public class HikerTest : IDisposable
  {
    public HikerTest()
    {
      DBConfiguration.ConnectionString = "server=localhost;hiker id=root;password=root;port=8889;database=takeahike_test;";
    }

    public void Dispose()
    {
      Hiker.ClearAll();
    }

    [TestMethod]
    public void HikerConstructor_CreatesNewInstanceOfObject_Hiker()
    {
    Hiker newHiker = new Hiker("Test Name", "first", "last", 98105, "(803)234-5554", "email@email.com", 1, 1);
    Assert.AreEqual(typeof(Hiker), newHiker.GetType());
    }

    [TestMethod]
    public void GetHikerName_ReturnsHikerName_String()
    {
      string name = "Test Name";
      Hiker newHiker = new Hiker(name, "first", "last", 98105, "(803)234-5554", "email@email.com", 1, 1);
      string result = newHiker.GetHikerName();
      Assert.AreEqual(name, result);
    }

    [TestMethod]
    public void Save_SavesHikerToDatabase_HikerList()
    {
      Hiker testHiker = new Hiker("Test Name", "first", "last", 98105, "(803)234-5554", "email@email.com", 1, 1);
      testHiker.Save();
      List<Hiker> result = Hiker.GetAll();
      List<Hiker> testList = new List<Hiker>{testHiker};
      CollectionAssert.AreEqual(testList, result);
    }

    [TestMethod]
    public void Save_DatabaseAssignsIdToHiker_Id()
    {
      Hiker testHiker = new Hiker("Test Name", "first", "last", 98105, "(803)234-5554", "email@email.com", 1, 1);
      testHiker.Save();
      Hiker savedHiker = Hiker.GetAll()[0];
      int result = savedHiker.GetId();
      int testId = testHiker.GetId();
      Assert.AreEqual(testId, result);
    }

    [TestMethod]
    public void Equals_ReturnsTrueIfPropertiesAreTheSame_Hiker()
    {
      Hiker testHiker1 = new Hiker("Test Name", "first", "last", 98105, "(803)234-5554", "email@email.com", 1, 1);
      Hiker testHiker2 = new Hiker("Test Name", "first", "last", 98105, "(803)234-5554", "email@email.com", 1, 1);
      Assert.AreEqual(testHiker1, testHiker2);
    }

    [TestMethod]
    public void GetAll_HikersStartEmpty_HikerList()
    {
      int result = Hiker.GetAll().Count;
      Assert.AreEqual(0, result);
    }

    [TestMethod]
    public void GetAll_ReturnsAllHikers_HikerList()
    {
      Hiker testHiker1 = new Hiker("Test Name", "first", "last", 98105, "(803)234-5554", "email@email.com", 1, 1);
      Hiker testHiker2 = new Hiker("Test Name", "first", "last", 98105, "(803)234-5554", "email@email.com", 1, 1);
      testHiker1.Save();
      testHiker2.Save();
      List<Hiker> result = Hiker.GetAll();
      List<Hiker> newList = new List<Hiker> { testHiker1, testHiker2 };
      CollectionAssert.AreEqual(result, newList);
    }

    [TestMethod]
    public void Find_ReturnsHikerInDataBase_Hiker()
    {
      Hiker testHiker = new Hiker("Test Name", "first", "last", 98105, "(803)234-5554", "email@email.com", 1, 1);
      testHiker.Save();
      Hiker foundHiker = Hiker.Find(testHiker.GetId());
      Assert.AreEqual(testHiker, foundHiker);
    }

    [TestMethod]
    public void GetFiltered_ReturnsSelectedHikersInDatabase_HikerList()
    {
      Hiker testHiker1 = new Hiker("Test Name1", "first", "last", 98105, "(803)234-5554", "email@email.com", 1, 1);
      testHiker1.Save();
      Hiker testHiker2 = new Hiker("Test Name2", "first", "last", 98105, "(803)234-5554", "email@email.com", 2, 2);
      testHiker2.Save();
      List<Hiker> result = Hiker.GetFiltered(1, 1);
      List<Hiker> testList = new List<Hiker>{ testHiker1 };
      CollectionAssert.AreEqual(testList, result);
    }

    [TestMethod]
    public void Edit_EditsHikerName_String()
    {
      string Name1 = "Test1";
      Hiker testHiker = new Hiker(Name1, "first", "last", 98105, "(803)234-5554", "email@email.com", 2, 2);
      testHiker.Save();
      string Name2 = "Test2";
      testHiker.Edit(Name2, "first", "last", 98105, "(803)234-5554", "email@email.com", 2, 2);
      string result = Hiker.Find(testHiker.GetId()).GetHikerName();
      Assert.AreEqual(Name2, result);
    }

  }
}
