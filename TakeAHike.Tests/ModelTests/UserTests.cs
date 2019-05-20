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
      DBConfiguration.ConnectionString = "server=localhost;user id=root;password=root;port=8889;database=takeahiketest;";
    }

    // public void Dispose()
    // {
    //   Client.ClearAll();
    // }

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
    
  }
}
