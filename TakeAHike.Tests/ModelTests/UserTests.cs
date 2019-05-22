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

    [TestMethod]
    public void Find_ReturnsUserInDataBase_User()
    {
      User testUser = new User("Test Name", "first", "last", 98105, "(803)234-5554", "email@email.com", 1, 1);
      testUser.Save();
      User foundUser = User.Find(testUser.GetId());
      Assert.AreEqual(testUser, foundUser);
    }

    [TestMethod]
    public void GetFiltered_ReturnsSelectedUsersInDatabase_UserList()
    {
      User testUser1 = new User("Test Name1", "first", "last", 98105, "(803)234-5554", "email@email.com", 1, 1);
      testUser1.Save();
      User testUser2 = new User("Test Name2", "first", "last", 98105, "(803)234-5554", "email@email.com", 2, 2);
      testUser2.Save();
      List<User> result = User.GetFiltered(1, 1);
      List<User> testList = new List<User>{ testUser1 };
      CollectionAssert.AreEqual(testList, result);
    }

    [TestMethod]
    public void Edit_EditsUserName_String()
    {
      string Name1 = "Test1";
      User testUser = new User(Name1, "first", "last", 98105, "(803)234-5554", "email@email.com", 2, 2);
      testUser.Save();
      string Name2 = "Test2";
      testUser.Edit(Name2, "first", "last", 98105, "(803)234-5554", "email@email.com", 2, 2);
      string result = User.Find(testUser.GetId()).GetUserName();
      Assert.AreEqual(Name2, result);
    }

  }
}
