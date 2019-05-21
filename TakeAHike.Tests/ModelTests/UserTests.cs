using Microsoft.VisualStudio.TestTools.UnitTesting;
using TakeAHike.Models;
using System.Collections.Generic;
using System;

namespace TakeAHike.Tests
{
  [TestClass]
  public class UserTest : IDisposable
  {
    public UserTest()
    {
      DBConfiguration.ConnectionString = "server=localhost;user id=root;password=root;port=8889;database=takeahike_test;";
    }

    public void Dispose()
    {
      User.ClearAll();
    }

    [TestMethod]
    public void UserConstructor_CreatesNewInstanceOfObject_User()
    {
    User newUser = new User("Test Name", "first", "last", 98105, "(803)234-5554", "email@email.com", 1, 1);
    Assert.AreEqual(typeof(User), newUser.GetType());
    }

    [TestMethod]
    public void GetUserName_ReturnsUserName_String()
    {
      string name = "Test Name";
      User newUser = new User(name, "first", "last", 98105, "(803)234-5554", "email@email.com", 1, 1);
      string result = newUser.GetUserName();
      Assert.AreEqual(name, result);
    }

    [TestMethod]
    public void Save_SavesUserToDatabase_UserList()
    {
      User testUser = new User("Test Name", "first", "last", 98105, "(803)234-5554", "email@email.com", 1, 1);
      testUser.Save();
      List<User> result = User.GetAll();
      List<User> testList = new List<User>{testUser};
      CollectionAssert.AreEqual(testList, result);
    }

    [TestMethod]
    public void Save_DatabaseAssignsIdToUser_Id()
    {
      User testUser = new User("Test Name", "first", "last", 98105, "(803)234-5554", "email@email.com", 1, 1);
      testUser.Save();
      User savedUser = User.GetAll()[0];
      int result = savedUser.GetId();
      int testId = testUser.GetId();
      Assert.AreEqual(testId, result);
    }

    [TestMethod]
    public void Equals_ReturnsTrueIfPropertiesAreTheSame_User()
    {
      User testUser1 = new User("Test Name", "first", "last", 98105, "(803)234-5554", "email@email.com", 1, 1);
      User testUser2 = new User("Test Name", "first", "last", 98105, "(803)234-5554", "email@email.com", 1, 1);
      Assert.AreEqual(testUser1, testUser2);
    }

    [TestMethod]
    public void GetAll_UsersStartEmpty_UserList()
    {
      int result = User.GetAll().Count;
      Assert.AreEqual(0, result);
    }

    [TestMethod]
    public void GetAll_ReturnsAllUsers_UserList()
    {
      User testUser1 = new User("Test Name", "first", "last", 98105, "(803)234-5554", "email@email.com", 1, 1);
      User testUser2 = new User("Test Name", "first", "last", 98105, "(803)234-5554", "email@email.com", 1, 1);
      testUser1.Save();
      testUser2.Save();
      List<User> result = User.GetAll();
      List<User> newList = new List<User> { testUser1, testUser2 };
      CollectionAssert.AreEqual(result, newList);
    }

  }
}
