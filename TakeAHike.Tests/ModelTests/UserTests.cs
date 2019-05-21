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
      DBConfiguration.ConnectionString = "server=localhost;user id=root;password=root;port=8889;database=takeahike_Stest;";
    }

    public void Dispose()
    {
      Client.ClearAll();
    }

    [TestMethod]
    public void UserConstructor_CreatesNewInstanceOfObject_User()
    {
    user newUser = new User("Test Name");
    Asser.AreEqual(typeof(user), newUser.GetType());
    }

    [TestMethod]
    public void GetName_ReturnsUserName_String()
    {
      string name = "Test Name";
      user newUser = new User(name);
      string result = newUser.GetName();
      Assert.AreEqual(name, result)
    }

    [TestMethod]
    public void Save_SavesUserToDatabase_UserList()
    {
      User testUser = new User("Test Name", 1, "F");
      testUser.Save();
      List<User> result = User.GetAll();
      List<User> testList = new List<User>{testUser};
      CollectionAssert.AreEqual(testList, result);
    }

    [TestMethod]
    public void Save_DatabaseAssignsIdToUser_Id()
    {
      User testUser = new User("Test Name", 1, "F");
      testUser.Save();
      User savedUser = User.GetAll()[0];
      int result = savedUser.GetId();
      int testId = testUser.GetId();
      Assert.AreEqual(testId, result);
    }

    [TestMethod]
    public void Equals_ReturnsTrueIfPropertiesAreTheSame_User()
    {
      User testUser1 = new User("Test Name", 1, "F");
      User testUser2 = new User("Test Name", 1, "F");
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
      User testUser1 = new User("Test Name", 1, "F");
      User testUser2 = new User("Test Name", 1, "F");
      testUser1.Save();
      testUser2.Save();
      List<User> result = User.GetAll();
      List<User> newList = new List<User> { testUser1, testUser2 };
      CollectionAssert.AreEqual(result, newList);
    }

  }
}
